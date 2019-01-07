using System;

using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using System.IO;
using SQLite;
using Android.Support.V7.App;
using System.Linq;
using Android.Content;
using System.Collections;

namespace Curculator
{
    [Activity(Label = "База")]
    class New2Activity: AppCompatActivity
    {
        //string name;
                
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

                infoBase.ItemClick += InfoBase_ItemClick;



                //1. получаем GetStringExtra

                //name = intent.GetStringExtra("calculate");


                //2. добавляем в БД

                var db = new SQLiteConnection(dbPath);      //setup db connection \устанавливаем соединение\
                //db.CreateTable<CalcModel>();                //setup a table \устанавливаем таблицу\
                //CalcModel dataBase = new CalcModel(name);   //setup a new object \устанавливаем новый объект\
                //db.Insert(dataBase);                        //store object into the table \сохраняем объект в таблицу\
                var table = db.Table<CalcModel>();          //connect to the table, that contains the data we want \соединяем таблицу, которая содержит нужную нам информацию\



                //3. вывод на экран

                ArrayAdapter<CalcModel> adapter = new ArrayAdapter<CalcModel>(this, Android.Resource.Layout.SimpleListItem1, table.ToList());
                infoBase.FastScrollEnabled = true;
                infoBase.Adapter = adapter;
                Console.WriteLine(" записываем в Таблицу результвтов ");

            }
            catch (Exception)
            {
               
            }

        }


        private void InfoBase_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {

            var intent = new Intent(this, typeof(NewActivity));
            intent.PutExtra("calculate", infoBase.GetItemAtPosition(e.Position).ToString());
            StartActivity(intent);
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