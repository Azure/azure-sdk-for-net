// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace Azure.Storage.DataMovement.Blobs
{
    internal class BlobSourceCheckpointDetails : StorageResourceCheckpointDetails
    {
        public override int Length => 0;

        protected override void Serialize(Stream stream)
        {
        }

        internal static BlobSourceCheckpointDetails Deserialize(Stream stream) => new();
    }
}
