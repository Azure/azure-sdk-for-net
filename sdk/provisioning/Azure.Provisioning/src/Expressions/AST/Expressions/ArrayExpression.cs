// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

public class ArrayExpression(params BicepExpression[] values) : BicepExpression
{
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
