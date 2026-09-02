// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.ServiceFabric.Models
{
    // PatchProxyResource is replaced with TrackedResource for C# (via @@alternateType),
    // which loses the etag property. Adding it back for backward compatibility.
    public partial class ServiceFabricApplicationPatch
    {
        /// <summary> Azure resource etag. </summary>
        public ETag? ETag { get; }
    }
}
