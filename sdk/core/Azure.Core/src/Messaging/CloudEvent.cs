// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.Messaging
{
    /// <summary> Represents a CloudEvent conforming to the 1.0 schema. This type has built-in serialization using System.Text.Json.</summary>
    [JsonConverter(typeof(CloudEventConverter))]
    [RequiresUnreferencedCode(DynamicData.SerializationRequiresUnreferencedCode)]
    [RequiresDynamicCode(DynamicData.SerializationRequiresUnreferencedCode)]
    public class CloudEvent
    {
        /// <summary> Initializes a new instance of the <see cref="CloudEvent"/> class. </summary>
        /// <param name="source"> Identifies the context in which an event happened. The combination of id and source must be unique for each distinct event. </param>
        /// <param name="type"> Type of event related to the originating occurrence. For example, "Contoso.Items.ItemReceived". </param>
        /// <param name="jsonSerializableData"> Event data specific to the event type. </param>
        /// <param name="dataSerializationType">The type to use when serializing the data.
        /// If not specified, <see cref="object.GetType()"/> will be used on <paramref name="jsonSerializableData"/>.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="type"/> was null.
        /// </exception>
        public CloudEvent(string source, string type, object? jsonSerializableData, Type? dataSerializationType = default)
        {
            if (jsonSerializableData is BinaryData)
            {
                throw new InvalidOperationException("This constructor does not support BinaryData. Use the constructor that takes a BinaryData instance.");
            }
            Source = source;
            Type = type;
            Id = Guid.NewGuid().ToString();
            DataFormat = CloudEventDataFormat.Json;
            Data = new BinaryData(jsonSerializableData, type: dataSerializationType ?? jsonSerializableData?.GetType());
            SpecVersion = "1.0";
        }

        /// <summary> Initializes a new instance of the <see cref="CloudEvent"/> class using binary event data.</summary>
        /// <param name="source"> Identifies the context in which an event happened. The combination of id and source must be unique for each distinct event. </param>
        /// <param name="type"> Type of event related to the originating occurrence. For example, "Contoso.Items.ItemReceived". </param>
        /// <param name="data"> Binary event data specific to the event type. </param>
        /// <param name="dataContentType"> Content type of the payload. A content type different from "application/json" should be specified if payload is not JSON. </param>
        /// <param name="dataFormat">The format that the data of a <see cref="CloudEvent"/> should be sent in
        /// when using the JSON envelope format.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="type"/> was null.
        /// </exception>
        public CloudEvent(string source, string type, BinaryData? data, string? dataContentType, CloudEventDataFormat dataFormat = CloudEventDataFormat.Binary)
        {
            Source = source;
            Type = type;
            DataContentType = dataContentType;
            Id = Guid.NewGuid().ToString();
            DataFormat = dataFormat;
            Data = data;
            SpecVersion = "1.0";
        }

        internal CloudEvent() { }

        /// <summary>
        /// Gets or sets the event data as <see cref="BinaryData"/>. Using BinaryData,
        /// one can deserialize the payload into rich data, or access the raw JSON data using <see cref="BinaryData.ToString()"/>.
        /// </summary>
        public BinaryData? Data { get; set; }

        /// <summary>
        /// Gets or sets an identifier for the event. The combination of <see cref="Id"/> and <see cref="Source"/> must be unique for each distinct event.
        /// If not explicitly set, this will default to a <see cref="Guid"/>.
        /// </summary>
        public string Id
        {
            get
            {
                return _id!;
            }
            set
            {
                Argument.AssertNotNull(value, nameof(value));
                _id = value;
            }
        }
        private string? _id;

        internal CloudEventDataFormat DataFormat { get; set; }

        /// <summary>Gets or sets the context in which an event happened. The combination of <see cref="Id"/>
        /// and <see cref="Source"/> must be unique for each distinct event.</summary>
        public string Source
        {
            get
            {
                return _source!;
            }
            set
            {
                Argument.AssertNotNull(value, nameof(value));
                _source = value;
            }
        }
        private string? _source;

        /// <summary>Gets or sets the type of event related to the originating occurrence.</summary>
        public string Type
        {
            get
            {
                return _type!;
            }
            set
            {
                Argument.AssertNotNull(value, nameof(value));
                _type = value;
            }
        }
        private string? _type;

        /// <summary>
        /// The spec version of the cloud event.
        /// </summary>
        internal string? SpecVersion { get; set; }

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
        public IDictionary<string, object> ExtensionAttributes { get; } = new CloudEventExtensionAttributes<string, object>();

        /// <summary>
        /// Given JSON-encoded events, parses the event envelope and returns an array of CloudEvents.
        /// If the specified event is not valid JSON an exception is thrown.
        /// By default, if the event is missing required properties, an exception is thrown though this can be relaxed
        /// by setting the <paramref name="skipValidation"/> parameter.
        /// </summary>
        /// <param name="json">An instance of <see cref="BinaryData"/> containing the JSON for one or more CloudEvents.</param>
        /// <param name="skipValidation">Set to <see langword="true"/> to allow missing or invalid properties to still parse into a CloudEvent.
        /// In particular, by setting strict to <see langword="true"/>, the source, id, specversion and type properties are no longer required
        /// to be present in the JSON. Additionally, the casing requirements of the extension attribute names are relaxed.
        /// </param>
        /// <returns> An array of <see cref="CloudEvent"/> instances.</returns>
        public static CloudEvent[] ParseMany(BinaryData json, bool skipValidation = false)
        {
            Argument.AssertNotNull(json, nameof(json));

            CloudEvent[]? cloudEvents = null;
            JsonDocument requestDocument = JsonDocument.Parse(json);

            // Parse JsonElement into separate events, deserialize event envelope properties
            if (requestDocument.RootElement.ValueKind == JsonValueKind.Object)
            {
                cloudEvents = new CloudEvent[1];
                cloudEvents[0] = CloudEventConverter.DeserializeCloudEvent(requestDocument.RootElement, skipValidation);
            }
            else if (requestDocument.RootElement.ValueKind == JsonValueKind.Array)
            {
                cloudEvents = new CloudEvent[requestDocument.RootElement.GetArrayLength()];
                int i = 0;
                foreach (JsonElement property in requestDocument.RootElement.EnumerateArray())
                {
                    cloudEvents[i++] = CloudEventConverter.DeserializeCloudEvent(property, skipValidation);
                }
            }
            return cloudEvents ?? Array.Empty<CloudEvent>();
        }

        /// <summary>
        /// Given a single JSON-encoded event, parses the event envelope and returns a <see cref="CloudEvent"/>.
        /// If the specified event is not valid JSON an exception is thrown.
        /// By default, if the event is missing required properties, an exception is thrown though this can be relaxed
        /// by setting the <paramref name="skipValidation"/> parameter.
        /// </summary>
        /// <param name="json">An instance of <see cref="BinaryData"/> containing the JSON for the CloudEvent.</param>
        /// <param name="skipValidation">Set to <see langword="true"/> to allow missing or invalid properties to still parse into a CloudEvent.
        /// In particular, by setting strict to <see langword="true"/>, the source, id, specversion and type properties are no longer required
        /// to be present in the JSON. Additionally, the casing requirements of the extension attribute names are relaxed.
        /// </param>
        /// <returns> A <see cref="CloudEvent"/>. </returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="json"/> contained multiple events. <see cref="ParseMany"/> should be used instead.
        /// </exception>
        public static CloudEvent? Parse(BinaryData json, bool skipValidation = false)
        {
            Argument.AssertNotNull(json, nameof(json));

            using JsonDocument requestDocument = JsonDocument.Parse(json);
            CloudEvent? cloudEvent = null;
            if (requestDocument.RootElement.ValueKind == JsonValueKind.Object)
            {
                cloudEvent = CloudEventConverter.DeserializeCloudEvent(requestDocument.RootElement, skipValidation);
            }
            else if (requestDocument.RootElement.ValueKind == JsonValueKind.Array)
            {
                if (requestDocument.RootElement.GetArrayLength() > 1)
                {
                    throw new ArgumentException(
                        "The BinaryData instance contains JSON from multiple cloud events. This method " +
                        "should only be used with BinaryData containing a single cloud event. " +
                        Environment.NewLine +
                        $"To parse multiple events, use the {nameof(ParseMany)} overload.");
                }
                foreach (JsonElement property in requestDocument.RootElement.EnumerateArray())
                {
                    cloudEvent = CloudEventConverter.DeserializeCloudEvent(property, skipValidation);
                    break;
                }
            }
            return cloudEvent;
        }
    }
}
