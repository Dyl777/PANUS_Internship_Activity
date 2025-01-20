using System;

class Program
{
    static void Main()
    {
        
        Hospital hospital = new Hospital();

        
        hospital.AddPatient(1, "John Doe", 30);      
        hospital.AddPatient("Jane Smith", 25);       
        
        
        hospital.DisplayPatients();
        
        
        hospital.AddPatient(2, "Alice Johnson", 28);
        hospital.AddPatient("Bob Brown", 35);

        
        hospital.DisplayPatients();
    }
}
