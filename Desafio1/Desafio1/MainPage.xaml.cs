using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Desafio1
{
    public partial class MainPage : ContentPage
    {
        private string expression = "";
        private string valor1 = "";
        private string valor2 = "";
        private string operador = "";

        public MainPage()
        {
            InitializeComponent();
        }

        void OnButtonNumberClicked(object sender, EventArgs e)
        {
            Button btnNumero = (Button)sender;

            if (!lblNumero.Text.Equals("0"))
            {
                lblNumero.Text += btnNumero.Text;
                expression += btnNumero.Text;
            }
            else
            {
                if (btnNumero.ClassId.Equals("btnPonto"))
                {
                    lblNumero.Text += btnNumero.Text;
                    expression += btnNumero.Text;
                }
                else
                {
                    lblNumero.Text = btnNumero.Text;
                    expression = btnNumero.Text;
                }
            }
        }

        void OnButtonOperationClicked(object sender, EventArgs e)
        {
            Button btnOperator = (Button)sender;

            if(btnOperator.ClassId.Equals("btnIgual"))
            {
                Expression ex = new Expression(expression);
                lblNumero.Text = ex.calculate() + "";
                return;
            }

            if (string.IsNullOrEmpty(operador))
            {
            }

            //if (!lblNumero.Text.Last().Equals('.'))
            //{
            //    if(btnOperator.ClassId.Equals("btnDiv"))
            //    {
            //        lblNumero.Text += "÷";
            //        expression += "/";
            //        return;
            //    }
            //    if (btnOperator.ClassId.Equals("btnMult"))
            //    {
            //        lblNumero.Text += "x";
            //        expression += "*";
            //        return;
            //    }
            //    lblNumero.Text += btnOperator.Text;
            //    expression += btnOperator.Text;
            //}
            //else
            //{
            //    if (btnOperator.ClassId.Equals("btnDiv"))
            //    {
            //        lblNumero.Text += "0÷";
            //        expression += "0/";
            //        return;
            //    }
            //    if (btnOperator.ClassId.Equals("btnMult"))
            //    {
            //        lblNumero.Text += "0x";
            //        expression += "0*";
            //        return;
            //    }
            //    lblNumero.Text += "0" + btnOperator.Text;
            //    expression += "0" + btnOperator.Text;
            //}
        }

        void OnButtonClearClicked(object sender, EventArgs e)
        {
            lblNumero.Text = "0";
            valor1 = "";
            valor2 = "";
            operador = "";
        }

        void OnButtonMaisMenosClicked(object sender, EventArgs e)
        {
            lblNumero.Text = "123";
        }
    }
}
