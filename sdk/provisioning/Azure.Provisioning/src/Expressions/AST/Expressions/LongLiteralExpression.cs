// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Globalization;
using System.Text.Json;

namespace Azure.Provisioning.Expressions;

// Preserve IntLiteralExpression's public Int32 API while reading Int64 schema values.
internal sealed class LongLiteralExpression(long value) : LiteralExpression(value), IJsonModel<BicepExpression>
{
    internal new long Value => (long)base.Value!;

    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(Value.ToString(CultureInfo.InvariantCulture));

    void IJsonModel<BicepExpression>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("kind", "integer");
        writer.WriteString("value", Value.ToString(CultureInfo.InvariantCulture));
        writer.WriteEndObject();
    }

    public override bool Equals(BicepExpression? other) => other is LongLiteralExpression integer && Value == integer.Value;
    public override int GetHashCode() => typeof(LongLiteralExpression).GetHashCode() ^ Value.GetHashCode();
}
