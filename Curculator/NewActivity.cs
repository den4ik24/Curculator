using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Content;
using SQLite;
using System.IO;

namespace Curculator
{
    [Activity(Label = "Result")]

    class NewActivity : AppCompatActivity
    {
        string dbPath = Path.Combine(System.Environment.GetFolderPath
           (System.Environment.SpecialFolder.Personal), "dataBase.db3"); //path to the database file

        TextView result;
        V7Toolbar myToolbar;
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.NewActivity);
            myToolbar = FindViewById<V7Toolbar>(Resource.Id.my_toolbar);
            SetSupportActionBar(myToolbar);

            result = FindViewById<TextView>(Resource.Id.result);
           
            var intent = Intent;
            String name = intent.GetStringExtra("calculate");

            result.Text = name;

           // Res();
               
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

                case Resource.Id.toBD:
                    var intent = new Intent(this, typeof(New2Activity));
                    intent.PutExtra("calculate", result.Text);
                    StartActivity(intent);
                    return true;
                                        
                default:
                    return base.OnOptionsItemSelected(item);


            }

        }

        //public void Res()
        //{
        //    var db = new SQLiteConnection(dbPath);      //setup db connection \устанавливаем соединение\
        //    db.CreateTable<CalcModel>();                //setup a table \устанавливаем таблицу\
        //    CalcModel dataBase = new CalcModel(result.Text);   //setup a new object \устанавливаем новый объект\
        //    db.Insert(dataBase);                        //store object into the table \сохраняем объект в таблицу\
        //    var table = db.Table<CalcModel>();          //connect to the table, that contains the data we want \соединяем таблицу, которая содержит нужную нам информацию\
        //    Console.WriteLine(" отправляем результат в БД ");
        //}

      
    }
}