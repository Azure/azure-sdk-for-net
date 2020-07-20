// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Listeners
{
    // IStorageBlobClients are flyweights; distinct references do not equate to distinct storage accounts.
    internal class CloudBlobClientComparer : IEqualityComparer<CloudBlobClient>
    {
        public bool Equals(CloudBlobClient x, CloudBlobClient y)
        {
            if (x == null)
            {
                throw new ArgumentNullException(nameof(x));
            }
            if (y == null)
            {
                throw new ArgumentNullException(nameof(y));
            }

            return x.Credentials.AccountName == y.Credentials.AccountName;
        }

        public int GetHashCode(CloudBlobClient obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return obj.Credentials.AccountName.GetHashCode();
        }
    }
}
