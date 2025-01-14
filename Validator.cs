
namespace Calculator.ValidatorUtilities {

class Validator
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

}
