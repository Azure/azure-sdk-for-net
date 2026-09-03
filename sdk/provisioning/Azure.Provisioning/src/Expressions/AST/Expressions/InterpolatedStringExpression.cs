// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Represents a Bicep interpolated string expression composed of literal and embedded expression segments.
/// </summary>
/// <param name="values">The literal and expression segments that make up the interpolated string.</param>
public partial class InterpolatedStringExpression(BicepExpression[] values) : BicepExpression
{
    /// <summary>
    /// Gets the literal and expression segments that make up the interpolated string.
    /// </summary>
    public BicepExpression[] Values { get; } = values;
    internal override BicepWriter Write(BicepWriter writer)
    {
        writer.Append('\'');
        foreach (BicepExpression value in Values)
        {
            if (value is StringLiteralExpression lit)
            {
                writer = writer.AppendEscaped(lit.Value);
            }
            else
            {
                writer = writer.Append("${").Append(value).Append('}');
            }
        }
        return writer.Append('\'');
    }
}
