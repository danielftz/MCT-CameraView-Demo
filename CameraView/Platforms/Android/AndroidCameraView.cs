using Android.Content;
using AndroidX.Camera.Core;
using AndroidX.Camera.Lifecycle;
using AndroidX.Camera.View;
using AndroidX.CardView.Widget;
using AndroidX.Core.Content;
using AndroidX.Lifecycle;
using Google.Common.Util.Concurrent;
using Java.Lang;
using Java.Util.Concurrent;
using SDebug = System.Diagnostics.Debug;
using Size = Android.Util.Size;

namespace CameraView.Platforms.Android
{
    
    public class AndroidCameraView : CardView, IDisposable
    {
        private static readonly Context _context = Platform.AppContext;
        private PreviewView? _viewFinder;
        private Preview? _preview;
        private ICamera? _camera;
        private ProcessCameraProvider? _cameraProvider;


        public AndroidCameraView() : base(_context)
        {
            CardElevation = 0f;

            StartCameraPreview();
            
        }

        private void StartCameraPreview()
        {
            try
            {
                IListenableFuture? cameraProviderFuture = ProcessCameraProvider.GetInstance(_context);

                //equivalent to cameraProviderFuture.ContinueWith(); Runnable will start when a ProcessCameraProvider Instance is retrieved
                cameraProviderFuture.AddListener(new Runnable(() =>
                {
                    try
                    {
                        _cameraProvider = (ProcessCameraProvider?)cameraProviderFuture.Get();
                        if (_cameraProvider is not null)
                        { 
                            _cameraProvider.UnbindAll();


                            _viewFinder = new PreviewView(_context)
                            {
                                LayoutParameters = new LayoutParams(Width, Height),
                            };
                            _viewFinder.SetScaleType(PreviewView.ScaleType.FillCenter);
                            AddView(_viewFinder);

                            //Refer to Android documentation to retrieve cameras that are not the default back camera
                            if (_cameraProvider.HasCamera(CameraSelector.DefaultBackCamera) is true && _viewFinder is not null)
                            {
                                

                                _preview = new Preview.Builder()
                                            .SetTargetResolution(new Size(1080, 1920))
                                            .SetCameraSelector(CameraSelector.DefaultBackCamera)
                                            .Build();

                                _preview.SetSurfaceProvider(_viewFinder.SurfaceProvider);


                                ILifecycleOwner? owner = Platform.CurrentActivity as ILifecycleOwner;

                                //initialize back camera
                                _camera = _cameraProvider.BindToLifecycle(owner, CameraSelector.DefaultBackCamera, _preview);


                                //start the camera with AutoFocus'
                                MeteringPoint point = new SurfaceOrientedMeteringPointFactory(1f, 1f).CreatePoint(0, 5f, 0.5f);
                                FocusMeteringAction action = new FocusMeteringAction.Builder(point, FocusMeteringAction.FlagAf + FocusMeteringAction.FlagAe + FocusMeteringAction.FlagAwb)
                                                                                    .SetAutoCancelDuration(1, TimeUnit.Seconds!)
                                                                                    .Build();
                                _camera.CameraControl.StartFocusAndMetering(action);
                            }
                        }

                    }
                    catch (System.Exception e)
                    {
                        //NOTE: HACK: If ListenableFuture has errors, (On Windows) please navigate to
                        //C:\Users\<UserName>\.nuget\packages\xamarin.google.guava.listenablefuture\1.0.0.10\buildTransitive\net6.0-android31.0
                        //and uncomment the line
                        //   <!--AndroidJavaLibrary Include="$(MSBuildThisFileDirectory)..\..\jar\*.jar" /-->
                        //in the xml file  Xamarin.Google.Guava.ListenableFuture.targets


                        SDebug.WriteLine($"{e.GetType()}, {e.Message}");
                    }
                }), ContextCompat.GetMainExecutor(_context));
            }
            catch (System.Exception e)
            {
                SDebug.WriteLine($"{e.GetType()}, {e.Message}");
            }
        }
    }
}
