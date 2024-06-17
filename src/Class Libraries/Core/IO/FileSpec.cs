namespace WhenFresh.Utilities.Core.IO;

using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.IO;

[SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "This naming is intentional.")]
public class FileSpec : IEnumerable<FileInfo>
{
    private static readonly string GlobDirectory = $"{Path.DirectorySeparatorChar}**{Path.DirectorySeparatorChar}";

    public FileSpec(string value)
    {
        if (null == value)
        {
            throw new ArgumentNullException("value");
        }

        value = value.Trim();
        if (0 == value.Length)
        {
            throw new ArgumentOutOfRangeException("value");
        }

        Value = value;
    }

    private string Value { get; set; }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<FileInfo> GetEnumerator()
    {
        if (!Value.Contains("*"))
        {
            var file = new FileInfo(Value);
            if (!file.Exists)
            {
                throw new FileNotFoundException(file.FullName);
            }

            yield return file;
            yield break;
        }

        DirectoryInfo directory;
        string pattern;
        var option = SearchOption.TopDirectoryOnly;
        if (Value.Contains(GlobDirectory))
        {
            var index = Value.IndexOf(GlobDirectory, StringComparison.Ordinal);
            directory = new DirectoryInfo(Value.Substring(0, index));
            pattern = Value.Substring(index + 4);
            option = SearchOption.AllDirectories;
        }
        else
        {
            var index = Value.IndexOf('*');
            directory = new DirectoryInfo(Value.Substring(0, index));
            pattern = Value.Substring(index);
        }

        foreach (var file in directory.EnumerateFiles(pattern, option))
        {
            yield return file;
        }
    }
}