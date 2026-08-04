// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Linq;
using System.Text.Json;
using Azure.Provisioning;

namespace Azure.Provisioning.Expressions;

public partial class ModuleStatement : IJsonModel<BicepStatement>
{
    void IJsonModel<BicepStatement>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        string path = Type.ToString().Trim('\'');

        writer.WriteStartObject();
        writer.WriteString("bicepIdentifier", Name);
        writer.WriteString("path", path);
        writer.WritePropertyName("value");
        ((IJsonModel<BicepExpression>)Body).Write(writer, ModelReaderWriterOptions.Json);
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
                throw new FormatException($"The model {nameof(ModuleStatement)} does not support writing '{format}' format.");
        }
    }

    BicepStatement IPersistableModel<BicepStatement>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        throw new NotSupportedException("BicepStatement deserialization requires the statement type context. Use Infrastructure.DeserializeInfrastructure instead.");
    }

    string IPersistableModel<BicepStatement>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    public override bool Equals(BicepStatement? other) =>
        other is ModuleStatement m && Name == m.Name && Type.Equals(m.Type) && Body.Equals(m.Body) &&
        Decorators.SequenceEqual(m.Decorators);
    public override int GetHashCode() => typeof(ModuleStatement).GetHashCode() ^ (Name?.GetHashCode() ?? 0) ^ (Type?.GetHashCode() ?? 0) ^ (Body?.GetHashCode() ?? 0);

    internal static ModuleStatement DeserializeModuleStatement(JsonElement element)
    {
        string name = element.GetProperty("bicepIdentifier").GetString()!;
        string path = element.GetProperty("path").GetString()!;
        BicepExpression body = UnknownBicepExpression.DeserializeBicepExpression(element.GetProperty("value"));

        ModuleStatement stmt = new(name, new StringLiteralExpression(path), body);

        DecoratorsNodeSerializer.ReadDecoratorsNode(element, stmt.Decorators);

        return stmt;
    }
}
