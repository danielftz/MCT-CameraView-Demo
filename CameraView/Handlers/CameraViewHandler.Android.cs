#if ANDROID
using CameraView.Platforms.Android;
using Microsoft.Maui.Handlers;

namespace CameraView.Handlers
{
    public partial class CameraViewHandler : ViewHandler<ICameraView, AndroidCameraView>
    {
        protected override AndroidCameraView CreatePlatformView()
        {
            return new AndroidCameraView();
        }
    }
}
#endif
