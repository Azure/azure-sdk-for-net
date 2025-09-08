// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.MySql.Models
{
    internal partial class UnknownServerPropertiesForCreate : IUtf8JsonSerializable, IJsonModel<MySqlServerPropertiesForCreate>
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
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MySqlServerPropertiesForCreate>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MySqlServerPropertiesForCreate)} does not support writing '{format}' format.");
            }

            base.JsonModelWriteCore(writer, options);
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

        internal static UnknownServerPropertiesForCreate DeserializeUnknownServerPropertiesForCreate(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            MySqlServerVersion? version = default;
            MySqlSslEnforcementEnum? sslEnforcement = default;
            MySqlMinimalTlsVersionEnum? minimalTlsVersion = default;
            MySqlInfrastructureEncryption? infrastructureEncryption = default;
            MySqlPublicNetworkAccessEnum? publicNetworkAccess = default;
            MySqlStorageProfile storageProfile = default;
            MySqlCreateMode createMode = "Unknown";
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("version"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    version = new MySqlServerVersion(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("sslEnforcement"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    sslEnforcement = property.Value.GetString().ToMySqlSslEnforcementEnum();
                    continue;
                }
                if (property.NameEquals("minimalTlsVersion"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    minimalTlsVersion = new MySqlMinimalTlsVersionEnum(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("infrastructureEncryption"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    infrastructureEncryption = new MySqlInfrastructureEncryption(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("publicNetworkAccess"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    publicNetworkAccess = new MySqlPublicNetworkAccessEnum(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("storageProfile"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    storageProfile = MySqlStorageProfile.DeserializeMySqlStorageProfile(property.Value, options);
                    continue;
                }
                if (property.NameEquals("createMode"u8))
                {
                    createMode = new MySqlCreateMode(property.Value.GetString());
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new UnknownServerPropertiesForCreate(
                version,
                sslEnforcement,
                minimalTlsVersion,
                infrastructureEncryption,
                publicNetworkAccess,
                storageProfile,
                createMode,
                serializedAdditionalRawData);
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