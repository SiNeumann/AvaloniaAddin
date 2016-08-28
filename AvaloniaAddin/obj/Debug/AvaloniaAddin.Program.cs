using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Logging.Serilog;
using Avalonia.Platform;
using Serilog;
namespace  ${ProjectName } {
		internal class Program
{
	static void Main(string[] args)
	{
		InitializeLogging();

		// TODO: Make this work with GTK/Skia/Cairo depending on command-line args
		// again.
		AppBuilder.Configure<App>()
			.UsePlatformDetect()
			.Start<MainWindow>();
	}

	// This will be made into a runtime configuration extension soon!
	private static void InitializeLogging()
	{
#if DEBUG

#endif
	}

	private static void ConfigureAssetAssembly(AppBuilder builder)
	{
		// AvaloniaLocator.CurrentMutable
		//   .GetService<IAssetLoader>()
		//  .SetDefaultAssembly(typeof(App).Assembly);
	}
}

