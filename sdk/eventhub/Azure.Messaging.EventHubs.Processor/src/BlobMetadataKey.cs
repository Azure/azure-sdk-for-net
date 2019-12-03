// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   The set of keys to access or modify metadata for a blob.
    /// </summary>
    ///
    /// <remarks>
    ///   The current storage SDK throws an exception when the key contains
    ///   an uppercase letter.
    /// </remarks>
    ///
    internal static class BlobMetadataKey
    {
        /// <summary>The key to the owner identifier metadata.</summary>
        public const string OwnerIdentifier = "ownerid";

        /// <summary>The key to the offset metadata.</summary>
        public const string Offset = "offset";

        /// <summary>The key to the sequence number metadata.</summary>
        public const string SequenceNumber = "sequencenumber";
    }
}
