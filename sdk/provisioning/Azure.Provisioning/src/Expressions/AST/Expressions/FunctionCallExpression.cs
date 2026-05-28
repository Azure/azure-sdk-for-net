// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

public class FunctionCallExpression(BicepExpression function, params BicepExpression[] arguments) : BicepExpression
{
    public BicepExpression Function { get; } = function;
    public BicepExpression[] Arguments { get; } = arguments;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(Function).Append('(')
            .AppendAll(Arguments, (w, a) => w.Append(a), w => w.Append(", ")).Append(')');
}
