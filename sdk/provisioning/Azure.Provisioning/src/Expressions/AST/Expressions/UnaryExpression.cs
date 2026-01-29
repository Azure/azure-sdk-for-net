// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Provisioning.Expressions;

public class UnaryExpression(UnaryBicepOperator op, BicepExpression value) : BicepExpression
{
    public UnaryBicepOperator Operator { get; } = op;
    public BicepExpression Value { get; } = value;
    internal override BicepWriter Write(BicepWriter writer) => Operator switch
    {
        UnaryBicepOperator.Not => writer.Append('!').Append(Value),
        UnaryBicepOperator.Negate => writer.Append('-').Append(Value),
        UnaryBicepOperator.SuppressNull => writer.Append(Value).Append('!'),
        _ => throw new NotImplementedException($"Unknown {nameof(UnaryBicepOperator)} value {Operator}")
    };
}
