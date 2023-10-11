﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace Azure.Storage.DataMovement.Blobs
{
    internal class BlobSourceCheckpointData : StorageResourceCheckpointData
    {
        public override int Length => 0;

        protected override void Serialize(Stream stream)
        {
        }
    }
}
