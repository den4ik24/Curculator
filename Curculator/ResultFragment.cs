using System.IO;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;


namespace Curculator
{
    // [Activity(Label = "Result")]

    class ResultFragment : Fragment
    {
        string dbPath = Path.Combine(System.Environment.GetFolderPath
           (System.Environment.SpecialFolder.Personal), "dataBase.db3"); //path to the database file

        TextView result;
        //V7Toolbar myToolbar;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            //myToolbar = Activity.FindViewById<V7Toolbar>(Resource.Id.my_toolbar);
            //SetSupportActionBar(myToolbar);
            View view = inflater.Inflate(Resource.Layout.Result, container, false);
            result = view.FindViewById<TextView>(Resource.Id.result);
            var intent = new Intent();
            //var intent = Intent;
            string name = intent.GetStringExtra("calculate");
            result.Text = name;
            return view; //inflater.Inflate(Resource.Layout.Calculator, container, false);
        }        
        //public override bool OnCreateOptionsMenu(IMenu menu)
        //{    
        //    MenuInflater.Inflate(Resource.Menu.menu, menu);
        //    return true;
        //}

        //public override bool OnOptionsItemSelected(IMenuItem item)
        //{
        //    switch (item.ItemId)                  
        //        case Android.Resource.Id.Home:
        //            Finish();
        //            return true;
        //        case Resource.Id.toBD:
        //            var intent = new Intent(this, typeof(DataBaseActivity));
        //            intent.PutExtra("calculate", result.Text);
        //            StartActivity(intent);
        //            return true;                                 
        //        default:
        //            return base.OnOptionsItemSelected(item);
        //    }
        //}

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