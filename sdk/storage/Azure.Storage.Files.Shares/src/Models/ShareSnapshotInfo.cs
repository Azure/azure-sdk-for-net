// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// ShareSnapshotInfo
    /// </summary>
    public class ShareSnapshotInfo
    {
        /// <summary>
        /// This header is a DateTime value that uniquely identifies the share snapshot. The value of this header may be used in subsequent requests to access the share snapshot. This value is opaque.
        /// </summary>
        public string Snapshot { get; internal set; }

        /// <summary>
        /// The ETag contains a value which represents the version of the share snapshot, in quotes. A share snapshot cannot be modified, so the ETag of a given share snapshot never changes. However, if new metadata was supplied with the Snapshot Share request then the ETag of the share snapshot differs from that of the base share. If no metadata was specified with the request, the ETag of the share snapshot is identical to that of the base share at the time the share snapshot was taken.
        /// </summary>
        public ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the share was last modified. A share snapshot cannot be modified, so the last modified time of a given share snapshot never changes. However, if new metadata was supplied with the Snapshot Share request then the last modified time of the share snapshot differs from that of the base share. If no metadata was specified with the request, the last modified time of the share snapshot is identical to that of the base share at the time the share snapshot was taken.
        /// </summary>
        public DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of ShareSnapshotInfo instances.
        /// You can use ShareModelFactory.ShareSnapshotInfo instead.
        /// </summary>
        internal ShareSnapshotInfo() { }
    }
}
