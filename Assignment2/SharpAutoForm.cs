﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class SharpAutoSaleForm : Form
    {

        private double _BasePrice;
        private double _TradeInAllowance;
        private double _AdditionalOptionsTotal;
        private const double tax = 0.13;

        public SharpAutoSaleForm()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            //Quit
            Application.Exit();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {

        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {

        }

        private void StandardRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void PeriizedRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CustomRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void StereoSystemCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void LeatherInteriorCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ComputerNavigationCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Calculates the amount to pay for the vehicle
        /// </summary>
        private void Calculate()
        {

        }

        /// <summary>
        /// Validates all of the fields on the form for correct values.
        /// </summary>
        /// <returns></returns>
        private bool ValidateForm()
        {
            return true;
        }
    }
}