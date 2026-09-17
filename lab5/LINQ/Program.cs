using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public string Name { get; set; }
    public double Salary { get; set; }
    public string Department { get; set; }
    public bool IsResigned { get; set; }
    public int Experience { get; set; }
}

class Program
{
    static void Main()
    {
        // Create a list of employees
        List<Employee> employees = new List<Employee>
        {
            new Employee { Name = "Ram", Salary = 50000, Department = "IT", IsResigned = false, Experience = 2 },
            new Employee { Name = "Shyam", Salary = 45000, Department = "HR", IsResigned = false, Experience = 1 },
            new Employee { Name = "Hari", Salary = 60000, Department = "IT", IsResigned = true, Experience = 5 },
            new Employee { Name = "Sita", Salary = 55000, Department = "Finance", IsResigned = false, Experience = 3 },
            new Employee { Name = "Gita", Salary = 40000, Department = "HR", IsResigned = false, Experience = 0 }
        };

        // ------------------------------------------------
        // 1. FILTER ACTIVE EMPLOYEES
        // ------------------------------------------------

        // Query Syntax
        var activeQuery =
            from e in employees
            where e.IsResigned == false
            select e;

        // Method Syntax
        var activeMethod = employees
            .Where(e => e.IsResigned == false);

        Console.WriteLine("1. Active Employees - Query Syntax:");
        foreach (var e in activeQuery)
            Console.WriteLine(e.Name);

        Console.WriteLine("\nActive Employees - Method Syntax:");
        foreach (var e in activeMethod)
            Console.WriteLine(e.Name);


        // ------------------------------------------------
        // 2. SORT BY SALARY DESCENDING
        // ------------------------------------------------

        // Query Syntax
        var salaryQuery =
            from e in employees
            orderby e.Salary descending
            select e;

        // Method Syntax
        var salaryMethod = employees
            .OrderByDescending(e => e.Salary);

        Console.WriteLine("\n2. Employees Sorted by Salary - Query Syntax:");
        foreach (var e in salaryQuery)
            Console.WriteLine(e.Name + " - " + e.Salary);

        Console.WriteLine("\nEmployees Sorted by Salary - Method Syntax:");
        foreach (var e in salaryMethod)
            Console.WriteLine(e.Name + " - " + e.Salary);


        // ------------------------------------------------
        // 3. GET DISTINCT DEPARTMENTS
        // ------------------------------------------------

        // Query Syntax
        var departmentQuery =
            (from e in employees
             select e.Department).Distinct();

        // Method Syntax
        var departmentMethod = employees
            .Select(e => e.Department)
            .Distinct();

        Console.WriteLine("\n3. Distinct Departments - Query Syntax:");
        foreach (var department in departmentQuery)
            Console.WriteLine(department);

        Console.WriteLine("\nDistinct Departments - Method Syntax:");
        foreach (var department in departmentMethod)
            Console.WriteLine(department);


        // ------------------------------------------------
        // 4. CHECK IF ANY EMPLOYEE HAS ZERO EXPERIENCE
        // ------------------------------------------------

        // Query Syntax
        var zeroExperienceQuery =
            (from e in employees
             where e.Experience == 0
             select e).Any();

        // Method Syntax
        var zeroExperienceMethod =
            employees.Any(e => e.Experience == 0);

        Console.WriteLine("\n4. Any Employee with Zero Experience?");
        Console.WriteLine("Query Syntax: " + zeroExperienceQuery);
        Console.WriteLine("Method Syntax: " + zeroExperienceMethod);


        // ------------------------------------------------
        // 5. PROJECT ONLY NAME AND SALARY
        // ------------------------------------------------

        // Query Syntax
        var nameSalaryQuery =
            from e in employees
            select new
            {
                e.Name,
                e.Salary
            };

        // Method Syntax
        var nameSalaryMethod = employees
            .Select(e => new
            {
                e.Name,
                e.Salary
            });

        Console.WriteLine("\n5. Name and Salary - Query Syntax:");
        foreach (var e in nameSalaryQuery)
            Console.WriteLine(e.Name + " - " + e.Salary);

        Console.WriteLine("\nName and Salary - Method Syntax:");
        foreach (var e in nameSalaryMethod)
            Console.WriteLine(e.Name + " - " + e.Salary);
    }
}