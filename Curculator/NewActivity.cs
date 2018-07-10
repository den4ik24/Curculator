using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using System.IO;
using SQLite;


namespace Curculator
{
    [Activity(Label ="Result")]

    class NewActivity : AppCompatActivity
    {

        string dbPath = Path.Combine(System.Environment.GetFolderPath
            (System.Environment.SpecialFolder.Personal), "dataBase.db3");

        TextView result;
        V7Toolbar myToolbar;
        TextView displayText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.NewActivity);
            myToolbar = FindViewById<V7Toolbar>(Resource.Id.my_toolbar);
            SetSupportActionBar(myToolbar);
            result = FindViewById<TextView>(Resource.Id.result);
            displayText = FindViewById<TextView>(Resource.Id.displayText);

            var intent = Intent;
            String name = intent.GetStringExtra("calculate");

            String numberA = intent.GetStringExtra("A");
            String numberB = intent.GetStringExtra("B");

            String deistvie = intent.GetStringExtra("deistvie");

            result.Text = name;



            var db = new SQLiteConnection(dbPath);
                db.CreateTable<CalcModel>();
            CalcModel dataBase = new CalcModel(name, deistvie, numberA, numberB);
                db.Insert(dataBase);
                var table = db.Table<CalcModel>();
                foreach(var item in table)
                {
                    
                    Console.WriteLine(displayText.Text);
                    displayText.Text = item.Res +" = "+ item.NumberA +" "+ item.Deistvie +" "+ item.NumberB +"\n" + displayText.Text ;
                   
                }
            
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