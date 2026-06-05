// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    public partial class SecurityCenterTagsResourceInfo
    {
        /// <summary> Initializes a new instance of <see cref="SecurityCenterTagsResourceInfo"/>. </summary>
        public SecurityCenterTagsResourceInfo()
        {
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Resource tags. </summary>
        public IDictionary<string, string> Tags { get; }

        // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59437.
        // MPG generation omits the base JsonModelWriteCore and explicit MRW interface members for this
        // abstract discriminated base model, while generated derived models override/call the base writer.
        // Keep this custom code so the generated hierarchy compiles and preserves unknown JSON properties.
        /// <inheritdoc/>
        BinaryData IPersistableModel<SecurityCenterTagsResourceInfo>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        /// <inheritdoc/>
        SecurityCenterTagsResourceInfo IPersistableModel<SecurityCenterTagsResourceInfo>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        /// <inheritdoc/>
        string IPersistableModel<SecurityCenterTagsResourceInfo>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <inheritdoc/>
        void IJsonModel<SecurityCenterTagsResourceInfo>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => WriteJson(writer, options);

        /// <inheritdoc/>
        SecurityCenterTagsResourceInfo IJsonModel<SecurityCenterTagsResourceInfo>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        /// <summary> Writes the model payload to JSON. </summary>
        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (Optional.IsCollectionDefined(Tags))
            {
                writer.WritePropertyName("tags"u8);
                writer.WriteStartObject();
                foreach (var item in Tags)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            WriteAdditionalProperties(writer, options, _additionalBinaryDataProperties);
        }

        private void WriteJson(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        private static void WriteAdditionalProperties(Utf8JsonWriter writer, ModelReaderWriterOptions options, IDictionary<string, BinaryData> additionalProperties)
        {
            if (options.Format == "W" || additionalProperties == null)
            {
                return;
            }
            foreach (var item in additionalProperties)
            {
                writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
                writer.WriteRawValue(item.Value);
#else
                using JsonDocument document = JsonDocument.Parse(item.Value);
                JsonSerializer.Serialize(writer, document.RootElement);
#endif
            }
        }
    }
}
