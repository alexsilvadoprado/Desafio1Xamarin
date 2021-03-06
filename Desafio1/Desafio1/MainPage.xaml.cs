﻿using org.mariuszgromada.math.mxparser;
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
        #region VARIÁVEIS
        private string expression = "";
        private string valor1 = "";
        private string valor2 = "";
        private string operador = "";
        private string resultado = "";
        private bool operadorPrimario = true;
        #endregion

        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Trata evento de clique nos botões numéricos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                        lblNumero.Text = "0" + btnNumero.Text;
                        resultado = "";
                        return;
                    }
                    valor1 += btnNumero.Text;
                    lblNumero.Text = btnNumero.Text;
                    resultado = "";
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
                        lblNumero.Text += btnNumero.Text;
                        return;
                    }
                    if (btnNumero.ClassId.Equals("btnPonto"))
                    {
                        valor2 += "0" + btnNumero.Text;
                        lblNumero.Text += valor2;
                        return;
                    }
                    valor2 += btnNumero.Text;
                    lblNumero.Text += valor2;
                }
                else
                {
                    if (btnNumero.ClassId.Equals("btnPonto") && valor2.Contains('.'))
                        return;
                    if (!string.IsNullOrEmpty(resultado))
                    {
                        valor2 = btnNumero.Text;
                        lblNumero.Text += btnNumero.Text;
                        resultado = "";
                        return;
                    }
                    valor2 += btnNumero.Text;
                    lblNumero.Text += btnNumero.Text;
                }
            }
        }

        /// <summary>
        /// Trata eventos de clique nos botões de operação
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnButtonOperationClicked(object sender, EventArgs e)
        {
            Button btnOperator = (Button)sender;

            if (btnOperator.ClassId.Equals("btnIgual"))
            {
                if (string.IsNullOrEmpty(valor1))
                    valor1 = resultado;
                if (string.IsNullOrEmpty(valor2) && !string.IsNullOrEmpty(operador))
                    valor2 = valor1;
                else if (string.IsNullOrEmpty(valor2))
                    expression = valor1;
                
                expression = valor1 + operador + valor2;
                Expression ex = new Expression(expression);
                resultado = ex.calculate() + "";
                resultado = resultado.Replace(',', '.');
                lblNumero.Text = resultado;
                valor1 = "";
                operadorPrimario = true;
                HabilitaOperadores();
                return;
            }
            else
            {
                if (!string.IsNullOrEmpty(resultado) && string.IsNullOrEmpty(valor1))
                {
                    valor1 = resultado;
                }
                valor2 = "";

                if (!lblNumero.Text.Last().Equals('.'))
                {
                    if (btnOperator.ClassId.Equals("btnDiv"))
                    {
                        operador = "/";
                        operadorPrimario = false;
                        lblNumero.Text += "÷";
                        HabilitaOperadores(false);
                        return;
                    }
                    if (btnOperator.ClassId.Equals("btnMult"))
                    {
                        operador = "*";
                        operadorPrimario = false;
                        lblNumero.Text += "x";
                        HabilitaOperadores(false);
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
                        HabilitaOperadores(false);
                        return;
                    }
                    if (btnOperator.ClassId.Equals("btnMult"))
                    {
                        operador = "0*";
                        operadorPrimario = false;
                        lblNumero.Text += "0x";
                        HabilitaOperadores(false);
                        return;
                    }
                    operador = "0" + btnOperator.Text;
                    operadorPrimario = false;
                    lblNumero.Text += "0" + btnOperator.Text;
                }

                HabilitaOperadores(false);
            }
        }

        /// <summary>
        /// Hailita/Desabilita botões de operação
        /// </summary>
        /// <param name="habilitar"></param>
        void HabilitaOperadores(bool habilitar = true)
        {
            btnDiv.IsEnabled = habilitar;
            btnMult.IsEnabled = habilitar;
            btnMenos.IsEnabled = habilitar;
            btnMais.IsEnabled = habilitar;
        }

        /// <summary>
        /// Trata eventos de clique no botão "C" (Clear)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnButtonClearClicked(object sender, EventArgs e)
        {
            lblNumero.Text = "0";
            operadorPrimario = true;
            valor1 = "";
            valor2 = "";
            operador = "";
            resultado = "";
            HabilitaOperadores();
        }

        /// <summary>
        /// Trata eventos de clique no botão +/-
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnButtonMaisMenosClicked(object sender, EventArgs e)
        {
            if (operadorPrimario)
            {
                if (string.IsNullOrEmpty(valor1) && !string.IsNullOrEmpty(resultado))
                {
                    valor1 = resultado;
                    valor1 = "-" + valor1;
                    lblNumero.Text = valor1;
                }
            }
            else
            {
                valor2 = "(-" + valor2 + ")";
                lblNumero.Text = valor1 + operador + valor2;
            }
        }
    }
}
