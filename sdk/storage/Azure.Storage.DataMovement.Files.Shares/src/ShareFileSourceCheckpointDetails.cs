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

        /// <summary>
        /// Snapshot identifier for the source file.
        /// </summary>
        public string Snapshot;
        public byte[] SnapshotBytes;

        public override int Length => CalculateLength();

        /// <summary>
        /// Constructor for creating from options.
        /// </summary>
        public ShareFileSourceCheckpointDetails(
            ShareProtocol shareProtocol,
            ShareFileStorageResourceOptions options = default)
            : this(
                shareProtocol: shareProtocol,
                snapshot: options?.Snapshot)
        { }

        /// <summary>
        /// Constructor for deserialization.
        /// </summary>
        public ShareFileSourceCheckpointDetails(
            ShareProtocol shareProtocol,
            string snapshot)
        {
            Version = DataMovementShareConstants.SourceCheckpointDetails.SchemaVersion;
            ShareProtocol = shareProtocol;
            Snapshot = snapshot;
            SnapshotBytes = !string.IsNullOrEmpty(snapshot) ? Encoding.UTF8.GetBytes(snapshot) : Array.Empty<byte>();
        }

        protected override void Serialize(Stream stream)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            int currentVariableLengthIndex = DataMovementShareConstants.SourceCheckpointDetails.VariableLengthStartIndex;
            using BinaryWriter writer = new BinaryWriter(stream, Encoding.UTF8, leaveOpen: true);

            // Version
            writer.Write(Version);

            // ShareProtocol
            writer.Write((byte)ShareProtocol);

            // Snapshot offset/length
            if (SnapshotBytes.Length > 0)
            {
                writer.WriteVariableLengthFieldInfo(SnapshotBytes.Length, ref currentVariableLengthIndex);
            }
            else
            {
                // Padding for no snapshot
                writer.WriteEmptyLengthOffset();
            }

            // Write variable-length data
            if (SnapshotBytes.Length > 0)
            {
                writer.Write(SnapshotBytes);
            }
        }

        internal static ShareFileSourceCheckpointDetails Deserialize(Stream stream)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            ShareProtocol shareProtocol = ShareProtocol.Smb;
            string snapshot = null;

            // Handle empty stream (version 0 - legacy checkpoints)
            long streamLength = stream.Length;
            if (streamLength == 0)
            {
                return new ShareFileSourceCheckpointDetails(
                    shareProtocol: shareProtocol,
                    snapshot: null);
            }

            using BinaryReader reader = new BinaryReader(stream, Encoding.UTF8, leaveOpen: true);

            // Version
            int version = reader.ReadInt32();

            // Handle version 1 (no snapshot support)
            if (version == DataMovementShareConstants.SourceCheckpointDetails.SchemaVersion_1)
            {
                shareProtocol = (ShareProtocol)reader.ReadByte();
                return new ShareFileSourceCheckpointDetails(
                    shareProtocol: shareProtocol,
                    snapshot: null);
            }

            // Version 2+ with snapshot support
            if (version != DataMovementShareConstants.SourceCheckpointDetails.SchemaVersion)
            {
                throw Storage.Errors.UnsupportedJobSchemaVersionHeader(version);
            }

            // ShareProtocol
            shareProtocol = (ShareProtocol)reader.ReadByte();

            // Snapshot offset/length
            int snapshotOffset = reader.ReadInt32();
            int snapshotLength = reader.ReadInt32();

            // Read variable-length data
            if (snapshotOffset > 0)
            {
                CheckpointerExtensions.ValidateOffsetsAndLength(snapshotOffset, snapshotLength, streamLength);
                reader.BaseStream.Position = snapshotOffset;
                snapshot = Encoding.UTF8.GetString(reader.ReadBytes(snapshotLength));
            }

            return new ShareFileSourceCheckpointDetails(
                shareProtocol: shareProtocol,
                snapshot: snapshot);
        }

        private int CalculateLength()
        {
            int length = DataMovementShareConstants.SourceCheckpointDetails.VariableLengthStartIndex;
            if (SnapshotBytes.Length > 0)
            {
                length += SnapshotBytes.Length;
            }
            return length;
        }
    }
}
