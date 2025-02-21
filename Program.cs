using System;

namespace EmployeeMangement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeManager manager = new EmployeeManager();

            // إضافة موظفين إلى القائمة
            manager.AddEmployee(1,new Employee(2, "Sara", 28, "Project Manager", 9000));
            manager.AddEmployee(2,new Employee(3, "Omar", 40, "HR Manager", 6000));
            manager.AddEmployee(3,new Employee(4, "Lina", 35, "Data Scientist", 8000));

            // عرض قائمة الموظفين
            manager.DisplayEmployees();

            // البحث عن موظف بواسطة الرقم
            Employee foundByID = manager.SearchEmployee(employeeID: 1);
            if (foundByID != null)
                Console.WriteLine($"Found Employee: {foundByID.NameEmployee}, Job: {foundByID.JobTitle}");
            else
                Console.WriteLine("Employee not found by ID.");

            // البحث عن موظف بواسطة الاسم
            Employee foundByName = manager.SearchEmployee(nameEmployee: "Sara");
            if (foundByName != null)
                Console.WriteLine($"Found Employee: {foundByName.NameEmployee}, Job: {foundByName.JobTitle}");
            else
                Console.WriteLine("Employee not found by name.");

            // تحديث بيانات موظف
            manager.UpdateEmployee(1, "John Doe", 32, "Senior Developer", 10000);

            // حذف موظف
            manager.DeleteEmployee(1);

            // حساب إحصائيات الرواتب
            manager.CalculateSalaryStats();
        }
    }
}
