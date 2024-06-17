namespace WhenFresh.Utilities.Core.IO;

using System.IO;

public class CurrentTempDirectory : TempDirectory
{
    public CurrentTempDirectory()
        : base(Location)
    {
    }

    public static DirectoryInfo Location
    {
        get
        {
            var current = new DirectoryInfo(Environment.CurrentDirectory);
            
            
            return current.ToDirectory("Temp", true);
        }
    }
}