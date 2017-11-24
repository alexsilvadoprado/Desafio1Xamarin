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
        private string resultado = "";
        private bool operadorPrimario = true;

        public MainPage()
        {
            InitializeComponent();
        }

        void OnButtonNumberClicked(object sender, EventArgs e)
        {
            Button btnNumero = (Button)sender;

            if (!lblNumero.Text.Equals("0"))
            {
                if (operadorPrimario)
                {
                    if (string.IsNullOrEmpty(resultado))
                    {
                        valor1 += btnNumero.Text;
                        lblNumero.Text += btnNumero.Text;
                        resultado = "";
                    }
                    else
                    {
                        valor1 = btnNumero.Text;
                        lblNumero.Text = btnNumero.Text;
                        resultado = "0";
                    }
                }
                else
                {
                    valor2 += btnNumero.Text;
                    lblNumero.Text += btnNumero.Text;
                }
            }
            else
            {
                if (btnNumero.ClassId.Equals("btnPonto"))
                {
                    if (operadorPrimario)
                    {
                        if (string.IsNullOrEmpty(resultado))
                        {
                            valor1 += btnNumero.Text;
                            lblNumero.Text += btnNumero.Text;
                            resultado = "";
                        }
                        else
                        {
                            valor1 = btnNumero.Text;
                            lblNumero.Text = btnNumero.Text;
                            resultado = "0";
                        }
                    }
                    else
                    {
                        valor2 += btnNumero.Text;
                        lblNumero.Text += btnNumero.Text;
                    }
                }
                else
                {
                    if (operadorPrimario)
                    {
                        //if (string.IsNullOrEmpty(resultado))
                        //{
                        //    valor1 = btnNumero.Text;
                        //    lblNumero.Text = btnNumero.Text;
                        //    resultado = "";
                        //}
                        //else
                        //{
                        //    valor1 = btnNumero.Text;
                        //    lblNumero.Text = btnNumero.Text;
                        //    resultado = "0";
                        //}
                        valor1 = btnNumero.Text;
                        lblNumero.Text = btnNumero.Text;
                        resultado = "0";
                    }
                    else
                    {
                        valor2 += btnNumero.Text;
                        lblNumero.Text += btnNumero.Text;
                    }
                }
            }
        }

        void OnButtonOperationClicked(object sender, EventArgs e)
        {
            Button btnOperator = (Button)sender;

            if (btnOperator.ClassId.Equals("btnIgual"))
            {
                expression = valor1 + operador + valor2;
                Expression ex = new Expression(expression);
                resultado = ex.calculate() + "";
                lblNumero.Text = resultado;
                valor1 = resultado;
                operadorPrimario = true;
                return;
            }

            if (string.IsNullOrEmpty(operador))
            {
                if (!lblNumero.Text.Last().Equals('.'))
                {
                    if (btnOperator.ClassId.Equals("btnDiv"))
                    {
                        operador = "/";
                        operadorPrimario = false;
                        lblNumero.Text += "÷";
                        return;
                    }
                    if (btnOperator.ClassId.Equals("btnMult"))
                    {
                        operador = "*";
                        operadorPrimario = false;
                        lblNumero.Text += "x";
                        return;
                    }
                    operador = btnOperator.Text;
                    operadorPrimario = false;
                    lblNumero.Text += btnOperator.Text;
                }
                else
                {
                    if (btnOperator.ClassId.Equals("btnDiv"))
                    {
                        operador = "0/";
                        operadorPrimario = false;
                        lblNumero.Text += "0÷";
                        return;
                    }
                    if (btnOperator.ClassId.Equals("btnMult"))
                    {
                        operador = "0*";
                        operadorPrimario = false;
                        lblNumero.Text += "0x";
                        return;
                    }
                    operador = "0" + btnOperator.Text;
                    operadorPrimario = false;
                    lblNumero.Text += "0" + btnOperator.Text;
                }
            }
        }

        void OnButtonClearClicked(object sender, EventArgs e)
        {
            lblNumero.Text = "0";
            valor1 = "";
            valor2 = "";
            operador = "";
            resultado = "";
        }

        void OnButtonMaisMenosClicked(object sender, EventArgs e)
        {
            lblNumero.Text = "123";
        }
    }
}
