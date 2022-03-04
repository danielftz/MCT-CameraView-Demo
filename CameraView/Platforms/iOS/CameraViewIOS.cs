using AVFoundation;
using CoreGraphics;
using CoreVideo;
using Foundation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using UIKit;

namespace CameraView.Platforms.iOS
{
    public class CameraViewIOS : UIView
    {
        private AVCaptureDevice? _cameraDevice;
        private AVCaptureSession? _captureSession;
        private AVCaptureVideoPreviewLayer? _previewLayer;
        private AVCaptureVideoDataOutput? _videoOutput;

        public void StartCamera()
        {
            try
            {
                if (AVCaptureDevice.GetAuthorizationStatus(AVAuthorizationMediaType.Video) == AVAuthorizationStatus.Authorized)
                {
                    SetupCameraDeviceInput();
                    InitializeCaptureSession();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"{e.GetType()}, {e.Message}");
            }
        }

        private void SetupCameraDeviceInput()
        {
            //AVCaptureDeviceType[] cameras = { AVCaptureDeviceType.BuiltInWideAngleCamera };
            var session = AVCaptureDeviceDiscoverySession.Create(new AVCaptureDeviceType[] { AVCaptureDeviceType.BuiltInWideAngleCamera }, nameof(AVMediaTypes.Video), AVCaptureDevicePosition.Back);
            //AVCaptureDevice[] captureDevices = AVCaptureDevice.DevicesWithMediaType(AVMediaTypes.Video.ToString());

            _cameraDevice = AVCaptureDevice.GetDefaultDevice(AVMediaTypes.Video);
            //Debug.WriteLine(session.Devices.Count());
            //_cameraDevice = session.Devices.FirstOrDefault();
            Debug.WriteLine(_cameraDevice);
            if (_cameraDevice is not null)
            {
                _cameraDevice.LockForConfiguration(out NSError err);
                if (err is null)
                {
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
                }

                _cameraDevice.UnlockForConfiguration();
            }
        }

        private void InitializeCaptureSession()
        {
            if (_cameraDevice is not null)
            {
                _captureSession = new AVCaptureSession();
                _captureSession.BeginConfiguration();
                _previewLayer = new AVCaptureVideoPreviewLayer(_captureSession, AVCaptureVideoPreviewLayer.InitMode.WithConnection)
                {
                    Frame = Bounds,
                    VideoGravity = AVLayerVideoGravity.ResizeAspectFill,
                };
                Layer.AddSublayer(_previewLayer);
                _captureSession.AddInput(new AVCaptureDeviceInput(_cameraDevice, out NSError err));
                Debug.WriteLine(_cameraDevice.ActivePrimaryConstituentDevice);
                if (err is null)
                {
                    if (_captureSession.CanSetSessionPreset(AVCaptureSession.PresetHigh))
                    {
                        _captureSession.SessionPreset = AVCaptureSession.PresetHigh;
                    }

                    _videoOutput = new AVCaptureVideoDataOutput()
                    {
                        AlwaysDiscardsLateVideoFrames = true,
                        UncompressedVideoSetting = new AVVideoSettingsUncompressed()
                        {
                            PixelFormatType = CVPixelFormatType.CV422YpCbCr8
                        }
                    };

                    if (_captureSession.CanAddOutput(_videoOutput))
                    {
                        _captureSession.AddOutput(_videoOutput);
                        Debug.WriteLine("Succeeded adding video input");
                    }

                    _captureSession.CommitConfiguration();
                    _captureSession.StartRunning();
                    Debug.WriteLine(_captureSession.Running);
                    Debug.WriteLine(_previewLayer.Connection);
                    //_videoOutput = new AVCaptureVideoDataOutput()
                    //{
                    //    AlwaysDiscardsLateVideoFrames = true,
                    //    UncompressedVideoSetting = new AVVideoSettingsUncompressed()
                    //    {
                    //        PixelFormatType = CVPixelFormatType.CV422YpCbCr8
                    //    }
                    //};
                }

            }
        }
    }
}
