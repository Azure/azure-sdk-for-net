// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Linq;
using System.Text.Json;
using Azure.Provisioning;

namespace Azure.Provisioning.Expressions;

public partial class ParameterStatement : IJsonModel<BicepStatement>
{
    void IJsonModel<BicepStatement>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("bicepIdentifier", Name);
        writer.WritePropertyName("valueType");
        ((IJsonModel<BicepExpression>)Type).Write(writer, ModelReaderWriterOptions.Json);
        if (DefaultValue != null)
        {
            writer.WritePropertyName("defaultValue");
            ((IJsonModel<BicepExpression>)DefaultValue).Write(writer, ModelReaderWriterOptions.Json);
        }
        if (Decorators.Count > 0)
        {
            DecoratorsNodeSerializer.WriteDecoratorsNode(writer, Decorators);
        }
        writer.WriteEndObject();
    }

    BicepStatement IJsonModel<BicepStatement>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        throw new NotSupportedException("BicepStatement deserialization requires the statement type context. Use Infrastructure.DeserializeInfrastructure instead.");
    }

    BinaryData IPersistableModel<BicepStatement>.Write(ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<BicepStatement>)this).GetFormatFromOptions(options) : options.Format;
        switch (format)
        {
            case "J":
                return ModelReaderWriter.Write(this, options, AzureProvisioningContext.Default);
            case "bicep":
                return new BinaryData(new BicepWriter().Append(this).ToString());
            default:
                throw new FormatException($"The model {nameof(ParameterStatement)} does not support writing '{format}' format.");
        }
    }

    BicepStatement IPersistableModel<BicepStatement>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        throw new NotSupportedException("BicepStatement deserialization requires the statement type context. Use Infrastructure.DeserializeInfrastructure instead.");
    }

    string IPersistableModel<BicepStatement>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    public override bool Equals(BicepStatement? other) =>
        other is ParameterStatement p && Name == p.Name && Type.Equals(p.Type) &&
        ((DefaultValue == null && p.DefaultValue == null) || (DefaultValue != null && DefaultValue.Equals(p.DefaultValue))) &&
        Decorators.SequenceEqual(p.Decorators);
    public override int GetHashCode() => typeof(ParameterStatement).GetHashCode() ^ (Name?.GetHashCode() ?? 0) ^ (Type?.GetHashCode() ?? 0) ^ (DefaultValue?.GetHashCode() ?? 0);

    internal static ParameterStatement DeserializeParameterStatement(JsonElement element)
    {
        string name = element.GetProperty("bicepIdentifier").GetString()!;
        BicepExpression type = UnknownBicepExpression.DeserializeBicepExpression(element.GetProperty("valueType"));
        BicepExpression? defaultValue = null;
        if (element.TryGetProperty("defaultValue", out JsonElement dv))
        {
            defaultValue = UnknownBicepExpression.DeserializeBicepExpression(dv);
        }

        ParameterStatement stmt = new(name, type, defaultValue);

        DecoratorsNodeSerializer.ReadDecoratorsNode(element, stmt.Decorators);

        return stmt;
    }
}
