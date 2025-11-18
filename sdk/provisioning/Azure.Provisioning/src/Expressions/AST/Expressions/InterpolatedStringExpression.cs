// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

public class InterpolatedStringExpression(BicepExpression[] values) : BicepExpression
{
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
