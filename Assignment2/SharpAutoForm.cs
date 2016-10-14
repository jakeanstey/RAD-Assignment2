/**
 * Sharp Auto Form
 * Jake Anstey - 200281238
 * Created 2016-09-24
 * Sharp Auto Form is a car price calculator that includes trade in value and additional features.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class SharpAutoSaleForm : Form
    {

        private double _BasePrice = 0;
        private double _TradeInAllowance = 0;
        private double _AdditionalOptionsTotal = 0;
        private String LastSelectedRadioButton = "StandardRadioButton";
        private const double _SalesTax = 0.13;

        /// <summary>
        /// Instansiate the class
        /// </summary>
        public SharpAutoSaleForm()
        {
            InitializeComponent();
            AdditionalOptionsTextBox.Text = "$0.00";
        }

        /// <summary>
        /// Handles the closing of the application for the exit button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            //Quit
            Application.Exit();
        }

        /// <summary>
        /// Handles the clear button even and clears the form back to default.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            BasePriceTextBox.Text = "0";
            TradeInAllowanceTextBox.Text = "0";
            AdditionalOptionsTextBox.Text = "";
            SubTotalTextBox.Text = "";
            SalesTaxTextBox.Text = "";
            TotalTextBox.Text = "";
            AmountDueTextBox.Text = "";

            StereoSystemCheckBox.Checked = false;
            LeatherInteriorCheckBox.Checked = false;
            ComputerNavigationCheckBox.Checked = false;

            StandardRadioButton.Checked = true;
            LastSelectedRadioButton = "StandardRadioButton";
        }

        /// <summary>
        /// Handles the click event of the calculate button. Form verification happens here.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            if (Validate(BasePriceTextBox) && Validate(TradeInAllowanceTextBox))
            {
                Calculate();
            }
        }

        //handles the change of the standard radio button
        private void StandardRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            CalculateAdditional(sender);
        }

        //handles the change of the pearlized radio button
        private void PeriizedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            CalculateAdditional(sender);
        }

        //handles the change of the custom radio button
        private void CustomRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            CalculateAdditional(sender);
        }

        /// <summary>
        /// Will handle the addition or subtraction of the additional features price based on the selected Radio Button.
        /// </summary>
        /// <param name="sender"></param>
        private void CalculateAdditional(object sender)
        {
            double _standardCost = 0.00;
            double _PeriizedCost = 1500.00;
            double _CustomCost = 2800.00;

            RadioButton selected = sender as RadioButton;

            //if the standard gets selected
            if(selected.Text == "Standard" && selected.Checked == true)
            {
                if(LastSelectedRadioButton == "PeriizedRadioButton")
                {
                    _AdditionalOptionsTotal -= _PeriizedCost;
                    _AdditionalOptionsTotal += _standardCost;
                }else
                {
                    _AdditionalOptionsTotal -= _CustomCost;
                    _AdditionalOptionsTotal += _standardCost;
                }

                LastSelectedRadioButton = "StandardRadioButton";
            }
            //If the pearlized gets selected
            else if(selected.Text == "Pearlized" && selected.Checked == true)
            {
                Debug.Write("This");
                if(LastSelectedRadioButton == "StandardRadioButton")
                {
                    _AdditionalOptionsTotal -= _standardCost;
                    _AdditionalOptionsTotal += _PeriizedCost;
                }
                else
                {
                    _AdditionalOptionsTotal -= _CustomCost;
                    _AdditionalOptionsTotal += _PeriizedCost;
                }

                LastSelectedRadioButton = "PeriizedRadioButton";
            }
            //If the Custom get selected
            else if(selected.Text == "Custom" && selected.Checked == true)
            {
                if(LastSelectedRadioButton == "StandardRadioButton")
                {
                    _AdditionalOptionsTotal -= _standardCost;
                    _AdditionalOptionsTotal += _CustomCost;
                }
                else
                {
                    _AdditionalOptionsTotal -= _PeriizedCost;
                    _AdditionalOptionsTotal += _CustomCost;
                }

                LastSelectedRadioButton = "CustomRadioButton";
            }

            AdditionalOptionsTextBox.Text = "$" + _AdditionalOptionsTotal;

        }

        /// <summary>
        /// Adds on to additional costs the amount of a stereo system.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StereoSystemCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            double StereoSystemCost = 800.00;

            if(StereoSystemCheckBox.Checked == true)
            {
                _AdditionalOptionsTotal += StereoSystemCost;
            }else
            {
                _AdditionalOptionsTotal -= StereoSystemCost;
            }

            AdditionalOptionsTextBox.Text = "$" + _AdditionalOptionsTotal;
        }

        /// <summary>
        /// Adds on to additional costs the amount of leather interior.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeatherInteriorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            double _LeatherInteriorCost = 2348.00;

            if(LeatherInteriorCheckBox.Checked == true)
            {
                _AdditionalOptionsTotal += _LeatherInteriorCost;
            }else
            {
                _AdditionalOptionsTotal -= _LeatherInteriorCost;
            }

            AdditionalOptionsTextBox.Text = "$" + _AdditionalOptionsTotal;
        }

        /// <summary>
        /// Adds on to additional costs the amount of the navigation system.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComputerNavigationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            double _NavSystemCost = 1200.00;

            if(ComputerNavigationCheckBox.Checked == true)
            {
                _AdditionalOptionsTotal += _NavSystemCost;
            }else
            {
                _AdditionalOptionsTotal -= _NavSystemCost;
            }
            AdditionalOptionsTextBox.Text = "$" + _AdditionalOptionsTotal;
        }

        /// <summary>
        /// Calculates the amount to pay for the vehicle
        /// </summary>
        private void Calculate()
        {
            double basePrice = Double.Parse(BasePriceTextBox.Text);
            double tradeIn = Double.Parse(TradeInAllowanceTextBox.Text);

            double subtotal = (basePrice + _AdditionalOptionsTotal);
            SubTotalTextBox.Text = "$" + subtotal;

            double salesTax = (subtotal * _SalesTax);
            SalesTaxTextBox.Text = "$" + salesTax;

            double total = (subtotal + salesTax);
            TotalTextBox.Text = "$" + total;

            double amountDue = (total - tradeIn);
            AmountDueTextBox.Text = "$" + amountDue;
        }

        /// <summary>
        /// Validates all of the fields on the form for correct values.
        /// </summary>
        /// <returns></returns>
        private bool Validate(TextBox textBox)
        {
            if(textBox.Text != "")
            {
                try
                {
                    Convert.ToDouble(textBox.Text);
                }
                catch(Exception)
                {
                    ResetAndFocusTextBox(textBox);
                    ErrorLabel.Text = textBox.Name + " must be a number.";
                    return false;
                }
            }else
            {
                ResetAndFocusTextBox(textBox);
                ErrorLabel.Text = textBox.Name + " must not be empty";
                return false;
            }
            return true;
        }

        /// <summary>
        /// Will reset and focus a specific text box in case of error.
        /// </summary>
        /// <param name="textBox"></param>
        private void ResetAndFocusTextBox(TextBox textBox)
        {
            textBox.Text = "0";
            textBox.SelectAll();
            textBox.Focus();
        }
        
        /// <summary>
        /// Handles the exit menu item, calls on the exit button event, closes application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            ExitButton_Click(sender, e);
        }

        /// <summary>
        /// Handles the calculate menu item, calls on the calculate button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculateMenuItem_Click(object sender, EventArgs e)
        {
            CalculateButton_Click(sender, e);
        }

        /// <summary>
        /// Handles the clear menu item, calls on clear button event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearMenuItem_Click(object sender, EventArgs e)
        {
            ClearButton_Click(sender, e);
        }

        /// <summary>
        /// Handles the font menu item, shows font dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FontMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog.ShowDialog();
        }

        /// <summary>
        /// Handles the color menu item, shows the color dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog.ShowDialog();
        }

        /// <summary>
        /// Call on the about form and display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }
    }
}
