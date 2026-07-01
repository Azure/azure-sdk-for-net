// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Provisioning;

namespace Azure.Provisioning.Expressions;

public partial class NestedExpression : IJsonModel<BicepExpression>
{
    void IJsonModel<BicepExpression>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("kind", "nested-access");
        writer.WritePropertyName("base");
        ((IJsonModel<BicepExpression>)Value).Write(writer, options);
        writer.WriteString("member", NestedMember);
        writer.WriteEndObject();
    }

    BicepExpression IJsonModel<BicepExpression>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        using JsonDocument doc = JsonDocument.ParseValue(ref reader);
        return DeserializeNestedExpression(doc.RootElement);
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
                throw new FormatException($"The model {nameof(NestedExpression)} does not support writing '{format}' format.");
        }
    }

    BicepExpression IPersistableModel<BicepExpression>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        using JsonDocument doc = JsonDocument.Parse(data);
        return DeserializeNestedExpression(doc.RootElement);
    }

    string IPersistableModel<BicepExpression>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    public override bool Equals(BicepExpression? other) => other is NestedExpression n && Value.Equals(n.Value) && NestedMember == n.NestedMember;
    public override int GetHashCode() => typeof(NestedExpression).GetHashCode() ^ (Value?.GetHashCode() ?? 0) ^ (NestedMember?.GetHashCode() ?? 0);

    internal static NestedExpression DeserializeNestedExpression(JsonElement element)
    {
        return new NestedExpression(
            UnknownBicepExpression.DeserializeBicepExpression(element.GetProperty("base")),
            element.GetProperty("member").GetString()!);
    }
}
