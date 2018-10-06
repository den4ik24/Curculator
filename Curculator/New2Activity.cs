using System;

using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using System.IO;
using SQLite;
using Android.Support.V7.App;

namespace Curculator
{
    [Activity(Label = "DataBase")]
    class New2Activity: AppCompatActivity
    {
        string dbPath = Path.Combine(System.Environment.GetFolderPath
           (System.Environment.SpecialFolder.Personal), "dataBase.db3"); //path to the database file

        V7Toolbar myToolbar;
        ListView infoBase;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);
                SetContentView(Resource.Layout.New2Activity);

                myToolbar = FindViewById<V7Toolbar>(Resource.Id.my_toolbar);
                SetSupportActionBar(myToolbar);

                infoBase = FindViewById<ListView>(Resource.Id.infoBase);

                var intent = Intent;
                
                String[] name = { intent.GetStringExtra("calculate") };
                //infoBase.Text = name;
                ArrayAdapter<String> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, name);
                infoBase.FastScrollEnabled = true;
                infoBase.Adapter = adapter;


                var db = new SQLiteConnection(dbPath);      //setup db connection
                db.CreateTable<CalcModel>();                //setup a table
                CalcModel dataBase = new CalcModel(name);   //setup a new object
                db.Insert(dataBase);                        //store object into the table
                var table = db.Table<CalcModel>();          //connect to the table, that contains the data we want
                                                            //var stockList = db.Table<CalcModel>();
                foreach (var item in table)
                {
                    CalcModel myCalcModel = new CalcModel(item.Res);
                    Console.WriteLine(item.Res + "\n" + infoBase);                                     
                    
                    break;
                }

            }
            catch (Exception)
            {
                //System.Diagnostics.Debug.WriteLine("SQLiteEx", ex.Message);
              
            }


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