using Android.Content;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Platform;

namespace CameraView.Platforms.Android
{
    public class CameraViewRendererDroid : ViewRenderer<CameraView, CameraViewDroid>
    {
        public CameraViewRendererDroid(Context context) : base(context)
        {
        }

        protected async override void OnElementChanged(ElementChangedEventArgs<CameraView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement is not null)
            {
				if (Control is null && Context is not null)
                {
                    SetNativeControl(new CameraViewDroid(Context));

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
