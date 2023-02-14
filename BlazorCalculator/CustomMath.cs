using System.Runtime.InteropServices;

namespace BlazorCalculator
{
    public class CustomMath : ICustomMath
    {
        public CustomMath() { }


        public double GetPercentage(double whole, double fraction)
        {
            if ( whole == 0)
            {
                throw new DivideByZeroException("you cannot divide by zero");
            }
            return fraction / whole * 100;
        }

        public double AddNumbers(double num1, double num2)
        {
            double finalResult = num1 + num2;
            return finalResult;
        }
        public double SubtractNumbers(double num1, double num2)
        {
            double finalResult = num1 - num2;
            return finalResult;
        }
        public double MultiplyNumbers(double num1, double num2)
        {
            double finalResult = num1 * num2;
            return finalResult;
        }
        public double DivideNumbers(double num1, double num2)
        {
            if (num2 == 0)
            {
                throw new DivideByZeroException("Cannot Divide by Zero");
            }
            double finalResult = num1 / num2;
            return finalResult;
        }

        public double GetModulo(double num1, double num2)
        {
            if (num2 == 0)
            {
                throw new DivideByZeroException("Cannot Divide by Zero");
            }
            double finalResult = num1 % num2;
            return finalResult;
        }
    }
}
