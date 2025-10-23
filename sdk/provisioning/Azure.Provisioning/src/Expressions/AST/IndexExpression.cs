// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

public class IndexExpression(BicepExpression value, BicepExpression index) : BicepExpression
{
    public BicepExpression Value { get; } = value;
    public BicepExpression Index { get; } = index;
    internal override BicepWriter Write(BicepWriter writer) =>
    writer.Append(Value).Append('[').Append(Index).Append(']');
}

public class SafeIndexExpression(BicepExpression value, BicepExpression index) : BicepExpression
{
 public BicepExpression Value { get; } = value;
    public BicepExpression Index { get; } = index;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(Value).Append("[?").Append(Index).Append(']');
}
