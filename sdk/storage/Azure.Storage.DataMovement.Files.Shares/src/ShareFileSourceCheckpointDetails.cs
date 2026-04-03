// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using Azure.Storage.Common;

namespace Azure.Storage.DataMovement.Files.Shares
{
    internal class ShareFileSourceCheckpointDetails : StorageResourceCheckpointDetailsInternal
    {
        /// <summary>
        /// Schema version.
        /// </summary>
        public int Version;

        /// <summary>
        /// Share Protocol for source files/directories.
        /// </summary>
        public ShareProtocol ShareProtocol;

        public override int Length => DataMovementShareConstants.SourceCheckpointDetails.DataSize;

        public ShareFileSourceCheckpointDetails(
            ShareProtocol shareProtocol)
        {
            Version = DataMovementShareConstants.SourceCheckpointDetails.SchemaVersion;
            ShareProtocol = shareProtocol;
        }

        protected override void Serialize(Stream stream)
        {
            Argument.AssertNotNull(stream, nameof(stream));
            BinaryWriter writer = new(stream);

            // Version
            writer.Write(Version);

            // ShareProtocol
            writer.Write((byte)ShareProtocol);
        }

        internal static ShareFileSourceCheckpointDetails Deserialize(Stream stream)
        {
            Argument.AssertNotNull(stream, nameof(stream));
            BinaryReader reader = new BinaryReader(stream);

            ShareProtocol shareProtocol = ShareProtocol.Smb;
            // If it is version 1+ (before version 1, stream is empty and Version did not exist)
            if (stream.Length > 0)
            {
                int version = reader.ReadInt32();
                if (version != DataMovementShareConstants.SourceCheckpointDetails.SchemaVersion)
                {
                    throw Storage.Errors.UnsupportedJobSchemaVersionHeader(version);
                }
                shareProtocol = (ShareProtocol)reader.ReadByte();
            }

            // When deserializing, the version of the new CheckpointDetails is always the latest version.
            return new(shareProtocol: shareProtocol);
        }
    }
}
