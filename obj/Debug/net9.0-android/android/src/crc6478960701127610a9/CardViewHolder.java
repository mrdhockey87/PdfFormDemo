package crc6478960701127610a9;


public class CardViewHolder
	extends androidx.recyclerview.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Maui.PDFView.Platforms.Android.Common.CardViewHolder, Maui.PDFView", CardViewHolder.class, __md_methods);
	}

	public CardViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == CardViewHolder.class) {
			mono.android.TypeManager.Activate ("Maui.PDFView.Platforms.Android.Common.CardViewHolder, Maui.PDFView", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
		}
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
