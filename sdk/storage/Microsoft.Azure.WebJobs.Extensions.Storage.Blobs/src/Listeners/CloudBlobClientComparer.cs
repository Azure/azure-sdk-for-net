// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Storage.Blobs;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    // IStorageBlobClients are flyweights; distinct references do not equate to distinct storage accounts.
    internal class CloudBlobClientComparer : IEqualityComparer<BlobServiceClient>
    {
        public bool Equals(BlobServiceClient x, BlobServiceClient y)
        {
            if (x == null)
            {
                throw new ArgumentNullException(nameof(x));
            }
            if (y == null)
            {
                throw new ArgumentNullException(nameof(y));
            }

            return x.AccountName == y.AccountName;
        }

        public int GetHashCode(BlobServiceClient obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            // BlobServiceClient.AccountName can be null for vanity domains and
            // other less common scenarios (including underspecified mocks).
            return obj.AccountName?.GetHashCode() ?? 0;
        }
    }
}
