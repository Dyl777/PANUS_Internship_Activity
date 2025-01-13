using System;

class Program
{
    static void Main()
    {
string first_operand;
string second_operand;
string op;
float result;

float first_operand_processed = 0;
float second_operand_processed = 0;

Console.WriteLine("Enter the first operator: ");
first_operand = Console.ReadLine();
try
{
    first_operand_processed = float.Parse(first_operand);
}
catch (FormatException)
{
    Console.WriteLine("Invalid first operand format");
    Environment.Exit(1);
}

Console.WriteLine("\nEnter the operator: ");
op = Console.ReadLine();

if (op.Replace(" ", "") != "*" && op.Replace(" ", "") != "-" && op.Replace(" ", "") != "+" && 
    op.Replace(" ", "") != "/" && op.Replace(" ", "") != "%")
{
    Console.WriteLine("Invalid operator");
    Environment.Exit(1);
}

Console.WriteLine("\nEnter the second operator: ");
second_operand = Console.ReadLine();
try
{
    second_operand_processed = float.Parse(second_operand);
}
catch (FormatException)
{
    Console.WriteLine("Invalid second operand format");
    Environment.Exit(1);
}

Console.WriteLine("\nThe result of the calculation is: ");

if(op.Replace(" ", "") == "*"){
  result = first_operand_processed * second_operand_processed;
   Console.WriteLine(result);
} else if(op.Replace(" ", "") == "+"){
  result = first_operand_processed + second_operand_processed;
   Console.WriteLine(result);
} else if(op.Replace(" ", "") == "-"){
  result = first_operand_processed - second_operand_processed;
   Console.WriteLine(result);
} else if(op.Replace(" ", "") == "%"){
  result = first_operand_processed % second_operand_processed;
   Console.WriteLine(result);
} else if(op.Replace(" ", "") == "/"){
  result = first_operand_processed / second_operand_processed;
   Console.WriteLine(result);
}
	
	}
}
