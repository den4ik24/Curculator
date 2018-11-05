using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System;
using Android.Content;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Views;
using SQLite;
using System.IO;
using System.Linq;

namespace Curculator
{

    [Activity(Label = "Calculator", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        

        TextView result;
        Button delete;
        Button radical;
        Button percent;
        Button reset;
        Button calculateButton;
        Button number;
        Button changeznak;
        Button operation;
        V7Toolbar myToolbar;

        string dbPath = Path.Combine(System.Environment.GetFolderPath
           (System.Environment.SpecialFolder.Personal), "dataBase.db3");


        protected override void OnCreate(Bundle savedInstanceState)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");


            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            myToolbar = FindViewById<V7Toolbar>(Resource.Id.my_toolbar);
            SetSupportActionBar(myToolbar);

            result = FindViewById<TextView>(Resource.Id.textView1);

            changeznak = FindViewById<Button>(Resource.Id.changeznak);
            changeznak.Click += Changeznak_click;

            delete = FindViewById<Button>(Resource.Id.delete);
            delete.Click += Delete_click;

            radical = FindViewById<Button>(Resource.Id.radical);
            radical.Click += Radical_click;

            percent = FindViewById<Button>(Resource.Id.percent);
            percent.Click += Percent_click;

            reset = FindViewById<Button>(Resource.Id.reset);
            reset.Click += Reset_click;

            calculateButton = FindViewById<Button>(Resource.Id.calculateButton);
            calculateButton.Click += CalculateButton_click;

            number = FindViewById<Button>(Resource.Id.number1);
            number.Click += Number_click;
            number = FindViewById<Button>(Resource.Id.number2);
            number.Click += Number_click;
            number = FindViewById<Button>(Resource.Id.number3);
            number.Click += Number_click;
            number = FindViewById<Button>(Resource.Id.number4);
            number.Click += Number_click;
            number = FindViewById<Button>(Resource.Id.number5);
            number.Click += Number_click;
            number = FindViewById<Button>(Resource.Id.number6);
            number.Click += Number_click;
            number = FindViewById<Button>(Resource.Id.number7);
            number.Click += Number_click;
            number = FindViewById<Button>(Resource.Id.number8);
            number.Click += Number_click;
            number = FindViewById<Button>(Resource.Id.number9);
            number.Click += Number_click;
            number = FindViewById<Button>(Resource.Id.numberComma);
            number.Click += Number_click;
            number = FindViewById<Button>(Resource.Id.number0);
            number.Click += Number_click;

            operation = FindViewById<Button>(Resource.Id.operationPlus);
            operation.Click += Operation_click;
            operation = FindViewById<Button>(Resource.Id.operationMinus);
            operation.Click += Operation_click;
            operation = FindViewById<Button>(Resource.Id.operationMultiply);
            operation.Click += Operation_click;
            operation = FindViewById<Button>(Resource.Id.operationDivide);
            operation.Click += Operation_click;
            operation = FindViewById<Button>(Resource.Id.operationDegree);
            operation.Click += Operation_click;



            var db = new SQLiteConnection(dbPath);      //setup db connection \устанавливаем соединение\
            db.CreateTable<CalcModel>();                //setup a table \устанавливаем таблицу\
            CalcModel dataBase = new CalcModel(result.Text);   //setup a new object \устанавливаем новый объект\
            db.Insert(dataBase);                        //store object into the table \сохраняем объект в таблицу\
            var table = db.Table<CalcModel>();          //connect to the table, that contains the data we want \соединяем таблицу, которая содержит нужную нам информацию\

            

            var intent = new Intent(this, typeof(New2Activity));
            intent.PutExtra("calculate", result.Text);
            StartActivity(intent);
        }

        

        private void Number_click (object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (button.Text == ".")
            {
                if (!result.Text.Contains("."))
                    result.Text += (sender as Button).Text;
            }
            else
                result.Text += (sender as Button).Text;
        }

        double a = 0, b = 0, c = 0;

        char znak = '+';

        private void Operation_click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToDouble(result.Text);
                znak = (sender as Button).Text[0];
                result.Text = "";
            }


            catch (Exception)
            {

            }

            
        }

        
        private void CalculateButton_click (object sender, EventArgs e)
        {
            
            
            try
            {
                b = Convert.ToDouble(result.Text);
                switch (znak)
                {
                    case '+':
                        c = a + b;
                        break;
                    case '-':
                        c = a - b;
                        break;
                    case '*':
                        c = a * b;
                        break;
                    case '/':
                        c = a / b;
                        break;
                    case '^':
                        c = Math.Pow(a, b);
                        break;
                }
                
                result.Text = "";

                var intent = new Intent(this, typeof(NewActivity));
                intent.PutExtra("calculate", c.ToString());
                StartActivity(intent);
                                
                
            }
            catch (Exception)
            {

            }
        }

        private void Radical_click (object sender, EventArgs e)
        {
     

            try
            {
                a = Convert.ToDouble(result.Text);
                result.Text = Convert.ToString(Math.Sqrt(a));
            }
            catch (Exception)
            {

            }
            result.Text = "";

            var intent = new Intent(this, typeof(NewActivity));
            intent.PutExtra("calculate", Convert.ToString(Math.Sqrt(a)));
            StartActivity(intent);
        }
        
        private void Percent_click (object sender, EventArgs e)
        {
            
            try
            {
                a = Convert.ToDouble(result.Text);
                result.Text = Convert.ToString(a / 100);
            }
            catch (Exception)
            {

            }
            result.Text = "";

            var intent = new Intent(this, typeof(NewActivity));
            intent.PutExtra("calculate", Convert.ToString(a / 100));
            Console.WriteLine(a);
            StartActivity(intent);
        }

        private void Reset_click (object sender,EventArgs e)
        {
            result.Text = "";
        }

        private void Changeznak_click (object sender, EventArgs e)
        {
            if (result.Text != "")
                if (result.Text[0] == '-')
                    result.Text = result.Text.Remove(0, 1);
                else result.Text = '-' + result.Text;
        }

        private void Delete_click (object sender, EventArgs e)
        {
            if (result.Text != "")
                result.Text = result.Text.Remove(result.Text.Length - 1, 1);
        }

        public void Inten(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(New2Activity));
            intent.PutExtra("calculate", result.ToString());
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
                               
                case Resource.Id.toBD:
                    var intent = new Intent(this, typeof(New2Activity));
                    intent.PutExtra("calculate", result.Text);
                    StartActivity(intent);
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
    }   

}

