// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary> Schema of common properties of snapshot events. </summary>
    public partial class AppConfigurationSnapshotEventData
    {
        /// <summary> The etag representing the new state of the snapshot. </summary>
        [CodeGenMember("Etag")]
        public string ETag { get; }
    }
}