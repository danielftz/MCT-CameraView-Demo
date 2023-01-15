#if IOS
using CameraView.Platforms.iOS;
using Microsoft.Maui.Handlers;

namespace CameraView.Handlers
{
    public partial class CameraViewHandler : ViewHandler<ICameraView, IOSCameraView>
    {
        protected override IOSCameraView CreatePlatformView()
        {
            return new IOSCameraView();
        }
    }
    
}
#endif