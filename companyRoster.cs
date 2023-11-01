namespace softUniClassesBonus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Employee> employees = new List<Employee>();
            
            for(int i = 1; i <= n; i++)
            {
                string[] details = Console.ReadLine().Split(' ').ToArray();
                string name = details[0];
                double salary = double.Parse(details[1]);
                string department = details[2];

                Employee employee = new Employee(name, salary, department);
                employees.Add(employee);
            }

            double maxSalary = 0.0;
            foreach(Employee employee in employees)
            {
                if(employee.Department == employee.GetMaxAvgSalaryDepartment(employees))
                {
                    Console.WriteLine($"Highest Average Salary: {employee.Department}");
                    break;
                }
            }
            employees = employees.OrderByDescending(emp => emp.Salary).ToList();
            foreach(Employee emp in employees)
            {
                if(emp.Department == emp.GetMaxAvgSalaryDepartment(employees))
                {
                    Console.WriteLine($"{emp.Name} {emp.Salary:f2}");
                }
            }
        }
    }

    class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }

        public Employee(string name, double salary, string department)
        {
            Name = name;
            Salary = salary;
            Department = department;
        }

        public string GetMaxAvgSalaryDepartment(List<Employee> employees)
        {
            List<string> departments = new List<string>();

            int maxSalIndex = 0;
            double maxAvgSalary = 0.0;
            foreach(Employee employee in employees)
            {
                if(!departments.Contains(employee.Department)) departments.Add(employee.Department);
            }
            double[] maxSalaries = new double[departments.Count];
            int[] countsOfSalaries = new int[departments.Count];
            foreach(Employee employee in employees)
            {
                int index = departments.IndexOf(employee.Department);
                maxSalaries[index] += employee.Salary;
                countsOfSalaries[index]++;
            }
            for(int i = 0; i < maxSalaries.Length; i++)
            {
                double avgSalary = maxSalaries[i] / countsOfSalaries[i];
                if(avgSalary >= maxAvgSalary)
                {
                    maxAvgSalary = avgSalary;
                    maxSalIndex = i;
                }
            }
            return departments[maxSalIndex];
        }
    }
}