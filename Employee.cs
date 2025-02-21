using System;

namespace EmployeeMangement
{
    public class Employee
    {
        // Default Constructor
        public Employee()
        {
        }

        // Parameterized Constructor
        public Employee(int employeeID, string nameEmployee, int age, string jobTitle, decimal salary)
        {
            this.EmployeeID = employeeID;
            this.NameEmployee = nameEmployee;
            this.Age = age;
            this.JobTitle = jobTitle;
            this.Salary = salary;
        }

        public int EmployeeID { get; set; }
        public string? NameEmployee { get; set; }
        public int Age { get; set; }
        public string JobTitle { get; set; }
        public decimal Salary { get; set; }

        public void DisplayEmployeeInfo()
        {
            Console.WriteLine($"Name: {NameEmployee}\n" +
                              $"Age: {Age}\n" +
                              $"Job Title: {JobTitle}\n" +
                              $"Salary: {Salary}");
        }
    }

  
}
