package crc6478960701127610a9;


public class ZoomableRecyclerView
	extends androidx.recyclerview.widget.RecyclerView
	implements
		mono.android.IGCUserPeer,
		android.view.ScaleGestureDetector.OnScaleGestureListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTouchEvent:(Landroid/view/MotionEvent;)Z:GetOnTouchEvent_Landroid_view_MotionEvent_Handler\n" +
			"n_dispatchDraw:(Landroid/graphics/Canvas;)V:GetDispatchDraw_Landroid_graphics_Canvas_Handler\n" +
			"n_onScale:(Landroid/view/ScaleGestureDetector;)Z:GetOnScale_Landroid_view_ScaleGestureDetector_Handler:Android.Views.ScaleGestureDetector/IOnScaleGestureListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onScaleBegin:(Landroid/view/ScaleGestureDetector;)Z:GetOnScaleBegin_Landroid_view_ScaleGestureDetector_Handler:Android.Views.ScaleGestureDetector/IOnScaleGestureListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onScaleEnd:(Landroid/view/ScaleGestureDetector;)V:GetOnScaleEnd_Landroid_view_ScaleGestureDetector_Handler:Android.Views.ScaleGestureDetector/IOnScaleGestureListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Maui.PDFView.Platforms.Android.Common.ZoomableRecyclerView, Maui.PDFView", ZoomableRecyclerView.class, __md_methods);
	}

	public ZoomableRecyclerView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == ZoomableRecyclerView.class) {
			mono.android.TypeManager.Activate ("Maui.PDFView.Platforms.Android.Common.ZoomableRecyclerView, Maui.PDFView", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}

	public ZoomableRecyclerView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == ZoomableRecyclerView.class) {
			mono.android.TypeManager.Activate ("Maui.PDFView.Platforms.Android.Common.ZoomableRecyclerView, Maui.PDFView", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}

	public ZoomableRecyclerView (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == ZoomableRecyclerView.class) {
			mono.android.TypeManager.Activate ("Maui.PDFView.Platforms.Android.Common.ZoomableRecyclerView, Maui.PDFView", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2 });
		}
	}

	public boolean onTouchEvent (android.view.MotionEvent p0)
	{
		return n_onTouchEvent (p0);
	}

	private native boolean n_onTouchEvent (android.view.MotionEvent p0);

	public void dispatchDraw (android.graphics.Canvas p0)
	{
		n_dispatchDraw (p0);
	}

	private native void n_dispatchDraw (android.graphics.Canvas p0);

	public boolean onScale (android.view.ScaleGestureDetector p0)
	{
		return n_onScale (p0);
	}

	private native boolean n_onScale (android.view.ScaleGestureDetector p0);

	public boolean onScaleBegin (android.view.ScaleGestureDetector p0)
	{
		return n_onScaleBegin (p0);
	}

	private native boolean n_onScaleBegin (android.view.ScaleGestureDetector p0);

	public void onScaleEnd (android.view.ScaleGestureDetector p0)
	{
		n_onScaleEnd (p0);
	}

	private native void n_onScaleEnd (android.view.ScaleGestureDetector p0);

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
