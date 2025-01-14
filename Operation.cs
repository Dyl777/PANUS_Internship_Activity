
namespace Calculator.OperationsUtilities {
abstract class Operations<T>
{
    public abstract T Add(T a, T b);
    public abstract T Subtract(T a, T b);
    public abstract T Multiply(T a, T b);
    public abstract T Divide(T a, T b);
    public abstract T Modulo(T a, T b);

    public static T PerformOperation(string op, T a, T b)
    {
        var instance = (Operations<T>)Activator.CreateInstance(typeof(T).Name == "Int32" ? typeof(IntOperations) :
                            typeof(T).Name == "Single" ? typeof(FloatOperations) :
                            typeof(DoubleOperations));

        return op switch
        {
            "+" => instance.Add(a, b),
            "-" => instance.Subtract(a, b),
            "*" => instance.Multiply(a, b),
            "/" => instance.Divide(a, b),
            "%" => instance.Modulo(a, b),
            _ => throw new ArgumentException("Unsupported operator")
        };
    }
}

}
