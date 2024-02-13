// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Text.RegularExpressions;
using Azure.Core;

[assembly: CodeGenSuppressType("HDInsightClusterGatewaySettings")]

namespace Azure.ResourceManager.HDInsight.Models
{
    public partial class HDInsightClusterGatewaySettings : IUtf8JsonSerializable, IJsonModel<HDInsightClusterGatewaySettings>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<HDInsightClusterGatewaySettings>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<HDInsightClusterGatewaySettings>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<HDInsightClusterGatewaySettings>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(HDInsightClusterGatewaySettings)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(IsCredentialEnabled))
            {
                writer.WritePropertyName("restAuthCredential.isEnabled"u8);
                writer.WriteBooleanValue(IsCredentialEnabled.Value);
            }
            if (Optional.IsDefined(UserName))
            {
                writer.WritePropertyName("restAuthCredential.username"u8);
                writer.WriteStringValue(UserName);
            }
            if (Optional.IsDefined(Password))
            {
                writer.WritePropertyName("restAuthCredential.password"u8);
                writer.WriteStringValue(Password);
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

        HDInsightClusterGatewaySettings IJsonModel<HDInsightClusterGatewaySettings>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<HDInsightClusterGatewaySettings>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(HDInsightClusterGatewaySettings)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeHDInsightClusterGatewaySettings(document.RootElement, options);
        }
            internal static HDInsightClusterGatewaySettings DeserializeHDInsightClusterGatewaySettings(JsonElement element, ModelReaderWriterOptions options = null)
            {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<bool> restAuthCredentialIsEnabled = default;
            Optional<string> restAuthCredentialUsername = default;
            Optional<string> restAuthCredentialPassword = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
                {
                    if (property.NameEquals("restAuthCredential.isEnabled"u8))
                    {
                        if (property.Value.ValueKind == JsonValueKind.Null)
                        {
                            property.ThrowNonNullablePropertyIsNull();
                            continue;
                        }
                        if (property.Value.ValueKind == JsonValueKind.String)
                        {
                            restAuthCredentialIsEnabled = bool.Parse(property.Value.GetString());
                            continue;
                        }
                        restAuthCredentialIsEnabled = property.Value.GetBoolean();
                        continue;
                    }
                    if (property.NameEquals("restAuthCredential.username"u8))
                    {
                        restAuthCredentialUsername = property.Value.GetString();
                        continue;
                    }
                    if (property.NameEquals("restAuthCredential.password"u8))
                    {
                        restAuthCredentialPassword = property.Value.GetString();
                        continue;
                    }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new HDInsightClusterGatewaySettings(Optional.ToNullable(restAuthCredentialIsEnabled), restAuthCredentialUsername.Value, restAuthCredentialPassword.Value, serializedAdditionalRawData);
            }
            BinaryData IPersistableModel<HDInsightClusterGatewaySettings>.Write(ModelReaderWriterOptions options)
        {
                var format = options.Format == "W" ? ((IPersistableModel<HDInsightClusterGatewaySettings>)this).GetFormatFromOptions(options) : options.Format;

                switch (format)
                {
                    case "J":
                        return ModelReaderWriter.Write(this, options);
                    default:
                        throw new FormatException($"The model {nameof(HDInsightClusterGatewaySettings)} does not support '{options.Format}' format.");
                }
            }

        HDInsightClusterGatewaySettings IPersistableModel<HDInsightClusterGatewaySettings>.Create(BinaryData data, ModelReaderWriterOptions options)
            {
                var format = options.Format == "W" ? ((IPersistableModel<HDInsightClusterGatewaySettings>)this).GetFormatFromOptions(options) : options.Format;

                switch (format)
                {
                    case "J":
                        {
                            using JsonDocument document = JsonDocument.Parse(data);
                            return DeserializeHDInsightClusterGatewaySettings(document.RootElement, options);
                        }
                    default:
                        throw new FormatException($"The model {nameof(HDInsightClusterGatewaySettings)} does not support '{options.Format}' format.");
                }
            }
            string IPersistableModel<HDInsightClusterGatewaySettings>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
