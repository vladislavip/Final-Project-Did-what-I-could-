using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject
{
    [Serializable]
    internal class InputTester
    {
        internal static int ReadInteger(string caption)
        {
        l1:
            Console.Write(caption);

            if (int.TryParse(Console.ReadLine(), out int value))
            {
                return value;
            }

            goto l1;
        }

        internal  static double ReadDouble(string caption)
        {
        l1:
            Console.Write(caption);

            if (double.TryParse(Console.ReadLine(), out double value))
            {
                return value;
            }

            goto l1;
        }


        internal static int CheckNum()
        {
        Step1:
            int number;
            bool result = int.TryParse(Console.ReadLine(), out number);

            if (result == true) { return number; }

            else
            {
                Console.WriteLine("Only numbers may be input");
                goto Step1;
            }


        }
        internal static string ReadString(string caption)
        {
        l1:
            Console.Write(caption);
            string value = Console.ReadLine();
            if (string.IsNullOrEmpty(value))
                goto l1;

            return value;
        }
        internal static int YearCheck(string caption)

        {
            l1:
            Console.Write(caption);


           if (int.TryParse(Console.ReadLine(), out int value) )

            {

                if (value >1900 && value < DateTime.Now.Year)
                {
                    return value;

                }
                else
                {
                    Console.WriteLine("Wrong Year Input");
                    goto l1;    
                }
               

            }
           else
            {
                Console.WriteLine("Wrong Year Input");
                goto l1;
            }




           
        }

    }
}
