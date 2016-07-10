using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Wasserstrom_Note_Tool
{
    /// <summary>
    /// Interaction logic for OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
            ErrorLabel.Content = "";
        }

        private void MultipleItemsCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ItemExceptionCheckBox.IsEnabled = true;
        }

        private void MultipleItemsCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ItemExceptionCheckBox.IsEnabled = false;
        }

        private void ItemExceptionCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ItemExceptionTextBox.IsEnabled = true;
            ItemExceptionListBox.IsEnabled = true;
            AddButton.IsEnabled = true;
            AddButton.IsDefault = true;
            AddButton.Focus();
        }

        private void ItemExceptionCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ItemExceptionTextBox.IsEnabled = false;
            ItemExceptionTextBox.Clear();
            ItemExceptionListBox.IsEnabled = false;
            SubmitButton.IsDefault = false;
            AddButton.IsEnabled = false;
        }

        private void ItemExceptionCheckBox_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (ItemExceptionCheckBox.IsEnabled == false)
            {
                ItemExceptionCheckBox.IsChecked = false;
            }
        }

        private void ItemExceptionCheckBox_LostFocus(object sender, RoutedEventArgs e)
        {
            ErrorLabel.Content = "";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddItem();
        }

        private void ItemExceptionTextBox_TouchEnter(object sender, TouchEventArgs e)
        {
            AddItem();
        }

        private void ItemExceptionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ErrorLabel.Content = "";
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ItemExceptionListBox.SelectedItem == null)
            {
                ErrorLabel.Content = "Please select item to remove";
                ItemExceptionTextBox.Focus();
            }
            else
            {
                ItemExceptionListBox.Items.Remove(ItemExceptionListBox.SelectedItem);
                ErrorLabel.Content = "";
                RemoveButton.IsEnabled = !ItemExceptionListBox.Items.IsEmpty;
            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            ItemNumbersCheckBox.IsChecked = false;
            MultipleItemsCheckBox.IsChecked = false;
            BackorderCheckBox.IsChecked = false;
            ItemExceptionCheckBox.IsEnabled = false;
            ResetButton.IsEnabled = false;
            CopyButton.IsEnabled = false;
            ItemExceptionListBox.Items.Clear();
            ItemExceptionTextBox.Clear();
            OrderOutputTextBox.Clear();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            ResetButton.IsEnabled = true;
            CopyButton.IsEnabled = true;
            OrderOutputTextBox.IsEnabled = true;

            var OutputText = "";
            OutputText += ItemNumbersCheckBox.IsChecked.Value ?
                MultipleItemsCheckBox.IsChecked.Value ? "Customer provided item numbers" : "Customer provided the item number"
                : MultipleItemsCheckBox.IsChecked.Value ? "Customer provided item descriptions" : "Customer provided the item description";

            if (ItemExceptionCheckBox.IsChecked.Value && !ItemExceptionListBox.Items.IsEmpty)
            {
                var listSize = ItemExceptionListBox.Items.Count;
                OutputText += " except for";
                foreach (var item in ItemExceptionListBox.Items)
                {
                    if (listSize - 1 == ItemExceptionListBox.Items.IndexOf(item) && listSize > 2)
                    {
                        OutputText += ", and the " + item;
                    }
                    else if (listSize - 1 == ItemExceptionListBox.Items.IndexOf(item) && listSize > 1)
                    {
                        OutputText += " and the " + item;
                    }
                    else if (ItemExceptionListBox.Items.IndexOf(item) == 0)
                    {
                        OutputText += " the " + item;
                    }
                    else
                    {
                        OutputText += ", the " + item;
                    }
                } 
            }

            if (ConfirmedDescriptionCheckBox.IsChecked.Value)
            {
                OutputText += MultipleItemsCheckBox.IsChecked.Value
                    ? " and confirmed all descriptions given for the items."
                    : " and confirmed the description given for the item.";
            }
            else
            {
                OutputText += ".";
            }
            if (BackorderCheckBox.IsChecked.Value)
            {
                OutputText += Environment.NewLine + Environment.NewLine + "Customer is aware of all backorders on the order.";
            }
            string initials = File.ReadAllText("initials.txt");
            OutputText += Environment.NewLine + Environment.NewLine + initials + " " + DateTime.Now.ToString("MM-dd-yy");
            OrderOutputTextBox.Text = OutputText;
        }

        /// <summary>
        /// Appends item from item exception text box to list box.
        /// </summary>
        private void AddItem()
        {
            if (ItemExceptionTextBox.Text == "")
            {
                ErrorLabel.Content = "Please enter an item.";
                ItemExceptionTextBox.Focus();
            }
            else
            {
                ItemExceptionListBox.Items.Add(ItemExceptionTextBox.Text);
                RemoveButton.IsEnabled = true;
                ItemExceptionTextBox.Clear();
                ResetButton.IsEnabled = true;
            }
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(OrderOutputTextBox.Text);
            CopyButton.IsEnabled = false;
            OrderOutputTextBox.Focus();
            OrderOutputTextBox.SelectAll();
        }
    }
}
