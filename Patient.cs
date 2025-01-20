public class Patient
{
    public int PatientID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    // Constructor to initialize patient
    public Patient(int patientID, string name, int age)
    {
        PatientID = patientID;
        Name = name;
        Age = age;
    }
}
