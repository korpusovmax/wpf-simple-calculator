using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string number = "";
        double left = 0;
        double right = 0;
        string op = "0";
        private void click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var code = button.Tag;
            if (""+code == "=")
            {
                right = int.Parse(number);
                operate();
                op = "0";
            } else if ("+-*/".Contains(""+code))
            {
                if (op == "0")
                {
                    left = int.Parse(number);
                    op = ""+code;
                    number = "";
                    output.Content = op;
                } else
                {
                    right = int.Parse(number);
                    operate();
                    op = ""+code;
                }
            } else
            {
                number += code;
                output.Content = number;
            }
        }

        private void operate()
        {
            double result = left;
            if (op == "+")
            {
                result += right;
            } else if (op == "-")
            {
                result -= right;
            } else if (op == "*")
            {
                result *= right;
            } else if (op == "/")
            {
                result /= right;
            }
            number = ""+result;
            left = result;
            right = 0;
            output.Content = number;
        }
    }
}
