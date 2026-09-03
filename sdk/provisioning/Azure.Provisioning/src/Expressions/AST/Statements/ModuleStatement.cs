// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Represents a Bicep <c>module</c> declaration statement.
/// </summary>
/// <param name="name">The module symbolic name.</param>
/// <param name="type">The module type or path expression.</param>
/// <param name="body">The module body expression.</param>
public partial class ModuleStatement(string name, BicepExpression type, BicepExpression body) : BicepStatement
{
    /// <summary>
    /// Gets the module symbolic name.
    /// </summary>
    public string Name { get; } = name;
    /// <summary>
    /// Gets the module type or path expression.
    /// </summary>
    public BicepExpression Type { get; } = type;
    /// <summary>
    /// Gets the module body expression.
    /// </summary>
    public BicepExpression Body { get; } = body;
    /// <summary>
    /// Gets the decorators applied to this module statement.
    /// </summary>
    public IList<DecoratorExpression> Decorators { get; } = [];
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.AppendAll(Decorators, (w, d) => w.Append(d).AppendLine())
            .Append("module ").Append(Name).Append(' ').Append(Type).Append(" = ").Append(Body).AppendLine();
}
