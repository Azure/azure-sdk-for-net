// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Provisioning;

namespace Azure.Provisioning.Expressions;

public partial class PropertyExpression : IJsonModel<BicepExpression>
{
    void IJsonModel<BicepExpression>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        // PropertyExpression is not written as a standalone kind node;
        // it's written inline within ObjectExpression
        writer.WritePropertyName(Name);
        ((IJsonModel<BicepExpression>)Value).Write(writer, options);
    }

    BicepExpression IJsonModel<BicepExpression>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        using JsonDocument doc = JsonDocument.ParseValue(ref reader);
        return UnknownBicepExpression.DeserializeBicepExpression(doc.RootElement);
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
                throw new FormatException($"The model {nameof(PropertyExpression)} does not support writing '{format}' format.");
        }
    }

    BicepExpression IPersistableModel<BicepExpression>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        using JsonDocument doc = JsonDocument.Parse(data);
        return UnknownBicepExpression.DeserializeBicepExpression(doc.RootElement);
    }

    string IPersistableModel<BicepExpression>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    public override bool Equals(BicepExpression? other) => other is PropertyExpression p && Name == p.Name && Value.Equals(p.Value);
    public override int GetHashCode() => typeof(PropertyExpression).GetHashCode() ^ (Name?.GetHashCode() ?? 0) ^ (Value?.GetHashCode() ?? 0);

    internal static PropertyExpression DeserializePropertyExpression(string name, JsonElement element)
    {
        return new PropertyExpression(name, UnknownBicepExpression.DeserializeBicepExpression(element));
    }
}
