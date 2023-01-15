package mono.androidx.camera.core;


public class ForwardingImageProxy_OnImageCloseListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		androidx.camera.core.ForwardingImageProxy.OnImageCloseListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onImageClose:(Landroidx/camera/core/ImageProxy;)V:GetOnImageClose_Landroidx_camera_core_ImageProxy_Handler:AndroidX.Camera.Core.ForwardingImageProxy/IOnImageCloseListenerInvoker, Xamarin.AndroidX.Camera.Core\n" +
			"";
		mono.android.Runtime.register ("AndroidX.Camera.Core.ForwardingImageProxy+IOnImageCloseListenerImplementor, Xamarin.AndroidX.Camera.Core", ForwardingImageProxy_OnImageCloseListenerImplementor.class, __md_methods);
	}


	public ForwardingImageProxy_OnImageCloseListenerImplementor ()
	{
		super ();
		if (getClass () == ForwardingImageProxy_OnImageCloseListenerImplementor.class) {
			mono.android.TypeManager.Activate ("AndroidX.Camera.Core.ForwardingImageProxy+IOnImageCloseListenerImplementor, Xamarin.AndroidX.Camera.Core", "", this, new java.lang.Object[] {  });
		}
	}


	public void onImageClose (androidx.camera.core.ImageProxy p0)
	{
		n_onImageClose (p0);
	}

	private native void n_onImageClose (androidx.camera.core.ImageProxy p0);

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
