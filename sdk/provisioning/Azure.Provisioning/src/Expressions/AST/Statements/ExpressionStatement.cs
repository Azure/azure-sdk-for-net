// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

public class ExpressionStatement(BicepExpression expression) : BicepStatement
{
    public BicepExpression Expression { get; } = expression;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(Expression);
}
