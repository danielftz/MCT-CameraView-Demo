using Microsoft.Maui.Controls.Compatibility;

namespace CameraView;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .ConfigureMauiHandlers(handlers =>
            {
#if ANDROID
				handlers.AddCompatibilityRenderer(typeof(CameraView), typeof(Platforms.Android.CameraViewRendererDroid));
#elif IOS
				handlers.AddCompatibilityRenderer(typeof(CameraView), typeof(Platforms.iOS.CameraViewRendererIOS));
#endif
			})
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		return builder.Build();
	}
}
