// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Containers.ContainerRegistry.Specialized
{
    internal class ChunkedUploadResult
    {
        public ChunkedUploadResult(string digest, string location, long size)
        {
            Digest = digest;
            Location = location;
            Size = size;
        }

        public string Digest { get; }

        public string Location { get; }

        public long Size { get; }
    }
}
