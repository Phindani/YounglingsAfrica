using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using System;
using Android.Views;

namespace YounglingsDemo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        DrawerLayout drawerLayout;
        NavigationView navigationView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            AppCenter.Start("3c9e1d1e-dcd0-4d9e-b549-e7effd9fe515", typeof(Analytics), typeof(Crashes));

            //var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            //SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(false);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Mipmap.ic_menu);

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

            if (navigationView != null)
                SetupDrawerContent(navigationView);

            ImageButton startButton = FindViewById<ImageButton>(Resource.Id.imageButton1);

            startButton.Click += StartButton_Click;
        }

        private void SetupDrawerContent(NavigationView navigationView)
        {
            navigationView.NavigationItemSelected += (object sender, NavigationView.NavigationItemSelectedEventArgs e) =>
              {
                  switch (e.MenuItem.ItemId)
                  {
                      case (Resource.Id.nav_home):
                          e.MenuItem.SetCheckable(true);
                          StartActivity(typeof(MainActivity));
                          break;

                  }
                 
                  drawerLayout.CloseDrawers();
              };
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                    return true;


            }
            return base.OnOptionsItemSelected(item);
        }

        private void StartButton_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(Questions));
        }
    }
}