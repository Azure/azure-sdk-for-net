// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Storage.DataMovement.Tests
{
    internal class TestProgressHandler : IProgress<StorageTransferProgress>
    {
        public List<StorageTransferProgress> Updates { get; private set; } = new List<StorageTransferProgress>();

        public void Report(StorageTransferProgress progress)
        {
            Updates.Add(progress);
        }
    }
}
