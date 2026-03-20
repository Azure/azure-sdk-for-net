// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Linq;
using System.Text.Json;
using Azure.Provisioning;

namespace Azure.Provisioning.Expressions;

public partial class ResourceStatement : IJsonModel<BicepStatement>
{
    void IJsonModel<BicepStatement>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        // Parse type string "Microsoft.Storage/storageAccounts@2024-01-01" into type and apiVersion
        string typeString = Type.ToString();
        string resourceType;
        string apiVersion;
        int atIndex = typeString.IndexOf('@');
        if (atIndex >= 0)
        {
            resourceType = typeString.Substring(0, atIndex).Trim('\'');
            apiVersion = typeString.Substring(atIndex + 1).Trim('\'');
        }
        else
        {
            resourceType = typeString.Trim('\'');
            apiVersion = "";
        }

        writer.WriteStartObject();
        writer.WriteString("bicepIdentifier", Name);
        writer.WriteString("type", resourceType);
        writer.WriteString("apiVersion", apiVersion);
        writer.WriteBoolean("existing", Existing);
        writer.WritePropertyName("value");
        ((IJsonModel<BicepExpression>)Body).Write(writer, ModelReaderWriterOptions.Json);
        DecoratorsNodeSerializer.WriteDecoratorsNode(writer, Decorators);
        if (Condition != null)
        {
            writer.WritePropertyName("condition");
            ((IJsonModel<BicepExpression>)Condition).Write(writer, ModelReaderWriterOptions.Json);
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
                throw new FormatException($"The model {nameof(ResourceStatement)} does not support writing '{format}' format.");
        }
    }

    BicepStatement IPersistableModel<BicepStatement>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        throw new NotSupportedException("BicepStatement deserialization requires the statement type context. Use Infrastructure.DeserializeInfrastructure instead.");
    }

    string IPersistableModel<BicepStatement>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    public override bool Equals(BicepStatement? other) =>
        other is ResourceStatement r && Name == r.Name && Type.Equals(r.Type) && Body.Equals(r.Body) && Existing == r.Existing &&
        ((Condition == null && r.Condition == null) || (Condition != null && Condition.Equals(r.Condition))) &&
        Decorators.SequenceEqual(r.Decorators);
    public override int GetHashCode() => typeof(ResourceStatement).GetHashCode() ^ (Name?.GetHashCode() ?? 0) ^ (Type?.GetHashCode() ?? 0) ^ (Body?.GetHashCode() ?? 0) ^ Existing.GetHashCode();

    internal static ResourceStatement DeserializeResourceStatement(JsonElement element)
    {
        string name = element.GetProperty("bicepIdentifier").GetString()!;
        string type = element.GetProperty("type").GetString()!;
        string apiVersion = element.GetProperty("apiVersion").GetString()!;
        bool existing = element.TryGetProperty("existing", out JsonElement e) && e.GetBoolean();
        BicepExpression body = UnknownBicepExpression.DeserializeBicepExpression(element.GetProperty("value"));

        ResourceStatement stmt = new(name, new StringLiteralExpression($"{type}@{apiVersion}"), body);
        stmt.Existing = existing;

        DecoratorsNodeSerializer.ReadDecoratorsNode(element, stmt.Decorators);
        if (element.TryGetProperty("condition", out JsonElement condition))
        {
            stmt.Condition = UnknownBicepExpression.DeserializeBicepExpression(condition);
        }

        return stmt;
    }
}
