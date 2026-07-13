// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Reference to another subresource. </summary>
    public partial class RoutingConfigurationNfvSubResource : IJsonModel<RoutingConfigurationNfvSubResource>
    {
        private readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="RoutingConfigurationNfvSubResource"/>. </summary>
        public RoutingConfigurationNfvSubResource()
        {
        }

        internal RoutingConfigurationNfvSubResource(string id, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            ResourceUri = id is null ? null : new Uri(id, UriKind.RelativeOrAbsolute);
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> Resource ID. </summary>
        public Uri ResourceUri { get; set; }

        BinaryData IPersistableModel<RoutingConfigurationNfvSubResource>.Write(ModelReaderWriterOptions options)
        {
            return ModelReaderWriter.Write(this, options, AzureResourceManagerNetworkContext.Default);
        }

        RoutingConfigurationNfvSubResource IPersistableModel<RoutingConfigurationNfvSubResource>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeRoutingConfigurationNfvSubResource(document.RootElement, options);
        }

        string IPersistableModel<RoutingConfigurationNfvSubResource>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        void IJsonModel<RoutingConfigurationNfvSubResource>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(ResourceUri))
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(ResourceUri.IsAbsoluteUri ? ResourceUri.AbsoluteUri : ResourceUri.OriginalString);
            }
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
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

        RoutingConfigurationNfvSubResource IJsonModel<RoutingConfigurationNfvSubResource>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRoutingConfigurationNfvSubResource(document.RootElement, options);
        }

        internal static RoutingConfigurationNfvSubResource DeserializeRoutingConfigurationNfvSubResource(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            string id = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("id"u8))
                {
                    id = prop.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new RoutingConfigurationNfvSubResource(id, additionalBinaryDataProperties);
        }
    }
}
