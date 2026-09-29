// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Represents a Bicep integer literal expression.
/// </summary>
/// <param name="value">The integer value.</param>
public class IntLiteralExpression(int value) : LiteralExpression(value)
{
    /// <summary>
    /// Gets the integer value.
    /// </summary>
    public new int Value { get => (int)base.Value!; }
    internal override BicepWriter Write(BicepWriter writer) => writer.Append(Value.ToString());
}
