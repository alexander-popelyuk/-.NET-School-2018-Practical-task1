using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_task1
{
    class Calculator
    {
        // generic constants
        const string OPERATION_LIST = "+-*/";

        // errors list
        const string OPERAND_ERROR_TEXT = "wrong operand entered";
        const string OPERATION_ERROR_TEXT = "wrong operation entered";
        const string DIV_ZERO_ERROR_TEXT = "division by zero";

        // help texts
        const string OPERAND_HELP_TEXT = "Enter integer value and press 'Enter'";
        const string OPERATION_HELP_TEXT = "Enter single operation character and press 'Enter'";
        const string GENERAL_HELP_TEXT = "Press 'Ctrl+C' to exit";

        public void Run()
        {
            int x, y;
            string op, error;

            PromptInput(out x, out y, out op);
            if (CheckInput(x, y, op, out error)) PrintResult(CalcResult(x, y, op));
            else PrintError(error);
        }

        private void PromptInput(out int x, out int y, out string op)
        {
            while (!PromptOperand("X", out x)) OnWrongOperand();
            while (!PromptOperand("Y", out y)) OnWrongOperand();
            while (!PromptOperation(out op)) OnWrongOperation();
        }

        private bool PromptOperand(string name, out int value)
        {
            Console.Write("Please, enter integer operand {0}: ", name);
            string input = Console.ReadLine();
            return int.TryParse(input, out value);
        }

        private bool PromptOperation(out string operation)
        {
            Console.Write("Please, enter desired operation [{0}]: ", OPERATION_LIST);
            string input = Console.ReadLine();
            operation = input.Trim();
            return !string.IsNullOrEmpty(operation) && OPERATION_LIST.Contains(operation);
        }

        private void OnWrongOperand()
        {
            PrintError(OPERAND_ERROR_TEXT);
            PrintHelp(OPERAND_HELP_TEXT);
            PrintHelp(GENERAL_HELP_TEXT);
        }

        private void OnWrongOperation()
        {
            PrintError(OPERATION_ERROR_TEXT);
            PrintHelp(OPERATION_HELP_TEXT);
            PrintHelp(GENERAL_HELP_TEXT);
        }

        private bool CheckInput(int x, int y, string op, out string error)
        {
            if (op == "/")
            {
                if (y == 0)
                {
                    error = DIV_ZERO_ERROR_TEXT;
                    return false;
                }
            }
            error = null;
            return true;
        }

        private int CalcResult(int x, int y, string op)
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

        private int Add(int x, int y)
        {
            return x + y;
        }

        private int Subtract(int x, int y)
        {
            return x - y;
        }

        private int Multiply(int x, int y)
        {
            return x * y;
        }

        private int Divide(int x, int y)
        {
            return x / y;
        }

        private void PrintError(string text)
        {
            Console.WriteLine("ERROR: {0}!", text);
        }

        private void PrintHelp(string text)
        {
            Console.WriteLine("HELP: {0}!", text);
        }

        private void PrintResult(int result)
        {
            Console.WriteLine("Operation result: {0}!", result);
        }
    }
}
