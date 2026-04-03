// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
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

        public override int Length => DataMovementShareConstants.SourceCheckpointDetails.VariableLengthStartIndex;

        /// <summary>
        /// Constructor for creating from options.
        /// </summary>
        public ShareFileSourceCheckpointDetails(
            ShareProtocol shareProtocol,
            ShareFileStorageResourceOptions options = default)
        {
            Version = DataMovementShareConstants.SourceCheckpointDetails.SchemaVersion;
            ShareProtocol = shareProtocol;
        }

        /// <summary>
        /// Constructor for deserialization.
        /// </summary>
        public ShareFileSourceCheckpointDetails(ShareProtocol shareProtocol)
        {
            Version = DataMovementShareConstants.SourceCheckpointDetails.SchemaVersion;
            ShareProtocol = shareProtocol;
        }

        protected override void Serialize(Stream stream)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            using BinaryWriter writer = new BinaryWriter(stream, Encoding.UTF8, leaveOpen: true);

            // Version
            writer.Write(Version);

            // ShareProtocol
            writer.Write((byte)ShareProtocol);
        }

        internal static ShareFileSourceCheckpointDetails Deserialize(Stream stream)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            ShareProtocol shareProtocol = ShareProtocol.Smb;

            // Handle empty stream (version 0 - legacy checkpoints)
            if (stream.Length == 0)
            {
                return new ShareFileSourceCheckpointDetails(shareProtocol);
            }

            using BinaryReader reader = new BinaryReader(stream, Encoding.UTF8, leaveOpen: true);

            // Version
            int version = reader.ReadInt32();

            // Handle version 1 (original version)
            if (version == DataMovementShareConstants.SourceCheckpointDetails.SchemaVersion_1)
            {
                shareProtocol = (ShareProtocol)reader.ReadByte();
                return new ShareFileSourceCheckpointDetails(shareProtocol);
            }

            // Current version
            if (version != DataMovementShareConstants.SourceCheckpointDetails.SchemaVersion)
            {
                throw Storage.Errors.UnsupportedJobSchemaVersionHeader(version);
            }

            // ShareProtocol
            shareProtocol = (ShareProtocol)reader.ReadByte();

            return new ShareFileSourceCheckpointDetails(shareProtocol);
        }
    }
}
