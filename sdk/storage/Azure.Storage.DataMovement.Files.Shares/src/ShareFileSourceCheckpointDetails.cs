// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace Azure.Storage.DataMovement.Files.Shares
{
    internal class ShareFileSourceCheckpointDetails : StorageResourceCheckpointDetailsInternal
    {
        public override int Length => 0;

        protected override void Serialize(Stream stream)
        {
        }

        internal static ShareFileSourceCheckpointDetails Deserialize(Stream stream) => new();
    }
}
