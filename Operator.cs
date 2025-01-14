
class Operator
{
    private static readonly string[] validOperators = { "+", "-", "*", "/", "%" };

    public static void ValidateOperator(string op)
    {
        if (Array.IndexOf(validOperators, op) == -1)
        {
            Console.WriteLine("Invalid operator");
            Environment.Exit(1);
        }
    }
}
