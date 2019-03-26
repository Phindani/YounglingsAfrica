using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace YounglingsDemo
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
        EditText username;
        EditText password;
        Button Login_button;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.login_page);

            username = FindViewById<EditText>(Resource.Id.et_username);
            password = FindViewById<EditText>(Resource.Id.et_password);
            //Login_button = FindViewById<Button>(Resource.Id.button1);


        }
    }
}