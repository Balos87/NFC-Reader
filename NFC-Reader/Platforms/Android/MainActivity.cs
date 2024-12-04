using Android.App;
using Android.Content;
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
            // Initiera NFC-pluginet (viktigt innan base.OnCreate)
            CrossNFC.Init(this);
            base.OnCreate(savedInstanceState);
        }

        protected override void OnResume()
        {
            base.OnResume();
            // Återstarta NFC-lyssning (för Android 10+)
            CrossNFC.OnResume();
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            // Hantera NFC-taggupptäckt
            CrossNFC.OnNewIntent(intent);
        }

    }
}
