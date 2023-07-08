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
using Calculator.ExpressionTreeCalculator;

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool IsErrorShown = false;

        private readonly ICalculator calculator;

        public MainWindow()
        {
            InitializeComponent();

            calculator = new ExpressionTreeCalculator.Calculator();
        }

        void Button_Cleare(object sender, RoutedEventArgs e)
        {
            TextBlock.Text = String.Empty;
        }
        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            string expression = TextBlock.Text;

            if (string.IsNullOrEmpty(expression))
            {
                return;
            }

            int AmountOfCharsToDelte = expression[expression.Length - 1] == ' ' ? 3 : 1;
            string newExpression = expression.Substring(0, expression.Length - AmountOfCharsToDelte);
            TextBlock.Text = newExpression;
        }
        void Button_Click(object sender, RoutedEventArgs e)
        {
            if (IsErrorShown)
            {
                TextBlock.Text = String.Empty;
                IsErrorShown = false;
            }

            TextBlock.Text += ((Button)e.OriginalSource).Content.ToString();
        }

        void Button_Result(object sender, RoutedEventArgs e)
        {
            string result;
            try
            {
                result = this.calculator.Calculate(TextBlock.Text).ToString();
            }
            catch (Exception ex)
            {
                result = ex.Message;
                IsErrorShown = true;
            }
            TextBlock.Text = result;
        }

        private void Button_Reverse(object sender, RoutedEventArgs e)
        {
            double result;
            string resultString;
            try
            {
                result = this.calculator.Calculate(TextBlock.Text);
                result = 1 / result;
                resultString = result.ToString();
            }
            catch (Exception ex)
            {
                resultString = ex.Message;
                IsErrorShown = true;
            }
            TextBlock.Text = resultString;
        }

        private void Button_Procent(object sender, RoutedEventArgs e)
        {
            double result;
            string resultString;
            try
            {
                result = this.calculator.Calculate(TextBlock.Text);
                result = result / 100;
                resultString = result.ToString();
            }
            catch (Exception ex)
            {
                resultString = ex.Message;
                IsErrorShown = true;
            }
            TextBlock.Text = resultString;
        }
    }
}
