package crc6478960701127610a9;


public class ZoomableLinearLayoutManager
	extends androidx.recyclerview.widget.LinearLayoutManager
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAttachedToWindow:(Landroidx/recyclerview/widget/RecyclerView;)V:GetOnAttachedToWindow_Landroidx_recyclerview_widget_RecyclerView_Handler\n" +
			"n_scrollVerticallyBy:(ILandroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)I:GetScrollVerticallyBy_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Handler\n" +
			"n_scrollHorizontallyBy:(ILandroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)I:GetScrollHorizontallyBy_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Handler\n" +
			"";
		mono.android.Runtime.register ("Maui.PDFView.Platforms.Android.Common.ZoomableLinearLayoutManager, Maui.PDFView", ZoomableLinearLayoutManager.class, __md_methods);
	}

	public ZoomableLinearLayoutManager (android.content.Context p0)
	{
		super (p0);
		if (getClass () == ZoomableLinearLayoutManager.class) {
			mono.android.TypeManager.Activate ("Maui.PDFView.Platforms.Android.Common.ZoomableLinearLayoutManager, Maui.PDFView", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}

	public ZoomableLinearLayoutManager (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == ZoomableLinearLayoutManager.class) {
			mono.android.TypeManager.Activate ("Maui.PDFView.Platforms.Android.Common.ZoomableLinearLayoutManager, Maui.PDFView", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2, p3 });
		}
	}

	public ZoomableLinearLayoutManager (android.content.Context p0, int p1, boolean p2)
	{
		super (p0, p1, p2);
		if (getClass () == ZoomableLinearLayoutManager.class) {
			mono.android.TypeManager.Activate ("Maui.PDFView.Platforms.Android.Common.ZoomableLinearLayoutManager, Maui.PDFView", "Android.Content.Context, Mono.Android:System.Int32, System.Private.CoreLib:System.Boolean, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2 });
		}
	}

	public void onAttachedToWindow (androidx.recyclerview.widget.RecyclerView p0)
	{
		n_onAttachedToWindow (p0);
	}

	private native void n_onAttachedToWindow (androidx.recyclerview.widget.RecyclerView p0);

	public int scrollVerticallyBy (int p0, androidx.recyclerview.widget.RecyclerView.Recycler p1, androidx.recyclerview.widget.RecyclerView.State p2)
	{
		return n_scrollVerticallyBy (p0, p1, p2);
	}

	private native int n_scrollVerticallyBy (int p0, androidx.recyclerview.widget.RecyclerView.Recycler p1, androidx.recyclerview.widget.RecyclerView.State p2);

	public int scrollHorizontallyBy (int p0, androidx.recyclerview.widget.RecyclerView.Recycler p1, androidx.recyclerview.widget.RecyclerView.State p2)
	{
		return n_scrollHorizontallyBy (p0, p1, p2);
	}

	private native int n_scrollHorizontallyBy (int p0, androidx.recyclerview.widget.RecyclerView.Recycler p1, androidx.recyclerview.widget.RecyclerView.State p2);

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
