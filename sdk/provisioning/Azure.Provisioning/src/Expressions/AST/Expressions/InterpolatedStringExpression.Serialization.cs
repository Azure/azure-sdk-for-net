// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Provisioning;

namespace Azure.Provisioning.Expressions;

public partial class InterpolatedStringExpression : IJsonModel<BicepExpression>
{
    void IJsonModel<BicepExpression>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("kind", "interpolated-string");
        writer.WritePropertyName("segments");
        writer.WriteStartArray();
        foreach (BicepExpression value in Values)
        {
            ((IJsonModel<BicepExpression>)value).Write(writer, options);
        }
        writer.WriteEndArray();
        writer.WriteEndObject();
    }

    BicepExpression IJsonModel<BicepExpression>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        using JsonDocument doc = JsonDocument.ParseValue(ref reader);
        return DeserializeInterpolatedStringExpression(doc.RootElement);
    }

    BinaryData IPersistableModel<BicepExpression>.Write(ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<BicepExpression>)this).GetFormatFromOptions(options) : options.Format;
        switch (format)
        {
            case "J":
                return ModelReaderWriter.Write(this, options, AzureProvisioningContext.Default);
            case "bicep":
                return new BinaryData(new BicepWriter().Append(this).ToString());
            default:
                throw new FormatException($"The model {nameof(InterpolatedStringExpression)} does not support writing '{format}' format.");
        }
    }

    BicepExpression IPersistableModel<BicepExpression>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        using JsonDocument doc = JsonDocument.Parse(data);
        return DeserializeInterpolatedStringExpression(doc.RootElement);
    }

    string IPersistableModel<BicepExpression>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    public override bool Equals(BicepExpression? other) =>
        other is InterpolatedStringExpression i && Values.SequenceEqual(i.Values);
    public override int GetHashCode()
    {
        int hash = typeof(InterpolatedStringExpression).GetHashCode();
        foreach (var v in Values) hash = hash * 31 + (v?.GetHashCode() ?? 0);
        return hash;
    }

    internal static InterpolatedStringExpression DeserializeInterpolatedStringExpression(JsonElement element)
    {
        List<BicepExpression> values = new();
        foreach (JsonElement seg in element.GetProperty("segments").EnumerateArray())
        {
            values.Add(UnknownBicepExpression.DeserializeBicepExpression(seg));
        }
        return new InterpolatedStringExpression([.. values]);
    }
}
