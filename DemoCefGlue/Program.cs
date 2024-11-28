using System;
using System.IO;
using Avalonia;
using Xilium.CefGlue;
using Xilium.CefGlue.Common;

namespace DemoCefGlue;

sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        // generate a unique cache path to avoid problems when launching more than one process
        // https://www.magpcss.org/ceforum/viewtopic.php?f=6&t=19665
        var cachePath = Path.Combine(Path.GetTempPath(), "CefGlue_" + Guid.NewGuid().ToString().Replace("-", null));
        AppDomain.CurrentDomain.ProcessExit += delegate { Cleanup(cachePath); };

        AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .AfterSetup(_ => CefRuntimeLoader.Initialize(new CefSettings
            {
                RootCachePath = cachePath,
                WindowlessRenderingEnabled = true
            }))
            .LogToTrace()
            .StartWithClassicDesktopLifetime(args);
    }

    private static void Cleanup(string cachePath)
    {
        CefRuntime.Shutdown(); // must shutdown cef to free cache files (so that cleanup is able to delete files)

        try
        {
            var dirInfo = new DirectoryInfo(cachePath);
            if (dirInfo.Exists)
            {
                dirInfo.Delete(true);
            }
        }
        catch (UnauthorizedAccessException)
        {
            // ignore
        }
        catch (IOException)
        {
            // ignore
        }
    }
}
