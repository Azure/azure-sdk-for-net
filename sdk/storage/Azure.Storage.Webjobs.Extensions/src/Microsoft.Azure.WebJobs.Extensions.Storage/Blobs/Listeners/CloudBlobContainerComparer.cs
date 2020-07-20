// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.Azure.Storage.Blob;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Listeners
{
    // IStorageBlobContainers are flyweights; distinct references do not equate to distinct containers.
    internal class CloudBlobContainerComparer : IEqualityComparer<CloudBlobContainer>
    {
        public bool Equals(CloudBlobContainer x, CloudBlobContainer y)
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

        public int GetHashCode(CloudBlobContainer obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return obj.Uri.GetHashCode();
        }
    }
}
