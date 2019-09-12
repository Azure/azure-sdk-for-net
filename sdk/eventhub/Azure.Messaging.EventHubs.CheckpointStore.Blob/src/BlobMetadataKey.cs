// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.CheckpointStore.Blob
{
    /// <summary>
    ///   The set of keys to access or modify blobs' metadata.
    /// </summary>
    ///
    internal static class BlobMetadataKey
    {
        /// <summary>The key to the owner identifier metadata.</summary>
        public const string OwnerIdentifier = "OwnerId";

        /// <summary>The key to the offset metadata.</summary>
        public const string Offset = "Offset";

        /// <summary>The key to the sequence number metadata.</summary>
        public const string SequenceNumber = "SequenceNumber";
    }
}
