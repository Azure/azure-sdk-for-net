// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Represents a Bicep <c>param</c> declaration statement.
/// </summary>
/// <param name="name">The parameter name.</param>
/// <param name="type">The parameter type expression.</param>
/// <param name="defaultValue">An optional default value expression.</param>
public partial class ParameterStatement(string name, BicepExpression type, BicepExpression? defaultValue) : BicepStatement
{
    /// <summary>
    /// Gets the parameter name.
    /// </summary>
    public string Name { get; } = name;
    /// <summary>
    /// Gets the parameter type expression.
    /// </summary>
    public BicepExpression Type { get; } = type;
    /// <summary>
    /// Gets the optional default value expression.
    /// </summary>
    public BicepExpression? DefaultValue { get; } = defaultValue;
    /// <summary>
    /// Gets the decorators applied to this parameter statement.
    /// </summary>
    public IList<DecoratorExpression> Decorators { get; } = [];
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.AppendAll(Decorators, (w, d) => w.Append(d).AppendLine())
            .Append("param ").Append(Name).Append(' ').Append(Type)
            .AppendIf(DefaultValue != null, w => w.Append(" = ").Append(DefaultValue!))
            .AppendLine();
    // note: use NullLiteral if you want a null default value
}
