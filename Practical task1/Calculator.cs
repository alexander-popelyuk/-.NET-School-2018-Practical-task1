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
    //
    // Summary:
    //  Encapsulates calculator object.
    class Calculator
    {
        //
        // Summary:
        //  Performs single calculation cycle.
        public void Run()
        {
            decimal x, y;
            string operation;

            PromptInput(out x, out y, out operation);
            PrintResult(CalcResult(x, y, operation));
        }
        //
        // Summary:
        //   Prompts user parameters required for calculations until got correct input.
        //
        // Parameters:
        //   x:
        //     The X operand.
        //
        //   y:
        //     The Y operand.
        //
        //   operation:
        //     The operation to be performed.
        private void PromptInput(out decimal x, out decimal y, out string operation)
        {
            while (!PromptOperand("X", out x)) OnWrongOperand();
            while (!PromptOperand("Y", out y)) OnWrongOperand();
            while (!PromptOperation(out operation)) OnWrongOperation();
        }
        //
        // Summary:
        //   Prompts user for number operand.
        //
        // Parameters:
        //   name:
        //     The operand name.
        //
        //   value:
        //     The operand value.
        //
        // Returns:
        //   true if operation is successful; false otherwise.
        private bool PromptOperand(string name, out decimal value)
        {
            Console.Write("Please, enter operand {0}: ", name);
            string input = Console.ReadLine();
            return decimal.TryParse(input, out value);
        }
        //
        // Summary:
        //   Prompts user for operation.
        //
        // Parameters:
        //   operation:
        //     The operation string.
        //
        // Returns:
        //   true if operation is successful; false otherwise.
        private bool PromptOperation(out string operation)
        {
            const string OPERATION_LIST = "+-*/";
            Console.Write("Please, enter operation [{0}]: ", OPERATION_LIST);
            string input = Console.ReadLine();
            operation = input.Trim();
            return !string.IsNullOrEmpty(operation) && OPERATION_LIST.Contains(operation);
        }
        //
        // Summary:
        //   Performs 'wrong operand' error handling.
        private void OnWrongOperand()
        {
            PrintError("Wrong operand entered.");
            PrintHelp("Enter number and press 'Enter'.");
        }
        //
        // Summary:
        //   Performs 'wrong operation' error handling.
        private void OnWrongOperation()
        {
            PrintError("Wrong operation entered.");
            PrintHelp("Enter single operation character and press 'Enter'.");
        }
        //
        // Summary:
        //   Calculates operation result.
        //
        // Parameters:
        //   x:
        //     The X operand.
        //
        //   y:
        //     The Y operand.
        //
        //   operation:
        //     The operation to be performed.
        //
        // Returns:
        //   Result of calculations.
        private decimal CalcResult(decimal x, decimal y, string operation)
        {
            switch (operation)
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
        //
        // Summary:
        //   Performs addition of its parameters.
        //
        // Parameters:
        //   x:
        //     The X operand.
        //
        //   y:
        //     The Y operand.
        //
        // Returns:
        //   Result of calculations.
        private decimal Add(decimal x, decimal y)
        {
            return x + y;
        }
        //
        // Summary:
        //   Subtracts Y from X.
        //
        // Parameters:
        //   x:
        //     The X operand.
        //
        //   y:
        //     The Y operand.
        //
        // Returns:
        //   Result of calculations.
        private decimal Subtract(decimal x, decimal y)
        {
            return x - y;
        }
        //
        // Summary:
        //   Multiplies X and Y.
        //
        // Parameters:
        //   x:
        //     The X operand.
        //
        //   y:
        //     The Y operand.
        //
        // Returns:
        //   Result of calculations.
        private decimal Multiply(decimal x, decimal y)
        {
            return x * y;
        }
        //
        // Summary:
        //   Divides X by Y.
        //
        // Parameters:
        //   x:
        //     The X operand.
        //
        //   y:
        //     The Y operand.
        //
        // Returns:
        //   Result of calculations.
        private decimal Divide(decimal x, decimal y)
        {
            return x / y;
        }
        //
        // Summary:
        //   Prints error message.
        //
        // Parameters:
        //   text:
        //     The message text.
        private void PrintError(string text)
        {
            Console.WriteLine("ERROR: {0}", text);
        }
        //
        // Summary:
        //   Prints help message.
        //
        // Parameters:
        //   text:
        //     The message text.
        private void PrintHelp(string text)
        {
            Console.WriteLine("HELP: {0}", text);
        }
        //
        // Summary:
        //   Prints calculations result.
        //
        // Parameters:
        //   result:
        //     The result to print.
        private void PrintResult(decimal result)
        {
            Console.WriteLine("Operation result: {0}", result);
        }
    }
}
