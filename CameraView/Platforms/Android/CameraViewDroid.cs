using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using AndroidX.Camera.Core;
using AndroidX.Camera.Lifecycle;
using AndroidX.Camera.View;
using AndroidX.Core.Content;
using AndroidX.Lifecycle;
using Google.Common.Util.Concurrent;
using Java.Lang;
using Java.Util.Concurrent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraView.Platforms.Android
{
    public class CameraViewDroid : FrameLayout, IDisposable
    {
        private readonly Context _context;
        private IExecutorService? _cameraExecutor;
        private PreviewView? _viewFinder;
		private ICamera? _camera;
		private ProcessCameraProvider? _cameraProvider;

		private bool _isDisposed = false;
		public CameraViewDroid(Context context) : base(context)
        {
            _context = context;
        }

        public void StartCamera()
        {
            try
            {
                _cameraExecutor = Executors.NewSingleThreadExecutor();
                _viewFinder = new PreviewView(_context)
                {
                    LayoutParameters = new LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent)
                };
                AddView(_viewFinder);

				IListenableFuture cameraProviderFuture = ProcessCameraProvider.GetInstance(_context);
				//equivalent to cameraProviderFuture.ContinueWith(); Runnable will start when a ProcessCameraProvider Instance is retrieved
				cameraProviderFuture.AddListener(new Runnable(() =>
				{
					_cameraProvider = (ProcessCameraProvider?)cameraProviderFuture.Get();
					if (_cameraProvider is not null)
					{
						_cameraProvider.UnbindAll();
						if (_cameraProvider.HasCamera(CameraSelector.DefaultBackCamera) is true)
						{
							//initialize preview
							Preview preview = new Preview.Builder()
														.SetCameraSelector(CameraSelector.DefaultBackCamera)
														.Build();
							preview.SetSurfaceProvider(_viewFinder.SurfaceProvider);

							ILifecycleOwner owner = (ILifecycleOwner)_context;
							//initialize back camera
							//HACK: if the app uses new NavigationPage() as the root object, will throw exception at this line
							_camera = _cameraProvider.BindToLifecycle(owner, CameraSelector.DefaultBackCamera, preview);

							//start the camera with AutoFocus
							MeteringPoint point = _viewFinder.MeteringPointFactory.CreatePoint(_viewFinder.Width / 2, _viewFinder.Height / 2, 0.1F);
							FocusMeteringAction action = new FocusMeteringAction.Builder(point)
																				.DisableAutoCancel()
																				.Build();
							_camera.CameraControl.StartFocusAndMetering(action);
						}
					}
				}), ContextCompat.GetMainExecutor(_context));

			}
			catch (System.Exception e)
            {
				System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

		protected override void Dispose(bool disposing)
		{
			if (_isDisposed is false)
			{
				if (disposing)
				{
					_viewFinder?.Dispose();
					_cameraProvider?.UnbindAll();
					_cameraProvider?.Dispose();
					_camera?.Dispose();
					_cameraExecutor?.Dispose();
				}
				_cameraProvider = null;
				_cameraExecutor = null;
				_viewFinder = null;
				_camera = null;

				base.Dispose(disposing);
				_isDisposed = true;
			}
		}

		void IDisposable.Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}

	
}
