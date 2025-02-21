using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeMangement
{
    public class EmployeeManager
    {
        // استخدام Dictionary بدلاً من List لتسريع عمليات البحث والحذف
        private Dictionary<int, Employee> employees = new Dictionary<int, Employee>();

        // إضافة موظف إلى القاموس
        public void AddEmployee(int employeeID, Employee employee)
        {
            if (employees.ContainsKey(employeeID)) // التحقق من أن الموظف بنفس ID غير موجود
            {
                Console.WriteLine($"Error: Employee with ID {employeeID} already exists.");
                return;
            }

            employees.Add(employeeID, employee); // إضافة الموظف
            Console.WriteLine($"Employee {employee.NameEmployee} added successfully!");
        }

        // تحديث بيانات الموظف
        public void UpdateEmployee(int employeeID, string newName, int? newAge, string newJobTitle, decimal? newSalary)
        {
            // البحث عن الموظف باستخدام TryGetValue (طريقة أكثر كفاءة)
            if (employees.TryGetValue(employeeID, out var employee))
            {
                // تحديث البيانات إذا كانت القيم الجديدة غير null أو فارغة
                if (!string.IsNullOrEmpty(newName)) employee.NameEmployee = newName;
                if (newAge.HasValue) employee.Age = newAge.Value;
                if (!string.IsNullOrEmpty(newJobTitle)) employee.JobTitle = newJobTitle;
                if (newSalary.HasValue) employee.Salary = newSalary.Value;

                Console.WriteLine($"Employee {employee.EmployeeID} updated successfully!");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        // حذف موظف من القاموس
        public void DeleteEmployee(int employeeID)
        {
            // استخدام Remove مباشرة دون الحاجة إلى البحث أولًا
            if (employees.Remove(employeeID))
            {
                Console.WriteLine($"Employee with ID {employeeID} deleted successfully.");
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

            foreach (var emp in employees.Values) // استخدام `Values` للوصول إلى جميع الموظفين
            {
                Console.WriteLine($"ID: {emp.EmployeeID}, Name: {emp.NameEmployee}, Age: {emp.Age}, Job: {emp.JobTitle}, Salary: {emp.Salary}");
            }
        }

        // البحث عن موظف بواسطة ID أو الاسم
        public Employee SearchEmployee(int? employeeID = null, string nameEmployee = null)
        {
            return employees.Values.FirstOrDefault(emp =>
                (employeeID.HasValue && emp.EmployeeID == employeeID) ||
                (!string.IsNullOrEmpty(nameEmployee) && emp.NameEmployee.Equals(nameEmployee, StringComparison.OrdinalIgnoreCase))
            );
        }

        // حساب إحصائيات الرواتب (إجمالي ومتوسط الرواتب)
        public void CalculateSalaryStats()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }

            decimal totalSalary = employees.Values.Sum(emp => emp.Salary); // حساب إجمالي الرواتب
            decimal averageSalary = employees.Values.Average(emp => emp.Salary); // حساب متوسط الرواتب

            Console.WriteLine($"Total Salary: {totalSalary}");
            Console.WriteLine($"Average Salary: {averageSalary}");
        }
    }


   
}
