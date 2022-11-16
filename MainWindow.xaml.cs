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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window //Partial means that a class can be defined in another file
    {
        double lastNumber, result;
        Operation selectedOperator;

        public MainWindow()
        {
            InitializeComponent();

            acButton.Click += AcButton_Click;
            negativeButton.Click += NegativeButton_Click;
            percentageButton.Click += PercentageButton_Click;
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            double actualNumber = 0;
            if (double.TryParse(resultLabel.Content.ToString(), out actualNumber))
            {
                MathOperation(actualNumber);
                resultLabel.Content = result.ToString();
            }
        }

        private void MathOperation(double actualNumber)
        {
            switch (selectedOperator)
            {
                case Operation.Multiplication:
                    result = SimpleMath.Multiply(lastNumber, actualNumber);
                    break;
                case Operation.Division:
                    result = SimpleMath.Divide(lastNumber, actualNumber);
                    break;
                case Operation.Sum:
                    result = SimpleMath.Add(lastNumber, actualNumber);
                    break;
                case Operation.Subtraction:
                    result = SimpleMath.Subtract(lastNumber, actualNumber);
                    break;
            }
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
            }

            CheckForOperation(sender);
        }

        private void CheckForOperation(object sender)
        {
            if ((Button)sender == multiplicationButton)
            {
                selectedOperator = Operation.Multiplication;
            }
            else if ((Button)sender == divisionButton)
            {
                selectedOperator = Operation.Division;
            }
            else if ((Button)sender == minusButton)
            {
                selectedOperator = Operation.Subtraction;
            }
            else if ((Button)sender == plusButton)
            {
                selectedOperator = Operation.Sum;
            }
            else
            {
                throw new Exception("Button is not a operation Button");
            }
        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out tempNumber))
            {
                if(lastNumber != 0)
                {
                    tempNumber = SimpleMath.PercentageOperation(lastNumber, tempNumber);
                    resultLabel.Content = tempNumber.ToString();
                }
                else
                {
                    tempNumber = SimpleMath.PercentageOfaNumber(tempNumber);
                    resultLabel.Content = tempNumber.ToString();
                }                
            }           
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
            lastNumber = 0;
            selectedOperator = Operation.NoOperation;
            result = 0;
        }

        private void pointButton_Click(object sender, RoutedEventArgs e)
        {
            if (!resultLabel.Content.ToString().Contains("."))
            {
                resultLabel.Content = $"{resultLabel.Content}.";
            }
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button buttonNumber = (Button)sender;
            string result = buttonNumber.Content.ToString();

            if (resultLabel.Content.ToString() == "0")
            {
                int selectedValue = int.Parse(resultLabel.Content.ToString());
                resultLabel.Content = result;
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}" + result;
            }
        }
    }

    public enum Operation
    {
        Multiplication,
        Division,
        Sum,
        Subtraction,
        NoOperation
    }
}
