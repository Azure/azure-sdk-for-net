// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Provisioning;

namespace Azure.Provisioning.Expressions;

public partial class UnaryExpression : IJsonModel<BicepExpression>
{
    void IJsonModel<BicepExpression>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("kind", "unary");
        writer.WriteString("operator", Operator switch
        {
            UnaryBicepOperator.Not => "!",
            UnaryBicepOperator.Negate => "-",
            UnaryBicepOperator.SuppressNull => "!*",
            _ => throw new NotImplementedException($"Unknown operator: {Operator}")
        });
        writer.WritePropertyName("value");
        ((IJsonModel<BicepExpression>)Value).Write(writer, options);
        writer.WriteEndObject();
    }

    BicepExpression IJsonModel<BicepExpression>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        using JsonDocument doc = JsonDocument.ParseValue(ref reader);
        return DeserializeUnaryExpression(doc.RootElement);
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
                throw new FormatException($"The model {nameof(UnaryExpression)} does not support writing '{format}' format.");
        }
    }

    BicepExpression IPersistableModel<BicepExpression>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        using JsonDocument doc = JsonDocument.Parse(data);
        return DeserializeUnaryExpression(doc.RootElement);
    }

    string IPersistableModel<BicepExpression>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    public override bool Equals(BicepExpression? other) => other is UnaryExpression u && Operator == u.Operator && Value.Equals(u.Value);
    public override int GetHashCode() => typeof(UnaryExpression).GetHashCode() ^ Operator.GetHashCode() ^ (Value?.GetHashCode() ?? 0);

    internal static UnaryExpression DeserializeUnaryExpression(JsonElement element)
    {
        UnaryBicepOperator op = element.GetProperty("operator").GetString()! switch
        {
            "!" => UnaryBicepOperator.Not,
            "-" => UnaryBicepOperator.Negate,
            "!*" => UnaryBicepOperator.SuppressNull,
            var unknown => throw new NotImplementedException($"Unknown unary operator: {unknown}")
        };
        return new UnaryExpression(op, UnknownBicepExpression.DeserializeBicepExpression(element.GetProperty("value")));
    }
}
