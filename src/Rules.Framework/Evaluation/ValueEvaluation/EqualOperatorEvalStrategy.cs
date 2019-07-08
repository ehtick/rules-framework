﻿using System;

namespace Rules.Framework.Evaluation.ValueEvaluation
{
    internal class EqualOperatorEvalStrategy : IOperatorEvalStrategy
    {
        public bool Eval<T>(T leftOperand, T rightOperand) where T : IComparable<T>
        {
            return leftOperand.CompareTo(rightOperand) == 0;
        }
    }
}