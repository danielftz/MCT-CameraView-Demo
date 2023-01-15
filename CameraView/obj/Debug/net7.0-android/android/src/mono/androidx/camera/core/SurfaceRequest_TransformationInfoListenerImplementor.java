package mono.androidx.camera.core;


public class SurfaceRequest_TransformationInfoListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		androidx.camera.core.SurfaceRequest.TransformationInfoListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTransformationInfoUpdate:(Landroidx/camera/core/SurfaceRequest$TransformationInfo;)V:GetOnTransformationInfoUpdate_Landroidx_camera_core_SurfaceRequest_TransformationInfo_Handler:AndroidX.Camera.Core.SurfaceRequest/ITransformationInfoListenerInvoker, Xamarin.AndroidX.Camera.Core\n" +
			"";
		mono.android.Runtime.register ("AndroidX.Camera.Core.SurfaceRequest+ITransformationInfoListenerImplementor, Xamarin.AndroidX.Camera.Core", SurfaceRequest_TransformationInfoListenerImplementor.class, __md_methods);
	}


	public SurfaceRequest_TransformationInfoListenerImplementor ()
	{
		super ();
		if (getClass () == SurfaceRequest_TransformationInfoListenerImplementor.class) {
			mono.android.TypeManager.Activate ("AndroidX.Camera.Core.SurfaceRequest+ITransformationInfoListenerImplementor, Xamarin.AndroidX.Camera.Core", "", this, new java.lang.Object[] {  });
		}
	}


	public void onTransformationInfoUpdate (androidx.camera.core.SurfaceRequest.TransformationInfo p0)
	{
		n_onTransformationInfoUpdate (p0);
	}

	private native void n_onTransformationInfoUpdate (androidx.camera.core.SurfaceRequest.TransformationInfo p0);

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
