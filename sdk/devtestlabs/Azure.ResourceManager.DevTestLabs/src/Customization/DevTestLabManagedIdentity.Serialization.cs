// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

// This customization is here to override the serialization and deserialization for `ManagedIdentityType`
namespace Azure.ResourceManager.DevTestLabs.Models
{
    public partial class DevTestLabManagedIdentity : IUtf8JsonSerializable, IJsonModel<DevTestLabManagedIdentity>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DevTestLabManagedIdentity>)this).Write(writer, new ModelReaderWriterOptions("W"));
        void IJsonModel<DevTestLabManagedIdentity>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DevTestLabManagedIdentity>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DevTestLabManagedIdentity)} does not support '{format}' format.");
            }
            writer.WriteStartObject();
            if (Optional.IsDefined(ManagedIdentityType))
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(ManagedIdentityType.ToString());
            }
            if (Optional.IsDefined(PrincipalId))
            {
                writer.WritePropertyName("principalId"u8);
                writer.WriteStringValue(PrincipalId.Value);
            }
            if (Optional.IsDefined(TenantId))
            {
                writer.WritePropertyName("tenantId"u8);
                writer.WriteStringValue(TenantId.Value);
            }
            if (Optional.IsDefined(ClientSecretUri))
            {
                writer.WritePropertyName("clientSecretUrl"u8);
                writer.WriteStringValue(ClientSecretUri.AbsoluteUri);
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }

        DevTestLabManagedIdentity IJsonModel<DevTestLabManagedIdentity>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DevTestLabManagedIdentity>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DevTestLabManagedIdentity)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDevTestLabManagedIdentity(document.RootElement, options);
        }

        internal static DevTestLabManagedIdentity DeserializeDevTestLabManagedIdentity(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ManagedServiceIdentityType type = default;
            Guid? principalId = default;
            Guid? tenantId = default;
            Uri clientSecretUrl = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    type = new ManagedServiceIdentityType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("principalId"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    principalId = property.Value.GetGuid();
                    continue;
                }
                if (property.NameEquals("tenantId"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    tenantId = property.Value.GetGuid();
                    continue;
                }
                if (property.NameEquals("clientSecretUrl"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    clientSecretUrl = new Uri(property.Value.GetString());
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new DevTestLabManagedIdentity(type, principalId, tenantId, clientSecretUrl, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<DevTestLabManagedIdentity>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DevTestLabManagedIdentity>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerDevTestLabsContext.Default);
                default:
                    throw new FormatException($"The model {nameof(DevTestLabManagedIdentity)} does not support '{options.Format}' format.");
            }
        }

        DevTestLabManagedIdentity IPersistableModel<DevTestLabManagedIdentity>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DevTestLabManagedIdentity>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeDevTestLabManagedIdentity(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(DevTestLabManagedIdentity)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<DevTestLabManagedIdentity>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
