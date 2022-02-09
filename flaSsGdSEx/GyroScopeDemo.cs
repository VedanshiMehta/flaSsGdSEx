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
    [Activity(Label = "GyroScopeDemo")]
    public class GyroScopeDemo : Activity
    {
        private Button start;
        private Button stop;
        private TextView textV;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.gyroscopeDemo);
            UIReference();
            UIClickEvent();
        }

        private void UIClickEvent()
        {
            start.Click += Start_Click;
            stop.Click += Stop_Click;
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            if (Gyroscope.IsMonitoring)
            {
               Gyroscope.ReadingChanged -= Gyroscope_ReadingChanged;
                Gyroscope.Stop();
            }
        }



        private void Start_Click(object sender, EventArgs e)
        {
            if (!Gyroscope.IsMonitoring)
            {
                Gyroscope.ReadingChanged += Gyroscope_ReadingChanged;
                Gyroscope.Start(SensorSpeed.Game);

            }
        }

        private void Gyroscope_ReadingChanged(object sender, GyroscopeChangedEventArgs e)
        {
            textV.Text = $"Reading X: {e.Reading.AngularVelocity.X}, Reading Y: {e.Reading.AngularVelocity.Y}, Reading Z: {e.Reading.AngularVelocity.Z}";
        }

        


        private void UIReference()
        {
            start = FindViewById<Button>(Resource.Id.buttonStartGS);
            stop = FindViewById<Button>(Resource.Id.buttonStopGS);
            textV = FindViewById<TextView>(Resource.Id.textViewGS);

        }
    }
}