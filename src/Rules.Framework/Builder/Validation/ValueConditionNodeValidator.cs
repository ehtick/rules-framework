namespace Rules.Framework.Builder.Validation
{
    using System;
    using FluentValidation;
    using Rules.Framework.Core;
    using Rules.Framework.Core.ConditionNodes;

    internal class ValueConditionNodeValidator<T, TConditionType> : AbstractValidator<ValueConditionNodeTemplate<T, TConditionType>>
        where T : IComparable
    {
        public ValueConditionNodeValidator()
        {
            this.RuleFor(c => c.ConditionType).NotEmpty();
            this.RuleFor(c => c.ConditionType).IsInEnum().When(c => c.ConditionType is { } && c.ConditionType.GetType().IsEnum);
            this.RuleFor(c => c.DataType).IsInEnum();
            this.RuleFor(c => c.DataType).Equal(DataTypes.Integer).When(c => c.Operand is int);
            this.RuleFor(c => c.DataType).Equal(DataTypes.String).When(c => c.Operand is string);
            this.RuleFor(c => c.DataType).Equal(DataTypes.Decimal).When(c => c.Operand is decimal);
            this.RuleFor(c => c.DataType).Equal(DataTypes.Boolean).When(c => c.Operand is bool);
            this.RuleFor(c => c.Operator).IsInEnum();

            this.RuleFor(c => c.Operator)
                .IsContainedOn(Operators.Equal, Operators.NotEqual, Operators.Contains)
                .When(c => c.DataType == DataTypes.String)
                .WithMessage(cn => $"Condition nodes with data type '{cn.DataType}' can't define a operator of type '{cn.Operator}'.");

            this.RuleFor(c => c.Operator)
                .IsContainedOn(Operators.Equal, Operators.NotEqual)
                .When(c => c.DataType == DataTypes.Boolean)
                .WithMessage(cn => $"Condition nodes with data type '{cn.DataType}' can't define a operator of type '{cn.Operator}'.");

            this.RuleFor(c => c.Operator)
                .IsContainedOn(Operators.Equal, Operators.NotEqual, Operators.GreaterThan, Operators.GreaterThanOrEqual, Operators.LesserThan, Operators.LesserThanOrEqual)
                .When(c => c.DataType == DataTypes.Integer)
                .WithMessage(cn => $"Condition nodes with data type '{cn.DataType}' can't define a operator of type '{cn.Operator}'.");

            this.RuleFor(c => c.Operator)
                .IsContainedOn(Operators.Equal, Operators.NotEqual, Operators.GreaterThan, Operators.GreaterThanOrEqual, Operators.LesserThan, Operators.LesserThanOrEqual)
                .When(c => c.DataType == DataTypes.Decimal)
                .WithMessage(cn => $"Condition nodes with data type '{cn.DataType}' can't define a operator of type '{cn.Operator}'.");
        }
    }
}