namespace PayrollSystem
{
    public class EmployeeService : IEmployee
    {
        
        public List<Employee> employees = new List<Employee>();
        public void CreateEmployee(Employee employee)
        {
            employee.EmployeeCode = Helper.GenerateCode();
            employee.DateJoined = DateTime.Now;
            
            var findEmployee = FindByIdOrCode(employee.Id, employee.EmployeeCode);

            if(findEmployee == null)
            {
                employees.Add(employee);

                Console.WriteLine("Employee account created successfully!");
            }
            else
            {
                Console.WriteLine("Employee account already exist!");
            }

            
        }

        public void DeleteEmployee(int id)
        {
            var employee = employees.Find(i => i.Id == id);

            if(employee == null)
            {
                employees.Remove(employee);
                Console.WriteLine($"Successfully removed employee with Id: {id} and Name:{employee.LastName}{employee.FirstName}{employee.FirstName}");
            }
            else
            {
                Console.WriteLine("NOT FOUND!");
            }

        }

        public Employee FindByIdOrCode(int id, string code)
        {
            return employees.Find(i => i.Id == id || i.EmployeeCode == code);
        }

        public List<Employee> ListAllEmployees()
        {
            return employees;
        }

        public Employee UpdateEmployee(int id, Employee model)
        {
            var employee = employees.Find(i => i.Id == id);

            if (employee == null)
            {
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.MiddleName = model.MiddleName;



                Console.WriteLine("Employee successfully  updated!"); 
            }
            else
            {
                Console.WriteLine("NOT FOUND!");
            }

            return employee;

        }

        public Employee ViewEmployee(int id)
        {
            var employee = employees.Find(i => i.Id == id);

            return employee;
        }
    }
}
