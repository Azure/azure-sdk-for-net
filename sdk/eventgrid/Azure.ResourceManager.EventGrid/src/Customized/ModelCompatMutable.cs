#pragma warning disable SA1402

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;

[assembly: CodeGenSuppressType("EventTypeUnderTopic")]
[assembly: CodeGenSuppressType("PartnerDetails")]
[assembly: CodeGenSuppressType("TopicTypeAdditionalEnforcedPermission")]

namespace Azure.ResourceManager.EventGrid.Models
{
    // These replacements preserve GA mutable model shapes that changed during the Swagger -> TypeSpec migration.
    public partial class EventTypeUnderTopic : ResourceData, IJsonModel<EventTypeUnderTopic>, IPersistableModel<EventTypeUnderTopic>
    {
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;
        private string _displayName;
        private string _description;
        private Uri _schemaUri;
        private bool? _isInDefaultSet;

        /// <summary> Initializes a new instance of the <see cref="EventTypeUnderTopic"/> class. </summary>
        public EventTypeUnderTopic()
        {
        }

        internal EventTypeUnderTopic(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, EventTypeProperties properties, IDictionary<string, BinaryData> additionalBinaryDataProperties)
            : base(id, name, resourceType, systemData)
        {
            _displayName = properties?.DisplayName;
            _description = properties?.Description;
            _schemaUri = properties?.SchemaUri;
            _isInDefaultSet = properties?.IsInDefaultSet;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> Gets or sets the display name. </summary>
        [WirePath("properties.displayName")]
        public string DisplayName
        {
            get => _displayName;
            set => _displayName = value;
        }

        /// <summary> Gets or sets the description. </summary>
        [WirePath("properties.description")]
        public string Description
        {
            get => _description;
            set => _description = value;
        }

        /// <summary> Gets or sets the schema uri. </summary>
        [WirePath("properties.schemaUrl")]
        public Uri SchemaUri
        {
            get => _schemaUri;
            set => _schemaUri = value;
        }

        /// <summary> Gets or sets the is in default set. </summary>
        [WirePath("properties.isInDefaultSet")]
        public bool? IsInDefaultSet
        {
            get => _isInDefaultSet;
            set => _isInDefaultSet = value;
        }

        /// <summary> Creates a GA-compatible event type under topic model from a serialized payload. </summary>
        /// <param name="data"> The serialized model payload. </param>
        /// <param name="options"> The model reader/writer options. </param>
        /// <returns> The deserialized GA-compatible event type under topic model. </returns>
        protected virtual ResourceData PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<EventTypeUnderTopic>)this).GetFormatFromOptions(options) : options.Format;
            return format switch
            {
                "J" => DeserializeEventTypeUnderTopic(JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions).RootElement, options),
                _ => throw new FormatException($"The model {nameof(EventTypeUnderTopic)} does not support reading '{options.Format}' format."),
            };
        }

        /// <summary> Serializes this GA-compatible event type under topic model. </summary>
        /// <param name="options"> The model reader/writer options. </param>
        /// <returns> The serialized model payload. </returns>
        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<EventTypeUnderTopic>)this).GetFormatFromOptions(options) : options.Format;
            return format switch
            {
                "J" => ModelReaderWriter.Write(this, options, AzureResourceManagerEventGridContext.Default),
                _ => throw new FormatException($"The model {nameof(EventTypeUnderTopic)} does not support writing '{options.Format}' format."),
            };
        }

        BinaryData IPersistableModel<EventTypeUnderTopic>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        EventTypeUnderTopic IPersistableModel<EventTypeUnderTopic>.Create(BinaryData data, ModelReaderWriterOptions options) => (EventTypeUnderTopic)PersistableModelCreateCore(data, options);
        string IPersistableModel<EventTypeUnderTopic>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        void IJsonModel<EventTypeUnderTopic>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <summary> Writes the JSON representation of this GA-compatible event type under topic model. </summary>
        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The model reader/writer options. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<EventTypeUnderTopic>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(EventTypeUnderTopic)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (Optional.IsDefined(_displayName) || Optional.IsDefined(_description) || Optional.IsDefined(_schemaUri) || Optional.IsDefined(_isInDefaultSet))
            {
                writer.WritePropertyName("properties"u8);
                writer.WriteStartObject();
                if (Optional.IsDefined(_displayName))
                {
                    writer.WritePropertyName("displayName"u8);
                    writer.WriteStringValue(_displayName);
                }
                if (Optional.IsDefined(_description))
                {
                    writer.WritePropertyName("description"u8);
                    writer.WriteStringValue(_description);
                }
                if (Optional.IsDefined(_schemaUri))
                {
                    writer.WritePropertyName("schemaUrl"u8);
                    writer.WriteStringValue(_schemaUri.AbsoluteUri);
                }
                if (Optional.IsDefined(_isInDefaultSet))
                {
                    writer.WritePropertyName("isInDefaultSet"u8);
                    writer.WriteBooleanValue(_isInDefaultSet.Value);
                }
                writer.WriteEndObject();
            }
            CompatModelSerializationHelpers.WriteAdditionalProperties(writer, options, _additionalBinaryDataProperties);
        }

        EventTypeUnderTopic IJsonModel<EventTypeUnderTopic>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (EventTypeUnderTopic)JsonModelCreateCore(ref reader, options);

        /// <summary> Creates a GA-compatible event type under topic model from its JSON representation. </summary>
        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The model reader/writer options. </param>
        /// <returns> The deserialized GA-compatible event type under topic model. </returns>
        protected virtual ResourceData JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<EventTypeUnderTopic>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(EventTypeUnderTopic)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeEventTypeUnderTopic(document.RootElement, options);
        }

        internal static EventTypeUnderTopic DeserializeEventTypeUnderTopic(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            ResourceIdentifier id = default;
            string name = default;
            ResourceType resourceType = default;
            SystemData systemData = default;
            EventTypeProperties properties = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();

            foreach (JsonProperty prop in element.EnumerateObject())
            {
                if (prop.NameEquals("id"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        id = new ResourceIdentifier(prop.Value.GetString());
                    }
                    continue;
                }
                if (prop.NameEquals("name"u8))
                {
                    name = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        resourceType = new ResourceType(prop.Value.GetString());
                    }
                    continue;
                }
                if (prop.NameEquals("systemData"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        systemData = ModelReaderWriter.Read<SystemData>(new BinaryData(Encoding.UTF8.GetBytes(prop.Value.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerEventGridContext.Default);
                    }
                    continue;
                }
                if (prop.NameEquals("properties"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        properties = EventTypeProperties.DeserializeEventTypeProperties(prop.Value, options);
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }

            return new EventTypeUnderTopic(id, name, resourceType, systemData, properties, additionalBinaryDataProperties);
        }
    }

    public partial class PartnerDetails : IJsonModel<PartnerDetails>, IPersistableModel<PartnerDetails>
    {
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of the <see cref="PartnerDetails"/> class. </summary>
        public PartnerDetails()
        {
        }

        internal PartnerDetails(string description, string longDescription, Uri setupUri, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Description = description;
            LongDescription = longDescription;
            SetupUri = setupUri;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> Gets or sets the description. </summary>
        [WirePath("description")]
        public string Description { get; set; }

        /// <summary> Gets or sets the long description. </summary>
        [WirePath("longDescription")]
        public string LongDescription { get; set; }

        /// <summary> Gets or sets the setup URI. </summary>
        [WirePath("setupUri")]
        public Uri SetupUri { get; set; }

        /// <summary> Creates a GA-compatible partner details model from a serialized payload. </summary>
        /// <param name="data"> The serialized model payload. </param>
        /// <param name="options"> The model reader/writer options. </param>
        /// <returns> The deserialized GA-compatible partner details model. </returns>
        protected virtual PartnerDetails PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<PartnerDetails>)this).GetFormatFromOptions(options) : options.Format;
            return format switch
            {
                "J" => DeserializePartnerDetails(JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions).RootElement, options),
                _ => throw new FormatException($"The model {nameof(PartnerDetails)} does not support reading '{options.Format}' format."),
            };
        }

        /// <summary> Serializes this GA-compatible partner details model. </summary>
        /// <param name="options"> The model reader/writer options. </param>
        /// <returns> The serialized model payload. </returns>
        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<PartnerDetails>)this).GetFormatFromOptions(options) : options.Format;
            return format switch
            {
                "J" => ModelReaderWriter.Write(this, options, AzureResourceManagerEventGridContext.Default),
                _ => throw new FormatException($"The model {nameof(PartnerDetails)} does not support writing '{options.Format}' format."),
            };
        }

        BinaryData IPersistableModel<PartnerDetails>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        PartnerDetails IPersistableModel<PartnerDetails>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<PartnerDetails>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        void IJsonModel<PartnerDetails>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <summary> Writes the JSON representation of this GA-compatible partner details model. </summary>
        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The model reader/writer options. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<PartnerDetails>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(PartnerDetails)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(Description))
            {
                writer.WritePropertyName("description"u8);
                writer.WriteStringValue(Description);
            }
            if (Optional.IsDefined(LongDescription))
            {
                writer.WritePropertyName("longDescription"u8);
                writer.WriteStringValue(LongDescription);
            }
            if (Optional.IsDefined(SetupUri))
            {
                writer.WritePropertyName("setupUri"u8);
                writer.WriteStringValue(SetupUri.AbsoluteUri);
            }
            CompatModelSerializationHelpers.WriteAdditionalProperties(writer, options, _additionalBinaryDataProperties);
        }

        PartnerDetails IJsonModel<PartnerDetails>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        /// <summary> Creates a GA-compatible partner details model from its JSON representation. </summary>
        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The model reader/writer options. </param>
        /// <returns> The deserialized GA-compatible partner details model. </returns>
        protected virtual PartnerDetails JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<PartnerDetails>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(PartnerDetails)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializePartnerDetails(document.RootElement, options);
        }

        internal static PartnerDetails DeserializePartnerDetails(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            string description = default;
            string longDescription = default;
            Uri setupUri = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();

            foreach (JsonProperty prop in element.EnumerateObject())
            {
                if (prop.NameEquals("description"u8))
                {
                    description = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("longDescription"u8))
                {
                    longDescription = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("setupUri"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        setupUri = string.IsNullOrEmpty(prop.Value.GetString()) ? null : new Uri(prop.Value.GetString(), UriKind.RelativeOrAbsolute);
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }

            return new PartnerDetails(description, longDescription, setupUri, additionalBinaryDataProperties);
        }
    }

    public partial class TopicTypeAdditionalEnforcedPermission : IJsonModel<TopicTypeAdditionalEnforcedPermission>, IPersistableModel<TopicTypeAdditionalEnforcedPermission>
    {
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of the <see cref="TopicTypeAdditionalEnforcedPermission"/> class. </summary>
        public TopicTypeAdditionalEnforcedPermission()
        {
        }

        internal TopicTypeAdditionalEnforcedPermission(string permissionName, bool? isDataAction, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            PermissionName = permissionName;
            IsDataAction = isDataAction;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> Gets or sets the permission name. </summary>
        [WirePath("permissionName")]
        public string PermissionName { get; set; }

        /// <summary> Gets or sets a value indicating whether the permission is a data action. </summary>
        [WirePath("isDataAction")]
        public bool? IsDataAction { get; set; }

        /// <summary> Creates a GA-compatible topic type additional enforced permission model from a serialized payload. </summary>
        /// <param name="data"> The serialized model payload. </param>
        /// <param name="options"> The model reader/writer options. </param>
        /// <returns> The deserialized GA-compatible topic type additional enforced permission model. </returns>
        protected virtual TopicTypeAdditionalEnforcedPermission PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<TopicTypeAdditionalEnforcedPermission>)this).GetFormatFromOptions(options) : options.Format;
            return format switch
            {
                "J" => DeserializeTopicTypeAdditionalEnforcedPermission(JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions).RootElement, options),
                _ => throw new FormatException($"The model {nameof(TopicTypeAdditionalEnforcedPermission)} does not support reading '{options.Format}' format."),
            };
        }

        /// <summary> Serializes this GA-compatible topic type additional enforced permission model. </summary>
        /// <param name="options"> The model reader/writer options. </param>
        /// <returns> The serialized model payload. </returns>
        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<TopicTypeAdditionalEnforcedPermission>)this).GetFormatFromOptions(options) : options.Format;
            return format switch
            {
                "J" => ModelReaderWriter.Write(this, options, AzureResourceManagerEventGridContext.Default),
                _ => throw new FormatException($"The model {nameof(TopicTypeAdditionalEnforcedPermission)} does not support writing '{options.Format}' format."),
            };
        }

        BinaryData IPersistableModel<TopicTypeAdditionalEnforcedPermission>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        TopicTypeAdditionalEnforcedPermission IPersistableModel<TopicTypeAdditionalEnforcedPermission>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<TopicTypeAdditionalEnforcedPermission>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        void IJsonModel<TopicTypeAdditionalEnforcedPermission>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <summary> Writes the JSON representation of this GA-compatible topic type additional enforced permission model. </summary>
        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The model reader/writer options. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<TopicTypeAdditionalEnforcedPermission>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(TopicTypeAdditionalEnforcedPermission)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(PermissionName))
            {
                writer.WritePropertyName("permissionName"u8);
                writer.WriteStringValue(PermissionName);
            }
            if (Optional.IsDefined(IsDataAction))
            {
                writer.WritePropertyName("isDataAction"u8);
                writer.WriteBooleanValue(IsDataAction.Value);
            }
            CompatModelSerializationHelpers.WriteAdditionalProperties(writer, options, _additionalBinaryDataProperties);
        }

        TopicTypeAdditionalEnforcedPermission IJsonModel<TopicTypeAdditionalEnforcedPermission>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        /// <summary> Creates a GA-compatible topic type additional enforced permission model from its JSON representation. </summary>
        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The model reader/writer options. </param>
        /// <returns> The deserialized GA-compatible topic type additional enforced permission model. </returns>
        protected virtual TopicTypeAdditionalEnforcedPermission JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<TopicTypeAdditionalEnforcedPermission>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(TopicTypeAdditionalEnforcedPermission)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeTopicTypeAdditionalEnforcedPermission(document.RootElement, options);
        }

        internal static TopicTypeAdditionalEnforcedPermission DeserializeTopicTypeAdditionalEnforcedPermission(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            string permissionName = default;
            bool? isDataAction = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();

            foreach (JsonProperty prop in element.EnumerateObject())
            {
                if (prop.NameEquals("permissionName"u8))
                {
                    permissionName = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("isDataAction"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        isDataAction = prop.Value.GetBoolean();
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }

            return new TopicTypeAdditionalEnforcedPermission(permissionName, isDataAction, additionalBinaryDataProperties);
        }
    }
}
