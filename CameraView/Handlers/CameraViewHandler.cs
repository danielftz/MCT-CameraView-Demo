#if ANDROID
using PlatformView = CameraView.Platforms.Android.AndroidCameraView;
#elif IOS
using PlatformView = CameraView.Platforms.iOS.IOSCameraView;
#endif
using Microsoft.Maui.Handlers;

namespace CameraView.Handlers
{
    public partial class CameraViewHandler : ICameraViewHandler
    {
        ICameraView ICameraViewHandler.VirtualView => VirtualView;

        PlatformView ICameraViewHandler.PlatformView => PlatformView;

        public static IPropertyMapper<ICameraView, ICameraViewHandler> Mapper = new PropertyMapper<ICameraView, ICameraViewHandler>(ViewMapper)
        {
        };

        public static CommandMapper<ICameraView, ICameraViewHandler> CommandMapper = new(ViewCommandMapper)
        {
        };

        public CameraViewHandler() : base(Mapper, CommandMapper)
        {

        }

        public CameraViewHandler(IPropertyMapper? mapper = null, CommandMapper? commandMapper = null) : base(mapper ?? Mapper, commandMapper ?? CommandMapper)
        {

        }
    }

    public interface ICameraViewHandler : IViewHandler
    {
        new ICameraView VirtualView { get; }

        new PlatformView PlatformView { get; }
    } 
}
