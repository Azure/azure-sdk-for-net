// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Represents a Bicep <c>extension</c> declaration statement.
/// </summary>
/// <param name="reference">The extension name or artifact string literal expression.</param>
/// <param name="configuration">The optional extension configuration object.</param>
/// <param name="alias">The optional namespace alias.</param>
public class ExtensionStatement(
    BicepExpression reference,
    ObjectExpression? configuration = null,
    string? alias = null) : BicepStatement
{
    /// <summary>
    /// Gets the extension reference expression.
    /// </summary>
    public BicepExpression Reference { get; } = reference;

    /// <summary>
    /// Gets the optional extension configuration object.
    /// </summary>
    public ObjectExpression? Configuration { get; } = configuration;

    /// <summary>
    /// Gets the optional namespace alias.
    /// </summary>
    public string? Alias { get; } = alias;

    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append("extension ").Append(Reference)
            .AppendIf(Configuration is not null, w => w.Append(" with ").Append(Configuration!))
            .AppendIf(Alias is not null, w => w.Append(" as ").Append(Alias!))
            .AppendLine();
}
