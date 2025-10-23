// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ContainerService.Models
{
    public partial class ManagedClusterIdentity : IUtf8JsonSerializable, IJsonModel<ManagedClusterIdentity>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ManagedClusterIdentity>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<ManagedClusterIdentity>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ManagedClusterIdentity>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ManagedClusterIdentity)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (options.Format != "W" && Optional.IsDefined(PrincipalId))
            {
                writer.WritePropertyName("principalId"u8);
                writer.WriteStringValue(PrincipalId.Value);
            }
            if (options.Format != "W" && Optional.IsDefined(TenantId))
            {
                writer.WritePropertyName("tenantId"u8);
                writer.WriteStringValue(TenantId.Value);
            }
            if (Optional.IsDefined(ResourceIdentityType))
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(ResourceIdentityType.ToString());
            }
            if (Optional.IsCollectionDefined(DelegatedResources))
            {
                writer.WritePropertyName("delegatedResources"u8);
                writer.WriteStartObject();
                foreach (var item in DelegatedResources)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteObjectValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (Optional.IsCollectionDefined(UserAssignedIdentities))
            {
                writer.WritePropertyName("userAssignedIdentities"u8);
                writer.WriteStartObject();
                foreach (var item in UserAssignedIdentities)
                {
                    writer.WritePropertyName(item.Key);
                    ((IJsonModel<UserAssignedIdentity>)item.Value).Write(writer, options);
                }
                writer.WriteEndObject();
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

        ManagedClusterIdentity IJsonModel<ManagedClusterIdentity>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ManagedClusterIdentity>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ManagedClusterIdentity)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeManagedClusterIdentity(document.RootElement, options);
        }

        internal static ManagedClusterIdentity DeserializeManagedClusterIdentity(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Guid? principalId = default;
            Guid? tenantId = default;
            ManagedServiceIdentityType type = default;
            IDictionary<string, ManagedClusterDelegatedIdentity> delegatedResources = default;
            IDictionary<ResourceIdentifier, UserAssignedIdentity> userAssignedIdentities = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
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
                if (property.NameEquals("type"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    type = ToResourceIdentityType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("delegatedResources"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, ManagedClusterDelegatedIdentity> dictionary = new Dictionary<string, ManagedClusterDelegatedIdentity>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, ManagedClusterDelegatedIdentity.DeserializeManagedClusterDelegatedIdentity(property0.Value));
                    }
                    delegatedResources = dictionary;
                    continue;
                }
                if (property.NameEquals("userAssignedIdentities"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<ResourceIdentifier, UserAssignedIdentity> dictionary = new Dictionary<ResourceIdentifier, UserAssignedIdentity>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(new ResourceIdentifier(property0.Name), ModelReaderWriter.Read<UserAssignedIdentity>(new BinaryData(Encoding.UTF8.GetBytes(property0.Value.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerContainerServiceContext.Default));
                    }
                    userAssignedIdentities = dictionary;
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new ManagedClusterIdentity(principalId, tenantId, type, delegatedResources ?? new ChangeTrackingDictionary<string, ManagedClusterDelegatedIdentity>(), userAssignedIdentities ?? new ChangeTrackingDictionary<ResourceIdentifier, UserAssignedIdentity>(), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ManagedClusterIdentity>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ManagedClusterIdentity>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerContainerServiceContext.Default);
                default:
                    throw new FormatException($"The model {nameof(ManagedClusterIdentity)} does not support '{options.Format}' format.");
            }
        }

        ManagedClusterIdentity IPersistableModel<ManagedClusterIdentity>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ManagedClusterIdentity>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeManagedClusterIdentity(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ManagedClusterIdentity)} does not support '{options.Format}' format.");
            }
        }

        internal static ManagedServiceIdentityType ToResourceIdentityType(string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "None")) return ManagedServiceIdentityType.None;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "SystemAssigned")) return ManagedServiceIdentityType.SystemAssigned;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "UserAssigned")) return ManagedServiceIdentityType.UserAssigned;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ResourceIdentityType value.");
        }

        string IPersistableModel<ManagedClusterIdentity>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
