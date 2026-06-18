// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the NetworkVirtualApplianceSkuResource type. </summary>
    public partial class NetworkVirtualApplianceSkuResource
    {
        /// <summary> Invokes the AddTag compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.NetworkVirtualApplianceSkuResource> AddTag(global::System.String p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
        /// <summary> Invokes the RemoveTag compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.NetworkVirtualApplianceSkuResource> RemoveTag(global::System.String p0, global::System.Threading.CancellationToken p1) => default;
        /// <summary> Invokes the SetTags compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.NetworkVirtualApplianceSkuResource> SetTags(global::System.Collections.Generic.IDictionary<global::System.String, global::System.String> p0, global::System.Threading.CancellationToken p1) => default;
        /// <summary> Invokes the AddTagAsync compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.NetworkVirtualApplianceSkuResource>> AddTagAsync(global::System.String p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
        /// <summary> Invokes the RemoveTagAsync compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.NetworkVirtualApplianceSkuResource>> RemoveTagAsync(global::System.String p0, global::System.Threading.CancellationToken p1) => default;
        /// <summary> Invokes the SetTagsAsync compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.NetworkVirtualApplianceSkuResource>> SetTagsAsync(global::System.Collections.Generic.IDictionary<global::System.String, global::System.String> p0, global::System.Threading.CancellationToken p1) => default;
    }
}
