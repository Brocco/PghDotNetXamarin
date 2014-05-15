using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using System.Linq;
using System.Collections.Generic;
//using PortableClassLibrary;

namespace Android
{
    [Activity(Label = "Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
		//TodoViewModel todoVm;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button addNewButton = FindViewById<Button>(Resource.Id.addNewButton);
			EditText addNewTextBox = FindViewById<EditText> (Resource.Id.addNewTextBox);

			//todoVm = new TodoViewModel ();
        }
    }
}

