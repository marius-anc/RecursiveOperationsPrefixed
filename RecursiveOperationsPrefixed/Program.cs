using System;

namespace RecursiveOperationsPrefixed
{
    class Program
    {
        const string Operators = "+ - * /";

        static void Main()
        {
            string[] input = Console.ReadLine().Trim().Split(' ');
            if (ArrayContainsOperations(input))
            {
                PrefixedRecursive(input);
            }
            else
            {
                PrintArray(input);
            }
        }

        private static void PrintArray(string[] input)
        {
            foreach (string element in input)
            {
                Console.Write(element + " ");
            }
        }

        private static bool ArrayContainsOperations(string[] input)
        {
            foreach (string entity in input)
            {
                if (Operators.Contains(entity))
                {
                    return true;
                }
            }

            return false;
        }

        private static void PrefixedRecursive(string[] input)
        {
            const int step = 2;
            const int groupSize = 3;
            double result;
            for (int i = 0; i < input.Length - step; i++)
            {
                double firstNumber;
                double secondNumber;
                if (Operators.Contains(input[i]) && double.TryParse(input[i + 1], out firstNumber) && double.TryParse(input[i + step], out secondNumber))
                {
                    result = input[i] switch
                    {
                        "+" => firstNumber + secondNumber,
                        "-" => firstNumber - secondNumber,
                        "*" => firstNumber * secondNumber,
                        "/" => firstNumber / secondNumber,
                        _ => 0,
                    };
                    if (input.Length != groupSize)
                    {
                        string[] newInput = new string[input.Length - step];
                        input[0..i].CopyTo(newInput, 0);
                        newInput[i] = result.ToString();
                        input[(i + groupSize) ..input.Length].CopyTo(newInput, i + 1);
                        PrefixedRecursive(newInput);
                    }
                    else
                    {
                        Console.WriteLine(result);
                    }

                    break;
                }
            }
        }
    }
}
