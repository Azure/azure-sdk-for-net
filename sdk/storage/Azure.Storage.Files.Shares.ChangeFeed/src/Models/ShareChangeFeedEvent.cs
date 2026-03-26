// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    public class ShareChangeFeedEvent
    {
        public long SchemaVersion { get; internal set; }
        public ShareChangeFeedReasonType Reason { get; internal set; }
        public ShareChangeFeedProtocol Protocol { get; internal set; }
        public DateTimeOffset EventTime { get; internal set; }
        public string Id { get; internal set; }
        public long ContainerVersionNumber { get; internal set; }
        public ShareChangeFeedEventData EventData { get; internal set; }

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

        internal ShareChangeFeedEvent() { }

        public override string ToString()
            => $"{EventTime}: {Reason} ({Protocol}) {EventData?.FullFilePath ?? EventData?.FileName ?? "Unknown"}";
    }
}
