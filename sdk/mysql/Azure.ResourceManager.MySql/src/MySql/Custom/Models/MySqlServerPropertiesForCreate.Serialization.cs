// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.MySql.Models
{
    [PersistableModelProxy(typeof(UnknownServerPropertiesForCreate))]
    public partial class MySqlServerPropertiesForCreate : IUtf8JsonSerializable, IJsonModel<MySqlServerPropertiesForCreate>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<MySqlServerPropertiesForCreate>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<MySqlServerPropertiesForCreate>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MySqlServerPropertiesForCreate>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MySqlServerPropertiesForCreate)} does not support writing '{format}' format.");
            }

            if (Optional.IsDefined(Version))
            {
                writer.WritePropertyName("version"u8);
                writer.WriteStringValue(Version.Value.ToString());
            }
            if (Optional.IsDefined(SslEnforcement))
            {
                writer.WritePropertyName("sslEnforcement"u8);
                writer.WriteStringValue(SslEnforcement.Value.ToSerialString());
            }
            if (Optional.IsDefined(MinimalTlsVersion))
            {
                writer.WritePropertyName("minimalTlsVersion"u8);
                writer.WriteStringValue(MinimalTlsVersion.Value.ToString());
            }
            if (Optional.IsDefined(InfrastructureEncryption))
            {
                writer.WritePropertyName("infrastructureEncryption"u8);
                writer.WriteStringValue(InfrastructureEncryption.Value.ToString());
            }
            if (Optional.IsDefined(PublicNetworkAccess))
            {
                writer.WritePropertyName("publicNetworkAccess"u8);
                writer.WriteStringValue(PublicNetworkAccess.Value.ToString());
            }
            if (Optional.IsDefined(StorageProfile))
            {
                writer.WritePropertyName("storageProfile"u8);
                writer.WriteObjectValue(StorageProfile, options);
            }
            writer.WritePropertyName("createMode"u8);
            writer.WriteStringValue(CreateMode.ToString());
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        MySqlServerPropertiesForCreate IJsonModel<MySqlServerPropertiesForCreate>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MySqlServerPropertiesForCreate>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MySqlServerPropertiesForCreate)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMySqlServerPropertiesForCreate(document.RootElement, options);
        }

        internal static MySqlServerPropertiesForCreate DeserializeMySqlServerPropertiesForCreate(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("createMode", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "Default": return MySqlServerPropertiesForDefaultCreate.DeserializeMySqlServerPropertiesForDefaultCreate(element, options);
                    case "GeoRestore": return MySqlServerPropertiesForGeoRestore.DeserializeMySqlServerPropertiesForGeoRestore(element, options);
                    case "PointInTimeRestore": return MySqlServerPropertiesForRestore.DeserializeMySqlServerPropertiesForRestore(element, options);
                    case "Replica": return MySqlServerPropertiesForReplica.DeserializeMySqlServerPropertiesForReplica(element, options);
                }
            }
            return UnknownServerPropertiesForCreate.DeserializeUnknownServerPropertiesForCreate(element, options);
        }

        BinaryData IPersistableModel<MySqlServerPropertiesForCreate>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MySqlServerPropertiesForCreate>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerMySqlContext.Default);
                default:
                    throw new FormatException($"The model {nameof(MySqlServerPropertiesForCreate)} does not support writing '{options.Format}' format.");
            }
        }

        MySqlServerPropertiesForCreate IPersistableModel<MySqlServerPropertiesForCreate>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MySqlServerPropertiesForCreate>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeMySqlServerPropertiesForCreate(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(MySqlServerPropertiesForCreate)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<MySqlServerPropertiesForCreate>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}