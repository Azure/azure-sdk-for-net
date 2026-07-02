// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs
{
    public partial class BlobClientSettings
    {
        internal string ConnectionString { get; set; }

        internal string BlobContainerName { get; set; }

        internal string BlobName { get; set; }
    }
}
