﻿using System;

namespace SimpleCalculator
{
    public class UserInterface
    {
        Expression exp = new Expression();
        Evaluator eval = new Evaluator();
        Stack stack = new Stack();

        public int PromptCounter = 0;

        public string Prompt()
        {
            return string.Format("[{0}]> ", PromptCounter.ToString());
        }

        private string AnswerPrefix()
        {
            return "   =";
        }

        public void HandleInput(string input)
        {
            switch (input)
            {
                case "exit":
                case "quit":
                    {
                        Console.WriteLine("Bye!");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    }
                case "last":
                    {
                        Console.WriteLine(stack.LastAnswer);
                        break;
                    }
                case "lastp":
                    {
                        Console.WriteLine(stack.LastExpression);
                        break;
                    }
                default:
                    if (!Constants.IsInputANewConst(input))
                    {
                            exp.CheckIfUserInputIsValid(input);
                            eval.EvaluateUserInput(exp.Value_1, exp.Value_2, exp.Operator);
                            if (exp.IsValidInput)
                            {
                                Console.WriteLine(string.Format("{0} {1}", AnswerPrefix(), eval.ResultFromEval));
                                stack.SetLastExpression(exp.Value_1, exp.Value_2, exp.Operator);
                                stack.SetLastAnswer(eval.ResultFromEval);
                            }
                            else
                            {
                                Console.WriteLine(ErrorMessages.InvalidFormat());
                            }
                        }
                    break;
            }
            PromptCounter++;
        }
    }
}
