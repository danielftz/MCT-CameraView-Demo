package mono.androidx.camera.core.impl;


public class CameraStateRegistry_OnOpenAvailableListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		androidx.camera.core.impl.CameraStateRegistry.OnOpenAvailableListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onOpenAvailable:()V:GetOnOpenAvailableHandler:AndroidX.Camera.Core.Impl.CameraStateRegistry/IOnOpenAvailableListenerInvoker, Xamarin.AndroidX.Camera.Core\n" +
			"";
		mono.android.Runtime.register ("AndroidX.Camera.Core.Impl.CameraStateRegistry+IOnOpenAvailableListenerImplementor, Xamarin.AndroidX.Camera.Core", CameraStateRegistry_OnOpenAvailableListenerImplementor.class, __md_methods);
	}


	public CameraStateRegistry_OnOpenAvailableListenerImplementor ()
	{
		super ();
		if (getClass () == CameraStateRegistry_OnOpenAvailableListenerImplementor.class) {
			mono.android.TypeManager.Activate ("AndroidX.Camera.Core.Impl.CameraStateRegistry+IOnOpenAvailableListenerImplementor, Xamarin.AndroidX.Camera.Core", "", this, new java.lang.Object[] {  });
		}
	}


	public void onOpenAvailable ()
	{
		n_onOpenAvailable ();
	}

	private native void n_onOpenAvailable ();

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
