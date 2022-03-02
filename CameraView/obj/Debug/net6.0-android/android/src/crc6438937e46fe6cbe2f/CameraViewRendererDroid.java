package crc6438937e46fe6cbe2f;


public class CameraViewRendererDroid
	extends crc6477f0d89a9cfd64b1.ViewRenderer_2
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("CameraView.Platforms.Android.CameraViewRendererDroid, CameraView", CameraViewRendererDroid.class, __md_methods);
	}


	public CameraViewRendererDroid (android.content.Context p0)
	{
		super (p0);
		if (getClass () == CameraViewRendererDroid.class)
			mono.android.TypeManager.Activate ("CameraView.Platforms.Android.CameraViewRendererDroid, CameraView", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public CameraViewRendererDroid (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == CameraViewRendererDroid.class)
			mono.android.TypeManager.Activate ("CameraView.Platforms.Android.CameraViewRendererDroid, CameraView", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public CameraViewRendererDroid (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == CameraViewRendererDroid.class)
			mono.android.TypeManager.Activate ("CameraView.Platforms.Android.CameraViewRendererDroid, CameraView", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2 });
	}

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
