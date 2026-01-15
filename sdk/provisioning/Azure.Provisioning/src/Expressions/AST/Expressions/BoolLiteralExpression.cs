// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

public class BoolLiteralExpression(bool value) : LiteralExpression(value)
{
    public new bool Value { get => (bool)base.Value!; }
    internal override BicepWriter Write(BicepWriter writer) => writer.Append(Value ? "true" : "false");
}
