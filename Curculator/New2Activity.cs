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
using Android.Support.V7.App;

namespace Curculator
{
    [Activity(Label = "DataBase")]
    class New2Activity: AppCompatActivity
    {
        string dbPath = Path.Combine(System.Environment.GetFolderPath
           (System.Environment.SpecialFolder.Personal), "dataBase.db3"); 

        V7Toolbar myToolbar;
        ListView infoBase;

        protected override void OnCreate(Bundle savedInstanceState)
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

            var db = new SQLiteConnection(dbPath);
            db.CreateTable<CalcModel>();
            CalcModel dataBase = new CalcModel(name);
            db.Insert(dataBase);
            var table = db.Table<CalcModel>();
              foreach (var item in table)
              {

                Console.WriteLine(infoBase);
                infoBase = item.Res + "\n" + infoBase;
                
                //Ошибка CS0266  Не удается неявно преобразовать тип "string" в "Android.Widget.ListView".Существует явное преобразование(возможно, пропущено приведение типов).

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