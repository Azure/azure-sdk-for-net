// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Represents a Bicep member access expression (<c>value.member</c>).
/// </summary>
/// <param name="value">The expression whose member is being accessed.</param>
/// <param name="member">The member name.</param>
public partial class MemberExpression(BicepExpression value, string member) : BicepExpression
{
    /// <summary>
    /// Gets the expression whose member is being accessed.
    /// </summary>
    public BicepExpression Value { get; } = value;
    /// <summary>
    /// Gets the member name.
    /// </summary>
    public string Member { get; } = member;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(Value).Append('.').Append(Member);
}
