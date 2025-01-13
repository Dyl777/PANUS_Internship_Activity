# Variables, Data Types, Operators, Control Structures, Input and Output Operations

## Table of Contents
1. **Variables in C#**
2. **Data Types in C#**
3. **Operators in C#**
4. **Control Structures in C#**
   - `if` Statement
   - `switch` Statement
   - `for` Loop
   - `while` Loop
5. **Input and Output Operations in C#**

---

## 1. Variables in C#

A variable in C# is a storage location in memory that holds a value that can be changed during the execution of a program. Variables are declared with a specific data type that determines the kind of data the variable can hold.

### Declaring a Variable:
```csharp
int number;       // Declaration of an integer variable
string name;      // Declaration of a string variable
double salary;    // Declaration of a double variable
```

### Initializing a Variable:
You can assign a value to a variable when it is declared.
```csharp
int age = 25;
string city = "New York";
double pi = 3.14159;
```

### Variable Scope:
A variable's scope determines where in the code it can be accessed. Variables can be local (within a method) or global (within a class).

---

## 2. Data Types in C#

C# is a statically-typed language, meaning the type of a variable must be known at compile time. Data types can be broadly categorized into two categories: value types and reference types.

### Value Types
Value types directly contain their data. Examples include:
- **int**: Represents an integer (e.g., 10)
- **float**: Represents a floating-point number (e.g., 3.14f)
- **double**: Represents a double-precision floating-point number (e.g., 3.14159)
- **bool**: Represents a Boolean value (true or false)
- **char**: Represents a single character (e.g., 'A')
- **struct**: User-defined value types (e.g., DateTime)

### Reference Types
Reference types store references to their data (pointers). Examples include:
- **string**: Represents a sequence of characters (e.g., "Hello")
- **object**: The base type for all other types in C#
- **arrays**: An ordered collection of elements (e.g., int[])

### Nullable Types
Value types can be made nullable using the `?` syntax. This allows them to represent `null` as a valid value.
```csharp
int? number = null;
```

---

## 3. Operators in C#

Operators are used to perform operations on variables and values. C# provides various operators that can be classified into several categories.

### Arithmetic Operators:
- `+`: Addition
- `-`: Subtraction
- `*`: Multiplication
- `/`: Division
- `%`: Modulus (remainder)

### Relational Operators:
- `==`: Equal to
- `!=`: Not equal to
- `>`: Greater than
- `<`: Less than
- `>=`: Greater than or equal to
- `<=`: Less than or equal to

### Logical Operators:
- `&&`: Logical AND
- `||`: Logical OR
- `!`: Logical NOT

### Assignment Operators:
- `=`: Assign value
- `+=`: Add and assign
- `-=`: Subtract and assign
- `*=`: Multiply and assign
- `/=`: Divide and assign
- `%=`: Modulus and assign

### Bitwise Operators:
- `&`: Bitwise AND
- `|`: Bitwise OR
- `^`: Bitwise XOR
- `~`: Bitwise NOT
- `<<`: Left shift
- `>>`: Right shift

### Conditional (Ternary) Operator:
The ternary operator is a shorthand for an `if-else` statement.
```csharp
int max = (a > b) ? a : b;  // Returns 'a' if true, else returns 'b'
```

---

## 4. Control Structures in C#

Control structures allow the flow of execution to be directed based on certain conditions or loops.

### `if` Statement

The `if` statement evaluates a condition, and if the condition is true, it executes a block of code. Otherwise, it skips the block.

```csharp
if (age >= 18)
{
    Console.WriteLine("You are an adult.");
}
else
{
    Console.WriteLine("You are a minor.");
}
```

### `switch` Statement

The `switch` statement selects one of many code blocks to execute based on a variable's value.

```csharp
int day = 3;
switch (day)
{
    case 1:
        Console.WriteLine("Monday");
        break;
    case 2:
        Console.WriteLine("Tuesday");
        break;
    case 3:
        Console.WriteLine("Wednesday");
        break;
    default:
        Console.WriteLine("Invalid day");
        break;
}
```

### `for` Loop

A `for` loop is used to repeat a block of code a specific number of times. It consists of three parts: initialization, condition, and iteration.

```csharp
for (int i = 0; i < 5; i++)
{
    Console.WriteLine("i = " + i);
}
```

### `while` Loop

A `while` loop repeats a block of code as long as a specified condition is true. The condition is evaluated before each iteration.

```csharp
int i = 0;
while (i < 5)
{
    Console.WriteLine("i = " + i);
    i++;
}
```

### `do-while` Loop

Similar to the `while` loop, but the condition is evaluated after the loop is executed, ensuring that the loop runs at least once.

```csharp
int i = 0;
do
{
    Console.WriteLine("i = " + i);
    i++;
} while (i < 5);
```

---

## 5. Input and Output Operations in C#

C# provides the `Console` class to perform input and output operations in console-based applications.

### Output Operation
The `Console.WriteLine()` method is used to print output to the console.

```csharp
Console.WriteLine("Hello, world!"); // Prints text to the console
```

The `Console.Write()` method can be used if you don't want to append a new line at the end.

```csharp
Console.Write("Enter your name: ");
```

### Input Operation
To read input from the user, the `Console.ReadLine()` method is used.

```csharp
string name = Console.ReadLine();  // Reads input as a string
Console.WriteLine("Hello, " + name);
```

To read numbers or other types, you must convert the string input to the desired type:

```csharp
Console.Write("Enter your age: ");
int age = int.Parse(Console.ReadLine());  // Converts input string to integer
Console.WriteLine("Your age is " + age);
```

To handle invalid input, use `TryParse()`:

```csharp
Console.Write("Enter a number: ");
if (int.TryParse(Console.ReadLine(), out int number))
{
    Console.WriteLine("You entered: " + number);
}
else
{
    Console.WriteLine("Invalid number.");
}
```

---
