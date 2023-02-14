namespace BlazorCalculator
{
    public interface ICustomMath
    {
        public double GetPercentage(double whole, double fraction);

        public double AddNumbers(double num1, double num2);

        public double SubtractNumbers(double num1, double num2);

        public double MultiplyNumbers(double num1, double num2);

        public double DivideNumbers(double num1, double num2);

        public double GetModulo(double num1, double num2);
    }
}
