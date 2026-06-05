// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    public abstract partial class SecurityCenterResourceDetails
    {
        /// <summary> Initializes a new instance of <see cref="SecurityCenterResourceDetails"/>. </summary>
        protected SecurityCenterResourceDetails()
        {
        }

        // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59437.
        // MPG generation omits the base JsonModelWriteCore and explicit MRW interface members for this
        // abstract discriminated base model, while generated derived models override/call the base writer.
        // Keep this custom code so the generated hierarchy compiles and preserves unknown JSON properties.
        /// <inheritdoc/>
        BinaryData IPersistableModel<SecurityCenterResourceDetails>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        /// <inheritdoc/>
        SecurityCenterResourceDetails IPersistableModel<SecurityCenterResourceDetails>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        /// <inheritdoc/>
        string IPersistableModel<SecurityCenterResourceDetails>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <inheritdoc/>
        void IJsonModel<SecurityCenterResourceDetails>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => WriteJson(writer, options);

        /// <inheritdoc/>
        SecurityCenterResourceDetails IJsonModel<SecurityCenterResourceDetails>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        /// <summary> Writes the model payload to JSON. </summary>
        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
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
