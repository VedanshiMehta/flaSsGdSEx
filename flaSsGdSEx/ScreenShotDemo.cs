using Android.App;
using Android.Content;
using Android.Graphics;
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
    [Activity(Label = "ScreenShotDemo")]
    public class ScreenShotDemo : Activity
    {
        private Button buttonScreenSh;
        private ImageView myview;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            
            SetContentView(Resource.Layout.screenshotDemo);


            buttonScreenSh = FindViewById<Button>(Resource.Id.buttonScreenShot);
            myview = FindViewById<ImageView>(Resource.Id.imageViewSS);

            buttonScreenSh.Click += ButtonScreenSh_Click;
        }

        private async void ButtonScreenSh_Click(object sender, EventArgs e)
        {
            var screenshot = await Screenshot.CaptureAsync();
            var stream = await screenshot.OpenReadAsync();

            myview.SetImageBitmap(BitmapFactory.DecodeStream(stream));

          
        }
    }
}