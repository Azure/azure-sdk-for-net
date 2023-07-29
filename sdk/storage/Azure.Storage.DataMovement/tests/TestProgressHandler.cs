// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Storage.DataMovement.Tests
{
    internal class TestProgressHandler : IProgress<DataTransferProgress>
    {
        public List<DataTransferProgress> Updates { get; private set; } = new List<DataTransferProgress>();

        public void Report(DataTransferProgress progress)
        {
            Updates.Add(progress);
        }
    }
}
