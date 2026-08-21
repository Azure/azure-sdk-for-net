// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using Azure.Storage.ChangeFeed.Common;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    /// <summary>
    /// Represents a single event in the Azure Files Change Feed. Each event corresponds
    /// to a mutation (create, rename, delete, write, etc.) on a file or directory within
    /// a file share.
    /// </summary>
    public class ShareChangeFeedEvent : IChangeFeedEvent
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
        /// <exception cref="FormatException">
        /// Thrown if any required field is missing, null, or has the wrong type.
        /// </exception>
        internal ShareChangeFeedEvent(Dictionary<string, object> record)
        {
            SchemaVersion = RequireLong(record, Constants.FilesChangeFeed.Event.SchemaVersion);
            Reason = new ShareChangeFeedReasonType(RequireString(record, Constants.FilesChangeFeed.Event.Reason));
            Protocol = new ShareChangeFeedProtocol(RequireString(record, Constants.FilesChangeFeed.Event.Protocol));

            string eventTime = RequireString(record, Constants.FilesChangeFeed.Event.EventTime);
            try
            {
                EventTime = DateTimeOffset.Parse(eventTime, CultureInfo.InvariantCulture);
            }
            catch (FormatException ex)
            {
                throw new FormatException(
                    $"Change feed event field '{Constants.FilesChangeFeed.Event.EventTime}' is not a valid DateTimeOffset: '{eventTime}'.",
                    ex);
            }

            Id = RequireString(record, Constants.FilesChangeFeed.Event.Id);
            ContainerVersionNumber = RequireLong(record, Constants.FilesChangeFeed.Event.Cvnt);
            EventData = new ShareChangeFeedEventData(RequireDict(record, Constants.FilesChangeFeed.Event.Data));
        }

        private static string RequireString(Dictionary<string, object> record, string key)
        {
            if (!record.TryGetValue(key, out object value))
                throw new FormatException($"Change feed event is missing required field '{key}'.");
            if (value is null)
                throw new FormatException($"Change feed event field '{key}' is null.");
            if (value is not string s)
                throw new FormatException($"Change feed event field '{key}' must be a string but was {value.GetType().Name}.");
            return s;
        }

        private static long RequireLong(Dictionary<string, object> record, string key)
        {
            if (!record.TryGetValue(key, out object value))
                throw new FormatException($"Change feed event is missing required field '{key}'.");
            if (value is null)
                throw new FormatException($"Change feed event field '{key}' is null.");
            if (value is not long l)
                throw new FormatException($"Change feed event field '{key}' must be a long but was {value.GetType().Name}.");
            return l;
        }

        private static Dictionary<string, object> RequireDict(Dictionary<string, object> record, string key)
        {
            if (!record.TryGetValue(key, out object value))
                throw new FormatException($"Change feed event is missing required field '{key}'.");
            if (value is null)
                throw new FormatException($"Change feed event field '{key}' is null.");
            if (value is not Dictionary<string, object> d)
                throw new FormatException($"Change feed event field '{key}' must be a record but was {value.GetType().Name}.");
            return d;
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
