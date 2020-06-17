// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;

namespace Azure.Storage.Blobs.ChangeFeed.Models
{
    /// <summary>
    /// BlobChangeFeedEvent.
    /// </summary>
    public class BlobChangeFeedEvent
    {
        /// <summary>
        /// Internal constructor.
        /// </summary>
        internal BlobChangeFeedEvent(Dictionary<string, object> record)
        {
            Topic = (string)record[Constants.ChangeFeed.Event.Topic];
            Subject = (string)record[Constants.ChangeFeed.Event.Subject];
            EventType = new BlobChangeFeedEventType((string)record[Constants.ChangeFeed.Event.EventType]);
            EventTime = DateTimeOffset.Parse((string)record[Constants.ChangeFeed.Event.EventTime], CultureInfo.InvariantCulture);
            Id = Guid.Parse((string)record[Constants.ChangeFeed.Event.EventId]);
            EventData = new BlobChangeFeedEventData((Dictionary<string, object>)record[Constants.ChangeFeed.Event.Data]);
            record.TryGetValue(Constants.ChangeFeed.Event.SchemaVersion, out object schemaVersion);
            SchemaVersion = (long)schemaVersion;
            record.TryGetValue(Constants.ChangeFeed.Event.MetadataVersion, out object metadataVersion);
            MetadataVersion = (string)metadataVersion;
        }

        internal BlobChangeFeedEvent() { }

        /// <summary>
        /// Full resource path to the event source. This field is not writeable. Event Grid provides this value.
        /// </summary>
        public string Topic { get; internal set; }

        /// <summary>
        /// Publisher-defined path to the event subject.
        /// </summary>
        public string Subject { get; internal set; }

        /// <summary>
        /// One of the registered event types for this event source.
        /// </summary>
        public BlobChangeFeedEventType EventType { get; internal set; }

        /// <summary>
        /// The time the event is generated based on the provider's UTC time.
        /// </summary>
        public DateTimeOffset EventTime { get; internal set; }

        /// <summary>
        /// Unique identifier for the event.
        /// </summary>
        public Guid Id { get; internal set; }

        /// <summary>
        /// Blob storage event data.
        /// </summary>
        public BlobChangeFeedEventData EventData { get; internal set; }

        /// <summary>
        /// The schema version of the data object. The publisher defines the schema version.
        /// </summary>
        public long SchemaVersion { get; internal set; }

        /// <summary>
        /// The schema version of the event metadata. Event Grid defines the schema of the top-level properties.
        /// Event Grid provides this value.
        /// </summary>
        public string MetadataVersion { get; internal set; }

        /// <inheritdoc/>
        public override string ToString() => $"{EventTime}: {EventType} {Subject} ({EventData?.ToString() ?? "Unknown Event"})";
    }
}
