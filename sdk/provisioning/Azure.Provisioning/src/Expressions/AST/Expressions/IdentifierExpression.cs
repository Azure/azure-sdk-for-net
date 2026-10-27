// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Represents a Bicep identifier expression (a reference to a named symbol).
/// </summary>
/// <param name="name">The identifier name.</param>
public class IdentifierExpression(string name) : BicepExpression
{
    /// <summary>
    /// Gets the identifier name.
    /// </summary>
    public string Name { get; } = name;
    internal override BicepWriter Write(BicepWriter writer) => writer.Append(Name);
}
