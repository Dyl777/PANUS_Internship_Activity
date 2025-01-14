using Calculator.OperationsUtilities;

namespace Calculator.IntOperationsUtilities {

class IntOperations : Operations<int>
{
    public override int Add(int a, int b) => a + b;
    public override int Subtract(int a, int b) => a - b;
    public override int Multiply(int a, int b) => a * b;
    public override int Divide(int a, int b)
    {
        if (b == 0)
            throw new DivideByZeroException("Division by zero is not allowed");
        return a / b;
    }
    public override int Modulo(int a, int b) => a % b;
}

}
