// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

public class IntLiteralExpression(int value) : LiteralExpression(value)
{
    public new int Value { get => (int)base.Value!; }
    internal override BicepWriter Write(BicepWriter writer) => writer.Append(Value.ToString());
}
