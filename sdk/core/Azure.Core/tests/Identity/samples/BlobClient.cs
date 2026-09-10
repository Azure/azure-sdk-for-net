// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Storage.Blobs
{
    // Stand-in for the real BlobClient so the credential snippets compile without taking a
    // project reference on Azure.Storage.Blobs (which would create a circular dependency
    // back through Azure.Core).
    internal class BlobClient
    {
        public BlobClient(Uri blobUri, TokenCredential credential)
        {
        }
    }
}
