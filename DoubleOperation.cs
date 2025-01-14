using Calculator.OperationsUtilities;

namespace Calculator.DoubleOperationsUtilities {

class DoubleOperations : Operations<double>
{
    public override double Add(double a, double b) => a + b;
    public override double Subtract(double a, double b) => a - b;
    public override double Multiply(double a, double b) => a * b;
    public override double Divide(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException("Division by zero is not allowed");
        return a / b;
    }
    public override double Modulo(double a, double b) => a % b;
}

}
