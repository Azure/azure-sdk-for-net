// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Blobs;
using Microsoft.Azure.Storage.Blob;

namespace Microsoft.Azure.WebJobs
{
    internal static class StorageExtensions
    {
        // $$$ Move to better place. From 
        internal static void ValidateContractCompatibility<TPath>(this IBindablePath<TPath> path, IReadOnlyDictionary<string, Type> bindingDataContract)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }

            BindingTemplateExtensions.ValidateContractCompatibility(path.ParameterNames, bindingDataContract);
        }

        public static string GetBlobPath(this ICloudBlob blob)
        {
            return ToBlobPath(blob).ToString();
        }

        public static BlobPath ToBlobPath(this ICloudBlob blob)
        {
            if (blob == null)
            {
                throw new ArgumentNullException("blob");
            }

            return new BlobPath(blob.Container.Name, blob.Name);
        }
    }
}
