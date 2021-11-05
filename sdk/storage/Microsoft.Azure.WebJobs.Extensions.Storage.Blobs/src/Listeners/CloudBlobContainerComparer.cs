// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Storage.Blobs;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    // IStorageBlobContainers are flyweights; distinct references do not equate to distinct containers.
    internal class CloudBlobContainerComparer : IEqualityComparer<BlobContainerClient>
    {
        public bool Equals(BlobContainerClient x, BlobContainerClient y)
        {
            if (x == null)
            {
                throw new ArgumentNullException(nameof(x));
            }
            if (y == null)
            {
                throw new ArgumentNullException(nameof(y));
            }

            return x.Uri == y.Uri;
        }

        public int GetHashCode(BlobContainerClient obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return obj.Uri.GetHashCode();
        }
    }
}
