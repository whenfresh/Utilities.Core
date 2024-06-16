﻿namespace WhenFresh.Utilities.Core.Compression;

using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Compression;
using WhenFresh.Utilities.Core.IO;

public static class GZip
{
    [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "I want type safety.")]
    public static FileInfo Extract(FileInfo source,
                                   DirectoryInfo destination)
    {
        if (null == source)
        {
            throw new ArgumentNullException("source");
        }

        source.Refresh();
#if NET20
            if (FileSystemInfoExtensionMethods.NotFound(source))
#else
        if (source.NotFound())
#endif
        {
            throw new FileNotFoundException(source.FullName);
        }

        if (null == destination)
        {
            throw new ArgumentNullException("destination");
        }

#if NET20
            if (FileSystemInfoExtensionMethods.NotFound(destination))
#else
        if (destination.NotFound())
#endif
        {
            throw new DirectoryNotFoundException(destination.FullName);
        }

        FileInfo file;
        using (var temp = new TempDirectory())
        {
            using (var compressed = new FileStream(source.FullName, FileMode.Open, FileAccess.Read))
            {
                using (var gzip = new GZipStream(compressed, CompressionMode.Decompress))
                {
                    var decompressed = temp.Info.ToFile(source.Name.Remove(source.Name.Length - 3));
                    using (var stream = new FileStream(decompressed.FullName, FileMode.Create, FileAccess.Write))
                    {
                        var bytes = new byte[4096];
                        int i;
                        while ((i = gzip.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            stream.Write(bytes, 0, i);
                        }
                    }

#if NET20 || NET35
                        file = new FileInfo(Path.Combine(destination.FullName, decompressed.Name));
#else
                    file = destination.CombineAsFile(decompressed.Name);
#endif

                    decompressed.MoveTo(file.FullName);
                }
            }
        }

        return file;
    }
}