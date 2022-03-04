using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using Microsoft.Maui.Controls.Platform;

namespace CameraView.Platforms.iOS
{
    public class CameraViewRendererIOS : ViewRenderer<CameraView, CameraViewIOS>
    {
		protected override async void OnElementChanged(ElementChangedEventArgs<CameraView> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement is not null)
			{
				// the MeescanBarcodeScanner that this Renderer IS attached to. 
				if (Control is null)
				{
					SetNativeControl(new CameraViewIOS());
					PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.Camera>();

					if (status is not PermissionStatus.Granted)
					{
						await Device.InvokeOnMainThreadAsync(async () =>
						{
							status = await Permissions.RequestAsync<Permissions.Camera>();
						});
					}

					if (status is PermissionStatus.Granted)
					{
						Control?.StartCamera();
					}
				}
			}
		}
	}
}
