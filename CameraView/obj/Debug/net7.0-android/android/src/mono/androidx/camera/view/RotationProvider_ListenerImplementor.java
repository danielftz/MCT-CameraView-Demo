package mono.androidx.camera.view;


public class RotationProvider_ListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		androidx.camera.view.RotationProvider.Listener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onRotationChanged:(I)V:GetOnRotationChanged_IHandler:AndroidX.Camera.View.RotationProvider/IListenerInvoker, Xamarin.AndroidX.Camera.View\n" +
			"";
		mono.android.Runtime.register ("AndroidX.Camera.View.RotationProvider+IListenerImplementor, Xamarin.AndroidX.Camera.View", RotationProvider_ListenerImplementor.class, __md_methods);
	}


	public RotationProvider_ListenerImplementor ()
	{
		super ();
		if (getClass () == RotationProvider_ListenerImplementor.class) {
			mono.android.TypeManager.Activate ("AndroidX.Camera.View.RotationProvider+IListenerImplementor, Xamarin.AndroidX.Camera.View", "", this, new java.lang.Object[] {  });
		}
	}


	public void onRotationChanged (int p0)
	{
		n_onRotationChanged (p0);
	}

	private native void n_onRotationChanged (int p0);

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
