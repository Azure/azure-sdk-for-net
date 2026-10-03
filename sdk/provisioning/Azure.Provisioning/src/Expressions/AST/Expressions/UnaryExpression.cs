// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Represents a Bicep unary expression composed of an operator and a single operand.
/// </summary>
/// <param name="op">The unary operator.</param>
/// <param name="value">The operand expression.</param>
public partial class UnaryExpression(UnaryBicepOperator op, BicepExpression value) : BicepExpression
{
    /// <summary>
    /// Gets the unary operator.
    /// </summary>
    public UnaryBicepOperator Operator { get; } = op;
    /// <summary>
    /// Gets the operand expression.
    /// </summary>
    public BicepExpression Value { get; } = value;
    internal override BicepWriter Write(BicepWriter writer) => Operator switch
    {
        UnaryBicepOperator.Not => writer.Append('!').Append(Value),
        UnaryBicepOperator.Negate => writer.Append('-').Append(Value),
        UnaryBicepOperator.SuppressNull => writer.Append(Value).Append('!'),
        _ => throw new NotImplementedException($"Unknown {nameof(UnaryBicepOperator)} value {Operator}")
    };
}
