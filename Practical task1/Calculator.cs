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
            string op, error;

            PromptInput(out x, out y, out op);
            if (CheckInput(x, y, op, out error)) PrintResult(CalcResult(x, y, op));
            else PrintError(error);
        }

        private void PromptInput(out decimal x, out decimal y, out string op)
        {
            while (!PromptOperand("X", out x)) OnWrongOperand();
            while (!PromptOperand("Y", out y)) OnWrongOperand();
            while (!PromptOperation(out op)) OnWrongOperation();
        }

        private bool PromptOperand(string name, out decimal value)
        {
            Console.Write("Please, enter operand number {0}: ", name);
            string input = Console.ReadLine();
            return decimal.TryParse(input, out value);
        }

        private bool PromptOperation(out string operation)
        {
            const string OPERATION_LIST = "+-*/";
            Console.Write("Please, enter desired operation [{0}]: ", OPERATION_LIST);
            string input = Console.ReadLine();
            operation = input.Trim();
            return !string.IsNullOrEmpty(operation) && OPERATION_LIST.Contains(operation);
        }

        private void OnWrongOperand()
        {
            PrintError("wrong operand entered");
            PrintHelp("Enter number and press 'Enter'");
        }

        private void OnWrongOperation()
        {
            PrintError("wrong operation entered");
            PrintHelp("Enter single operation character and press 'Enter'");
        }

        private bool CheckInput(decimal x, decimal y, string op, out string error)
        {
            if (op == "/")
            {
                if (y == 0)
                {
                    error = "division by zero";
                    return false;
                }
            }
            error = null;
            return true;
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
            Console.WriteLine("ERROR: {0}!", text);
        }

        private void PrintHelp(string text)
        {
            Console.WriteLine("HELP: {0}.", text);
            Console.WriteLine("HELP: Press 'Ctrl+C' to exit.");
        }

        private void PrintResult(decimal result)
        {
            Console.WriteLine("Operation result: {0}!", result);
        }
    }
}
