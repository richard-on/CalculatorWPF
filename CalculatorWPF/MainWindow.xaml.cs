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

namespace CalculatorWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement button in LayoutRoot.Children)
            {
                if (button is Button)
                {
                    ((Button)button).Click += Button_Click;
                }
            }
        }

        string leftOperand = "";
        string rightOperand = "";
        string operation = "";

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = (string)((Button)e.OriginalSource).Content;
            textBlock.Text += s;

            double num;
            bool result = double.TryParse(s, out num);

            if (result)
            {
                if (operation == "")
                {
                    leftOperand += s;
                }
                else
                {
                    rightOperand += s;
                }
            } 

            else
            {
                if (s == "=")
                {
                    Update_RightOp();
                    textBlock.Text += rightOperand;
                    operation = "";
                }

                else if (s == "CE")
                {
                    leftOperand = "";
                    rightOperand = "";
                    operation = "";
                    textBlock.Text = "";
                }

                else if(s == ",")
                {
                    if (operation == "")
                    {
                        leftOperand += ",";
                    }
                    else
                    {
                        rightOperand += ",";
                    }
                }

                else
                {

                    if (rightOperand != "")
                    {
                        Update_RightOp();
                        leftOperand = rightOperand;
                        rightOperand = "";
                    }
                    operation = s;
                }
            }
        }

        private void Update_RightOp()
        {
            double num1 = double.Parse(leftOperand);
            double num2 = double.Parse(rightOperand);
            switch (operation)
            {
                case "+":
                    rightOperand = (num1 + num2).ToString();
                    break;
                case "-":
                    rightOperand = (num1 - num2).ToString();
                    break;
                case "*":
                    rightOperand = (num1 * num2).ToString();
                    break;
                case "/":
                    rightOperand = (num1 / num2).ToString();
                    break;
            }
        }
    }
}