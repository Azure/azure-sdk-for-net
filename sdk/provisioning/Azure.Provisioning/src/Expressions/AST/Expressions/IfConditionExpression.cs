// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions
{
    public partial class IfConditionExpression(BicepExpression condition, BicepExpression body) : BicepExpression
    {
        public BicepExpression Condition { get; } = condition;
        public BicepExpression Body { get; } = body;
        internal override BicepWriter Write(BicepWriter writer)
            => writer.Append("if (").Append(Condition).Append(") ").Append(Body);
    }
}
