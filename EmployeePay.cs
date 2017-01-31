/* EmployeePay class
 * This class defines a template for an employee object to include instance data members,
 * public properties, and constructors.  It includes methods to calculate federal tax, 
 * retirement, social tax, and take-home pay.  It also include method to return full name of employee type, as well as
 * override ToString() method to display information.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayCalculateApp
{
    class EmployeePay
    {
        // Declare instance data members and constants
        private const decimal FEDERAL_TAX = 0.18M;
        private const decimal RETIRE = 0.10M;
        private const decimal SOCIAL_TAX = 0.06M;
        private string employeeID;
        private string employeeFirstName;
        private string employeeLastName;
        private char employeeType;
        private decimal employeeGrossPay;
        private decimal takeHomePay;
        private decimal payFederalTax;
        private decimal payRetirement;
        private decimal paySocialTax;
       
        // Create constructors
        // Default constructor
        public EmployeePay()
        {

        }

        // Constructor with one argument
        public EmployeePay(string emID)
        {
            employeeID = emID;
        }

        // Constructor with two arguments
        public EmployeePay(string emID, string firstName)
        {
            employeeID = emID;
            employeeFirstName = firstName;
        }

        // Constructor with three arguments
        public EmployeePay(string emID, string firstName, string lastName)
        {
            employeeID = emID;
            employeeFirstName = firstName;
            employeeLastName = lastName;
        }

        // Constructor with four arguments
        public EmployeePay(string emID, string firstName, string lastName, char type)
        {
            employeeID = emID;
            employeeFirstName = firstName;
            employeeLastName = lastName;
            employeeType = type;
        }

        // Constructor with five arguments
        public EmployeePay(string emID, string firstName, string lastName, char type, decimal grossPay)
        {
            employeeID = emID;
            employeeFirstName = firstName;
            employeeLastName = lastName;
            employeeType = type;
            employeeGrossPay = grossPay;
        }

        // Create properties
        public string EmployeeID
        {
            get
            {
                return employeeID;
            }
            set
            {
                employeeID = value;
            }
        }

        public string EmployeeFirstName
        {
            get
            {
                return employeeFirstName;
            }
            set
            {
                employeeFirstName = value;
            }
        }

        public string EmployeeLastName
        {
            get
            {
                return employeeLastName;
            }
            set
            {
                employeeLastName = value;
            }
        }

        public char EmployeeType
        {
            get
            {
                return employeeType;
            }
            set
            {
                employeeType = value;
            }
        }

        public decimal EmployeeGrossPay
        {
            get
            {
                return employeeGrossPay;
            }
            set
            {
                employeeGrossPay = value;
            }
        }

        // Create CalculateFederalTax() method
        public decimal CalculateFederalTax()
        {
            // Calculate federal tax
            payFederalTax = employeeGrossPay * FEDERAL_TAX;
            return payFederalTax;
        }

        // Create CalculateRetirement() method
        public decimal CalculateRetirement()
        {
            // Calculate retirement contribution
            payRetirement = employeeGrossPay * RETIRE;
            return payRetirement;
        }

        // Create CalculateSocialTax() method
        public decimal CalculateSocialTax()
        {
            // Calculate social tax
            paySocialTax = employeeGrossPay * SOCIAL_TAX;
            return paySocialTax;
        }

        // Create CalculateTakeHomePay() method to calculate take-home pay
        public decimal CalculateTakeHomePay()
        {
            // Calculate take-home pay
            takeHomePay = employeeGrossPay - (payFederalTax + payRetirement + paySocialTax);
            return takeHomePay;
        }

        // Create ReturnNameOfEmployeeType() method to return full name of employee type
        public string ReturnNameOfEmployeeType()
        {
            // Declare variable
            string employeeTypeName;

            // Use if-else statement to assign full name for the type of employee
            if (employeeType == 'S')
            {
                employeeTypeName = "Salaried";
                return employeeTypeName;
            }
            else
            {
                employeeTypeName = "Hourly";
                return employeeTypeName;
            }
        }

        // Override ToString() method
        public override string ToString()
        {
            return "\n\nEmployee ID: " + employeeID +
                   "\nEmployee Name: " + employeeFirstName + " " + employeeLastName +
                   "\nEmployee Type: " + ReturnNameOfEmployeeType() +
                   "\nEmployee gross pay: " + employeeGrossPay.ToString("C") +
                   "\nFederal Tax: " + CalculateFederalTax().ToString("C") +
                   "\nRetirement Contribution: " + CalculateRetirement().ToString("C") +
                   "\nSocial Tax: " + CalculateSocialTax().ToString("C") +
                   "\n\nEmployee take-home pay: " + CalculateTakeHomePay().ToString("C");
        }
    }
}
