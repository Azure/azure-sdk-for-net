// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Messaging
{
    /// <summary> Represents a CloudEvent using the 1.0 Schema. This type has built-in serialization using System.Text.Json.</summary>
    [JsonConverter(typeof(CloudEventConverter))]
    public class CloudEvent
    {
        /// <summary> Initializes a new instance of the <see cref="CloudEvent"/> class. </summary>
        /// <param name="source"> Identifies the context in which an event happened. The combination of id and source must be unique for each distinct event. </param>
        /// <param name="type"> Type of event related to the originating occurrence. For example, "Contoso.Items.ItemReceived". </param>
        /// <param name="jsonSerializable"> Event data specific to the event type. </param>
        /// <param name="dataSerializationType">The type to use when serializing the data.
        /// If not specified, <see cref="object.GetType()"/> will be used on <paramref name="jsonSerializable"/>.</param>
        public CloudEvent(string source, string type, object jsonSerializable, Type? dataSerializationType = default)
        {
            Argument.AssertNotNull(source, nameof(source));
            Argument.AssertNotNull(type, nameof(type));

            Source = source;
            Type = type;
            DataSerializationType = dataSerializationType ?? jsonSerializable?.GetType();
            JsonSerializableData = jsonSerializable;
            Id = Guid.NewGuid().ToString();
        }

        /// <summary> Initializes a new instance of the <see cref="CloudEvent"/> class using binary event data.</summary>
        /// <param name="source"> Identifies the context in which an event happened. The combination of id and source must be unique for each distinct event. </param>
        /// <param name="type"> Type of event related to the originating occurrence. For example, "Contoso.Items.ItemReceived". </param>
        /// <param name="data"> Binary event data specific to the event type. </param>
        /// <param name="dataContentType"> Content type of the payload. A content type different from "application/json" should be specified if payload is not JSON. </param>
        public CloudEvent(string source, string type, ReadOnlyMemory<byte> data, string dataContentType)
        {
            Argument.AssertNotNull(source, nameof(source));
            Argument.AssertNotNull(type, nameof(type));

            Source = source;
            Type = type;
            DataContentType = dataContentType;
            DataBase64 = data;
            Id = Guid.NewGuid().ToString();
        }

        internal CloudEvent() { }

        /// <summary>
        /// Gets or sets an identifier for the event. The combination of <see cref="Id"/> and <see cref="Source"/> must be unique for each distinct event.
        /// If not explicitly set, this will default to a <see cref="Guid"/>.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>Gets or sets the context in which an event happened. The combination of <see cref="Id"/> and <see cref="Source"/> must be unique for each distinct event.</summary>
        public string? Source { get; set; }

        /// <summary>Gets or sets the type of event related to the originating occurrence.</summary>
        public string? Type { get; set; }

        /// <summary>
        /// The spec version of the cloud event.
        /// </summary>
        internal string SpecVersion { get; set; } = "1.0";

        /// <summary>
        /// Gets or sets the time (in UTC) the event was generated, in RFC3339 format.
        /// If not explicitly set, this will default to the time that the event is constructed.
        /// </summary>
        public DateTimeOffset? Time { get; set; } = DateTimeOffset.UtcNow;

        /// <summary>Gets or sets the schema that the data adheres to.</summary>
        public string? DataSchema { get; set; }

        /// <summary>Gets or sets the content type of the data.</summary>
        public string? DataContentType { get; set; }

        internal Type? DataSerializationType { get; }

        /// <summary>Gets or sets the subject of the event in the context of the event producer (identified by source). </summary>
        public string? Subject { get; set; }

        /// <summary>
        /// Gets extension attributes that can be additionally added to the CloudEvent envelope.
        /// </summary>
        public IDictionary<string, object?> ExtensionAttributes { get; } = new CloudEventExtensionAttributes<string, object?>();

        /// <summary>Gets or sets the deserialized event data specific to the event type.</summary>
        internal object? JsonSerializableData
        {
            get
            {
                return _jsonSerializableData;
            }
            set
            {
                if (value != null)
                {
                    Data = new BinaryData(value, type: DataSerializationType);
                }
                _jsonSerializableData = value;
            }
        }
        private object? _jsonSerializableData;

        /// <summary>Gets or sets the event data specific to the event type, encoded as a base64 string.</summary>
        internal ReadOnlyMemory<byte>? DataBase64
        {
            get
            {
                return _dataBase64;
            }
            set
            {
                if (value != null)
                {
                    Data = new BinaryData(value.Value);
                    _dataBase64 = value;
                }
            }
        }
        private ReadOnlyMemory<byte>? _dataBase64;

        /// <summary>
        /// Given JSON-encoded events, parses the event envelope and returns an array of CloudEvents.
        /// </summary>
        /// <param name="requestContent"> The JSON-encoded representation of either a single event or an array or events, in the CloudEvent schema. </param>
        /// <returns> A list of <see cref="CloudEvent"/>. </returns>
        public static CloudEvent[]? Parse(string requestContent)
        {
            Argument.AssertNotNull(requestContent, nameof(requestContent));

            CloudEvent[]? cloudEvents = null;
            JsonDocument requestDocument = JsonDocument.Parse(requestContent);

            // Parse JsonElement into separate events, deserialize event envelope properties
            if (requestDocument.RootElement.ValueKind == JsonValueKind.Object)
            {
                cloudEvents = new CloudEvent[1];
                cloudEvents[0] = CloudEventConverter.DeserializeCloudEvent(requestDocument.RootElement);
            }
            else if (requestDocument.RootElement.ValueKind == JsonValueKind.Array)
            {
                cloudEvents = new CloudEvent[requestDocument.RootElement.GetArrayLength()];
                int i = 0;
                foreach (JsonElement property in requestDocument.RootElement.EnumerateArray())
                {
                    cloudEvents[i++] = CloudEventConverter.DeserializeCloudEvent(property);
                }
            }
            return cloudEvents ?? Array.Empty<CloudEvent>();
        }

        /// <summary>
        /// Gets the event data as <see cref="BinaryData"/>. Using BinaryData,
        /// one can deserialize the payload into rich data, or access the raw JSON data using <see cref="BinaryData.ToString()"/>.
        /// </summary>
        public BinaryData? Data { get; internal set; }
    }
}
