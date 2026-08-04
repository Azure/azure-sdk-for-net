// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

public partial class IndexExpression(BicepExpression value, BicepExpression index) : BicepExpression
{
    public BicepExpression Value { get; } = value;
    public BicepExpression Index { get; } = index;
    public bool FromEnd { get; set; }
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(Value).Append('[').Append(Index).Append(']');
}

public partial class SafeIndexExpression(BicepExpression value, BicepExpression index) : BicepExpression
{
    public BicepExpression Value { get; } = value;
    public BicepExpression Index { get; } = index;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(Value).Append("[?").Append(Index).Append(']');
}
