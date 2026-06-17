// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Custom partial for SecuritySubAssessmentAdditionalInfo polymorphic base class.
// TypeSpec generates this, but custom code provides additional constructors or helpers.
// CS1591 disabled due to generator limitation tracked in https://github.com/Azure/azure-sdk-for-net/issues/59437.
#pragma warning disable CS1591

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    public abstract partial class SecuritySubAssessmentAdditionalInfo
    {
        /// <summary> Initializes a new instance of <see cref="SecuritySubAssessmentAdditionalInfo"/>. </summary>
        protected SecuritySubAssessmentAdditionalInfo()
        {
        }

        // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59437.
        // MPG generation omits the base JsonModelWriteCore and explicit MRW interface members for this
        // abstract discriminated base model, while generated derived models override/call the base writer.
        // Keep this custom code so the generated hierarchy compiles and preserves unknown JSON properties.
        BinaryData IPersistableModel<SecuritySubAssessmentAdditionalInfo>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        SecuritySubAssessmentAdditionalInfo IPersistableModel<SecuritySubAssessmentAdditionalInfo>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<SecuritySubAssessmentAdditionalInfo>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        void IJsonModel<SecuritySubAssessmentAdditionalInfo>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => WriteJson(writer, options);
        SecuritySubAssessmentAdditionalInfo IJsonModel<SecuritySubAssessmentAdditionalInfo>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

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
