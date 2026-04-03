// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using Azure.Storage.Common;

namespace Azure.Storage.DataMovement.Blobs
{
    internal class BlobSourceCheckpointDetails : StorageResourceCheckpointDetails
    {
        /// <summary>
        /// Schema version.
        /// </summary>
        public int Version;

        public override int Length => DataMovementBlobConstants.SourceCheckpointDetails.VariableLengthStartIndex;

        /// <summary>
        /// Constructor for creating from options.
        /// </summary>
        public BlobSourceCheckpointDetails(BlobStorageResourceOptions options = default)
        {
            Version = DataMovementBlobConstants.SourceCheckpointDetails.SchemaVersion;
        }

        /// <summary>
        /// Constructor for deserialization.
        /// </summary>
        public BlobSourceCheckpointDetails()
        {
            Version = DataMovementBlobConstants.SourceCheckpointDetails.SchemaVersion;
        }

        protected override void Serialize(Stream stream)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            using BinaryWriter writer = new BinaryWriter(stream, Encoding.UTF8, leaveOpen: true);

            // Version
            writer.Write(Version);
        }

        internal static BlobSourceCheckpointDetails Deserialize(Stream stream)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            // Handle empty stream (legacy/old checkpoints without snapshot/version support)
            if (stream.Length == 0)
            {
                return new BlobSourceCheckpointDetails();
            }

            using BinaryReader reader = new BinaryReader(stream, Encoding.UTF8, leaveOpen: true);

            // Version
            int version = reader.ReadInt32();
            if (version != DataMovementBlobConstants.SourceCheckpointDetails.SchemaVersion)
            {
                throw Errors.UnsupportedJobSchemaVersionHeader(version);
            }

            return new BlobSourceCheckpointDetails();
        }
    }
}
