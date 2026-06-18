// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable SA1649 // File name should match first type name

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.ApiManagement.Models
{
    internal static class ApiManagementCompatibilityTypeExtensions
    {
        internal static GatewayRegenerateKeyType ToGatewayRegenerateKeyType(this string value)
            => value?.ToLowerInvariant() switch
            {
                "primary" => GatewayRegenerateKeyType.Primary,
                "secondary" => GatewayRegenerateKeyType.Secondary,
                _ => default
            };

        internal static string ToSerialString(this GatewayRegenerateKeyType value)
            => value switch
            {
                GatewayRegenerateKeyType.Primary => "primary",
                GatewayRegenerateKeyType.Secondary => "secondary",
                _ => null
            };
    }

    /// <summary> HTTP header and its value. </summary>
    public partial class HttpHeaderConfiguration : IJsonModel<HttpHeaderConfiguration>, IPersistableModel<HttpHeaderConfiguration>
    {
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="HttpHeaderConfiguration"/>. </summary>
        /// <param name="name"> Header name. </param>
        /// <param name="value"> Header value. </param>
        public HttpHeaderConfiguration(string name, string value)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(value, nameof(value));

            Name = name;
            Value = value;
        }

        internal HttpHeaderConfiguration(string name, string value, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Name = name;
            Value = value;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> Header name. </summary>
        [WirePath("name")]
        public string Name { get; set; }

        /// <summary> Header value. </summary>
        [WirePath("value")]
        public string Value { get; set; }

        internal static HttpHeaderConfiguration DeserializeHttpHeaderConfiguration(JsonElement element, ModelReaderWriterOptions options)
        {
            string name = default;
            string value = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = default;
            foreach (JsonProperty prop in element.EnumerateObject())
            {
                if (prop.NameEquals("name"u8))
                {
                    name = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("value"u8))
                {
                    value = prop.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties ??= new Dictionary<string, BinaryData>();
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new HttpHeaderConfiguration(name, value, additionalBinaryDataProperties);
        }

        void IJsonModel<HttpHeaderConfiguration>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<HttpHeaderConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(HttpHeaderConfiguration)} does not support writing '{format}' format.");
            }
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WritePropertyName("value"u8);
            writer.WriteStringValue(Value);
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
            {
                foreach (KeyValuePair<string, BinaryData> item in _additionalBinaryDataProperties)
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
        }

        HttpHeaderConfiguration IJsonModel<HttpHeaderConfiguration>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeHttpHeaderConfiguration(document.RootElement, options);
        }

        BinaryData IPersistableModel<HttpHeaderConfiguration>.Write(ModelReaderWriterOptions options)
        {
            using MemoryStream stream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            ((IJsonModel<HttpHeaderConfiguration>)this).Write(writer, options);
            writer.Flush();
            return BinaryData.FromBytes(stream.ToArray());
        }

        HttpHeaderConfiguration IPersistableModel<HttpHeaderConfiguration>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeHttpHeaderConfiguration(document.RootElement, options);
        }

        string IPersistableModel<HttpHeaderConfiguration>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }

    /// <summary> The Key being regenerated. </summary>
    public enum GatewayRegenerateKeyType
    {
        /// <summary> Primary. </summary>
        Primary = 0,

        /// <summary> Secondary. </summary>
        Secondary = 1
    }
}
