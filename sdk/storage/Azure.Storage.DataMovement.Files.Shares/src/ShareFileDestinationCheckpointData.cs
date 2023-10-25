﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace Azure.Storage.DataMovement.Files.Shares
{
    internal class ShareFileDestinationCheckpointData : StorageResourceCheckpointData
    {
        public override int Length => 0;

        protected override void Serialize(Stream stream)
        {
        }
    }
}
