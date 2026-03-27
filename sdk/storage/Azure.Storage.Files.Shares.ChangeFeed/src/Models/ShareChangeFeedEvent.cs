// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    /// <summary>
    /// Represents a single event in the Azure Files Change Feed. Each event corresponds
    /// to a mutation (create, rename, delete, write, etc.) on a file or directory within
    /// a file share.
    /// </summary>
    public class ShareChangeFeedEvent
    {
        /// <summary>
        /// The schema version of the change feed event record format.
        /// </summary>
        public long SchemaVersion { get; internal set; }

        /// <summary>
        /// The reason (operation type) that triggered this event, such as SmbCreate, RestDelete, etc.
        /// </summary>
        public ShareChangeFeedReasonType Reason { get; internal set; }

        /// <summary>
        /// The protocol used for the operation that generated this event (SMB or REST).
        /// </summary>
        public ShareChangeFeedProtocol Protocol { get; internal set; }

        /// <summary>
        /// The UTC timestamp when the event occurred.
        /// </summary>
        public DateTimeOffset EventTime { get; internal set; }

        /// <summary>
        /// A unique identifier for this change feed event.
        /// </summary>
        public string Id { get; internal set; }

        /// <summary>
        /// The container version number (Cvnt) at the time of this event. Used for
        /// filtering events in between-snapshot queries.
        /// </summary>
        public long ContainerVersionNumber { get; internal set; }

        /// <summary>
        /// The detailed data payload for this event, including file identifiers, paths, and identity information.
        /// </summary>
        public ShareChangeFeedEventData EventData { get; internal set; }

        /// <summary>
        /// Initializes a new <see cref="ShareChangeFeedEvent"/> from an Avro record dictionary.
        /// </summary>
        /// <param name="record">The deserialized Avro record containing event fields.</param>
        internal ShareChangeFeedEvent(Dictionary<string, object> record)
        {
            record.TryGetValue("SchemaVersion", out object schemaVersion);
            SchemaVersion = schemaVersion is long sv ? sv : 0;
            Reason = new ShareChangeFeedReasonType((string)record["Reason"]);
            Protocol = new ShareChangeFeedProtocol((string)record["Protocol"]);
            EventTime = DateTimeOffset.Parse((string)record["EventTime"], CultureInfo.InvariantCulture);
            Id = (string)record["Id"];
            record.TryGetValue("Cvnt", out object cvnt);
            ContainerVersionNumber = cvnt is long c ? c : 0;
            if (record.TryGetValue("Data", out object data) && data is Dictionary<string, object> dataDict)
                EventData = new ShareChangeFeedEventData(dataDict);
        }

        /// <summary>
        /// Initializes a new <see cref="ShareChangeFeedEvent"/> for mocking purposes.
        /// </summary>
        internal ShareChangeFeedEvent() { }

        /// <summary>
        /// Returns a human-readable string summarizing the event time, reason, protocol, and affected file path.
        /// </summary>
        /// <returns>A string representation of this change feed event.</returns>
        public override string ToString()
            => $"{EventTime}: {Reason} ({Protocol}) {EventData?.FullFilePath ?? EventData?.FileName ?? "Unknown"}";
    }
}
