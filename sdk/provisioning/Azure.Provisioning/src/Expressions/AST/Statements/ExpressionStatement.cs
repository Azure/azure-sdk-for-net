// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Represents a Bicep statement that wraps a single expression.
/// </summary>
/// <param name="expression">The expression.</param>
public partial class ExpressionStatement(BicepExpression expression) : BicepStatement
{
    /// <summary>
    /// Gets the expression.
    /// </summary>
    public BicepExpression Expression { get; } = expression;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(Expression);
}
