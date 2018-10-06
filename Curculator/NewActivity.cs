using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Content;


namespace Curculator
{
    [Activity(Label = "Result")]

    class NewActivity : AppCompatActivity
    {

        //string dbPath = Path.Combine(System.Environment.GetFolderPath
        //    (System.Environment.SpecialFolder.Personal), "dataBase.db3");

        TextView result;
        V7Toolbar myToolbar;
        //TextView displayText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.NewActivity);
            myToolbar = FindViewById<V7Toolbar>(Resource.Id.my_toolbar);
            SetSupportActionBar(myToolbar);

            result = FindViewById<TextView>(Resource.Id.result);
            //displayText = FindViewById<TextView>(Resource.Id.displayText);

            var intent = Intent;
            String name = intent.GetStringExtra("calculate");

            result.Text = name;


            //var db = new sqliteconnection(dbpath);
            //db.createtable<calcmodel>();
            //calcmodel database = new calcmodel(name);
            //db.insert(database);
            //var table = db.table<calcmodel>();
            //foreach (var item in table)
            //{

            //    console.writeline(displaytext.text);
            //    displaytext.text = item.res + "\n" + displaytext.text;

            //}
            
        }

        //public void Inten(object sender, EventArgs e)
        //{
        //    var intent = new Intent(this, typeof(New2Activity));
        //    intent.PutExtra("calculate", result.ToString());
        //    StartActivity(intent);
        //}

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
                    StartActivity(intent);
                    return true;
                                        
                default:
                    return base.OnOptionsItemSelected(item);


            }

        }



        
    }
}