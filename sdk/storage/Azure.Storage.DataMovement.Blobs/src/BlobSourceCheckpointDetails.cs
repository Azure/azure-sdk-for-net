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
        public bool IsSnapshotSet;
        public byte[] SnapshotBytes;

        /// <summary>
        /// Version identifier for the source blob.
        /// </summary>
        public string VersionId;
        public bool IsVersionIdSet;
        public byte[] VersionIdBytes;

        public override int Length => CalculateLength();

        /// <summary>
        /// Constructor for creating from options.
        /// </summary>
        public BlobSourceCheckpointDetails(BlobStorageResourceOptions options)
            : this(
                isSnapshotSet: options?._isSnapshotSet ?? false,
                snapshot: options?.Snapshot,
                isVersionIdSet: options?._isVersionIdSet ?? false,
                versionId: options?.VersionId)
        { }

        /// <summary>
        /// Constructor for deserialization.
        /// </summary>
        public BlobSourceCheckpointDetails(
            bool isSnapshotSet,
            string snapshot,
            bool isVersionIdSet,
            string versionId)
        {
            Version = DataMovementBlobConstants.SourceCheckpointDetails.SchemaVersion;

            IsSnapshotSet = isSnapshotSet;
            Snapshot = snapshot;
            SnapshotBytes = snapshot != default ? Encoding.UTF8.GetBytes(snapshot) : Array.Empty<byte>();

            IsVersionIdSet = isVersionIdSet;
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

            // Snapshot
            writer.Write(IsSnapshotSet);
            if (IsSnapshotSet)
            {
                // Snapshot offset/length
                writer.WriteVariableLengthFieldInfo(SnapshotBytes.Length, ref currentVariableLengthIndex);
            }
            else
            {
                // Padding
                writer.WriteEmptyLengthOffset();
            }

            // VersionId
            writer.Write(IsVersionIdSet);
            if (IsVersionIdSet)
            {
                // VersionId offset/length
                writer.WriteVariableLengthFieldInfo(VersionIdBytes.Length, ref currentVariableLengthIndex);
            }
            else
            {
                // Padding
                writer.WriteEmptyLengthOffset();
            }

            // Write variable-length data
            if (IsSnapshotSet)
            {
                writer.Write(SnapshotBytes);
            }
            if (IsVersionIdSet)
            {
                writer.Write(VersionIdBytes);
            }
        }

        internal static BlobSourceCheckpointDetails Deserialize(Stream stream)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            // Handle empty stream (legacy/old checkpoints)
            if (stream.Length == 0)
            {
                return new BlobSourceCheckpointDetails(
                    isSnapshotSet: false,
                    snapshot: null,
                    isVersionIdSet: false,
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
            bool isSnapshotSet = reader.ReadBoolean();
            int snapshotOffset = reader.ReadInt32();
            int snapshotLength = reader.ReadInt32();

            // VersionId
            bool isVersionIdSet = reader.ReadBoolean();
            int versionIdOffset = reader.ReadInt32();
            int versionIdLength = reader.ReadInt32();

            // Read variable-length data
            string snapshot = null;
            if (snapshotOffset > 0)
            {
                // TODO: CheckpointerExtensions.ValidateOffsetsAndLength(snapshotOffset, snapshotLength, streamLength);
                reader.BaseStream.Position = snapshotOffset;
                snapshot = reader.ReadBytes(snapshotLength).AsString();
            }

            string versionId = null;
            if (versionIdOffset > 0)
            {
                // TODO: CheckpointerExtensions.ValidateOffsetsAndLength(versionIdOffset, versionIdLength, streamLength);
                reader.BaseStream.Position = versionIdOffset;
                versionId = reader.ReadBytes(versionIdLength).AsString();
            }

            return new BlobSourceCheckpointDetails(
                isSnapshotSet: isSnapshotSet,
                snapshot: snapshot,
                isVersionIdSet: isVersionIdSet,
                versionId: versionId);
        }

        private int CalculateLength()
        {
            int length = DataMovementBlobConstants.SourceCheckpointDetails.VariableLengthStartIndex;
            if (IsSnapshotSet)
            {
                length += SnapshotBytes.Length;
            }
            if (IsVersionIdSet)
            {
                length += VersionIdBytes.Length;
            }
            return length;
        }
    }
}
