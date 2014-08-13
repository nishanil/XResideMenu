using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Custom.ResideMenu;


namespace XResideMenu
{
	[Activity (Label = "XResideMenu", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		private ResideMenu resideMenu;
		//private MainActivity mContext;
		private ResideMenuItem itemHome;
		private ResideMenuItem itemProfile;
		private ResideMenuItem itemCalendar;
		private ResideMenuItem itemSettings;


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.main);


			SetUpMenu ();
			ChangeFragment (new HomeFragment ());
			// Get our button from the layout resource,
			// and attach an event to it

		

		}

		private void SetUpMenu()
		{

			// attach to current activity;
			resideMenu = new ResideMenu(this);

			resideMenu.SetBackground(Resource.Drawable.menu_background);
			resideMenu.AttachToActivity(this);
			//resideMenu.OpenMenuEvent += async (sender, e) => ;
			//valid scale factor is between 0.0f and 1.0f. leftmenu'width is 150dip. 
			resideMenu.SetScaleValue(0.6f);

			// create menu items;
			itemHome     = new ResideMenuItem(this, Resource.Drawable.icon_home,     "Home");
			itemProfile  = new ResideMenuItem(this, Resource.Drawable.icon_profile,  "Profile");
			itemCalendar = new ResideMenuItem(this, Resource.Drawable.icon_calendar, "Calendar");
			itemSettings = new ResideMenuItem(this, Resource.Drawable.icon_settings, "Settings");

//			itemHome.setOnClickListener(this);
//			itemProfile.setOnClickListener(this);
//			itemCalendar.setOnClickListener(this);
//			itemSettings.setOnClickListener(this);

			resideMenu.AddMenuItem(itemHome, ResideMenu.DirectionLeft);
			resideMenu.AddMenuItem(itemProfile, ResideMenu.DirectionRight);
			resideMenu.AddMenuItem(itemCalendar, ResideMenu.DirectionRight);
			resideMenu.AddMenuItem(itemSettings, ResideMenu.DirectionRight);

			// You can disable a direction by setting ->
			resideMenu.SetSwipeDirectionDisable(ResideMenu.DirectionRight);

			FindViewById<Button> (Resource.Id.title_bar_left_menu).Click += (object sender, EventArgs e) => resideMenu.OpenMenu (ResideMenu.DirectionLeft);
			FindViewById<Button> (Resource.Id.title_bar_right_menu).Click += (object sender, EventArgs e) => resideMenu.OpenMenu (ResideMenu.DirectionRight);

		}

		private void ChangeFragment(Fragment targetFragment){
			resideMenu.ClearIgnoredViewList();

			FragmentManager
				.BeginTransaction ()
				.Replace (Resource.Id.main_fragment, targetFragment, "fragment")
				.SetTransitionStyle ((int)FragmentTransit.FragmentFade)
				.Commit ();
				
		}


		public ResideMenu GetResideMenu()
		{
			return resideMenu;
		}

		public override bool DispatchTouchEvent (MotionEvent ev)
		{
			return resideMenu.DispatchTouchEvent (ev);
		}

	}
}


