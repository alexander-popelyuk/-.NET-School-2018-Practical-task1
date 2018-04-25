using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_task1
{
    class Program
    {
        static void Main(string[] args)
        {
            // need to print help very extensively for program to be sane
            // test int.TryParse digit limits
            // add license in all files
            // test everything on VM

            try
            {
                Calculator calculator = new Calculator();
                calculator.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: Something goes wrong!");
            }
            Console.Write("Print any key to exit...");
            Console.ReadKey(true);
        }


        
    }
}
