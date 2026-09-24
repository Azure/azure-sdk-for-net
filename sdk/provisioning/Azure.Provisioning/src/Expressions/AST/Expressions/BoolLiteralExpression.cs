// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Represents a Bicep Boolean literal expression (<c>true</c> or <c>false</c>).
/// </summary>
/// <param name="value">The Boolean value.</param>
public partial class BoolLiteralExpression(bool value) : LiteralExpression(value)
{
    /// <summary>
    /// Gets the Boolean value.
    /// </summary>
    public new bool Value { get => (bool)base.Value!; }
    internal override BicepWriter Write(BicepWriter writer) => writer.Append(Value ? "true" : "false");
}
