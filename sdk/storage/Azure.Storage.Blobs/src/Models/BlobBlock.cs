// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Represents a single block in a block blob.  It describes the block's ID and size.
    /// </summary>
    [CodeGenModel("Block")]
    public readonly partial struct BlobBlock {}
}
