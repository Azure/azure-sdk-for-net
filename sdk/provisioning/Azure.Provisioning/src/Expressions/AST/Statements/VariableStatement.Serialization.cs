// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Linq;
using System.Text.Json;
using Azure.Provisioning;

namespace Azure.Provisioning.Expressions;

public partial class VariableStatement : IJsonModel<BicepStatement>
{
    void IJsonModel<BicepStatement>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("bicepIdentifier", Name);
        writer.WritePropertyName("value");
        ((IJsonModel<BicepExpression>)Value).Write(writer, ModelReaderWriterOptions.Json);
        DecoratorsNodeSerializer.WriteDecoratorsNode(writer, Decorators);
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
                throw new FormatException($"The model {nameof(VariableStatement)} does not support writing '{format}' format.");
        }
    }

    BicepStatement IPersistableModel<BicepStatement>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        throw new NotSupportedException("BicepStatement deserialization requires the statement type context. Use Infrastructure.DeserializeInfrastructure instead.");
    }

    string IPersistableModel<BicepStatement>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    internal static VariableStatement DeserializeVariableStatement(JsonElement element)
    {
        string name = element.GetProperty("bicepIdentifier").GetString()!;
        BicepExpression value = UnknownBicepExpression.DeserializeBicepExpression(element.GetProperty("value"));
        VariableStatement stmt = new(name, value);
        DecoratorsNodeSerializer.ReadDecoratorsNode(element, stmt.Decorators);
        return stmt;
    }

    public override bool Equals(BicepStatement? other) =>
        other is VariableStatement v && Name == v.Name && Value.Equals(v.Value) &&
        Decorators.SequenceEqual(v.Decorators);
    public override int GetHashCode() => typeof(VariableStatement).GetHashCode() ^ (Name?.GetHashCode() ?? 0) ^ (Value?.GetHashCode() ?? 0);
}
