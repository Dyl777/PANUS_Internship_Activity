using System;
using System.Collections.Generic;

public class Hospital
{
    // List to store patients
    private List<Patient> patients = new List<Patient>();

    // Method to add patient by ID, name, and age
    public void AddPatient(int patientID, string name, int age)
    {
        Patient newPatient = new Patient(patientID, name, age);
        patients.Add(newPatient);
        Console.WriteLine($"Patient {name} added with ID {patientID}.");
    }

    // Overloaded method to add patient by name and age only (assume ID is auto-generated)
    public void AddPatient(string name, int age)
    {
        int patientID = patients.Count + 1; 
        Patient newPatient = new Patient(patientID, name, age);
        patients.Add(newPatient);
        Console.WriteLine($"Patient {name} added with auto-generated ID {patientID}.");
    }

    
    public void DisplayPatients()
    {
        if (patients.Count == 0)
        {
            Console.WriteLine("No patients to display.");
        }
        else
        {
            Console.WriteLine("\n--- Patient List ---");
            foreach (var patient in patients)
            {
                Console.WriteLine($"ID: {patient.PatientID}, Name: {patient.Name}, Age: {patient.Age}");
            }
        }
    }
}
