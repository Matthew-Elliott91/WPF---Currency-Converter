using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF___Currency_Converter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            BindCurrency();
        }

        private void BindCurrency()
        {
            DataTable dtCurrency = new DataTable()
            {
                Columns =
                {
                    "CurrencyName",
                    "Value"
                },
                Rows =
                {
                    {"--SELECT--", 0},
                    {"Indian Rupee", 86.20 },
                    {"US Dollar", 1},
                    {"Euro", 0.98},
                    {"Saudi Riyal", 3.75},
                    {"Pound", 0.82},
                    
                }
            };
                   

            cmbFromCurrency.ItemsSource = dtCurrency.DefaultView;
            cmbFromCurrency.DisplayMemberPath = "CurrencyName";
            cmbFromCurrency.SelectedValuePath = "Value";
            cmbFromCurrency.SelectedIndex = 0;

            cmbToCurrency.ItemsSource = dtCurrency.DefaultView;
            cmbToCurrency.DisplayMemberPath = "CurrencyName";
            cmbToCurrency.SelectedValuePath = "Value";
            cmbToCurrency.SelectedIndex = 0;
        }


        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            double convertedValue;

            //Check if the user has entered a value to convert
            if (txtCurrency.Text == null || txtCurrency.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the currency value to convert");
                txtCurrency.Focus();
                return;
            }
            // Else if currency form is not selected tell the user to select the currency
            else if (cmbFromCurrency.SelectedValue == null || cmbFromCurrency.SelectedIndex == 0)
            {
                MessageBox.Show("Please select the currency to convert from");
                cmbFromCurrency.Focus();
                return;
            }
            // Check if currency to is not selected tell the user to select the currency
            else if (cmbToCurrency.SelectedValue == null || cmbToCurrency.SelectedIndex == 0)
            {
                MessageBox.Show("Please select the currency to convert to");
                cmbToCurrency.Focus();
                return;
            }
            // Check if currency to and from are the same
            else if (cmbFromCurrency.SelectedIndex == cmbToCurrency.SelectedIndex)
            {
                MessageBox.Show("You have chosen the same currency to convert to and from");
                cmbToCurrency.Focus();
                return;
            }
            // Convert the currency


            double fromCurrencyValue = double.Parse(cmbFromCurrency.SelectedValue.ToString());
            double toCurrencyValue = double.Parse(cmbToCurrency.SelectedValue.ToString());
            double amount = double.Parse(txtCurrency.Text);

            convertedValue = (amount * toCurrencyValue) / fromCurrencyValue;

            lblCurrency.Content = $"{cmbToCurrency.Text} {convertedValue:##.###}";




        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            txtCurrency.Text = "";

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9.]+").IsMatch(e.Text);
        }

        private void txtCurrency_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cmbFromCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbFromCurrency_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmbToCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbToCurrency_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}