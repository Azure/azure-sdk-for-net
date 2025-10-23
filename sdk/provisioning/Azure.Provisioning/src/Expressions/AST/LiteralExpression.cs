// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

public abstract class LiteralExpression(object? value = null) : BicepExpression
{
    public object? Value { get; } = value;
}

public class NullLiteralExpression() : LiteralExpression()
{
    internal override BicepWriter Write(BicepWriter writer) => writer.Append("null");
}

public class BoolLiteralExpression(bool value) : LiteralExpression(value)
{
    public new bool Value { get => (bool)base.Value!; }
    internal override BicepWriter Write(BicepWriter writer) => writer.Append(Value ? "true" : "false");
}

public class IntLiteralExpression(int value) : LiteralExpression(value)
{
    public new int Value { get => (int)base.Value!; }
    internal override BicepWriter Write(BicepWriter writer) => writer.Append(Value.ToString());
}

public class StringLiteralExpression(string value) : LiteralExpression(value)
{
    public new string Value { get => (string)base.Value!; }
    internal override BicepWriter Write(BicepWriter writer) =>
        (Value == null) ?
            writer.Append("null") :
            writer.Append('\'').AppendEscaped(Value).Append('\'');
}
