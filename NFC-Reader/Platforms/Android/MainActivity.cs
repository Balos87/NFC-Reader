using Android.App;
using Android.Content.PM;
using Android.OS;
using Plugin.NFC;

namespace NFC_Reader
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            // initializing NFC-plugin to make sure its runs before base.OnCreate
            CrossNFC.Init(this);

            base.OnCreate(savedInstanceState);
        }
    }
}
