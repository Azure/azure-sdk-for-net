// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.WebJobs.Host.Converters;
using Microsoft.Azure.Storage.Blob;

namespace Microsoft.Azure.WebJobs.Host.Blobs
{
    internal class StorageBlobConverter<T> : IConverter<ICloudBlob, T> where T : class, ICloudBlob
    {
        public T Convert(ICloudBlob input)
        {
            if (input == null)
            {
                return default(T);
            }

            T appendBlob = input as T;

            if (appendBlob == null)
            {
                throw new InvalidOperationException($"The blob is not an {typeof(T).Name}.");
            }

            return appendBlob;
        }
    }
}
