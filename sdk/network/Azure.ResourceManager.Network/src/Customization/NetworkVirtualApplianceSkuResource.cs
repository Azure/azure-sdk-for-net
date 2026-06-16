// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network
{
    public partial class NetworkVirtualApplianceSkuResource
    {
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.NetworkVirtualApplianceSkuResource> AddTag(global::System.String p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.NetworkVirtualApplianceSkuResource> RemoveTag(global::System.String p0, global::System.Threading.CancellationToken p1) => default;
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.NetworkVirtualApplianceSkuResource> SetTags(global::System.Collections.Generic.IDictionary<global::System.String, global::System.String> p0, global::System.Threading.CancellationToken p1) => default;
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.NetworkVirtualApplianceSkuResource>> AddTagAsync(global::System.String p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.NetworkVirtualApplianceSkuResource>> RemoveTagAsync(global::System.String p0, global::System.Threading.CancellationToken p1) => default;
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.NetworkVirtualApplianceSkuResource>> SetTagsAsync(global::System.Collections.Generic.IDictionary<global::System.String, global::System.String> p0, global::System.Threading.CancellationToken p1) => default;
    }
}
