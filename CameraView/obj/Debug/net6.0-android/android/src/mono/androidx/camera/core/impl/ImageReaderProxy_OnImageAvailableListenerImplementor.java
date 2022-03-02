package mono.androidx.camera.core.impl;


public class ImageReaderProxy_OnImageAvailableListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		androidx.camera.core.impl.ImageReaderProxy.OnImageAvailableListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onImageAvailable:(Landroidx/camera/core/impl/ImageReaderProxy;)V:GetOnImageAvailable_Landroidx_camera_core_impl_ImageReaderProxy_Handler:AndroidX.Camera.Core.Impl.IImageReaderProxyOnImageAvailableListenerInvoker, Xamarin.AndroidX.Camera.Core\n" +
			"";
		mono.android.Runtime.register ("AndroidX.Camera.Core.Impl.IImageReaderProxyOnImageAvailableListenerImplementor, Xamarin.AndroidX.Camera.Core", ImageReaderProxy_OnImageAvailableListenerImplementor.class, __md_methods);
	}


	public ImageReaderProxy_OnImageAvailableListenerImplementor ()
	{
		super ();
		if (getClass () == ImageReaderProxy_OnImageAvailableListenerImplementor.class)
			mono.android.TypeManager.Activate ("AndroidX.Camera.Core.Impl.IImageReaderProxyOnImageAvailableListenerImplementor, Xamarin.AndroidX.Camera.Core", "", this, new java.lang.Object[] {  });
	}


	public void onImageAvailable (androidx.camera.core.impl.ImageReaderProxy p0)
	{
		n_onImageAvailable (p0);
	}

	private native void n_onImageAvailable (androidx.camera.core.impl.ImageReaderProxy p0);

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
