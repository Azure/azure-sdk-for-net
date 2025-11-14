// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

public class NestedExpression(BicepExpression value, string nestedMember) : BicepExpression
{
    public BicepExpression Value { get; } = value;
    public string NestedMember { get; } = nestedMember;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(Value).Append("::").Append(NestedMember);
}
