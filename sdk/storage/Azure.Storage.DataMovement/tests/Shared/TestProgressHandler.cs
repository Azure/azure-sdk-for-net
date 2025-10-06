// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Storage.DataMovement.Tests
{
    internal class TestProgressHandler : IProgress<TransferProgress>
    {
        public List<TransferProgress> Updates { get; private set; } = new List<TransferProgress>();

        public void Report(TransferProgress progress)
        {
            Updates.Add(progress);
        }
    }
}
