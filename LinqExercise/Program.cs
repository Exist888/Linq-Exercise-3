using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            Console.WriteLine($"Sum of numbers: {numbers.Sum()}");

            //TODO: Print the Average of numbers
            Console.WriteLine($"Average of numbers: {numbers.Average()}");

            //TODO: Order numbers in ascending order and print to the console             Note to self, source: https://www.geeksforgeeks.org/c-sharp-program-to-sort-a-list-of-integers-using-the-linq-orderby-method/
            var orderedNumbers = numbers.OrderBy(x => x).ToArray();
            Console.Write("Numbers in order: ");
            foreach (var number in orderedNumbers)
            {
                Console.Write($"{number}, ");
            }

            //TODO: Order numbers in descending order and print to the console
            var descendingNumbers = numbers.OrderByDescending(x => x).ToArray();
            Console.WriteLine("");
            Console.Write("Numbers in descending order: ");
            foreach (var number in descendingNumbers)
            {
                Console.Write($"{number}, ");
            }

            //TODO: Print to the console only the numbers greater than 6
            var numbersAbove6 = numbers.Where(x => x > 6).ToArray();
            Console.WriteLine("");
            Console.Write("Numbers from above that are greater than six: ");
            foreach (var number in numbersAbove6)
            {
                Console.Write($"{number}, ");
            }

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**       Note to self, source: https://stackoverflow.com/questions/319973/how-to-get-first-n-elements-of-a-list-in-c
            var firstFourOrdered = orderedNumbers.Take(4).ToArray();                                                  //using .Take Method, see source in above line
            Console.WriteLine("");
            Console.Write("First four of numbers in ascending order: ");
            foreach (var number in firstFourOrdered)
            {
                Console.Write($"{number}, ");
            }

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order                  Note to self, sources: https://learn.microsoft.com/en-us/dotnet/api/system.array.setvalue?view=net-8.0
            firstFourOrdered.SetValue(41, 3);
            //firstFourOrdered.GetValue(3);
            var firstFourDescending = firstFourOrdered.OrderByDescending(x => x).ToArray();
            Console.WriteLine("");
            Console.Write("4th number from above changed to my age, then reversed into descending order: ");
            foreach (var number in firstFourDescending)
            {
                Console.Write($"{number}, ");
            }

            
            // List of employees ****Do not remove this****
            var employees = CreateEmployees();
            

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.             Note to self, source: https://stackoverflow.com/questions/23688947/linq-order-by-alphabetical
            Console.WriteLine("\n" +
                              "\n" +
                              "List of Employees' whose first names start with C or S,\n" +
                              "in ascending alphabetical order by First Name:");
            var startsWithCOrS = employees.Where(x => x.FirstName.StartsWith('C') || x.FirstName.StartsWith('S')).ToList();
            var orderedCOrS = startsWithCOrS.OrderBy(x => x.FirstName).ToList();
            orderedCOrS.ForEach(x => Console.WriteLine($"{x.FirstName} {x.LastName}"));

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            Console.WriteLine("\n" +
                              "List of Employees who are older than 26,\n" +
                              "in ascending order by age,\n" +
                              "and then in ascending alphabetical order by First Name:");
            var employeesOver26 = employees.Where(x => x.Age > 26).ToList();
            var over26OrderedByAge = employeesOver26.OrderBy(x => x.Age).ToList();
            var over26OrderedByFirstName = employeesOver26.OrderBy(x => x.FirstName).ToList();
            over26OrderedByAge.ForEach(x => Console.WriteLine($"{x.Age} {x.FirstName} {x.LastName}"));
            over26OrderedByFirstName.ForEach(x => Console.WriteLine($"{x.FirstName} {x.LastName} {x.Age}"));

            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            Console.WriteLine("\n" +
                              "For employees who have 10 years or less of experience,\n" +
                              "and who are 35 or older,\n" +
                              "here is the sum of their years of experience combined:");
            var employeesOver35 = employees.Where(x => x.Age > 35 && x.YearsOfExperience <= 10).ToList();
            //var employeesOver35And10YrsOrLessExp = employeesOver35.Where(x => x.YearsOfExperience <= 10).ToList();
            Console.WriteLine($"{employeesOver35.Sum(x => x.YearsOfExperience)}");
            
            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            Console.WriteLine("\n" +
                              "And for the same group of employees as those above,\n" +
                              "here is the average Years of Experience per person:");
            Console.WriteLine($"{employeesOver35.Average(x => x.YearsOfExperience):F2}");

            //TODO: Add an employee to the end of the list without using employees.Add()
            Console.WriteLine("\n" +
                              "And lastly, we have some exciting news.\n" +
                              "We just got an epic new employee.\n" +
                              "His experiences are as vast as the distant lands he has traversed.\n" +
                              "See if you can spot who it is,\n" +
                              "in the updated list below:");

            employees = employees.Append(new Employee("Frodo", "Baggins", 50, 7)).ToList();
            // var frodo = new Employee("Frodo", "Baggins", 50, 7);
            // employees = employees.Append(frodo).ToList();
            
            foreach (var person in employees)
            {
                Console.WriteLine($"{person.FullName} {person.Age}");
            }

            //Note to self: original code for last step below, improved code above:
            /*Employee frodo = new Employee()
            {
                Age = 50,
                FirstName = "Frodo",
                LastName = "Baggins",
                YearsOfExperience = 7,
            };
            employees.Insert(10, frodo);                                                                            //Note to self, source: https://www.c-sharpcorner.com/UploadFile/mahesh/insert-item-into-a-C-Sharp-list/
            foreach (var employeeItem in employees)
            {
                Console.WriteLine($"{employeeItem.FullName} {employeeItem.Age}");
            }

            Console.ReadLine();*/
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
