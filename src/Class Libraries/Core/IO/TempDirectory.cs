namespace WhenFresh.Utilities.IO;

using System.IO;
using System.Threading.Tasks;

public class TempDirectory : IDisposable
{
    public TempDirectory()
        : this(new DirectoryInfo(Path.GetTempPath()))
    {
    }

    public TempDirectory(DirectoryInfo directory)
    {
        ArgumentNullException.ThrowIfNull(directory);

        Info = directory.CombineAsDirectory(Guid.NewGuid());
        Info.Create();
    }

    ~TempDirectory()
    {
        Dispose(false);
    }

    public DirectoryInfo Info { get; protected set; }

    private bool Disposed { get; set; }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!Disposed && disposing)
        {
            if (Info.IsNotNull())
            {
                Info.Refresh();
                if (Info.Exists)
                {
                    DeleteFiles();
                    DeleteSubdirectories(Info);
                    Info.Delete();
                }

                Info = null;
            }
        }

        Disposed = true;
    }

    private static void DeleteSubdirectories(DirectoryInfo directory)
    {
        Parallel.ForEach(directory.EnumerateDirectories(),
                         subdirectory =>
                             {
                                 DeleteSubdirectories(subdirectory);
                                 subdirectory.Delete();
                             });
    }

    private void DeleteFiles()
    {
        Parallel.ForEach(Info.EnumerateFiles("*", SearchOption.AllDirectories),
                         file => file.Delete());
    }
}