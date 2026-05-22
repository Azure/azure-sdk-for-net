// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591, SA1402

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.SecurityCenter;

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

        BinaryData IPersistableModel<SecurityCenterTagsResourceInfo>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        SecurityCenterTagsResourceInfo IPersistableModel<SecurityCenterTagsResourceInfo>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<SecurityCenterTagsResourceInfo>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        void IJsonModel<SecurityCenterTagsResourceInfo>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => WriteJson(writer, options);
        SecurityCenterTagsResourceInfo IJsonModel<SecurityCenterTagsResourceInfo>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

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

    public abstract partial class SecurityAlertResourceIdentifier
    {
        /// <summary> Initializes a new instance of <see cref="SecurityAlertResourceIdentifier"/>. </summary>
        protected SecurityAlertResourceIdentifier()
        {
        }

        BinaryData IPersistableModel<SecurityAlertResourceIdentifier>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        SecurityAlertResourceIdentifier IPersistableModel<SecurityAlertResourceIdentifier>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<SecurityAlertResourceIdentifier>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        void IJsonModel<SecurityAlertResourceIdentifier>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => WriteJson(writer, options);
        SecurityAlertResourceIdentifier IJsonModel<SecurityAlertResourceIdentifier>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

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

    public abstract partial class SecurityCenterResourceDetails
    {
        /// <summary> Initializes a new instance of <see cref="SecurityCenterResourceDetails"/>. </summary>
        protected SecurityCenterResourceDetails()
        {
        }

        BinaryData IPersistableModel<SecurityCenterResourceDetails>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        SecurityCenterResourceDetails IPersistableModel<SecurityCenterResourceDetails>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<SecurityCenterResourceDetails>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        void IJsonModel<SecurityCenterResourceDetails>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => WriteJson(writer, options);
        SecurityCenterResourceDetails IJsonModel<SecurityCenterResourceDetails>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

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

    public abstract partial class AwsOrganizationalInfo
    {
        /// <summary> Initializes a new instance of <see cref="AwsOrganizationalInfo"/>. </summary>
        protected AwsOrganizationalInfo()
        {
        }

        BinaryData IPersistableModel<AwsOrganizationalInfo>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        AwsOrganizationalInfo IPersistableModel<AwsOrganizationalInfo>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<AwsOrganizationalInfo>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        void IJsonModel<AwsOrganizationalInfo>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => WriteJson(writer, options);
        AwsOrganizationalInfo IJsonModel<AwsOrganizationalInfo>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

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

    public abstract partial class SecurityCenterCloudOffering
    {
        /// <summary> Initializes a new instance of <see cref="SecurityCenterCloudOffering"/>. </summary>
        protected SecurityCenterCloudOffering()
        {
        }

        /// <summary> The offering description. </summary>
        public string Description { get; internal set; }

        BinaryData IPersistableModel<SecurityCenterCloudOffering>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        SecurityCenterCloudOffering IPersistableModel<SecurityCenterCloudOffering>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<SecurityCenterCloudOffering>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        void IJsonModel<SecurityCenterCloudOffering>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => WriteJson(writer, options);
        SecurityCenterCloudOffering IJsonModel<SecurityCenterCloudOffering>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (Optional.IsDefined(OfferingType))
            {
                writer.WritePropertyName("offeringType"u8);
                writer.WriteObjectValue(OfferingType, options);
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

    public abstract partial class SecuritySubAssessmentAdditionalInfo
    {
        /// <summary> Initializes a new instance of <see cref="SecuritySubAssessmentAdditionalInfo"/>. </summary>
        protected SecuritySubAssessmentAdditionalInfo()
        {
        }

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
