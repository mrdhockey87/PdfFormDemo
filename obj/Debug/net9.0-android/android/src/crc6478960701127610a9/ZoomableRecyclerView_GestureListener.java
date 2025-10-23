package crc6478960701127610a9;


public class ZoomableRecyclerView_GestureListener
	extends android.view.GestureDetector.SimpleOnGestureListener
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onScroll:(Landroid/view/MotionEvent;Landroid/view/MotionEvent;FF)Z:GetOnScroll_Landroid_view_MotionEvent_Landroid_view_MotionEvent_FFHandler\n" +
			"";
		mono.android.Runtime.register ("Maui.PDFView.Platforms.Android.Common.ZoomableRecyclerView+GestureListener, Maui.PDFView", ZoomableRecyclerView_GestureListener.class, __md_methods);
	}

	public ZoomableRecyclerView_GestureListener ()
	{
		super ();
		if (getClass () == ZoomableRecyclerView_GestureListener.class) {
			mono.android.TypeManager.Activate ("Maui.PDFView.Platforms.Android.Common.ZoomableRecyclerView+GestureListener, Maui.PDFView", "", this, new java.lang.Object[] {  });
		}
	}

	public ZoomableRecyclerView_GestureListener (crc6478960701127610a9.ZoomableRecyclerView p0)
	{
		super ();
		if (getClass () == ZoomableRecyclerView_GestureListener.class) {
			mono.android.TypeManager.Activate ("Maui.PDFView.Platforms.Android.Common.ZoomableRecyclerView+GestureListener, Maui.PDFView", "Maui.PDFView.Platforms.Android.Common.ZoomableRecyclerView, Maui.PDFView", this, new java.lang.Object[] { p0 });
		}
	}

	public boolean onScroll (android.view.MotionEvent p0, android.view.MotionEvent p1, float p2, float p3)
	{
		return n_onScroll (p0, p1, p2, p3);
	}

	private native boolean n_onScroll (android.view.MotionEvent p0, android.view.MotionEvent p1, float p2, float p3);

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
