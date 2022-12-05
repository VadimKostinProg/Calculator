using System;
using System.Collections.Generic;
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
using System.Data;

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void Button_Cleare(object sender, RoutedEventArgs e)
        {
            TextBlock.Text = String.Empty;
        }
        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                string toDelete = TextBlock.Text;
                StringBuilder sb = new StringBuilder();
                int AmountToDelte = toDelete[toDelete.Length - 1] == ' ' ? 3 : 1;
                for (int i = 0; i < toDelete.Length - AmountToDelte; i++) sb.Append(toDelete[i]);
                TextBlock.Text = sb.ToString();
            }
            catch(Exception ex) { }
        }
        void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBlock.Text += ((Button)e.OriginalSource).Content.ToString();
        }

        void Button_Result(object sender, RoutedEventArgs e)
        {
            string result;
            try
            {
                result = new ExpresionCalculator().Compute(TextBlock.Text).ToString();
            }
            catch (Exception ex)
            {
                result = "Error!";
            }
            TextBlock.Text = result;
        }

        private void Button_Reverse(object sender, RoutedEventArgs e)
        {
            double result;
            string resultString;
            try
            {
                result = new ExpresionCalculator().Compute(TextBlock.Text);
                result = 1 / result;
                resultString = result.ToString();
            }
            catch(Exception ex)
            {
                resultString = "Error!";
            }
            TextBlock.Text = resultString;
        }

        private void Button_Procent(object sender, RoutedEventArgs e)
        {
            double result;
            string resultString;
            try
            {
                result = new ExpresionCalculator().Compute(TextBlock.Text);
                result = result / 100;
                resultString = result.ToString();
            }
            catch (Exception ex)
            {
                resultString = "Error!";
            }
            TextBlock.Text = resultString;
        }
    }
}
