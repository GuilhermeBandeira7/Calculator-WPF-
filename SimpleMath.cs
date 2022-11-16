using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal static class SimpleMath
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }

        public static double Subtract(double n1, double n2)
        {
            return n1 - n2;
        }

        public static double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }

        public static double Divide(double n1, double n2)
        {
            return n1 / n2;
        }

        //Calculate the following operation --> Number + percentage of Number(ex: 80 + 10%)
        public static double PercentageOperation(double n1, double percentage)
        {
            return (percentage / 100) * n1;
        }

        public static double PercentageOfaNumber(double n1)
        {
            return n1 / 100;
        }
    }
}
