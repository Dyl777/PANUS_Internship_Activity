using System;
using System.Collections.Generic;

class Subject
{
    public string Name { get; set; }
    public int Credits { get; set; }
    public double Score { get; set; }
    public double GradePoint { get; set; }
}

class Program
{
    static double GetGradePoint(double score)
    {
        if (score >= 90) return 4.0;
        else if (score >= 80) return 3.0;
        else if (score >= 70) return 2.0;
        else if (score >= 60) return 1.0;
        else return 0.0;
    }

    static double CalculateGPA(List<Subject> subjects)
    {
        double totalPoints = 0;
        int totalCredits = 0;

        foreach (var subject in subjects)
        {
            subject.GradePoint = GetGradePoint(subject.Score);
            totalPoints += subject.GradePoint * subject.Credits;
            totalCredits += subject.Credits;
        }

        return totalCredits == 0 ? 0 : totalPoints / totalCredits;
    }

    static void Main()
    {
        List<Subject> subjects = new List<Subject>();
        Console.WriteLine("WELCOME TO PANUS GPA CALCULATOR PROGRAM");
        Console.Write("Enter number of subjects: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter subject name: ");
            string name = Console.ReadLine();
            Console.Write("Enter credits: ");
            int credits = int.Parse(Console.ReadLine());
            Console.Write("Enter score: ");
            double score = double.Parse(Console.ReadLine());

            subjects.Add(new Subject { Name = name, Credits = credits, Score = score });
        }

        double gpa = CalculateGPA(subjects);
        Console.WriteLine($"Student's GPA: {gpa:F2}");
    }
}
