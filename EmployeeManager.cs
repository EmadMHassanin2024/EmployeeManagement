using System;
using System.Collections.Generic;

namespace EmployeeMangement
{
    public class EmployeeManager
    {
        private List<Employee> employees = new List<Employee>();

       // public Dictionary<string, Employee> employees = new Dictionary<string, Employee>();    

        // إضافة موظف إلى القائمة
        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
            Console.WriteLine($"Employee {employee.NameEmployee} added successfully!");
        }


        // Update employee in list
        public void UpdateEmployee(int employeeID, string newName, int? newAge, string newJobTitle, decimal? newSalary)
        {
            // البحث عن الموظف في القائمة
            var employee = employees.FirstOrDefault(emp => emp.EmployeeID == employeeID);

            if (employee != null) // التأكد من أن الموظف موجود
            {
                // تحديث بيانات الموظف
                 if (!string.IsNullOrEmpty(newName))
                    employee.NameEmployee = newName;
                if (newAge.HasValue)
                    employee.Age = newAge.Value;
                if (!string.IsNullOrEmpty(newJobTitle))
                    employee.JobTitle = newJobTitle;
                if (newSalary.HasValue)
                    employee.Salary = newSalary.Value;

                Console.WriteLine($"Employee {employee.EmployeeID} updated successfully!");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        // Delete employee in list
        public void DeleteEmployee(int employeeID)
        {
            // البحث عن الموظف في القائمة
            var employee = employees.FirstOrDefault(emp => emp.EmployeeID == employeeID);

            if (employee != null) // التأكد من أن الموظف موجود
            {
                employees.Remove(employee); // حذف الموظف من القائمة
                Console.WriteLine($"Employee {employee.NameEmployee} deleted successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        // عرض جميع الموظفين
        public void DisplayEmployees()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }

            foreach (var emp in employees)
            {
                Console.WriteLine($"ID: {emp.EmployeeID}, Name: {emp.NameEmployee}, Age: {emp.Age}, Job: {emp.JobTitle}, Salary: {emp.Salary}");
            }
        }
     

        // البحث عن موظف
        public Employee SearchEmployee(int? employeeID = null, string nameEmployee = null)
            {
            //StringComparison.OrdinalIgnoreCaseحساسية الاحرف 
            //employeeID.HasValue: تحقق إذا كانت قيمة employeeID تم تحديدها أو إذا كانت غير null.
            var result = employees.FirstOrDefault(x =>
                    (employeeID.HasValue && x.EmployeeID == employeeID) ||
                    (!string.IsNullOrEmpty(nameEmployee) && x.NameEmployee.Equals(nameEmployee, StringComparison.OrdinalIgnoreCase))
                );

                return result;
            }

          public void CalculateSalaryStats()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }

            decimal totalSalary = employees.Sum(emp => emp.Salary); // حساب إجمالي الرواتب
            decimal averageSalary = employees.Average(emp => emp.Salary); // حساب متوسط الرواتب

            Console.WriteLine($"Total Salary: {totalSalary}");
            Console.WriteLine($"Average Salary: {averageSalary}");

        }







    }


}

