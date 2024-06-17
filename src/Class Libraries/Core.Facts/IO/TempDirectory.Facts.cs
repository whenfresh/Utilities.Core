namespace WhenFresh.Utilities.Core.Facts.IO;

using System;
using System.Globalization;
using System.IO;
using WhenFresh.Utilities.Core;
using WhenFresh.Utilities.Core.IO;

public sealed class TempDirectoryFacts
{
    [Fact]
    public void a_definition()
    {
        Assert.True(new TypeExpectations<TempDirectory>().DerivesFrom<object>()
                                                         .IsConcreteClass()
                                                         .IsUnsealed()
                                                         .HasDefaultConstructor()
                                                         .IsNotDecorated()
                                                         .Implements<IDisposable>()
                                                         .Result);
    }

    [Fact]
    public void ctor()
    {
        using (var directory = new TempDirectory())
        {
            Assert.NotNull(directory);
        }
    }

    [Fact]
    public void ctor_DirectoryInfo()
    {
        using (var directory = new TempDirectory(new DirectoryInfo(Path.GetTempPath())))
        {
            Assert.NotNull(directory);
        }
    }

    [Fact]
    public void ctor_DirectoryInfoNull()
    {
        Assert.Throws<ArgumentNullException>(() => new TempDirectory(null));
    }

    [Fact]
    public void op_Dispose()
    {
        TempDirectory directory = null;
        DirectoryInfo info;
        try
        {
            directory = new TempDirectory();
            info = directory.Info;
        }
        finally
        {
            if (null != directory)
            {
                directory.Dispose();
            }
        }

        Assert.Null(directory.Info);

        info.Refresh();
        Assert.False(info.Exists);
    }

    [Fact]
    public void op_Dispose_whenContainsDirectory()
    {
        using (var directory = new TempDirectory())
        {
            var example = directory.Info.CreateSubdirectory("example");
            example.CreateSubdirectory(Guid.NewGuid().ToString());
        }
    }

    [Fact]
    public void op_Dispose_whenContainsFile()
    {
        using (var directory = new TempDirectory())
        {
            object[] args = new[] { directory.Info.FullName };
            var file = new FileInfo(string.Format(CultureInfo.InvariantCulture, @"{0}\example.txt", args));
            using (file.Create())
            {
            }
        }
    }

    [Fact]
    public void prop_Info()
    {
        using (var directory = new TempDirectory())
        {
            Assert.True(directory.Info.Exists);
        }
    }
}