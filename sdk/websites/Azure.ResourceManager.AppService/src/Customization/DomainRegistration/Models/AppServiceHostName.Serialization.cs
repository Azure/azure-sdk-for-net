// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.AppService.Models
{
    public partial class AppServiceHostName : IUtf8JsonSerializable, IJsonModel<AppServiceHostName>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<AppServiceHostName>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<AppServiceHostName>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AppServiceHostName>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AppServiceHostName)} does not support writing '{format}' format.");
            }

            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsCollectionDefined(SiteNames))
            {
                writer.WritePropertyName("siteNames"u8);
                writer.WriteStartArray();
                foreach (var item in SiteNames)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(AzureResourceName))
            {
                writer.WritePropertyName("azureResourceName"u8);
                writer.WriteStringValue(AzureResourceName);
            }
            if (Optional.IsDefined(AzureResourceType))
            {
                writer.WritePropertyName("azureResourceType"u8);
                writer.WriteStringValue(AzureResourceType.Value.ToSerialString());
            }
            if (Optional.IsDefined(CustomHostNameDnsRecordType))
            {
                writer.WritePropertyName("customHostNameDnsRecordType"u8);
                writer.WriteStringValue(CustomHostNameDnsRecordType.Value.ToSerialString());
            }
            if (Optional.IsDefined(HostNameType))
            {
                writer.WritePropertyName("hostNameType"u8);
                writer.WriteStringValue(HostNameType.Value.ToSerialString());
            }
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

        AppServiceHostName IJsonModel<AppServiceHostName>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AppServiceHostName>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AppServiceHostName)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeAppServiceHostName(document.RootElement, options);
        }

        internal static AppServiceHostName DeserializeAppServiceHostName(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            IReadOnlyList<string> siteNames = default;
            string azureResourceName = default;
            AppServiceResourceType? azureResourceType = default;
            CustomHostNameDnsRecordType? customHostNameDnsRecordType = default;
            AppServiceHostNameType? hostNameType = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("siteNames"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    siteNames = array;
                    continue;
                }
                if (property.NameEquals("azureResourceName"u8))
                {
                    azureResourceName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("azureResourceType"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    azureResourceType = property.Value.GetString().ToAppServiceResourceType();
                    continue;
                }
                if (property.NameEquals("customHostNameDnsRecordType"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    customHostNameDnsRecordType = property.Value.GetString().ToCustomHostNameDnsRecordType();
                    continue;
                }
                if (property.NameEquals("hostNameType"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    hostNameType = property.Value.GetString().ToAppServiceHostNameType();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new AppServiceHostName(
                name,
                siteNames ?? new ChangeTrackingList<string>(),
                azureResourceName,
                azureResourceType,
                customHostNameDnsRecordType,
                hostNameType,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<AppServiceHostName>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AppServiceHostName>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerAppServiceContext.Default);
                default:
                    throw new FormatException($"The model {nameof(AppServiceHostName)} does not support writing '{options.Format}' format.");
            }
        }

        AppServiceHostName IPersistableModel<AppServiceHostName>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AppServiceHostName>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeAppServiceHostName(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(AppServiceHostName)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<AppServiceHostName>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
