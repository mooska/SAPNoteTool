using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wasserstrom_Note_Tool
{
    /// <summary>
    /// Interaction logic for ReturnCredit.xaml
    /// </summary>
    public partial class ReturnCredit : Page
    {
        public ReturnCredit()
        {
            InitializeComponent();
        }

        private void RequestTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RequestTypeComboBox.BorderBrush = Brushes.White;
            string ComboText = RequestTypeComboBox.SelectedItem != null
                ? ((ComboBoxItem)RequestTypeComboBox.SelectedItem).Content.ToString()
                : "";
            if(ComboText.ToLower() == "credit")
            {
                RestockFeeCheckBox.IsEnabled = false;
                ReorderCheckBox.IsEnabled = true;
                StockCheckCheckBox.IsEnabled = true;
                SalesActCheckBox.IsEnabled = true;
                ReasonComboBox.IsEnabled = true;
                ReasonLabel.IsEnabled = true;
                NumberOfLabelsLabel.IsEnabled = false;
                NumberOfLabelsTextBox.IsEnabled = false;
                CarrierCheckBox.IsEnabled = true;
                ReasonComboBox.Items.Clear();
                ReasonComboBox.Items.Add("Short Shipped");
                ReasonComboBox.Items.Add("CSR - Wrong Item");
                ReasonComboBox.Items.Add("Damage In Shipment");
            }
            else if (ComboText.ToLower() == "return")
            {
                RestockFeeCheckBox.IsEnabled = true;
                ReorderCheckBox.IsEnabled = true;
                StockCheckCheckBox.IsEnabled = true;
                SalesActCheckBox.IsEnabled = true;
                ReasonComboBox.IsEnabled = true;
                ReasonLabel.IsEnabled = true;
                NumberOfLabelsLabel.IsEnabled = true;
                NumberOfLabelsTextBox.IsEnabled = true;
                CarrierCheckBox.IsEnabled = true;
                ReasonComboBox.Items.Clear();
                ReasonComboBox.Items.Add("Customer - Wrong Item");
                ReasonComboBox.Items.Add("CSR - Wrong Item");
                ReasonComboBox.Items.Add("WH Sent Wrong Item");
            }
        }

        private void CarrierCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CarrierTextBox.IsEnabled = true;
        }

        private void CarrierCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CarrierTextBox.IsEnabled = false;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string OutputText = "";

            OutputText += RestockFeeCheckBox.IsChecked.Value
                ? "Customer is aware of a $10 restocking fee" + Environment.NewLine
                : "";
            OutputText += ReasonText();
            OutputText += ReorderCheckBox.IsChecked.Value 
                ? "Reorder:" + Environment.NewLine
                : "No reorder" + Environment.NewLine;
            string ComboText = RequestTypeComboBox.SelectedItem != null
                ? ((ComboBoxItem)RequestTypeComboBox.SelectedItem).Content.ToString()
                : "";
            if (ComboText.ToLower() == "return")
            {
                if(TextBoxValidation(NumberOfLabelsTextBox) && Int32.Parse(NumberOfLabelsTextBox.Text) > 1)
                {
                    OutputText += NumberOfLabelsTextBox.Text + " labels sent to " + Environment.NewLine;
                }
                else
                {
                    OutputText += NumberOfLabelsTextBox.Text + " label sent to " + Environment.NewLine;
                }
                OutputText += TextBoxValidation(NumberOfLabelsTextBox)
                    ? Int32.Parse(NumberOfLabelsTextBox.Text) > 1 ? "Tracking numbers: " + Environment.NewLine : "Tracking number: " + Environment.NewLine
                    : "";
            }
            OutputText += CarrierCheckBox.IsChecked.Value
                ? "Carrier was " + CarrierTextBox.Text + Environment.NewLine
                : "";
            OutputText += SalesActCheckBox.IsChecked.Value
                ? "S/A: " + Environment.NewLine
                : "";
            OutputText += StockCheckCheckBox.IsChecked.Value
                ? "Stock Check: " + Environment.NewLine
                : "";

            string initials = File.ReadAllText("initials.txt");
            OutputText += Environment.NewLine + initials + " " + DateTime.Now.ToString("MM-dd-yy");
            if (ComboText.ToLower() == "return")
            {
                ReturnCreditOutputTextBox.Text = TextBoxValidation(NumberOfLabelsTextBox)
                    ? OutputText
                    : "";
                if(ReturnCreditOutputTextBox.Text != "")
                {
                    CopyButton.IsEnabled = true;
                    ResetButton.IsEnabled = true;
                    ReturnCreditOutputTextBox.IsEnabled = true;
                }
            }
            else if(RequestTypeComboBox.SelectedItem != null)
            {
                ReturnCreditOutputTextBox.Text = OutputText;
                CopyButton.IsEnabled = true;
                ResetButton.IsEnabled = true;
                ReturnCreditOutputTextBox.IsEnabled = true;
            }
            else
            {
                RequestTypeComboBox.BorderBrush = Brushes.Salmon;
            }
        }

        private string ReasonText()
        {

            string ComboText = ReasonComboBox.SelectedItem != null
               ? ReasonComboBox.SelectedItem.ToString()
               : "";
            if (ComboText.ToLower() == "short shipped")
            {
                return "Warehouse short shipped the items" + Environment.NewLine;
            }
            if (ComboText.ToLower() == "csr - wrong item")
            {
                return "CSR ordered wrong items" + Environment.NewLine;
            }
            if (ComboText.ToLower() == "customer - wrong item")
            {
                return "Customer ordered wrong items" + Environment.NewLine;
            }
            if (ComboText.ToLower() == "damage in shipment")
            {
                return "Items were damaged in shipment" + Environment.NewLine;
            }
            if (ComboText.ToLower() == "wh sent wrong item")
            {
                return "Warehouse sent the wrong items" + Environment.NewLine;
            }
            return "(Insert reason here)" + Environment.NewLine;
        }

        private void NumberOfLabelsTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9.-]+");
            return !regex.IsMatch(text);
        }

        private static bool TextBoxValidation(TextBox textBox)
        {
            if (textBox.Text == "")
            {
                textBox.BorderBrush = Brushes.Salmon;
                return false;
            }
            else
            {
                textBox.BorderBrush = Brushes.White;
                return true;
            }
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(ReturnCreditOutputTextBox.Text);
            CopyButton.IsEnabled = false;
            ReturnCreditOutputTextBox.Focus();
            ReturnCreditOutputTextBox.SelectAll();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            resetCheckbox(RestockFeeCheckBox);
            resetCheckbox(ReorderCheckBox);
            resetCheckbox(StockCheckCheckBox);
            resetCheckbox(SalesActCheckBox);
            resetCheckbox(CarrierCheckBox);
            RequestTypeComboBox.SelectedIndex = -1;
            ReasonComboBox.Items.Clear();
            NumberOfLabelsTextBox.Clear();
            CarrierTextBox.Clear();
            CopyButton.IsEnabled = false;
            ResetButton.IsEnabled = false;
            ReturnCreditOutputTextBox.Clear();
            ReturnCreditOutputTextBox.IsEnabled = false;
        }

        private void resetCheckbox(CheckBox checkBox)
        {
            checkBox.IsChecked = false;
            checkBox.IsEnabled = false;
        }
    }
}
