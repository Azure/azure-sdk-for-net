// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Represents a Bicep <c>resource</c> declaration statement.
/// </summary>
/// <param name="name">The resource symbolic name.</param>
/// <param name="type">The resource type expression.</param>
/// <param name="body">The resource body expression.</param>
public class ResourceStatement(string name, BicepExpression type, BicepExpression body) : BicepStatement
{
    /// <summary>
    /// Gets the resource symbolic name.
    /// </summary>
    public string Name { get; } = name;
    /// <summary>
    /// Gets the resource type expression.
    /// </summary>
    public BicepExpression Type { get; } = type;
    /// <summary>
    /// Gets the resource body expression.
    /// </summary>
    public BicepExpression Body { get; } = body;
    /// <summary>
    /// Gets or sets a value indicating whether this is an existing resource reference.
    /// </summary>
    public bool Existing { get; set; }
    /// <summary>
    /// Gets or sets an optional condition expression that controls whether the resource is deployed.
    /// </summary>
    public BicepExpression? Condition { get; set; }
    /// <summary>
    /// Gets the decorators applied to this resource statement.
    /// </summary>
    public IList<DecoratorExpression> Decorators { get; } = [];
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.AppendAll(Decorators, (w, d) => w.Append(d).AppendLine())
            .Append("resource ").Append(Name).Append(' ').Append(Type)
            .AppendIf(Existing, w => w.Append(" existing"))
            .AppendIf(Condition is not null, w => w.Append(" = if (").Append(Condition!).Append(") "))
            .AppendIf(Condition is null, w => w.Append(" = "))
            .Append(Body).AppendLine();
}
