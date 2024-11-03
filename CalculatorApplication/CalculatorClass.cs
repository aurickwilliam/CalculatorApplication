using System;

namespace CalculatorApplication
{
    public delegate T Formula<T>(T arg1, T arg2);

    public class CalculatorClass
    {
        public Formula<double> formula;

        public double GetSum(double x, double y)
        {
            Console.WriteLine($"Sum        : {x + y}");
            return x + y;
        }

        public double GetDifference(double x, double y)
        {
            Console.WriteLine($"Difference : {x - y}");
            return x - y;
        }

        public double GetProduct(double x, double y)
        {
            Console.WriteLine($"Product    : {x * y}");
            return x * y;
        }

        public double GetQuotient(double x, double y)
        {
            Console.WriteLine($"Quotient   : {x / y }");
            return x / y;
        }

        public event Formula<double> CalculateEvent
        {
            add
            {
                Console.WriteLine("Added the Delegate");
                formula += value;
            }
            remove
            {
                Console.WriteLine("Removed the Delegate");
                formula -= value;
            }
        }

        static void Main(string[] args)
        {
            CalculatorClass cal = new CalculatorClass();

            Console.WriteLine("<============= CALCULATOR APPLICATION =============>\n");

            bool isCalculating = true;

            do
            {
                double num1, num2;

                do
                {
                    Console.Write("Enter the First Number       : ");
                    num1 = Convert.ToDouble(Console.ReadLine());

                    Console.Write("\nEnter the Second Number      : ");
                    num2 = Convert.ToDouble(Console.ReadLine());

                    if (num2 == 0)
                    {
                        Console.WriteLine("\nCannot Divide by 0\n");
                        continue;
                    }

                    break;
                }
                while (true);

                Console.WriteLine("\n----------------------------------------------------\n");

                Console.WriteLine("RESULT:\n");

                cal.formula = new Formula<double>(cal.GetSum);
                cal.formula += new Formula<double>(cal.GetDifference);
                cal.formula += new Formula<double>(cal.GetProduct);
                cal.formula += new Formula<double>(cal.GetQuotient);

                cal.formula.Invoke(num1, num2);

                do
                {
                    Console.Write("\nDo you want to Calculate Again(Y/N)? ");
                    string again = Console.ReadLine().ToUpper();

                    if(again != "Y" && again != "N")
                    {
                        Console.WriteLine("\nInvalid Input!\n");
                        continue;
                    }
                    else if(again == "N")
                    {
                        Console.WriteLine("\nExited!\n");
                        isCalculating = false;
                        break;
                    }

                    Console.WriteLine();
                    break;
                }
                while (true);
            }
            while (isCalculating);

            Console.WriteLine("<==================================================>");
        }
    }
}
