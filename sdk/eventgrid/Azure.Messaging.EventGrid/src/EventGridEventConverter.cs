// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;
using Azure.Messaging.EventGrid.Models;

namespace Azure.Messaging.EventGrid
{
    /// <summary>
    /// A custom converter that attributes the <see cref="EventGridEvent"/> type.
    /// This allows System.Text.Json to serialize and deserialize EventGridEvent by default.
    /// </summary>
    internal class EventGridEventConverter : JsonConverter<EventGridEvent>
    {
        /// <summary>
        /// Gets or sets the serializer to use for the data portion of the <see cref="EventGridEvent"/>. If not specified,
        /// JsonObjectSerializer is used.
        /// </summary>
        /// <inheritdoc cref="JsonConverter{EventGridEvent}.Read(ref Utf8JsonReader, Type, JsonSerializerOptions)"/>
        public override EventGridEvent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            JsonDocument requestDocument = JsonDocument.ParseValue(ref reader);
            return new EventGridEvent(EventGridEventInternal.DeserializeEventGridEventInternal(requestDocument.RootElement));
        }

        /// <inheritdoc cref="JsonConverter{EventGridEvent}.Write(Utf8JsonWriter, EventGridEvent, JsonSerializerOptions)"/>
        public override void Write(Utf8JsonWriter writer, EventGridEvent value, JsonSerializerOptions options)
        {
            JsonDocument data = JsonDocument.Parse(value.Data.ToStream());
            var eventGridEventInternal = new EventGridEventInternal(
                value.Id,
                value.Subject,
                data.RootElement,
                value.EventType,
                value.EventTime,
                value.DataVersion)
            {
                Topic = value.Topic
            };
            ((IUtf8JsonSerializable) eventGridEventInternal).Write(writer);
        }
    }
}
