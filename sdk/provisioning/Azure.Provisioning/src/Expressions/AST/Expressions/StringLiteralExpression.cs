// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

public class StringLiteralExpression(string value) : LiteralExpression(value)
{
    public new string Value { get => (string)base.Value!; }
    internal override BicepWriter Write(BicepWriter writer) => Value == null ?
        writer.Append("null") :
        writer.Append('\'').AppendEscaped(Value).Append('\'');
}
