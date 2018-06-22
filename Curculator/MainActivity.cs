using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System;

namespace Curculator
{

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView textView1;
        Button delete;
        Button radical;
        Button percent;
        Button reset;
        Button calculateButton;
        Button number;
        Button changeznak;
        Button operation;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            textView1 = FindViewById<TextView>(Resource.Id.textView1);

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


        }

        

        private void Number_click (object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (button.Text == ".")
            {
                if (!textView1.Text.Contains("."))
                    textView1.Text += (sender as Button).Text;
            }
            else
                textView1.Text += (sender as Button).Text;
        }

        double a = 0, b = 0, c = 0;

        char znak = '+';

        private void Operation_click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToDouble(textView1.Text);
                znak = (sender as Button).Text[0];
                textView1.Text = "";
            }
            catch (Exception)
            {

            }
        }

        private void CalculateButton_click (object sender, EventArgs e)
        {
            try
            {
                b = Convert.ToDouble(textView1.Text);
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
                textView1.Text = c.ToString();
            }
            catch (Exception)
            {

            }
        }

        private void Radical_click (object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToDouble(textView1.Text);
                textView1.Text = Convert.ToString(Math.Sqrt(a));
            }
            catch (Exception)
            {

            }
        }
        
        private void Percent_click (object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToDouble(textView1.Text);
                textView1.Text = Convert.ToString(a / 100);
            }
            catch (Exception)
            {

            }
        }

        private void Reset_click (object sender,EventArgs e)
        {
            textView1.Text = "";
        }

        private void Changeznak_click (object sender, EventArgs e)
        {
            if (textView1.Text != "")
                if (textView1.Text[0] == '-')
                    textView1.Text = textView1.Text.Remove(0, 1);
                else textView1.Text = '-' + textView1.Text;
        }

        private void Delete_click (object sender, EventArgs e)
        {
            if (textView1.Text != "")
                textView1.Text = textView1.Text.Remove(textView1.Text.Length - 1, 1);
        }

    }   

}

