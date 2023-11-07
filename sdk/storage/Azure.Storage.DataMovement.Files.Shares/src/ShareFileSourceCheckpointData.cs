// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace Azure.Storage.DataMovement.Files.Shares
{
    internal class ShareFileSourceCheckpointData : StorageResourceCheckpointData
    {
        public override int Length => 0;

        internal void SerializeInternal(Stream stream) => Serialize(stream);

        protected override void Serialize(Stream stream)
        {
        }

        internal static ShareFileSourceCheckpointData Deserialize(Stream stream) => new();
    }
}
