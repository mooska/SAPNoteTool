using System;
using System.Collections.Generic;
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
    /// Interaction logic for DamageFormula.xaml
    /// </summary>
    public partial class DamageFormula : Page
    {
        public DamageFormula()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            double casePrice = TextBoxValidation(CasePriceTextBox)
                ? Double.Parse(CasePriceTextBox.Text)
                : 0;
            double piecesPerCase = TextBoxValidation(CasePiecesTextBox)
                ? Double.Parse(CasePiecesTextBox.Text)
                : 0;
            double cases = TextBoxValidation(CasesTextBox)
                ? Double.Parse(CasesTextBox.Text)
                : 0;
            double piecesBroken = TextBoxValidation(BrokenPiecesTextBox)
                ? Double.Parse(BrokenPiecesTextBox.Text)
                : 0;
            List<double> textBoxValues = new List<double> { casePrice, piecesPerCase, cases, piecesBroken };
            string damageFormulaOutput;

            if (!EntryValidationTest(textBoxValues))
                return;
            else
            {
                damageFormulaOutput = createOutput(casePrice, piecesPerCase, cases, piecesBroken);
                DamageFormulaOutputTextBox.Text = damageFormulaOutput;
                CopyButton.IsEnabled = true;
                DamageFormulaOutputTextBox.IsEnabled = true;
                ResetButton.IsEnabled = true;
                CasePriceTextBox.BorderBrush = Brushes.White;
                CasePiecesTextBox.BorderBrush = Brushes.White;
                CasesTextBox.BorderBrush = Brushes.White;
                BrokenPiecesTextBox.BorderBrush = Brushes.White;
            }
        }

        private string createOutput(double casePrice, double piecesPerCase, double cases, double piecesBroken)
        {
            double totalValue = casePrice * cases;
            double totalPieces = piecesPerCase * cases;
            double pieceValue = casePrice / piecesPerCase;
            double brokenValue = pieceValue * piecesBroken;
            double newUnitPrice = (totalValue - brokenValue) / cases;
            double totalCredit = brokenValue / cases;
            string outputString =
                $"Case Price: {casePrice.ToString("C")}" + Environment.NewLine +
                $"Pieces In Case: {piecesPerCase}" + Environment.NewLine +
                $"Number of Cases: {cases}" + Environment.NewLine +
                $"Broken Pieces: {piecesBroken}" + Environment.NewLine +
                $"New Unit Price: {newUnitPrice.ToString("C")}" + Environment.NewLine + Environment.NewLine +
                $"Case Price: {casePrice.ToString("C")}" + Environment.NewLine +
                $"New Unit Price: {newUnitPrice.ToString("C")}" + Environment.NewLine +
                $"Case price: {totalCredit.ToString("C")}";

            return outputString;
        }

        private bool EntryValidationTest(List<double> textBoxValues)
        {
            foreach(var value in textBoxValues)
            {
                if (value == 0)
                    return false;
            }
            return true;
        }

        private static bool TextBoxValidation(TextBox textBox)
        {
            if(textBox.Text == "")
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

        private new void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9.-]+");
            return !regex.IsMatch(text);
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(DamageFormulaOutputTextBox.Text);
            CopyButton.IsEnabled = false;
            DamageFormulaOutputTextBox.Focus();
            DamageFormulaOutputTextBox.SelectAll();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            CasePriceTextBox.Clear();
            CasePiecesTextBox.Clear();
            CasesTextBox.Clear();
            BrokenPiecesTextBox.Clear();
            CopyButton.IsEnabled = false;
            ResetButton.IsEnabled = false;
            DamageFormulaOutputTextBox.Clear();
            DamageFormulaOutputTextBox.IsEnabled = false;
        }
    }
}
