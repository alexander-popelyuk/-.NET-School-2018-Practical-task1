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
    class Calculator
    {
        public void Run()
        {
            decimal x, y;
            string op;

            PromptInput(out x, out y, out op);
            PrintResult(CalcResult(x, y, op));
        }

        private void PromptInput(out decimal x, out decimal y, out string op)
        {
            while (!PromptOperand("X", out x)) OnWrongOperand();
            while (!PromptOperand("Y", out y)) OnWrongOperand();
            while (!PromptOperation(out op)) OnWrongOperation();
        }

        private bool PromptOperand(string name, out decimal value)
        {
            Console.Write("Please, enter operand {0}: ", name);
            string input = Console.ReadLine();
            return decimal.TryParse(input, out value);
        }

        private bool PromptOperation(out string operation)
        {
            const string OPERATION_LIST = "+-*/";
            Console.Write("Please, enter operation [{0}]: ", OPERATION_LIST);
            string input = Console.ReadLine();
            operation = input.Trim();
            return !string.IsNullOrEmpty(operation) && OPERATION_LIST.Contains(operation);
        }

        private void OnWrongOperand()
        {
            PrintError("Wrong operand entered.");
            PrintHelp("Enter number and press 'Enter'.");
        }

        private void OnWrongOperation()
        {
            PrintError("Wrong operation entered.");
            PrintHelp("Enter single operation character and press 'Enter'.");
        }

        private decimal CalcResult(decimal x, decimal y, string op)
        {
            switch (op)
            {
                case "+":
                    return Add(x, y);
                case "-":
                    return Subtract(x, y);
                case "*":
                    return Multiply(x, y);
                case "/":
                    return Divide(x, y);
                default:
                    return 0;
            }
        }

        private decimal Add(decimal x, decimal y)
        {
            return x + y;
        }

        private decimal Subtract(decimal x, decimal y)
        {
            return x - y;
        }

        private decimal Multiply(decimal x, decimal y)
        {
            return x * y;
        }

        private decimal Divide(decimal x, decimal y)
        {
            return x / y;
        }

        private void PrintError(string text)
        {
            Console.WriteLine("ERROR: {0}", text);
        }

        private void PrintHelp(string text)
        {
            Console.WriteLine("HELP: {0}", text);
        }

        private void PrintResult(decimal result)
        {
            Console.WriteLine("Operation result: {0}", result);
        }
    }
}
