using System;
using Packt.CS7;
using static System.Console;

namespace _7_6
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplacementVector dv1 = new DisplacementVector (3, 5); 
            DisplacementVector dv2 = new DisplacementVector (-2, 7); 
            DisplacementVector dv3 = dv1 + dv2; 
            WriteLine($"({dv1.X}, {dv1.Y}) + ({dv2.X}, {dv2.Y}) = ({dv3.X}, {dv3.Y})");

            Employee e1 = new Employee
            {
                Name = "John Jones",
                DateOfBirth = new DateTime (1990, 7, 28)
            };

            e1.WriteToConsole ();
            e1.EmployeeCode = "JJ001"; 
            e1.HireDate = new DateTime (2014, 11, 23); 
            WriteLine ($"{e1.Name} was hired on {e1.HireDate:dd/MM/yy}"); 

            WriteLine(e1.ToString()); 

            Employee aliceInEmployee = new Employee  
            { 
                Name = "Alice", 
                EmployeeCode = "AA123" 
            }; 
            Person aliceInPerson = aliceInEmployee; 
            aliceInEmployee.WriteToConsole (); 
            aliceInPerson.WriteToConsole (); 
            WriteLine (aliceInEmployee.ToString ()); 
            WriteLine (aliceInPerson.ToString ()); 

            if (aliceInPerson is Employee)
            {
                WriteLine ($"{nameof (aliceInPerson)} IS an Employee");
                Employee e2 = (Employee) aliceInPerson;
                // do something with e2
            }

            Employee e3 = aliceInPerson as Employee; 
            if (e3 != null) 
            { 
                WriteLine ($"{nameof (aliceInPerson)} AS an Employee"); 
                // do something with e3 
            } 

            try 
            { 
                e1.TimeTravel (new DateTime (1999, 12, 31)); 
                e1.TimeTravel (new DateTime (1950, 12, 25)); 
            } 
            catch (PersonException ex) 
            { 
                WriteLine (ex.Message); 
            }

            string email1 = "pamela@test.com"; 
            string email2 = "ian&test.com"; 
        
            WriteLine ($"{email1} is a valid e-mail address: {email1.IsValidEmail()}."); 
            WriteLine ($"{email2} is a valid e-mail address: {email2.IsValidEmail()}.");  

        }
    }
}
