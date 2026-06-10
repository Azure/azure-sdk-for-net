// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.HealthcareApis.Models
{
    // Compatibility shim for the GA-only FHIR access-policy model removed from the newer service API.
    /// <summary> An access policy entry. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class FhirServiceAccessPolicyEntry : IJsonModel<FhirServiceAccessPolicyEntry>
    {
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="FhirServiceAccessPolicyEntry"/>. </summary>
        /// <param name="objectId"> An Azure AD object ID (User or Apps) that is allowed access to the FHIR service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="objectId"/> is null. </exception>
        public FhirServiceAccessPolicyEntry(string objectId)
        {
            Argument.AssertNotNull(objectId, nameof(objectId));

            ObjectId = objectId;
        }

        /// <summary> Initializes a new instance of <see cref="FhirServiceAccessPolicyEntry"/>. </summary>
        /// <param name="objectId"> An Azure AD object ID (User or Apps) that is allowed access to the FHIR service. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        public FhirServiceAccessPolicyEntry(string objectId, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Argument.AssertNotNull(objectId, nameof(objectId));

            ObjectId = objectId;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> An Azure AD object ID (User or Apps) that is allowed access to the FHIR service. </summary>
        public string ObjectId { get; set; }

        BinaryData IPersistableModel<FhirServiceAccessPolicyEntry>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        FhirServiceAccessPolicyEntry IPersistableModel<FhirServiceAccessPolicyEntry>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        string IPersistableModel<FhirServiceAccessPolicyEntry>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        void IJsonModel<FhirServiceAccessPolicyEntry>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        FhirServiceAccessPolicyEntry IJsonModel<FhirServiceAccessPolicyEntry>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        private BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<FhirServiceAccessPolicyEntry>)this).GetFormatFromOptions(options) : options.Format;
            return format switch
            {
                "J" => ModelReaderWriter.Write(this, options, AzureResourceManagerHealthcareApisContext.Default),
                _ => throw new FormatException($"The model {nameof(FhirServiceAccessPolicyEntry)} does not support writing '{options.Format}' format.")
            };
        }

        private static FhirServiceAccessPolicyEntry PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? "J" : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FhirServiceAccessPolicyEntry)} does not support reading '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeFhirServiceAccessPolicyEntry(document.RootElement, options);
        }

        private void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<FhirServiceAccessPolicyEntry>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FhirServiceAccessPolicyEntry)} does not support writing '{format}' format.");
            }

            writer.WritePropertyName("objectId"u8);
            writer.WriteStringValue(ObjectId);
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
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

        private static FhirServiceAccessPolicyEntry JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? "J" : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FhirServiceAccessPolicyEntry)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFhirServiceAccessPolicyEntry(document.RootElement, options);
        }

        internal static FhirServiceAccessPolicyEntry DeserializeFhirServiceAccessPolicyEntry(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            string objectId = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("objectId"u8))
                {
                    objectId = prop.Value.GetString();
                    continue;
                }

                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }

            return new FhirServiceAccessPolicyEntry(objectId, additionalBinaryDataProperties);
        }
    }
}
