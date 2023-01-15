package mono.androidx.camera.view;


public class PreviewView_OnFrameUpdateListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		androidx.camera.view.PreviewView.OnFrameUpdateListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onFrameUpdate:(J)V:GetOnFrameUpdate_JHandler:AndroidX.Camera.View.PreviewView/IOnFrameUpdateListenerInvoker, Xamarin.AndroidX.Camera.View\n" +
			"";
		mono.android.Runtime.register ("AndroidX.Camera.View.PreviewView+IOnFrameUpdateListenerImplementor, Xamarin.AndroidX.Camera.View", PreviewView_OnFrameUpdateListenerImplementor.class, __md_methods);
	}


	public PreviewView_OnFrameUpdateListenerImplementor ()
	{
		super ();
		if (getClass () == PreviewView_OnFrameUpdateListenerImplementor.class) {
			mono.android.TypeManager.Activate ("AndroidX.Camera.View.PreviewView+IOnFrameUpdateListenerImplementor, Xamarin.AndroidX.Camera.View", "", this, new java.lang.Object[] {  });
		}
	}


	public void onFrameUpdate (long p0)
	{
		n_onFrameUpdate (p0);
	}

	private native void n_onFrameUpdate (long p0);

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
