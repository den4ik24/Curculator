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
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using System.IO;
using SQLite;

namespace Curculator
{
    [Activity(Label = "DataBase")]
    class New2Activity: NewActivity
    {
        string dbPath = Path.Combine(System.Environment.GetFolderPath
           (System.Environment.SpecialFolder.Personal), "dataBase.db3");

        V7Toolbar myToolbar;
        ListView infoBase;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            myToolbar = FindViewById<V7Toolbar>(Resource.Id.my_toolbar);
            SetSupportActionBar(myToolbar);
            infoBase = FindViewById<ListView>(Resource.Id.infoBase);

            SetContentView(Resource.Layout.New2Activity);

            var intent = Intent;
            String[] name = { intent.GetStringExtra("calculate") };

            
            //infoBase.Text = name;

            ArrayAdapter<String> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, name);

            infoBase.FastScrollEnabled = true;
            
            //infoBase.SetAdapter(adapter);
            infoBase.Adapter = adapter;

            var db = new SQLiteConnection(dbPath);
            db.CreateTable<CalcModel>();
            CalcModel dataBase = new CalcModel(name);
            db.Insert(dataBase);
            var table = db.Table<CalcModel>();
        //    foreach (var item in table)
        //    {

        //        Console.WriteLine(infoBase);
        //        infoBase = item.Res + "\n" + infoBase;

        //    }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu, menu);


            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {


                case Android.Resource.Id.Home:
                    Finish();
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }


    }

}