using BlazorCalculator.Client.Types;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace BlazorCalculator.Client.CodeBehind
{
    public class CalculatorPage : ComponentBase
    {
        private const string Zero = "0";
        protected AppState State { get; } = new AppState();

        protected override void OnInit()
        {
            State.Current = Zero;
            State.Stack = new Stack<Data>();
            base.OnInit();
        }

        protected void OnNewDigit(DigitClickEventArgs args)
        {
            State.Current = State.Current == Zero ? args.Value.ToString() : State.Current + args.Value;
        }

        protected void OnConstant(ConstantClickEventArgs args)
        {
            State.Current = args.Value.ToString();
        }

        protected void OnClear(ClearClickedEventArgs args)
        {
            State.Current = Zero;
            State.Stack.Clear();
        }

        protected void OnOperation(OperationClickedEventArgs args)
        {
            switch (args.Operation)
            {
                case Operation.Inverse:
                    State.Current = State.Current[0] == '-' ? State.Current.TrimStart('-') : "-" + State.Current;
                    break;
                case Operation.Add:
                case Operation.Substract:
                case Operation.Multiply:
                case Operation.Divide:
                case Operation.Mod:
                    State.Stack.Push(new ValueData(double.Parse(State.Current)));
                    State.Stack.Push(new OperationData(args.Operation));
                    State.Current = Zero;
                    break;
                case Operation.Fraction:
                    if (State.Current[State.Current.Length - 1] != '.')
                    {
                        State.Current += ".";
                    }
                    break;
                case Operation.Back:
                    if (State.Current.Length == 1)
                    {
                        State.Current = Zero;
                    }
                    else
                    {
                        State.Current = State.Current.Substring(0, State.Current.Length - 1);
                    }
                    break;
                case Operation.Sqrt:
                    State.Current = Math.Sqrt(double.Parse(State.Current)).ToString();
                    break;
                case Operation.Sqr:
                    State.Current = Math.Pow(double.Parse(State.Current), 2).ToString();
                    break;
                case Operation.Factorial:
                    var n = double.Parse(State.Current);
                    State.Current = Factorial((int)n).ToString();
                    break;
                case Operation.Execute:
                    var op = State.Stack.Pop() as OperationData;
                    var leftOperand = State.Stack.Pop() as ValueData;
                    var rightOperand = double.Parse(State.Current);
                    ExecuteOperation(leftOperand.Value, op.Operation, rightOperand);
                    break;
                default:
                    break;
            }
        }

        private void ExecuteOperation(double left, Operation op, double right)
        {
            double result = 0;
            switch (op)
            {
                case Operation.Add:
                    result = left + right;
                    break;
                case Operation.Substract:
                    result = left - right;
                    break;
                case Operation.Multiply:
                    result = left * right;
                    break;
                case Operation.Divide:
                    result = left / right;
                    break;
                case Operation.Mod:
                    result = left % right;
                    break;
                default:
                    break;
            }

            State.Current = result.ToString();
        }

        private int Factorial(int n)
        {
            if (n < 1)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }
    }
}
