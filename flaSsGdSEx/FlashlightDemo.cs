using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace flaSsGdSEx
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class FlashlightDemo : Activity
    {
        private Button bOn;
        private Button bOff;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.flashlightDemo);
            UIReference();
            UIClickEvents();
        }

        private void UIClickEvents()
        {
            bOn.Click += BOn_Click;
            bOff.Click += BOff_Click;
        }

        private async void BOff_Click(object sender, EventArgs e)
        {
            try
            {

                await Flashlight.TurnOffAsync();
            }
            catch (FeatureNotSupportedException fns)
            {

                Toast.MakeText(this, fns.StackTrace, ToastLength.Short).Show();

            }
            catch (PermissionException pe)
            {

                Toast.MakeText(this, pe.StackTrace, ToastLength.Short).Show();

            }

            catch (Exception exception)
            {

                Toast.MakeText(this, exception.StackTrace, ToastLength.Short).Show();

            }
        }

        private async void BOn_Click(object sender, EventArgs e)
        {
            try
            {

                await Flashlight.TurnOnAsync();
            }
            catch (FeatureNotSupportedException fns)
            {

                Toast.MakeText(this, fns.StackTrace, ToastLength.Short).Show();

            }
            catch (PermissionException pe)
            {

                Toast.MakeText(this, pe.StackTrace, ToastLength.Short).Show();

            }

            catch (Exception exception)
            {

                Toast.MakeText(this, exception.StackTrace, ToastLength.Short).Show();

            }
        }

        private void UIReference()
        {
            bOn = FindViewById<Button>(Resource.Id.buttonOn);
            bOff = FindViewById<Button>(Resource.Id.buttonOff);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}