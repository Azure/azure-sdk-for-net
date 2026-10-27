// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Represents a Bicep <c>var</c> declaration statement.
/// </summary>
/// <param name="name">The variable name.</param>
/// <param name="value">The variable value expression.</param>
public class VariableStatement(string name, BicepExpression value) : BicepStatement
{
    /// <summary>
    /// Gets the variable name.
    /// </summary>
    public string Name { get; } = name;
    /// <summary>
    /// Gets the variable value expression.
    /// </summary>
    public BicepExpression Value { get; } = value;
    /// <summary>
    /// Gets the decorators applied to this variable statement.
    /// </summary>
    public IList<DecoratorExpression> Decorators { get; } = [];
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.AppendAll(Decorators, (w, d) => w.Append(d).AppendLine())
            .Append("var ").Append(Name).Append(" = ").Append(Value).AppendLine();
}
