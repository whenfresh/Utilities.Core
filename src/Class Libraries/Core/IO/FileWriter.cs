﻿namespace WhenFresh.Utilities.Core.IO;

using System.IO;

public class FileWriter : StreamWriter
{
    public FileWriter(string path)
        : this(new FileInfo(path))
    {
    }

    public FileWriter(FileInfo file)
        : base(FromFile(file))
    {
    }

    private static Stream FromFile(FileInfo file)
    {
        if (null == file)
        {
            throw new ArgumentNullException("file");
        }

        return file.Open(FileMode.Append, FileAccess.Write, FileShare.Read);
    }
}