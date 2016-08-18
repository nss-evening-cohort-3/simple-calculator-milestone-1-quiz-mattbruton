﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression testExp = new Expression();
            Evaluator test = new Evaluator();
            UserInterface UI = new UserInterface();

            testExp.CheckIfUserInputIsValid("5/0");
            if (testExp.IsValidInput && test.CannotEvaluate)
            {
                test.EvaluateUserInput(testExp.Value_1, testExp.Value_2, testExp.Operator);
                Console.WriteLine("You entered: {0} {1} {2} ", testExp.Value_1, testExp.Operator, testExp.Value_2);
                Console.WriteLine(test.ResultFromEval);
            }
            else
            {
                Console.WriteLine(ErrorMessages.InvalidInput());
            }

            Console.WriteLine(UI.Prompt());
            UI.PromptCounter++;
            Console.WriteLine(UI.Prompt());

            Console.ReadKey();
        }
    }
}
