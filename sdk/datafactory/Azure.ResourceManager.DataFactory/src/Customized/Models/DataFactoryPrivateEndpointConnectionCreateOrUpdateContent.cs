// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// MPG migration back-compat: expose Azure.ETag? ETag on the create-or-update content. The TypeSpec
// SubResource model carries `etag?: string` with @visibility(Lifecycle.Read), but the
// @@Legacy.hierarchyBuilding override re-parents the C# class to ProxyResource and drops the etag
// member. Re-declare it manually as a read-only Azure.ETag? so callers continue to compile.

#nullable disable

namespace Azure.ResourceManager.DataFactory.Models
{
    public partial class DataFactoryPrivateEndpointConnectionCreateOrUpdateContent
    {
        /// <summary> Etag identifies change in the resource. </summary>
        public Azure.ETag? ETag { get; }
    }
}
