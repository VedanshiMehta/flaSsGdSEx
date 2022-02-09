using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace flaSsGdSEx
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button myFlashL;
        Button myScreeS;
        Button myGyro;
        Button myDetectS;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            myFlashL = FindViewById<Button>(Resource.Id.button1);
            myScreeS = FindViewById<Button>(Resource.Id.button2);
            myGyro = FindViewById<Button>(Resource.Id.button3);
            myDetectS = FindViewById<Button>(Resource.Id.button4);


            myFlashL.Click += MyFlashL_Click;
            myScreeS.Click += MyScreeS_Click;
            myGyro.Click += MyGyro_Click;
            myDetectS.Click += MyDetectS_Click;
        }

        private void MyFlashL_Click(object sender, System.EventArgs e)
        {
            Intent i = new Intent(Application.Context, typeof(FlashlightDemo));
            StartActivity(i);
        }

        private void MyScreeS_Click(object sender, System.EventArgs e)
        {
            Intent j = new Intent(Application.Context, typeof(ScreenShotDemo));
            StartActivity(j);
        }

        private void MyGyro_Click(object sender, System.EventArgs e)
        {
            Intent k = new Intent(Application.Context, typeof(GyroScopeDemo));
            StartActivity(k);
        }

        private void MyDetectS_Click(object sender, System.EventArgs e)
        {
            Intent l = new Intent(Application.Context, typeof(DeteShakeDemo));
            StartActivity(l);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}