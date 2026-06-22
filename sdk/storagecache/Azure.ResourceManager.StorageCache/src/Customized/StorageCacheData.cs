// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.StorageCache.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.StorageCache
{
    [CodeGenType("Cache")]
    public partial class StorageCacheData : TrackedResourceData
    {
        // primingJobs is writable in TypeSpec, but the previous C# surface exposed it as read-only.
        /// <summary> Specifies the priming jobs defined in the cache. </summary>
        [CodeGenMember("PrimingJobs")]
        public IReadOnlyList<PrimingJob> PrimingJobs
        {
            get
            {
                return Properties?.PrimingJobs as IReadOnlyList<PrimingJob>;
            }
        }
    }
}
