// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    /// <summary>
    /// Represents the metadata from a snapshot meta.json file
    /// at idx/snapshots/YYYY/MM/DD/HH/mm/ss/meta.json.
    /// </summary>
    internal class SnapshotMetadata
    {
        public int Version { get; set; }
        public DateTimeOffset SnapshotTimestamp { get; set; }
        public long CvId { get; set; }
        public DateTimeOffset MinLogWindowForNextSnapshot { get; set; }
        public DateTimeOffset MaxLogWindowForCurrentSnapshot { get; set; }
        public string Status { get; set; }
    }
}
