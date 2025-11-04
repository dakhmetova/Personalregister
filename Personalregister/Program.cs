namespace Personalregister
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }

        public Employee(int id, string name, string position, int salary)
        {
            // need to add ArgumentExceptions for invalid input values

            Id = id;
            Name = name;
            Position = position;
            Salary = salary;
        }
    }


    public class EmployeeRegister
    {
        private List<Employee> Employees = new List<Employee>();
        private int nextId = 1;


        public void AddEmployee(string name, string position, int salary)
        {
            var employee = new Employee(nextId++, name, position, salary);
            Employees.Add(employee);
        }


        //public void RemoveEmployee(int id){}

        //public Employee GetEmployee(int id){}


        public List<Employee> GetAllEmployees()
        {
            return Employees;
        }


        public void PrintEmployees()
        {
            if (Employees.Count == 0)
            {
                Console.WriteLine("No employees in the register.\n");
                return;
            }

            Console.WriteLine("\n\n--------------------- EMPLOYEE REGISTER ---------------------");
            Console.WriteLine($"{"ID",-5} | {"Name",-20} | {"Position",-20} | {"Salary",10}");
            Console.WriteLine(new string('-', 70));

            foreach (var emp in Employees)
                Console.WriteLine($"{emp.Id,-5} | {emp.Name,-20} | {emp.Position,-20} | {emp.Salary,10:F0}");

            Console.WriteLine(new string('-', 70));
            Console.WriteLine($"Average salary: {GetAverageSalary():F0}");
            Console.WriteLine();
        }


        public double GetAverageSalary()
        {
            return Employees.Count == 0 ? 0 : Employees.Average(e => e.Salary);
        }
    }


    public class Program
    {
        static void Main(string[] args)
        {
            var register = new EmployeeRegister();

            while (true)
            {
                Console.WriteLine("\n\n------- MENU -------");
                Console.WriteLine("1. Add new employee");
                Console.WriteLine("2. Show all employees");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option (1-3): ");

                string choice = Console.ReadLine()?.Trim() ?? "";

                switch (choice)
                {
                    case "1":
                        AddingEmployee(register);
                        break;
                    case "2":
                        register.PrintEmployees();
                        break;
                    case "3":
                        Console.WriteLine("Exiting program. Bye ^^\n");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.\n");
                        break;
                }
            }

        }


        private static void AddingEmployee(EmployeeRegister register)
        {
            // need to add ArgumentExceptions for invalid input values

            Console.Write("Enter employee name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Enter employee position: ");
            string position = Console.ReadLine() ?? "";

            int salary;
            Console.Write("Enter employee salary: ");
            string salaryInput = Console.ReadLine() ?? "";
            int.TryParse(salaryInput, out salary);

            register.AddEmployee(name, position, salary);
            Console.WriteLine("Employee added successfully.\n");
        }


    }
}
