// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Represents a Bicep <c>output</c> declaration statement.
/// </summary>
/// <param name="name">The output name.</param>
/// <param name="type">The output type expression.</param>
/// <param name="value">The output value expression.</param>
public partial class OutputStatement(string name, BicepExpression type, BicepExpression value) : BicepStatement
{
    /// <summary>
    /// Gets the output name.
    /// </summary>
    public string Name { get; } = name;
    /// <summary>
    /// Gets the output type expression.
    /// </summary>
    public BicepExpression Type { get; } = type;
    /// <summary>
    /// Gets the output value expression.
    /// </summary>
    public BicepExpression Value { get; } = value;
    /// <summary>
    /// Gets the decorators applied to this output statement.
    /// </summary>
    public IList<DecoratorExpression> Decorators { get; } = [];
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.AppendAll(Decorators, (w, d) => w.Append(d).AppendLine())
            .Append("output ").Append(Name).Append(' ').Append(Type).Append(" = ").Append(Value).AppendLine();
}
