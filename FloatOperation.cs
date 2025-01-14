class FloatOperations : Operations<float>
{
    public override float Add(float a, float b) => a + b;
    public override float Subtract(float a, float b) => a - b;
    public override float Multiply(float a, float b) => a * b;
    public override float Divide(float a, float b)
    {
        if (b == 0)
            throw new DivideByZeroException("Division by zero is not allowed");
        return a / b;
    }
    public override float Modulo(float a, float b) => a % b;
}
