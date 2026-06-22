// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.StorageCache.Models
{
    internal partial class CacheProperties
    {
        // primingJobs is writable in TypeSpec, but the previous C# surface exposed it as read-only.
        [Microsoft.TypeSpec.Generator.Customizations.CodeGenMember("PrimingJobs")]
        public IReadOnlyList<PrimingJob> PrimingJobs { get; } = new ChangeTrackingList<PrimingJob>();
    }
}
