// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.DataMovement.Blobs
{
    internal class BlobSourceCheckpointData : BlobCheckpointData
    {
        public BlobSourceCheckpointData(BlobType blobType)
            : base(DataMovementBlobConstants.SourceCheckpointData.SchemaVersion, blobType)
        {
        }

        public override int Length => DataMovementBlobConstants.SourceCheckpointData.DataSize;

        protected override void Serialize(Stream stream)
        {
            if (stream == null)
			{
				throw new ArgumentNullException(nameof(stream));
			}
            BinaryWriter writer = new BinaryWriter(stream);

            // Version
            writer.Write(Version);

            // BlobType
            writer.Write((byte)BlobType);
        }

        internal static BlobSourceCheckpointData Deserialize(Stream stream)
        {
            if (stream == null)
			{
				throw new ArgumentNullException(nameof(stream));
			}
            BinaryReader reader = new BinaryReader(stream);

            // Version
            int version = reader.ReadInt32();
            if (version != DataMovementBlobConstants.SourceCheckpointData.SchemaVersion)
            {
                throw Errors.UnsupportedJobSchemaVersionHeader(version.ToString());
            }

            // BlobType
            BlobType blobType = (BlobType)reader.ReadByte();

            return new BlobSourceCheckpointData(blobType);
        }
    }
}
