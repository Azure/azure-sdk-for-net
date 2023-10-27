// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using Azure.Core;

namespace Azure.Storage.DataMovement.Files.Shares
{
    internal class ShareFileSourceCheckpointData : StorageResourceCheckpointData
    {
        /// <summary>
        /// Schema version.
        /// </summary>
        public int Version;

        public override int Length => 0;

        public ShareFileSourceCheckpointData()
        {
            Version = DataMovementShareConstants.DestinationCheckpointData.SchemaVersion;
        }

        internal void SerializeInternal(Stream stream) => Serialize(stream);

        protected override void Serialize(Stream stream)
        {
            Argument.AssertNotNull(stream, nameof(stream));
            BinaryWriter writer = new BinaryWriter(stream);

            // Version
            writer.Write(Version);
        }

        internal static ShareFileSourceCheckpointData Deserialize(Stream stream)
        {
            Argument.AssertNotNull(stream, nameof(stream));
            BinaryReader reader = new BinaryReader(stream);

            // Version
            int version = reader.ReadInt32();
            if (version != DataMovementShareConstants.SourceCheckpointData.SchemaVersion)
            {
                throw Storage.Errors.UnsupportedJobSchemaVersionHeader(version.ToString());
            }

            return new ShareFileSourceCheckpointData();
        }
    }
}
