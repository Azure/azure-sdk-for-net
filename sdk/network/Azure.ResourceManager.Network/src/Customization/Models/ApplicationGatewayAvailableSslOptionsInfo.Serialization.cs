// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network.Models
{
    public partial class ApplicationGatewayAvailableSslOptionsInfo : IJsonModel<ApplicationGatewayAvailableSslOptionsInfo>, IPersistableModel<ApplicationGatewayAvailableSslOptionsInfo>
    {
        void IJsonModel<ApplicationGatewayAvailableSslOptionsInfo>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <summary> Writes the model as JSON. </summary>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            base.JsonModelWriteCore(writer, options);
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(PredefinedPolicies))
            {
                writer.WritePropertyName("predefinedPolicies"u8);
                writer.WriteStartArray();
                foreach (WritableSubResource item in PredefinedPolicies)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(DefaultPolicy))
            {
                writer.WritePropertyName("defaultPolicy"u8);
                writer.WriteStringValue(DefaultPolicy.Value.ToString());
            }
            if (Optional.IsCollectionDefined(AvailableCipherSuites))
            {
                writer.WritePropertyName("availableCipherSuites"u8);
                writer.WriteStartArray();
                foreach (ApplicationGatewaySslCipherSuite item in AvailableCipherSuites)
                {
                    writer.WriteStringValue(item.ToString());
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(AvailableProtocols))
            {
                writer.WritePropertyName("availableProtocols"u8);
                writer.WriteStartArray();
                foreach (ApplicationGatewaySslProtocol item in AvailableProtocols)
                {
                    writer.WriteStringValue(item.ToString());
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        ApplicationGatewayAvailableSslOptionsInfo IJsonModel<ApplicationGatewayAvailableSslOptionsInfo>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => (ApplicationGatewayAvailableSslOptionsInfo)JsonModelCreateCore(ref reader, options);

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override NetworkTrackedResourceData JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            ValidateReadFormat(options);
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeApplicationGatewayAvailableSslOptionsInfo(document.RootElement, options);
        }

        internal static ApplicationGatewayAvailableSslOptionsInfo DeserializeApplicationGatewayAvailableSslOptionsInfo(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ResourceIdentifier id = default;
            string name = default;
            ResourceType? resourceType = default;
            AzureLocation? location = default;
            IDictionary<string, string> tags = default;
            IList<WritableSubResource> predefinedPolicies = default;
            ApplicationGatewaySslPolicyName? defaultPolicy = default;
            IList<ApplicationGatewaySslCipherSuite> availableCipherSuites = default;
            IList<ApplicationGatewaySslProtocol> availableProtocols = default;
            var additionalBinaryDataProperties = new Dictionary<string, BinaryData>();
            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    if (property.Value.ValueKind != JsonValueKind.Null)
                    {
                        // Retain the released workaround for service IDs containing an empty resource group.
                        id = new ResourceIdentifier(property.Value.GetString().Replace("resourceGroups//", string.Empty));
                    }
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    if (property.Value.ValueKind != JsonValueKind.Null)
                    {
                        resourceType = new ResourceType(property.Value.GetString());
                    }
                    continue;
                }
                if (property.NameEquals("location"u8))
                {
                    if (property.Value.ValueKind != JsonValueKind.Null)
                    {
                        location = new AzureLocation(property.Value.GetString());
                    }
                    continue;
                }
                if (property.NameEquals("tags"u8))
                {
                    if (property.Value.ValueKind != JsonValueKind.Null)
                    {
                        tags = new Dictionary<string, string>();
                        foreach (JsonProperty tag in property.Value.EnumerateObject())
                        {
                            tags.Add(tag.Name, tag.Value.GetString());
                        }
                    }
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    foreach (JsonProperty member in property.Value.EnumerateObject())
                    {
                        if (member.Value.ValueKind == JsonValueKind.Null)
                        {
                            continue;
                        }
                        if (member.NameEquals("predefinedPolicies"u8))
                        {
                            predefinedPolicies = new List<WritableSubResource>();
                            foreach (JsonElement item in member.Value.EnumerateArray())
                            {
                                string json = item.ToString().Replace("resourceGroups//", string.Empty);
                                predefinedPolicies.Add(ModelReaderWriter.Read<WritableSubResource>(BinaryData.FromString(json), ModelSerializationExtensions.WireOptions, AzureResourceManagerNetworkContext.Default));
                            }
                            continue;
                        }
                        if (member.NameEquals("defaultPolicy"u8))
                        {
                            defaultPolicy = new ApplicationGatewaySslPolicyName(member.Value.GetString());
                            continue;
                        }
                        if (member.NameEquals("availableCipherSuites"u8))
                        {
                            availableCipherSuites = new List<ApplicationGatewaySslCipherSuite>();
                            foreach (JsonElement item in member.Value.EnumerateArray())
                            {
                                availableCipherSuites.Add(new ApplicationGatewaySslCipherSuite(item.GetString()));
                            }
                            continue;
                        }
                        if (member.NameEquals("availableProtocols"u8))
                        {
                            availableProtocols = new List<ApplicationGatewaySslProtocol>();
                            foreach (JsonElement item in member.Value.EnumerateArray())
                            {
                                availableProtocols.Add(new ApplicationGatewaySslProtocol(item.GetString()));
                            }
                        }
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            return new ApplicationGatewayAvailableSslOptionsInfo(id, name, resourceType, location,
                tags ?? new ChangeTrackingDictionary<string, string>(), additionalBinaryDataProperties,
                predefinedPolicies ?? new ChangeTrackingList<WritableSubResource>(), defaultPolicy,
                availableCipherSuites ?? new ChangeTrackingList<ApplicationGatewaySslCipherSuite>(),
                availableProtocols ?? new ChangeTrackingList<ApplicationGatewaySslProtocol>());
        }

        BinaryData IPersistableModel<ApplicationGatewayAvailableSslOptionsInfo>.Write(ModelReaderWriterOptions options)
            => PersistableModelWriteCore(options);

        ApplicationGatewayAvailableSslOptionsInfo IPersistableModel<ApplicationGatewayAvailableSslOptionsInfo>.Create(BinaryData data, ModelReaderWriterOptions options)
            => (ApplicationGatewayAvailableSslOptionsInfo)PersistableModelCreateCore(data, options);

        string IPersistableModel<ApplicationGatewayAvailableSslOptionsInfo>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override NetworkTrackedResourceData PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            ValidateReadFormat(options);
            using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeApplicationGatewayAvailableSslOptionsInfo(document.RootElement, options);
        }

        private static void ValidateReadFormat(ModelReaderWriterOptions options)
        {
            if (options.Format != "J" && options.Format != "W")
            {
                throw new FormatException($"The model {nameof(ApplicationGatewayAvailableSslOptionsInfo)} does not support reading '{options.Format}' format.");
            }
        }
    }
}
