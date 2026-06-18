// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Custom partial for SecurityAlertResourceIdentifier polymorphic base class.
// Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59437: the generator omits
// serialization members required by generated derived models for this discriminated base type.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The current TypeSpec models alert resource identifiers through regenerated derived details, but GA exposed this abstract base type; keep its protected constructor for custom or test derivation.
    /// <summary> Resource identifier for a security alert entity. </summary>
    public abstract partial class SecurityAlertResourceIdentifier
    {
        /// <summary> Initializes a new instance of <see cref="SecurityAlertResourceIdentifier"/>. </summary>
        protected SecurityAlertResourceIdentifier()
        {
        }

        // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59437.
        // MPG generation omits the base JsonModelWriteCore and explicit MRW interface members for this
        // abstract discriminated base model, while generated derived models override/call the base writer.
        // Keep this custom code so the generated hierarchy compiles and preserves unknown JSON properties.
        BinaryData IPersistableModel<SecurityAlertResourceIdentifier>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        SecurityAlertResourceIdentifier IPersistableModel<SecurityAlertResourceIdentifier>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<SecurityAlertResourceIdentifier>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        void IJsonModel<SecurityAlertResourceIdentifier>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => WriteJson(writer, options);
        SecurityAlertResourceIdentifier IJsonModel<SecurityAlertResourceIdentifier>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        /// <summary> Writes the JSON representation of the model. </summary>
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
