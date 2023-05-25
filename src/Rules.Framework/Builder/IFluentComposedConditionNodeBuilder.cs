namespace Rules.Framework.Builder
{
    using System;
    using Rules.Framework.Core;

    /// <summary>
    /// Fluent builder for composed condition nodes.
    /// </summary>
    /// <typeparam name="TConditionType">The type of the condition type.</typeparam>
    public interface IFluentComposedConditionNodeBuilder<TConditionType>
    {
        /// <summary>
        /// Adds a composed And condition to the fluent condition node builder.
        /// </summary>
        /// <param name="conditionFunc">The function containing the logic for the new condition.</param>
        /// <returns></returns>
        IFluentComposedConditionNodeBuilder<TConditionType> And(
            Func<IFluentComposedConditionNodeBuilder<TConditionType>, IFluentComposedConditionNodeBuilder<TConditionType>> conditionFunc);

        /// <summary>
        /// Builds the composed condition node.
        /// </summary>
        /// <returns></returns>
        IConditionNode<TConditionType> Build();

        /// <summary>
        /// Adds a composed Or condition to the fluent condition node builder.
        /// </summary>
        /// <param name="conditionFunc">The function containing the logic for the new condition.</param>
        /// <returns></returns>
        IFluentComposedConditionNodeBuilder<TConditionType> Or(
            Func<IFluentComposedConditionNodeBuilder<TConditionType>, IFluentComposedConditionNodeBuilder<TConditionType>> conditionFunc);

        /// <summary>
        /// Adds a value condition to the fluent condition node builder.
        /// </summary>
        /// <param name="conditionType">The condition type.</param>
        /// <param name="condOperator">The condition operator.</param>
        /// <param name="operand">The condition operand.</param>
        /// <returns></returns>
        IFluentComposedConditionNodeBuilder<TConditionType> Value<TDataType>(TConditionType conditionType, Operators condOperator, TDataType operand);

        /// <summary>
        /// Adds a value condition to the fluent condition node builder.
        /// </summary>
        /// <param name="valueConditionNode">The value condition node.</param>
        IFluentComposedConditionNodeBuilder<TConditionType> Value(IConditionNode<TConditionType> valueConditionNode);
    }
}