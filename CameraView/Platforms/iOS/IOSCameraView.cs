using System.Diagnostics;
using AVFoundation;
using CoreGraphics;
using Foundation;
using UIKit;

namespace CameraView.Platforms.iOS
{
    public class IOSCameraView : UIView
    {
        private AVCaptureDevice? _cameraDevice;
        private AVCaptureSession? _captureSession;
        private AVCaptureVideoPreviewLayer? _previewLayer;
        private AVCaptureDeviceInput? _inputStream;
        public IOSCameraView()
        {
            StartCameraView();
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            if (_previewLayer is not null)
            {
                _previewLayer.Frame = Bounds;
            }            
        }

        private void StartCameraView()
        {
            try
            {
                _cameraDevice = AVCaptureDevice.GetDefaultDevice(AVCaptureDeviceType.BuiltInWideAngleCamera, AVMediaTypes.Video, AVCaptureDevicePosition.Back)
                                    ?? throw new NullReferenceException("Camera not found");

                _cameraDevice.LockForConfiguration(out NSError err1);
                if (err1 is not null)
                {
                    throw new InvalidOperationException("Failure to lock camera for configuration");
                }

                if (_cameraDevice.AutoFocusRangeRestrictionSupported)
                {
                    _cameraDevice.AutoFocusRangeRestriction = AVCaptureAutoFocusRangeRestriction.Near;
                }
                if (_cameraDevice.IsFocusModeSupported(AVCaptureFocusMode.ContinuousAutoFocus))
                {
                    _cameraDevice.FocusMode = AVCaptureFocusMode.ContinuousAutoFocus;
                }
                if (_cameraDevice.IsExposureModeSupported(AVCaptureExposureMode.ContinuousAutoExposure))
                {
                    _cameraDevice.ExposureMode = AVCaptureExposureMode.ContinuousAutoExposure;
                }
                if (_cameraDevice.IsWhiteBalanceModeSupported(AVCaptureWhiteBalanceMode.ContinuousAutoWhiteBalance))
                {
                    _cameraDevice.WhiteBalanceMode = AVCaptureWhiteBalanceMode.ContinuousAutoWhiteBalance;
                }
                if (_cameraDevice.FocusPointOfInterestSupported)
                {
                    _cameraDevice.FocusPointOfInterest = new CGPoint(x: 0.5, y: 0.5);
                }
                if (_cameraDevice.ExposurePointOfInterestSupported)
                {
                    _cameraDevice.ExposurePointOfInterest = new CGPoint(x: 0.5, y: 0.5);
                }

                _cameraDevice.UnlockForConfiguration();


                //set up inputstream from camera
                _inputStream = new AVCaptureDeviceInput(_cameraDevice, out NSError err2);
                if (err2 is not null)
                {
                    throw new InvalidOperationException("Failure to add input to capture session");
                }


                //configure capture session
                _captureSession = new AVCaptureSession();
                _captureSession.BeginConfiguration();

                if (_captureSession.CanAddInput(_inputStream) is false)
                {
                    throw new InvalidOperationException("Failure to configure capture session");
                }
                _captureSession.AddInput(_inputStream);

                if (_captureSession.CanSetSessionPreset(AVCaptureSession.PresetHigh))
                {
                    _captureSession.SessionPreset = AVCaptureSession.PresetHigh;
                }
                _captureSession.CommitConfiguration();

                _previewLayer = new AVCaptureVideoPreviewLayer(_captureSession)
                {
                    //Frame = Bounds,
                    VideoGravity = AVLayerVideoGravity.ResizeAspectFill,
                };

                Layer.AddSublayer(_previewLayer);

                _captureSession?.StartRunning();
            }
            catch(Exception e)
            {
                Debug.WriteLine($"{e.GetType()}, {e.Message}");
            }
        }
    }
}
