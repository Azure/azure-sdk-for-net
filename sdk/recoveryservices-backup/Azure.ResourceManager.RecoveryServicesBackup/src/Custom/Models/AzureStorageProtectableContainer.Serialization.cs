// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.ResourceManager.RecoveryServicesBackup;

namespace Azure.ResourceManager.RecoveryServicesBackup.Models
{
    /// <summary> Azure Storage-specific protectable containers. </summary>
    public partial class AzureStorageProtectableContainer : ProtectableContainer, IJsonModel<AzureStorageProtectableContainer>
    {
        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override ProtectableContainer PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AzureStorageProtectableContainer>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeAzureStorageProtectableContainer(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(AzureStorageProtectableContainer)} does not support reading '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AzureStorageProtectableContainer>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerRecoveryServicesBackupContext.Default);
                default:
                    throw new FormatException($"The model {nameof(AzureStorageProtectableContainer)} does not support writing '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        BinaryData IPersistableModel<AzureStorageProtectableContainer>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        AzureStorageProtectableContainer IPersistableModel<AzureStorageProtectableContainer>.Create(BinaryData data, ModelReaderWriterOptions options) => (AzureStorageProtectableContainer)PersistableModelCreateCore(data, options);

        /// <param name="options"> The client options for reading and writing models. </param>
        string IPersistableModel<AzureStorageProtectableContainer>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        void IJsonModel<AzureStorageProtectableContainer>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AzureStorageProtectableContainer>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AzureStorageProtectableContainer)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
        }

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        AzureStorageProtectableContainer IJsonModel<AzureStorageProtectableContainer>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (AzureStorageProtectableContainer)JsonModelCreateCore(ref reader, options);

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override ProtectableContainer JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AzureStorageProtectableContainer>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AzureStorageProtectableContainer)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeAzureStorageProtectableContainer(document.RootElement, options);
        }

        /// <param name="element"> The JSON element to deserialize. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        internal static AzureStorageProtectableContainer DeserializeAzureStorageProtectableContainer(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string friendlyName = default;
            BackupManagementType? backupManagementType = default;
            ProtectableContainerType protectableContainerType = default;
            string healthStatus = default;
            string containerId = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("friendlyName"u8))
                {
                    friendlyName = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("backupManagementType"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    backupManagementType = new BackupManagementType(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("protectableContainerType"u8))
                {
                    protectableContainerType = prop.Value.GetString().ToProtectableContainerType();
                    continue;
                }
                if (prop.NameEquals("healthStatus"u8))
                {
                    healthStatus = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("containerId"u8))
                {
                    containerId = prop.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new AzureStorageProtectableContainer(
                friendlyName,
                backupManagementType,
                protectableContainerType,
                healthStatus,
                containerId,
                additionalBinaryDataProperties);
        }
    }
}
