/* MIT License
 * 
 * Copyright(c) 2018 Alexander Popelyuk
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

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
            // test int.TryParse digit limits -- OK! (but result still strives from overflow! decimal ?? double ?)
            // add license in all files
            // test everything on VM

            try
            {
                Calculator calculator = new Calculator();
                calculator.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: {0}!", ex.Message);
            }
            Console.Write("Press any key to exit...");
            Console.ReadKey(true);
        }


        
    }
}
