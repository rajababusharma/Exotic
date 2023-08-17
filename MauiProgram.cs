using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Storage;
using Exotic.Implementation;
using Exotic.View;
using Microsoft.Extensions.Logging;

namespace Exotic;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddSingleton<IFileSaver>(FileSaver.Default);
		builder.Services.AddTransient<Warehouse>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
