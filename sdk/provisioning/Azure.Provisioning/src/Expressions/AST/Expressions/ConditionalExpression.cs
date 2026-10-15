// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Represents a Bicep ternary conditional expression (<c>condition ? consequent : alternate</c>).
/// </summary>
/// <param name="condition">The condition expression.</param>
/// <param name="consequent">The expression returned when the condition is true.</param>
/// <param name="alternate">The expression returned when the condition is false.</param>
public partial class ConditionalExpression(BicepExpression condition, BicepExpression consequent, BicepExpression alternate) : BicepExpression
{
    /// <summary>
    /// Gets the condition expression.
    /// </summary>
    public BicepExpression Condition { get; } = condition;
    /// <summary>
    /// Gets the expression returned when the condition is true.
    /// </summary>
    public BicepExpression Consequent { get; } = consequent;
    /// <summary>
    /// Gets the expression returned when the condition is false.
    /// </summary>
    public BicepExpression Alternate { get; } = alternate;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(Condition).Append(" ? ").Append(Consequent).Append(" : ").Append(Alternate);
}
