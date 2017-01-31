/* EmployeePayCalculateApp class
 * Thiss class instantiates an employee object by using methods to get input from the user and allowing the user to enter employee ID,
 * employee first name, employee last name, employee type and employee pay amount.  For the method of getting employee pay amount, it uses
 * if-else statements in the method to determine the type of employee, and to check over time hours, then calculate gross pay based on that.
 * The program also displays the result that includes employee id, employee first and last name, employee type, employee gross pay, 
 * tax and retirement deductions as well as employee take-home pay after all deductions.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayCalculateApp
{
    public class EmployeePayCalculateApp
    {
        static void Main(string[] args)
        {
            // Declare variables 
            string employeeID;
            string employeeFirstName;
            string employeeLastName;
            char employeeType;
            decimal employeeGrossPay;

            // Call methods to get inputs from the user and assign to variables
            employeeID = InputEmployeeID();
            employeeFirstName = InputEmployeeName("First");
            employeeLastName = InputEmployeeName("Last");
            employeeType = InputEmployeeType();
            employeeGrossPay = InputAndCalculateEmployeeGrossPay(employeeType);

            // Create an employee object with five arguments
            EmployeePay employee = new EmployeePay(employeeID, employeeFirstName, employeeLastName, employeeType, employeeGrossPay);

            // Display the result using override ToString() method
            Console.Write(employee);
            Console.ReadKey();
        }

        // Create InputEmployeeID() method
        public static string InputEmployeeID()
        {
            // Declare local variable
            string inputID;
            // Prompt the user to enter employee ID
            Console.Write("Enter employee ID: ");
            inputID = Console.ReadLine();
            return inputID;
        }

        // Create InputEmployeeName() method
        public static string InputEmployeeName(string name)
        {
            // Declare local variable
            string inputName;
            // Prompt the user to enter employee first name or last name
            Console.Write("Enter employee {0} name: ", name);
            inputName = Console.ReadLine();
            return inputName;
        }

        // Create InputEmployeeType() method
        public static char InputEmployeeType()
        {
            // Declare local variables
            string inputType;
            char type;
            // Prompt the user to enter employee type
            Console.WriteLine("Enter employee type");
            Console.Write("Enter S for salaried employee, H for hourly employee: ");
            inputType = Console.ReadLine();
            type = Convert.ToChar(inputType);
            return type;
        }

        // Create InputAndCalculateEmployeeGrossPay() method to determine pay amount based on employee type, then calculate gross pay 
        public static decimal InputAndCalculateEmployeeGrossPay(char type)
        {
            // Declare local variables and constant
            const double OT_PAY_RATE = 1.5;
            string hoursWorkedInput;
            string hourlyPayInput;
            string salaryPayInput;
            double hoursWorked;
            double hourlyPay;
            decimal grossPay;
            
            // Use conditional statement to determine the type of employee
            // If employee is hourly employee
            if (type == 'H')
            {
                // Prompt user to input the number of hours clocked for the week and hourly rate 
                Console.Write("Please enter hours worked: ");
                hoursWorkedInput = Console.ReadLine();
                hoursWorked = Convert.ToDouble(hoursWorkedInput);
                Console.Write("Please enter hourly pay rate: ");
                hourlyPayInput = Console.ReadLine();
                hourlyPay = Convert.ToDouble(hourlyPayInput);

                // Overtime will be paid for hours over 40 at a rate of 1.5 of the base rate
                if (hoursWorked > 40)
                {
                    grossPay = Convert.ToDecimal((hoursWorked - 40) * hourlyPay * OT_PAY_RATE + hourlyPay * 40);
                    return grossPay;
                }
                else
                {
                    grossPay = Convert.ToDecimal(hoursWorked * hourlyPay);
                    return grossPay;
                }
            }
            // If employee is salaried employee
            else
            {
                // Prompt user to input the salary amount
                Console.Write("Please enter salary: ");
                salaryPayInput = Console.ReadLine();
                grossPay = Convert.ToDecimal(salaryPayInput);
                return grossPay;
            }
        }
    }
}
