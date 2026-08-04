// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Provisioning;

namespace Azure.Provisioning.Expressions;

public partial class FunctionCallExpression : IJsonModel<BicepExpression>
{
    void IJsonModel<BicepExpression>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("kind", "function-call");
        if (Function is IdentifierExpression id)
        {
            writer.WriteString("target", id.Name);
        }
        else
        {
            writer.WritePropertyName("target");
            ((IJsonModel<BicepExpression>)Function).Write(writer, options);
        }
        writer.WritePropertyName("args");
        writer.WriteStartArray();
        foreach (BicepExpression arg in Arguments)
        {
            ((IJsonModel<BicepExpression>)arg).Write(writer, options);
        }
        writer.WriteEndArray();
        writer.WriteEndObject();
    }

    BicepExpression IJsonModel<BicepExpression>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        using JsonDocument doc = JsonDocument.ParseValue(ref reader);
        return DeserializeFunctionCallExpression(doc.RootElement);
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
                throw new FormatException($"The model {nameof(FunctionCallExpression)} does not support writing '{format}' format.");
        }
    }

    BicepExpression IPersistableModel<BicepExpression>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        using JsonDocument doc = JsonDocument.Parse(data);
        return DeserializeFunctionCallExpression(doc.RootElement);
    }

    string IPersistableModel<BicepExpression>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    public override bool Equals(BicepExpression? other) =>
        other is FunctionCallExpression f && Function.Equals(f.Function) &&
        Arguments.SequenceEqual(f.Arguments);
    public override int GetHashCode()
    {
        int hash = typeof(FunctionCallExpression).GetHashCode();
        hash = hash * 31 + (Function?.GetHashCode() ?? 0);
        foreach (var a in Arguments) hash = hash * 31 + (a?.GetHashCode() ?? 0);
        return hash;
    }

    internal static FunctionCallExpression DeserializeFunctionCallExpression(JsonElement element)
    {
        JsonElement targetElement = element.GetProperty("target");
        BicepExpression function = targetElement.ValueKind == JsonValueKind.String
            ? new IdentifierExpression(targetElement.GetString()!)
            : UnknownBicepExpression.DeserializeBicepExpression(targetElement);
        List<BicepExpression> args = new();
        if (element.TryGetProperty("args", out JsonElement argsElement))
        {
            foreach (JsonElement arg in argsElement.EnumerateArray())
            {
                args.Add(UnknownBicepExpression.DeserializeBicepExpression(arg));
            }
        }
        return new FunctionCallExpression(function, [.. args]);
    }
}
