using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Platform.Android;

namespace XamarinGram.Droid
{
    [Activity(Label = "XamarinGram", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            // Set windows statusbar to light
            Window.SetStatusBarColor(Xamarin.Forms.Color.FromHex("#FAFAFA").ToAndroid());

            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                int newUiVisibility = (int)Window.DecorView.SystemUiVisibility;
                newUiVisibility |= (int)SystemUiFlags.LightStatusBar;
                Window.DecorView.SystemUiVisibility = (StatusBarVisibility)newUiVisibility;
            }

            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);
            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
    }
}