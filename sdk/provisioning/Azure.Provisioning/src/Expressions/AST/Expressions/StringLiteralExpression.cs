// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Represents a Bicep string literal expression.
/// </summary>
/// <param name="value">The string value.</param>
public partial class StringLiteralExpression(string value) : LiteralExpression(value)
{
    /// <summary>
    /// Gets the string value.
    /// </summary>
    public new string Value { get => (string)base.Value!; }
    internal override BicepWriter Write(BicepWriter writer) => Value == null ?
        writer.Append("null") :
        writer.Append('\'').AppendEscaped(Value).Append('\'');
}
