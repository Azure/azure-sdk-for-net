// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using System.ClientModel.Primitives;

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Represents a base class for all updates received from the VoiceLive service.
    /// </summary>
    public abstract partial class VoiceLiveUpdate : IJsonModel<VoiceLiveUpdate>, IPersistableModel<VoiceLiveUpdate>
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary>
        /// Initializes a new instance of the <see cref="VoiceLiveUpdate"/> class.
        /// </summary>
        /// <param name="kind">The kind of update.</param>
        protected VoiceLiveUpdate(VoiceLiveUpdateKind kind)
        {
            Kind = kind;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VoiceLiveUpdate"/> class.
        /// </summary>
        /// <param name="kind">The kind of update.</param>
        /// <param name="eventId">The event ID associated with this update.</param>
        /// <param name="additionalBinaryDataProperties">Additional properties to include in serialization.</param>
        internal VoiceLiveUpdate(VoiceLiveUpdateKind kind, string eventId, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Kind = kind;
            EventId = eventId;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary>
        /// Gets the kind of this update, indicating what type of event it represents.
        /// </summary>
        public VoiceLiveUpdateKind Kind { get; }

        /// <summary>
        /// Gets the unique identifier for this event, if provided by the service.
        /// </summary>
        public string EventId { get; }

        /// <summary>
        /// Gets the raw content of this update as binary data.
        /// </summary>
        /// <returns>The binary data representation of this update.</returns>
        public virtual BinaryData GetRawContent() => ModelReaderWriter.Write(this);

        /// <summary>
        /// Creates a VoiceLiveUpdate from a VoiceLiveServerEvent.
        /// </summary>
        /// <param name="serverEvent">The server event to convert.</param>
        /// <returns>The corresponding update, or null if the event cannot be converted.</returns>
        internal static VoiceLiveUpdate FromServerEvent(VoiceLiveServerEvent serverEvent)
        {
            if (serverEvent == null)
                return null;

            return VoiceLiveUpdateFactory.CreateUpdate(serverEvent);
        }

        /// <summary>
        /// Creates a VoiceLiveUpdate from binary data.
        /// </summary>
        /// <param name="data">The binary data to deserialize.</param>
        /// <param name="options">The serialization options.</param>
        /// <returns>The deserialized update.</returns>
        internal static VoiceLiveUpdate FromBinaryData(BinaryData data, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;
            
            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeVoiceLiveUpdate(document.RootElement, options);
        }

        /// <summary>
        /// Gets additional properties that are not part of the core update model.
        /// </summary>
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }

        /// <inheritdoc/>
        void IJsonModel<VoiceLiveUpdate>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            JsonModelWriteCore(writer, options);
        }

        /// <inheritdoc/>
        VoiceLiveUpdate IJsonModel<VoiceLiveUpdate>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            return JsonModelCreateCore(ref reader, options);
        }

        /// <inheritdoc/>
        VoiceLiveUpdate IPersistableModel<VoiceLiveUpdate>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            return PersistableModelCreateCore(data, options);
        }

        /// <inheritdoc/>
        BinaryData IPersistableModel<VoiceLiveUpdate>.Write(ModelReaderWriterOptions options)
        {
            return PersistableModelWriteCore(options);
        }

        /// <inheritdoc/>
        string IPersistableModel<VoiceLiveUpdate>.GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            return "J";
        }

        /// <summary>
        /// Writes the model to the provided writer.
        /// </summary>
        /// <param name="writer">The writer to write to.</param>
        /// <param name="options">The serialization options.</param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(Kind.ToSerialString());

            if (EventId != null)
            {
                writer.WritePropertyName("event_id"u8);
                writer.WriteStringValue(EventId);
            }

            if (options.Format != "W" && _additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
                    writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }

            writer.WriteEndObject();
        }

        /// <summary>
        /// Creates an instance from a reader.
        /// </summary>
        /// <param name="reader">The reader to read from.</param>
        /// <param name="options">The serialization options.</param>
        /// <returns>The created instance.</returns>
        protected virtual VoiceLiveUpdate JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using var document = JsonDocument.ParseValue(ref reader);
            return DeserializeVoiceLiveUpdate(document.RootElement, options);
        }

        /// <summary>
        /// Creates an instance from binary data.
        /// </summary>
        /// <param name="data">The binary data to read from.</param>
        /// <param name="options">The serialization options.</param>
        /// <returns>The created instance.</returns>
        protected virtual VoiceLiveUpdate PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            using var document = JsonDocument.Parse(data);
            return DeserializeVoiceLiveUpdate(document.RootElement, options);
        }

        /// <summary>
        /// Writes the model to binary data.
        /// </summary>
        /// <param name="options">The serialization options.</param>
        /// <returns>The binary data representation.</returns>
        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            return ModelReaderWriter.Write(this, options);
        }

        /// <summary>
        /// Deserializes a VoiceLiveUpdate from a JSON element.
        /// </summary>
        /// <param name="element">The JSON element to deserialize.</param>
        /// <param name="options">The serialization options.</param>
        /// <returns>The deserialized update.</returns>
        internal static VoiceLiveUpdate DeserializeVoiceLiveUpdate(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            VoiceLiveUpdateKind kind = VoiceLiveUpdateKind.Unknown;
            string eventId = null;
            var additionalPropertiesDictionary = new Dictionary<string, BinaryData>();

            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"u8))
                {
                    string typeValue = property.Value.GetString();
                    kind = VoiceLiveUpdateKind.FromServerEventType(typeValue);
                    continue;
                }

                if (property.NameEquals("event_id"u8))
                {
                    eventId = property.Value.GetString();
                    continue;
                }

                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }

            // Use the factory to create the appropriate update type
            return VoiceLiveUpdateFactory.CreateUpdate(element, kind, eventId, additionalPropertiesDictionary, options);
        }
    }
}