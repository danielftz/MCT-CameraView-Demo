package mono.androidx.camera.core.impl;


public class SessionConfig_ErrorListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		androidx.camera.core.impl.SessionConfig.ErrorListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onError:(Landroidx/camera/core/impl/SessionConfig;Landroidx/camera/core/impl/SessionConfig$SessionError;)V:GetOnError_Landroidx_camera_core_impl_SessionConfig_Landroidx_camera_core_impl_SessionConfig_SessionError_Handler:AndroidX.Camera.Core.Impl.SessionConfig/IErrorListenerInvoker, Xamarin.AndroidX.Camera.Core\n" +
			"";
		mono.android.Runtime.register ("AndroidX.Camera.Core.Impl.SessionConfig+IErrorListenerImplementor, Xamarin.AndroidX.Camera.Core", SessionConfig_ErrorListenerImplementor.class, __md_methods);
	}


	public SessionConfig_ErrorListenerImplementor ()
	{
		super ();
		if (getClass () == SessionConfig_ErrorListenerImplementor.class)
			mono.android.TypeManager.Activate ("AndroidX.Camera.Core.Impl.SessionConfig+IErrorListenerImplementor, Xamarin.AndroidX.Camera.Core", "", this, new java.lang.Object[] {  });
	}


	public void onError (androidx.camera.core.impl.SessionConfig p0, androidx.camera.core.impl.SessionConfig.SessionError p1)
	{
		n_onError (p0, p1);
	}

	private native void n_onError (androidx.camera.core.impl.SessionConfig p0, androidx.camera.core.impl.SessionConfig.SessionError p1);

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
