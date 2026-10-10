// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Represents a Bicep array expression.
/// </summary>
/// <param name="values">The array element expressions.</param>
public partial class ArrayExpression(params BicepExpression[] values) : BicepExpression
{
    /// <summary>
    /// Gets the array element expressions.
    /// </summary>
    public BicepExpression[] Values { get; } = values;
    internal override BicepWriter Write(BicepWriter writer)
    {
        if (Values.Length == 0)
        {
            return writer.Append("[]");
        }
        else
        {
            return writer.Append('[')
                .Indent(w => w.AppendLine().AppendAll(Values, (w, v) => w.Append(v), w => w./*Append(',').*/AppendLine()))
                .AppendLine().Append(']');
        }
    }
}
