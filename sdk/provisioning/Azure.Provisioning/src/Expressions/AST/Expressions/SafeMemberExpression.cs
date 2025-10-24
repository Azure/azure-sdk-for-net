// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

public class SafeMemberExpression(BicepExpression value, string member) : BicepExpression
{
    public BicepExpression Value { get; } = value;
    public string Member { get; } = member;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(Value).Append(".?").Append(Member);
}
