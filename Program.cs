using System;
using System.Collections.Generic;

namespace PayrollSystem
{
    class Program
    {
        static void Main()
        {

            /*try
            {
                Exercise app = new Exercise();

                Console.Write("Enter the number of days worked: ");
                app.NoOfDaysWorked = int.Parse(Console.ReadLine());

                var result = app.PaymentCalculation();

                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
            }*/


          



            Console.WriteLine("======First Employee======");
            Console.WriteLine("Enter your first name:");
            string firstname1 = Console.ReadLine();
            Console.WriteLine("Enter your last name:");
            string lastname1 = Console.ReadLine();
            Console.WriteLine("Enter your middle name:");
            string middlename1 = Console.ReadLine();

            Console.WriteLine("======Second Employee======");
            Console.WriteLine("Enter your first name:");
            string firstname2 = Console.ReadLine();
            Console.WriteLine("Enter your last name:");
            string lastname2 = Console.ReadLine();
            Console.WriteLine("Enter your middle name:");
            string middlename2 = Console.ReadLine();


            var newEmployee = new List<Employee>()
            {
                new Employee()
                {
                    Id = 0,
                    EmployeeCode = Helper.GenerateCode(),
                    FirstName = firstname1,
                    LastName = lastname1,
                    MiddleName = middlename1,
                    DateJoined = DateTime.Now,
                },
               
                new Employee()
                { 
                    Id = 1,
                    EmployeeCode = Helper.GenerateCode(),
                    FirstName = firstname2,
                    LastName = lastname2,
                    MiddleName = middlename2,
                    DateJoined = DateTime.Now
                }
            };

            var service = new EmployeeService();
            service.CreateEmployee(newEmployee[1]);
           var emp = service.ViewEmployee(newEmployee[1].Id);


            Console.WriteLine(emp.FirstName);
/*
 *      
            foreach (var emp in newEmployee)
            {
                Console.WriteLine($"Name:{emp.FirstName} {emp.LastName} {emp.MiddleName}\a\nDate joined:{emp.DateJoined}\nEmployee code{emp.EmployeeCode}\nEmployee id:{emp.Id}");
            }*/

            

















        }
    }

}
