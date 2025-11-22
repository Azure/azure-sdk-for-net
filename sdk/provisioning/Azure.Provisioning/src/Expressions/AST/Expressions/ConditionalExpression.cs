// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

public class ConditionalExpression(BicepExpression condition, BicepExpression consequent, BicepExpression alternate) : BicepExpression
{
    public BicepExpression Condition { get; } = condition;
    public BicepExpression Consequent { get; } = consequent;
    public BicepExpression Alternate { get; } = alternate;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(Condition).Append(" ? ").Append(Consequent).Append(" : ").Append(Alternate);
}
