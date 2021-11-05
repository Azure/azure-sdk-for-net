// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs.Specialized;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    internal class StorageBlobConverter<T> : IConverter<BlobBaseClient, T> where T : BlobBaseClient
    {
        public T Convert(BlobBaseClient input)
        {
            if (input == null)
            {
                return default(T);
            }

            T blob = input as T;

            if (blob == null)
            {
                throw new InvalidOperationException($"The blob is not an {typeof(T).Name}.");
            }

            return blob;
        }
    }
}
