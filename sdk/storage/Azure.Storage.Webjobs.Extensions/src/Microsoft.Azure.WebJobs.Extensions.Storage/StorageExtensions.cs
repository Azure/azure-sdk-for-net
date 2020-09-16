// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Blobs;
using Azure.Storage.Blobs.Specialized;

namespace Microsoft.Azure.WebJobs
{
    internal static class StorageExtensions
    {
        // $$$ Move to better place. From
        internal static void ValidateContractCompatibility<TPath>(this IBindablePath<TPath> path, IReadOnlyDictionary<string, Type> bindingDataContract)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            BindingTemplateExtensions.ValidateContractCompatibility(path.ParameterNames, bindingDataContract);
        }

        public static string GetBlobPath(this BlobBaseClient blob)
        {
            return ToBlobPath(blob).ToString();
        }

        public static BlobPath ToBlobPath(this BlobBaseClient blob)
        {
            if (blob == null)
            {
                throw new ArgumentNullException(nameof(blob));
            }

            return new BlobPath(blob.BlobContainerName, blob.Name);
        }
    }
}
