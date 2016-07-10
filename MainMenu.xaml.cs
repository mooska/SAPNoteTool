using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
            if (!File.Exists("initials.txt"))
            {
                File.Create("initials.txt");
            }
            InitialTextBox.Text = File.ReadAllText("initials.txt");
        }

        private void OrderNotesButton_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("initials.txt", InitialTextBox.Text);
            OrderPage orderPage = new OrderPage();
            this.NavigationService.Navigate(orderPage);
        }

        private void DamageFormulaNoteButton_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("initials.txt", InitialTextBox.Text);
            DamageFormula damageFormulaPage = new DamageFormula();
            this.NavigationService.Navigate(damageFormulaPage);
        }

        private void ReturnCreditNotesButton_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("initials.txt", InitialTextBox.Text);
            ReturnCredit returnCreditPage = new ReturnCredit();
            this.NavigationService.Navigate(returnCreditPage);
        }
    }
}
