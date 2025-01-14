// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace Azure.Storage.DataMovement
{
    internal class LocalSourceCheckpointDetails : StorageResourceCheckpointDetails
    {
        public override int Length => 0;

        protected internal override void Serialize(Stream stream)
        {
        }
    }
}
