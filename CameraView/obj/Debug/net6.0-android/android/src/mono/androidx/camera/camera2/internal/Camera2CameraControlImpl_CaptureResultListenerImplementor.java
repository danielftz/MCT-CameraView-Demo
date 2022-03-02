package mono.androidx.camera.camera2.internal;


public class Camera2CameraControlImpl_CaptureResultListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		androidx.camera.camera2.internal.Camera2CameraControlImpl.CaptureResultListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCaptureResult:(Landroid/hardware/camera2/TotalCaptureResult;)Z:GetOnCaptureResult_Landroid_hardware_camera2_TotalCaptureResult_Handler:AndroidX.Camera.Camera2.Internal.Camera2CameraControlImpl/ICaptureResultListenerInvoker, Xamarin.AndroidX.Camera.Camera2\n" +
			"";
		mono.android.Runtime.register ("AndroidX.Camera.Camera2.Internal.Camera2CameraControlImpl+ICaptureResultListenerImplementor, Xamarin.AndroidX.Camera.Camera2", Camera2CameraControlImpl_CaptureResultListenerImplementor.class, __md_methods);
	}


	public Camera2CameraControlImpl_CaptureResultListenerImplementor ()
	{
		super ();
		if (getClass () == Camera2CameraControlImpl_CaptureResultListenerImplementor.class)
			mono.android.TypeManager.Activate ("AndroidX.Camera.Camera2.Internal.Camera2CameraControlImpl+ICaptureResultListenerImplementor, Xamarin.AndroidX.Camera.Camera2", "", this, new java.lang.Object[] {  });
	}


	public boolean onCaptureResult (android.hardware.camera2.TotalCaptureResult p0)
	{
		return n_onCaptureResult (p0);
	}

	private native boolean n_onCaptureResult (android.hardware.camera2.TotalCaptureResult p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
