// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Represents a Bicep decorator expression (e.g., <c>@description('...')</c>).
/// </summary>
/// <param name="value">The decorator value expression.</param>
public class DecoratorExpression(BicepExpression value) : BicepExpression
{
    /// <summary>
    /// Gets the decorator value expression.
    /// </summary>
    public BicepExpression Value { get; } = value;
    internal override BicepWriter Write(BicepWriter writer) => writer.Append('@').Append(Value);
}
