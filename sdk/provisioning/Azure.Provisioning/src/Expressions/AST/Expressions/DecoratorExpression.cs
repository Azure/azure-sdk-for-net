// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

public class DecoratorExpression(BicepExpression value) : BicepExpression
{
    public BicepExpression Value { get; } = value;
    internal override BicepWriter Write(BicepWriter writer) => writer.Append('@').Append(Value);
}
