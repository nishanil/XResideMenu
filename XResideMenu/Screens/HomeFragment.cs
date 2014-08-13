using System;
using Android.App;
using Android.Views;
using Custom.ResideMenu;
using Android.Widget;

namespace XResideMenu
{
	public class HomeFragment : Fragment
	{
		private View parentView;
		private ResideMenu resideMenu;


		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Android.OS.Bundle savedInstanceState)
		{
			parentView = inflater.Inflate (Resource.Layout.home, container, false);

			var parentActivity = (MainActivity)this.Activity;

			resideMenu = parentActivity.GetResideMenu ();

			parentView.FindViewById<Button>(Resource.Id.btn_open_menu).Click += (object sender, EventArgs e) => resideMenu.OpenMenu(ResideMenu.DirectionLeft) ;

			FrameLayout ignoredView = parentView.FindViewById<FrameLayout> (Resource.Id.ignored_view);
			resideMenu.AddIgnoredView (ignoredView);

			return parentView;
		
		}


	}
}

