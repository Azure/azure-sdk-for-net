// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class DiskCreationData : IUtf8JsonSerializable, IJsonModel<DiskCreationData>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DiskCreationData>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<DiskCreationData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DiskCreationData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DiskCreationData)} does not support writing '{format}' format.");
            }

            writer.WritePropertyName("createOption"u8);
            writer.WriteStringValue(CreateOption.ToString());
            if (Optional.IsDefined(StorageAccountId))
            {
                writer.WritePropertyName("storageAccountId"u8);
                writer.WriteStringValue(StorageAccountId);
            }
            if (Optional.IsDefined(ImageReference))
            {
                writer.WritePropertyName("imageReference"u8);
                writer.WriteObjectValue(ImageReference, options);
            }
            if (Optional.IsDefined(GalleryImageReference))
            {
                writer.WritePropertyName("galleryImageReference"u8);
                writer.WriteObjectValue(GalleryImageReference, options);
            }
            if (Optional.IsDefined(SourceUri))
            {
                writer.WritePropertyName("sourceUri"u8);
                writer.WriteStringValue(SourceUri.AbsoluteUri);
            }
            if (Optional.IsDefined(SourceResourceId))
            {
                writer.WritePropertyName("sourceResourceId"u8);
                writer.WriteStringValue(SourceResourceId);
            }
            if (options.Format != "W" && Optional.IsDefined(SourceUniqueId))
            {
                writer.WritePropertyName("sourceUniqueId"u8);
                writer.WriteStringValue(SourceUniqueId);
            }
            if (Optional.IsDefined(UploadSizeBytes))
            {
                writer.WritePropertyName("uploadSizeBytes"u8);
                writer.WriteNumberValue(UploadSizeBytes.Value);
            }
            if (Optional.IsDefined(LogicalSectorSize))
            {
                writer.WritePropertyName("logicalSectorSize"u8);
                writer.WriteNumberValue(LogicalSectorSize.Value);
            }
            if (Optional.IsDefined(SecurityDataUri))
            {
                writer.WritePropertyName("securityDataUri"u8);
                writer.WriteStringValue(SecurityDataUri.AbsoluteUri);
            }
            if (Optional.IsDefined(SecurityMetadataUri))
            {
                writer.WritePropertyName("securityMetadataUri"u8);
                writer.WriteStringValue(SecurityMetadataUri.AbsoluteUri);
            }
            if (Optional.IsDefined(IsPerformancePlusEnabled))
            {
                writer.WritePropertyName("performancePlus"u8);
                writer.WriteBooleanValue(IsPerformancePlusEnabled.Value);
            }
            if (Optional.IsDefined(ElasticSanResourceId))
            {
                writer.WritePropertyName("elasticSanResourceId"u8);
                writer.WriteStringValue(ElasticSanResourceId);
            }
            if (Optional.IsDefined(ProvisionedBandwidthCopySpeed))
            {
                writer.WritePropertyName("provisionedBandwidthCopySpeed"u8);
                writer.WriteStringValue(ProvisionedBandwidthCopySpeed.Value.ToString());
            }
            if (Optional.IsDefined(InstantAccessDurationMinutes))
            {
                writer.WritePropertyName("instantAccessDurationMinutes"u8);
                writer.WriteNumberValue(InstantAccessDurationMinutes.Value);
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

        DiskCreationData IJsonModel<DiskCreationData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DiskCreationData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DiskCreationData)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDiskCreationData(document.RootElement, options);
        }

        internal static DiskCreationData DeserializeDiskCreationData(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            DiskCreateOption createOption = default;
            ResourceIdentifier storageAccountId = default;
            ImageDiskReference imageReference = default;
            ImageDiskReference galleryImageReference = default;
            Uri sourceUri = default;
            ResourceIdentifier sourceResourceId = default;
            string sourceUniqueId = default;
            long? uploadSizeBytes = default;
            int? logicalSectorSize = default;
            Uri securityDataUri = default;
            Uri securityMetadataUri = default;
            bool? performancePlus = default;
            ResourceIdentifier elasticSanResourceId = default;
            ProvisionedBandwidthCopyOption? provisionedBandwidthCopySpeed = default;
            long? instantAccessDurationMinutes = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("createOption"u8))
                {
                    createOption = new DiskCreateOption(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("storageAccountId"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    storageAccountId = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("imageReference"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    imageReference = ImageDiskReference.DeserializeImageDiskReference(property.Value, options);
                    continue;
                }
                if (property.NameEquals("galleryImageReference"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    galleryImageReference = ImageDiskReference.DeserializeImageDiskReference(property.Value, options);
                    continue;
                }
                if (property.NameEquals("sourceUri"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    sourceUri = new Uri(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("sourceResourceId"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    sourceResourceId = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("sourceUniqueId"u8))
                {
                    sourceUniqueId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("uploadSizeBytes"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    uploadSizeBytes = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("logicalSectorSize"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    logicalSectorSize = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("securityDataUri"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    securityDataUri = new Uri(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("securityMetadataUri"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    securityMetadataUri = new Uri(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("performancePlus"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    performancePlus = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("elasticSanResourceId"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    elasticSanResourceId = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("provisionedBandwidthCopySpeed"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    provisionedBandwidthCopySpeed = new ProvisionedBandwidthCopyOption(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("instantAccessDurationMinutes"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    instantAccessDurationMinutes = property.Value.GetInt64();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new DiskCreationData(
                createOption,
                storageAccountId,
                imageReference,
                galleryImageReference,
                sourceUri,
                sourceResourceId,
                sourceUniqueId,
                uploadSizeBytes,
                logicalSectorSize,
                securityDataUri,
                securityMetadataUri,
                performancePlus,
                elasticSanResourceId,
                provisionedBandwidthCopySpeed,
                instantAccessDurationMinutes,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<DiskCreationData>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DiskCreationData>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerComputeContext.Default);
                default:
                    throw new FormatException($"The model {nameof(DiskCreationData)} does not support writing '{options.Format}' format.");
            }
        }

        DiskCreationData IPersistableModel<DiskCreationData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DiskCreationData>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeDiskCreationData(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(DiskCreationData)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<DiskCreationData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
