// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Represents a Bicep binary expression composed of a left operand, an operator, and a right operand.
/// </summary>
/// <param name="left">The left operand.</param>
/// <param name="op">The binary operator.</param>
/// <param name="right">The right operand.</param>
public class BinaryExpression(BicepExpression left, BinaryBicepOperator op, BicepExpression right) : BicepExpression
{
    /// <summary>
    /// Gets the left operand expression.
    /// </summary>
    public BicepExpression Left { get; } = left;
    /// <summary>
    /// Gets the binary operator.
    /// </summary>
    public BinaryBicepOperator Operator { get; } = op;
    /// <summary>
    /// Gets the right operand expression.
    /// </summary>
    public BicepExpression Right { get; } = right;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append('(').Append(Left).Append(' ')
            .Append(
               Operator switch
               {
                   BinaryBicepOperator.And => "&&",
                   BinaryBicepOperator.Or => "||",
                   BinaryBicepOperator.Coalesce => "??",
                   BinaryBicepOperator.Equal => "==",
                   BinaryBicepOperator.EqualIgnoreCase => "=~",
                   BinaryBicepOperator.NotEqual => "!=",
                   BinaryBicepOperator.NotEqualIgnoreCase => "!~",
                   BinaryBicepOperator.Greater => ">",
                   BinaryBicepOperator.GreaterOrEqual => ">=",
                   BinaryBicepOperator.Less => "<",
                   BinaryBicepOperator.LessOrEqual => "<=",
                   BinaryBicepOperator.Add => "+",
                   BinaryBicepOperator.Subtract => "-",
                   BinaryBicepOperator.Multiply => "*",
                   BinaryBicepOperator.Divide => "/",
                   BinaryBicepOperator.Modulo => "%",
                   _ => throw new NotImplementedException($"Unknown {nameof(BinaryBicepOperator)} value {Operator}"),
               })
            .Append(' ').Append(Right).Append(')');
}
