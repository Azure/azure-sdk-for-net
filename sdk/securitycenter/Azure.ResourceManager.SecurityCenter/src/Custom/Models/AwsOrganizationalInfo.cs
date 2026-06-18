// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Custom partial for AwsOrganizationalInfo polymorphic base class.
// Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59437: the generator omits
// serialization members required by generated derived models for this discriminated base type.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Compatibility customization: preserves Azure.ResourceManager.SecurityCenter 1.1.0 public API shape during the MPG migration.
    /// <summary> AWS organizational information. </summary>
    public abstract partial class AwsOrganizationalInfo
    {
        /// <summary> Initializes a new instance of <see cref="AwsOrganizationalInfo"/>. </summary>
        protected AwsOrganizationalInfo()
        {
        }

        // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59437.
        // MPG generation omits the base JsonModelWriteCore and explicit MRW interface members for this
        // abstract discriminated base model, while generated derived models override/call the base writer.
        // Keep this custom code so the generated hierarchy compiles and preserves unknown JSON properties.
        BinaryData IPersistableModel<AwsOrganizationalInfo>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        AwsOrganizationalInfo IPersistableModel<AwsOrganizationalInfo>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<AwsOrganizationalInfo>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        void IJsonModel<AwsOrganizationalInfo>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => WriteJson(writer, options);
        AwsOrganizationalInfo IJsonModel<AwsOrganizationalInfo>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

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
