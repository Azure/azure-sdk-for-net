// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Provisioning;

namespace Azure.Provisioning.Expressions;

public partial class ObjectExpression : IJsonModel<BicepExpression>
{
    void IJsonModel<BicepExpression>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("kind", "object");
        writer.WritePropertyName("value");
        writer.WriteStartObject();
        foreach (PropertyExpression property in Properties)
        {
            writer.WritePropertyName(property.Name);
            ((IJsonModel<BicepExpression>)property.Value).Write(writer, options);
        }
        writer.WriteEndObject();
        writer.WriteEndObject();
    }

    BicepExpression IJsonModel<BicepExpression>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        using JsonDocument doc = JsonDocument.ParseValue(ref reader);
        return DeserializeObjectExpression(doc.RootElement);
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
                throw new FormatException($"The model {nameof(ObjectExpression)} does not support writing '{format}' format.");
        }
    }

    BicepExpression IPersistableModel<BicepExpression>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        using JsonDocument doc = JsonDocument.Parse(data);
        return DeserializeObjectExpression(doc.RootElement);
    }

    string IPersistableModel<BicepExpression>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    public override bool Equals(BicepExpression? other) =>
        other is ObjectExpression o && Properties.SequenceEqual(o.Properties);
    public override int GetHashCode()
    {
        int hash = typeof(ObjectExpression).GetHashCode();
        foreach (var p in Properties) hash = hash * 31 + (p?.GetHashCode() ?? 0);
        return hash;
    }

    internal static ObjectExpression DeserializeObjectExpression(JsonElement element)
    {
        List<PropertyExpression> properties = new();
        JsonElement value = element.GetProperty("value");
        foreach (JsonProperty prop in value.EnumerateObject())
        {
            properties.Add(new PropertyExpression(prop.Name, UnknownBicepExpression.DeserializeBicepExpression(prop.Value)));
        }
        return new ObjectExpression([.. properties]);
    }
}
