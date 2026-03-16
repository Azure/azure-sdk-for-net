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

        /// <summary>
        /// Snapshot identifier for the source blob.
        /// </summary>
        public string Snapshot;
        public byte[] SnapshotBytes;

        /// <summary>
        /// Version identifier for the source blob.
        /// </summary>
        public string VersionId;
        public byte[] VersionIdBytes;

        public override int Length => CalculateLength();

        /// <summary>
        /// Constructor for creating from options.
        /// </summary>
        public BlobSourceCheckpointDetails(BlobStorageResourceOptions options)
            : this(
                snapshot: options?.Snapshot,
                versionId: options?.VersionId)
        { }

        /// <summary>
        /// Constructor for deserialization.
        /// </summary>
        public BlobSourceCheckpointDetails(
            string snapshot,
            string versionId)
        {
            Version = DataMovementBlobConstants.SourceCheckpointDetails.SchemaVersion;
            Snapshot = snapshot;
            SnapshotBytes = snapshot != default ? Encoding.UTF8.GetBytes(snapshot) : Array.Empty<byte>();

            VersionId = versionId;
            VersionIdBytes = versionId != default ? Encoding.UTF8.GetBytes(versionId) : Array.Empty<byte>();
        }

        protected override void Serialize(Stream stream)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            int currentVariableLengthIndex = DataMovementBlobConstants.SourceCheckpointDetails.VariableLengthStartIndex;
            using BinaryWriter writer = new BinaryWriter(stream, Encoding.UTF8, leaveOpen: true);

            // Version
            writer.Write(Version);

            // Snapshot offset/length
            writer.WriteVariableLengthFieldInfo(SnapshotBytes.Length, ref currentVariableLengthIndex);

            // VersionId offset/length
            writer.WriteVariableLengthFieldInfo(VersionIdBytes.Length, ref currentVariableLengthIndex);

            // Write variable-length data
            if (SnapshotBytes.Length > 0)
            {
                writer.Write(SnapshotBytes);
            }
            if (VersionIdBytes.Length > 0)
            {
                writer.Write(VersionIdBytes);
            }
        }

        internal static BlobSourceCheckpointDetails Deserialize(Stream stream)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            // Handle empty stream (legacy/old checkpoints)
            long streamLength = stream.Length;
            if (streamLength == 0)
            {
                return new BlobSourceCheckpointDetails(
                    snapshot: null,
                    versionId: null);
            }

            using BinaryReader reader = new BinaryReader(stream, Encoding.UTF8, leaveOpen: true);

            // Version
            int version = reader.ReadInt32();
            if (version != DataMovementBlobConstants.SourceCheckpointDetails.SchemaVersion)
            {
                throw Errors.UnsupportedJobSchemaVersionHeader(version);
            }

            // Snapshot
            int snapshotOffset = reader.ReadInt32();
            int snapshotLength = reader.ReadInt32();

            // VersionId
            int versionIdOffset = reader.ReadInt32();
            int versionIdLength = reader.ReadInt32();

            // Read variable-length data
            string snapshot = null;
            if (snapshotOffset > 0)
            {
                CheckpointerExtensions.ValidateOffsetsAndLength(snapshotOffset, snapshotLength, streamLength);
                reader.BaseStream.Position = snapshotOffset;
                snapshot = reader.ReadBytes(snapshotLength).AsString();
            }

            string versionId = null;
            if (versionIdOffset > 0)
            {
                CheckpointerExtensions.ValidateOffsetsAndLength(versionIdOffset, versionIdLength, streamLength);
                reader.BaseStream.Position = versionIdOffset;
                versionId = reader.ReadBytes(versionIdLength).AsString();
            }

            return new BlobSourceCheckpointDetails(
                snapshot: snapshot,
                versionId: versionId);
        }

        private int CalculateLength()
        {
            int length = DataMovementBlobConstants.SourceCheckpointDetails.VariableLengthStartIndex;
            length += SnapshotBytes.Length;
            length += VersionIdBytes.Length;

            return length;
        }
    }
}
