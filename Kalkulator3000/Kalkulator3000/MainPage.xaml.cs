using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq.Expressions;

namespace Kalkulator3000
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private string _MathProblem = "";
        protected string MathProblem
        {
            get
            {
                return _MathProblem;
            }
            set 
            { 
                _MathProblem = value;
                ChangeLabel();
            }
        }
        protected string Ans;
        public MainPage()
        {
            InitializeComponent();
        }

        public void OnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            String Char = btn.Text;
            MathProblem += Char;
        }

        public void ShowAnswer(object sender, EventArgs e)
        {
            MathProblem += Ans;
        }

        public void Evaluate(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            bool success = true;
            try
            {
                var v = dt.Compute(MathProblem, null);
            }
            catch(Exception Idiota)
            {
                MathProblem = "";
                DisplayMath.Text = "Error";
                success = false;
            }
            finally
            {
                if (dt.Compute(MathProblem, null).ToString() == "+nekonečno")
                {
                    MathProblem = "";
                    DisplayMath.Text = "Error";
                    success = false;
                }
                if (success)
                {
                    MathProblem = dt.Compute(MathProblem, null).ToString();
                    Ans = dt.Compute(MathProblem, null).ToString();
                }
            }
        }

        private void ChangeLabel()
        {
            DisplayMath.Text = "";
            DisplayMath.Text = MathProblem;
        }

        public void DelLastChar(object sender, EventArgs e)
        {
            if (MathProblem != "")
            {
                MathProblem = MathProblem.Remove(MathProblem.Length - 1);
            }
            else
            {
                MathProblem = "";
            }
        }
        public void DeleteAll(object sender, EventArgs e)
        {
            MathProblem = "";
        }
    }
}