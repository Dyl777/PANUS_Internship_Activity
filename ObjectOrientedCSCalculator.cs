//Templates for type-specific classes, Object Oriented programming
//to spilt program logic to Operators and Operations 
//Instead of if-else handling, using Error handling classes as they automatically stop program
//execution with a non-zero error code
//The program displays a list of types available on the console for user to select then checks whether
//the entered choice is the correct type before selecting, It then takes the
//respective operands, operator and validates their type, and the resulting value is computed.
//Critics: it would make more sense I suppose to instead of always using three different types for an operand, we could just 
//add a member to the operand class and store the operand there and instantiate it in the program

//Abstract Class. An abstract class is a class which must have its methods implemented 
//by derived classes
//Static Class. A static class is a class which can't be instantiatied more than once. its like a Simpleton
//abstract methods. Are generally undefined methods in an abstract class


using System;
using Calculator.OperatorUtilities;
using Calculator.ValidatorUtilities;
using Calculator.OperationsUtilities;
using Calculator.IntOperationsUtilities;
using Calculator.FloatOperationsUtilities;
using Calculator.DoubleOperationsUtilities;

class Program
{
    static void Main()
    {
        Console.WriteLine("Choose data type: 1 for int, 2 for float, 3 for double");
        int dataTypeChoice = Validator.ValidateChoice();

        Console.WriteLine("\nEnter the first operand: ");
        int intOp1 = 0;
        float floatOp1 = 0f;
        double doubleOp1 = 0.0;

        switch (dataTypeChoice)
        {
            case 1:
                intOp1 = Validator.ValidateOperand<int>();
                break;
            case 2:
                floatOp1 = Validator.ValidateOperand<float>();
                break;
            case 3:
                doubleOp1 = Validator.ValidateOperand<double>();
                break;
        }

        Console.WriteLine("\nEnter the operator: ");
        string op = Console.ReadLine();
        Operator.ValidateOperator(op);

        Console.WriteLine("\nEnter the second operand: ");
        int intOp2 = 0;
        float floatOp2 = 0f;
        double doubleOp2 = 0.0;

        switch (dataTypeChoice)
        {
            case 1:
                intOp2 = Validator.ValidateOperand<int>();
                Console.WriteLine($"\nThe result is: {IntOperations.PerformOperation(op, intOp1, intOp2)}");
                break;
            case 2:
                floatOp2 = Validator.ValidateOperand<float>();
                Console.WriteLine($"\nThe result is: {FloatOperations.PerformOperation(op, floatOp1, floatOp2)}");
                break;
            case 3:
                doubleOp2 = Validator.ValidateOperand<double>();
                Console.WriteLine($"\nThe result is: {DoubleOperations.PerformOperation(op, doubleOp1, doubleOp2)}");
                break;
        }
    }
}

/*class Validator
{
    public static int ValidateChoice()
    {
        try
        {
            int choice = int.Parse(Console.ReadLine());
            if (choice < 1 || choice > 3)
                throw new ArgumentException("Invalid choice. Enter 1, 2, or 3.");
            return choice;
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid input. Please enter 1, 2, or 3.");
            Environment.Exit(1);
            return 0; 
        }
    }

    public static T ValidateOperand<T>() where T : IConvertible
    {
        try
        {
            string input = Console.ReadLine();
            return (T)Convert.ChangeType(input, typeof(T));
        }
        catch (Exception)
        {
            Console.WriteLine($"Invalid operand format for type {typeof(T).Name}");
            Environment.Exit(1);
            return default; 
        }
    }
}

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
}*/
