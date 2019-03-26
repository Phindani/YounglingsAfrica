using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.AppCenter.Analytics;
using Xamarin.Essentials;

namespace YounglingsDemo
{
    [Activity(Label = "Questions")]
    public class Questions : Activity
    {
        public RadioButton radioButton1;
        public RadioButton radioButton2;
        public RadioButton radioButton3;
        public RadioButton radioButton4;
        public ImageButton submitButton;
        public RadioGroup radioGroup;

        public CheckBox checkBox1;
        public CheckBox checkBox2;
        public CheckBox checkBox3;
        public CheckBox checkBox4;
        public CheckBox checkBox5;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.questionPage);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            radioGroup = FindViewById<RadioGroup>(Resource.Id.radioGroup1);

            radioButton1 = FindViewById<RadioButton>(Resource.Id.radioButton1);
            radioButton2 = FindViewById<RadioButton>(Resource.Id.radioButton2);
            radioButton3 = FindViewById<RadioButton>(Resource.Id.radioButton3);
            radioButton4 = FindViewById<RadioButton>(Resource.Id.radioButton4);

            checkBox1 = FindViewById<CheckBox>(Resource.Id.checkBox1);
            checkBox2 = FindViewById<CheckBox>(Resource.Id.checkBox2);
            checkBox3 = FindViewById<CheckBox>(Resource.Id.checkBox3);
            checkBox4 = FindViewById<CheckBox>(Resource.Id.checkBox4);
            checkBox5 = FindViewById<CheckBox>(Resource.Id.checkBox5);

            submitButton = FindViewById<ImageButton>(Resource.Id.imageButton);
            submitButton.Click += SubmitButton_ClickAsync;

        }

        public async void SubmitButton_ClickAsync(object sender, EventArgs e)
        {
            if (radioGroup.CheckedRadioButtonId != -1 && ((checkBox1.Checked || checkBox2.Checked || checkBox3.Checked
          || checkBox4.Checked || checkBox5.Checked)))
            {
                try
                {

                    LocationService locationService = new LocationService();

                    var devicelocation = await locationService.GetLocation();

                    var device = DeviceInfo.Model;
                    var manufacturer = DeviceInfo.Manufacturer;
                    DateTime dateTime = new DateTime();
                    dateTime = DateTime.Now;


                    Analytics.TrackEvent("Submit Click Button", new Dictionary<string, string> {
                { "Phone Model", device.ToString() },
                { "Manufacturer", manufacturer.ToString()},
                { "Location", devicelocation.ToString() },
                { "Time", dateTime.ToString()}
                });

                    StartActivity(typeof(Rewards));

                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                    checkBox4.Checked = false;
                    checkBox5.Checked = false;
                }
                catch (Exception)
                {
                    Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                    AlertDialog alert = dialog.Create();
                    alert.SetTitle("Failed");
                    alert.SetMessage("Could not get device location.");
                    alert.SetButton("OK", (c, ev) => { });
                    alert.Show();
                }

            }
            else
            {
                Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                AlertDialog alert = dialog.Create();
                alert.SetTitle("Validation");
                alert.SetMessage("Please select answers before you submit.");
                alert.SetButton("OK", (c, ev) => { });
                alert.Show();
            }
        }
    }
}