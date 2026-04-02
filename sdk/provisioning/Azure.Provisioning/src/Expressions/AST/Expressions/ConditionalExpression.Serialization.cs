// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Provisioning;

namespace Azure.Provisioning.Expressions;

public partial class ConditionalExpression : IJsonModel<BicepExpression>
{
    void IJsonModel<BicepExpression>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("kind", "ternary-operation");
        writer.WritePropertyName("condition");
        ((IJsonModel<BicepExpression>)Condition).Write(writer, options);
        writer.WritePropertyName("consequent");
        ((IJsonModel<BicepExpression>)Consequent).Write(writer, options);
        writer.WritePropertyName("alternate");
        ((IJsonModel<BicepExpression>)Alternate).Write(writer, options);
        writer.WriteEndObject();
    }

    BicepExpression IJsonModel<BicepExpression>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        using JsonDocument doc = JsonDocument.ParseValue(ref reader);
        return DeserializeConditionalExpression(doc.RootElement);
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
                throw new FormatException($"The model {nameof(ConditionalExpression)} does not support writing '{format}' format.");
        }
    }

    BicepExpression IPersistableModel<BicepExpression>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        using JsonDocument doc = JsonDocument.Parse(data);
        return DeserializeConditionalExpression(doc.RootElement);
    }

    string IPersistableModel<BicepExpression>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    public override bool Equals(BicepExpression? other) => other is ConditionalExpression c && Condition.Equals(c.Condition) && Consequent.Equals(c.Consequent) && Alternate.Equals(c.Alternate);
    public override int GetHashCode() => typeof(ConditionalExpression).GetHashCode() ^ (Condition?.GetHashCode() ?? 0) ^ (Consequent?.GetHashCode() ?? 0) ^ (Alternate?.GetHashCode() ?? 0);

    internal static ConditionalExpression DeserializeConditionalExpression(JsonElement element)
    {
        return new ConditionalExpression(
            UnknownBicepExpression.DeserializeBicepExpression(element.GetProperty("condition")),
            UnknownBicepExpression.DeserializeBicepExpression(element.GetProperty("consequent")),
            UnknownBicepExpression.DeserializeBicepExpression(element.GetProperty("alternate")));
    }
}
