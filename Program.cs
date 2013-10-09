using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringKateTAZ
{
    class Program
    {
        public class NegativeException : ApplicationException
        {
            
            public NegativeException(string arg1)
            {}
        }

        static void Main(string[] args)
        {
            // just some tests

            //string delimeter = ",";
            ////string numbers = "5\n9\n3\n13\n123\n1";
            //string numbers = "//;\n1;2";
            //if (numbers.Substring(0,2) == "//")
            //{
            //    numbers = numbers.Substring(2, numbers.Length - 2);
            //    string[] parts = numbers.Split('\n');
            //    delimeter = parts[0];
            //    numbers = numbers.Substring(2, numbers.Length - 2);
            //}

                //throw new NegativeException("negative numbers not allowed -5");

                    //System.ArgumentException("Numbers cannot be negative");//, "original");   


            //numbers = numbers.Substring(2, numbers.Length - 2);
            //Console.WriteLine(numbers);
            //var delimeter = numbers.Split('\n');
            //numbers = numbers.Substring(2, numbers.Length - 2);
            //Console.WriteLine(delimeter + "  " + numbers);
            //string s = "1,2,3,4";
            //int nSeparators = 0;
            ////char[] delimiters = new char[] { '\r', '\n' };
            //char[] delimiters = new char[] { ','};
            //string[] parts = s.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            //for (int i = 0; i < parts.Length; i++)
            //{
            //    Console.WriteLine(parts[i]);
            //}


        }

    }
}
