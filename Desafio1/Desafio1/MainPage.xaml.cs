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

            if (operadorPrimario)
            {
                if (string.IsNullOrEmpty(valor1))
                {
                    if (btnNumero.ClassId.Equals("btn0"))
                        return;
                    if (btnNumero.ClassId.Equals("btnPonto"))
                    {
                        valor1 += "0" + btnNumero.Text;
                        lblNumero.Text += btnNumero.Text;
                        return;
                    }
                    valor1 += btnNumero.Text;
                    lblNumero.Text = btnNumero.Text;
                }
                else
                {
                    if (string.IsNullOrEmpty(resultado))
                    {
                        if (btnNumero.ClassId.Equals("btnPonto") && valor1.Contains('.'))
                            return;
                        valor1 += btnNumero.Text;
                        lblNumero.Text += btnNumero.Text;
                    }
                    else
                    {
                        if (btnNumero.ClassId.Equals("btnPonto"))
                        {
                            if (valor1.Last() == '.')
                                return;
                            valor1 = "0" + btnNumero.Text;
                            lblNumero.Text = "0" + btnNumero.Text;
                            return;
                        }
                        valor1 = btnNumero.Text;
                        lblNumero.Text = btnNumero.Text;
                        resultado = "";
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(valor2))
                {
                    if (btnNumero.ClassId.Equals("btn0"))
                    {
                        lblNumero.Text = btnNumero.Text;
                        return;
                    }
                    if (btnNumero.ClassId.Equals("btnPonto"))
                    {
                        valor2 += "0" + btnNumero.Text;
                        lblNumero.Text = valor2;
                        return;
                    }
                    valor2 += btnNumero.Text;
                    lblNumero.Text = valor2;
                }
                else
                {
                    if (btnNumero.ClassId.Equals("btnPonto") && valor2.Contains('.'))
                        return;
                    valor2 += btnNumero.Text;
                    lblNumero.Text += btnNumero.Text;
                }
            }
        }

        void OnButtonOperationClicked(object sender, EventArgs e)
        {
            Button btnOperator = (Button)sender;

            if (btnOperator.ClassId.Equals("btnIgual"))
            {
                if (string.IsNullOrEmpty(valor2))
                    valor2 = valor1;
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
                if (!string.IsNullOrEmpty(resultado))
                    valor1 = resultado;

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
            operadorPrimario = true;
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
