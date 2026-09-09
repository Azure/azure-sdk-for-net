// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Represents a Bicep nested resource access expression (<c>value::nestedMember</c>).
/// </summary>
/// <param name="value">The parent expression.</param>
/// <param name="nestedMember">The nested resource member name.</param>
public class NestedExpression(BicepExpression value, string nestedMember) : BicepExpression
{
    /// <summary>
    /// Gets the parent expression.
    /// </summary>
    public BicepExpression Value { get; } = value;
    /// <summary>
    /// Gets the nested resource member name.
    /// </summary>
    public string NestedMember { get; } = nestedMember;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(Value).Append("::").Append(NestedMember);
}
