using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageInVoice
{
    class Program
    {
        static void Main(string[] args)
        {
            //variables
            string theName,
                   theReg;
            int theMileage,
                theLabour,
                theCost,
                quit;

            Console.OutputEncoding = Encoding.UTF8;

            //Ask user for customer info

            theName = GetCustomerInfo("the customer name: ");
            theReg = GetCustomerInfo("the registration of the customer's car: ");

            theMileage = GetCarMileage("the mileage of the car: ");
            theLabour = GetJobCosts("the number of hours worked: ");
            theCost = GetJobCosts("the cost of the parts for this job: ");
            Console.Clear();

            //Create the firsst invoice object
            ServiceInvoice s1 = new ServiceInvoice(theName, theReg, theMileage, theLabour, theCost);
            Console.WriteLine("PETE'S REPAIR SHOP");
            Console.WriteLine();
            Console.WriteLine("Customer invoice");
            Console.WriteLine();
            
            Console.WriteLine(s1.ToString());

            //Console.WriteLine();
            //Console.WriteLine("    -1 to quit");
            //quit = Convert.ToInt32(Console.ReadLine());

            //Loop to create more invoice objects
            string entry;
            int selection = 0;
            Console.WriteLine("Please press enter to continue and -1 to quit");
            entry = Console.ReadLine();
            bool validEntry = int.TryParse(entry, out selection);
            if (validEntry == false)
            {
                Console.WriteLine("Invalid Data entered ");
            }

            
            while (selection != -1)
            {
                Console.Clear();
                
                theName = GetCustomerInfo("the customer name: ");
                theReg = GetCustomerInfo("the registration of the customer's car: ");

                theMileage = GetCarMileage("the mileage of the car: ");
                theLabour = GetJobCosts("the number of hours worked: ");
                theCost = GetJobCosts("the cost of the parts for this job: ");
                Console.Clear();

                ServiceInvoice newInvoice = new ServiceInvoice(theName, theReg, theMileage, theLabour, theCost);
                Console.WriteLine("PETE'S REPAIR SHOP");
                Console.WriteLine();
                Console.WriteLine("Customer invoice");
                Console.WriteLine();
                Console.WriteLine(newInvoice.ToString());
                Console.ReadLine();
            }

            
        }

        //Get customer info
        public static string GetCustomerInfo(string input)
        {
            Console.Write("Please enter {0}", input);
            return (Console.ReadLine());
        }

        //Get mileage
        public static int GetCarMileage(string input)
        {
            string miles;
            int theMiles = 0;
            Console.Write("Please enter {0}", input);
            miles = Console.ReadLine();
            bool validEntry = int.TryParse(miles, out theMiles);
            if (validEntry == false )
            {
                Console.WriteLine("Invalid Data entered - 0 will be entered");
            }

            return theMiles;


            //miles = Console.ReadLine();
            //if (int.TryParse(Console.ReadLine(), out theMiles) == false)

            //{
            //    Console.WriteLine("Invalid Data entered");
            //}
            //return theMiles;
        }

        //Get Job costs
        public static int GetJobCosts (string input)
        {
            string userInput;
            int UserNum;
            Console.Write("Please enter {0}", input);

            userInput = Console.ReadLine();
            bool validEntry = int.TryParse(userInput, out UserNum);
            if (validEntry == false)
            {
                Console.WriteLine("Invalid Data entered - 0 will be entered");
            }
            return UserNum;

            //return theMiles;

            //userInput = Console.ReadLine();
            //if (int.TryParse(Console.ReadLine(), out UserNum) == false)

            //{
            //    Console.WriteLine("Invalid Data entered");
            //}
            //return UserNum;
        }


    }
}
