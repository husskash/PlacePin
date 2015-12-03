using Android.App;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;

namespace maps
{
	[Activity (Label = "maps", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		/*private GoogleMap mMap;
		protected override void OnCreate (Bundle savedInstanceState)
		{
			Xamarin.Insights.Initialize (XamarinInsights.ApiKey, this);
			base.OnCreate (savedInstanceState);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			SetUpMap ();
		}
		private void SetUpMap(){
			if (mMap == null) {
				FragmentManager.FindFragmentById<MapFragment> (Resource.Id.map).GetMapAsync(this);
			}
		}

		public void OnMapReady (GoogleMap googleMap)
		{
			mMap = googleMap;
		} */

		Fragment[] _fragments;

		protected override void OnCreate(Bundle bundle){
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);
			ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

			_fragments = new Fragment[] {
				new MyMapFragment (),
				new LocationsFragment (),
				new ShareFragment ()
			};

			AddTabToActionBar (Resource.String.map_tab_label, Resource.Drawable.abc_ic_ab_back_holo_dark);
			AddTabToActionBar (Resource.String.locations_tab_label, Resource.Drawable.abc_ic_ab_back_holo_dark);
			AddTabToActionBar (Resource.String.share_tab_label, Resource.Drawable.abc_ic_ab_back_holo_dark);
		}
		void AddTabToActionBar(int labelResourceId, int iconResourceId)
		{
			ActionBar.Tab tab = ActionBar.NewTab()
				.SetText(labelResourceId)
				.SetIcon(iconResourceId);
			tab.TabSelected += TabOnTabSelected;
			ActionBar.AddTab(tab);
		}

		void TabOnTabSelected(object sender, ActionBar.TabEventArgs tabEventArgs)
		{
			ActionBar.Tab tab = (ActionBar.Tab)sender;

			Fragment frag = _fragments[tab.Position];
			tabEventArgs.FragmentTransaction.Replace(Resource.Id.frameLayout, frag);
		}
	}
}
