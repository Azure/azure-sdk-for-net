// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Linq;
using System.Text.Json;
using Azure.Provisioning;

namespace Azure.Provisioning.Expressions;

public partial class OutputStatement : IJsonModel<BicepStatement>
{
    void IJsonModel<BicepStatement>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("bicepIdentifier", Name);
        writer.WritePropertyName("valueType");
        ((IJsonModel<BicepExpression>)Type).Write(writer, ModelReaderWriterOptions.Json);
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
                throw new FormatException($"The model {nameof(OutputStatement)} does not support writing '{format}' format.");
        }
    }

    BicepStatement IPersistableModel<BicepStatement>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        throw new NotSupportedException("BicepStatement deserialization requires the statement type context. Use Infrastructure.DeserializeInfrastructure instead.");
    }

    string IPersistableModel<BicepStatement>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    public override bool Equals(BicepStatement? other) =>
        other is OutputStatement o && Name == o.Name && Type.Equals(o.Type) && Value.Equals(o.Value) &&
        Decorators.SequenceEqual(o.Decorators);
    public override int GetHashCode() => typeof(OutputStatement).GetHashCode() ^ (Name?.GetHashCode() ?? 0) ^ (Type?.GetHashCode() ?? 0) ^ (Value?.GetHashCode() ?? 0);

    internal static OutputStatement DeserializeOutputStatement(JsonElement element)
    {
        string name = element.GetProperty("bicepIdentifier").GetString()!;
        BicepExpression type = UnknownBicepExpression.DeserializeBicepExpression(element.GetProperty("valueType"));
        BicepExpression value = UnknownBicepExpression.DeserializeBicepExpression(element.GetProperty("value"));

        OutputStatement stmt = new(name, type, value);

        DecoratorsNodeSerializer.ReadDecoratorsNode(element, stmt.Decorators);

        return stmt;
    }
}
