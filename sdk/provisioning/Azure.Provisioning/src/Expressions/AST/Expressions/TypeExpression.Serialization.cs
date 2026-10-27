// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Provisioning;

namespace Azure.Provisioning.Expressions;

public partial class TypeExpression : IJsonModel<BicepExpression>
{
    void IJsonModel<BicepExpression>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("kind", "primitive-type");
        string? typeName = BicepTypeMapping.GetBicepTypeName(Type);
        writer.WriteString("name", typeName ?? throw new NotSupportedException(
            $"Cannot map '{Type.FullName}' to a provisioning JSON primitive type."));
        writer.WriteEndObject();
    }

    BicepExpression IJsonModel<BicepExpression>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        using JsonDocument doc = JsonDocument.ParseValue(ref reader);
        return DeserializeTypeExpression(doc.RootElement);
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
                throw new FormatException($"The model {nameof(TypeExpression)} does not support writing '{format}' format.");
        }
    }

    BicepExpression IPersistableModel<BicepExpression>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        using JsonDocument doc = JsonDocument.Parse(data);
        return DeserializeTypeExpression(doc.RootElement);
    }

    string IPersistableModel<BicepExpression>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    /// <inheritdoc/>
    public override bool Equals(BicepExpression? other) => other is TypeExpression t && Type == t.Type;
    /// <inheritdoc/>
    public override int GetHashCode() => (typeof(TypeExpression).GetHashCode() * 31 + (Type?.GetHashCode() ?? 0));

    internal static BicepExpression DeserializeTypeExpression(JsonElement element) => SchemaTypeExpression.Deserialize(element);
}
