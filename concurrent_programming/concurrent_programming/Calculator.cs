namespace concurrent_programming
{
    public class Calculator
    {
        public Calculator()
        {

        }

        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Substract(double a, double b)
        {
            return a - b;
        } 

        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new ArgumentException("Cannot divide by 0", "b");
            }
            return a / b;
        }

        public double Multiply(double a, double b)
        {
            return a * b;
        }
    }
}