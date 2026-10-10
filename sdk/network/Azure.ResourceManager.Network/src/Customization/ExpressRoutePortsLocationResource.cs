// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ExpressRoutePortsLocationResource type. </summary>
    public partial class ExpressRoutePortsLocationResource
    {
        /// <summary> Invokes the AddTag compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release. There is no replacement operation for `ExpressRoutePortsLocationResource.AddTag`.", false)]
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.ExpressRoutePortsLocationResource> AddTag(global::System.String p0, global::System.String p1, global::System.Threading.CancellationToken p2) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the RemoveTag compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release. There is no replacement operation for `ExpressRoutePortsLocationResource.RemoveTag`.", false)]
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.ExpressRoutePortsLocationResource> RemoveTag(global::System.String p0, global::System.Threading.CancellationToken p1) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the SetTags compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release. There is no replacement operation for `ExpressRoutePortsLocationResource.SetTags`.", false)]
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.ExpressRoutePortsLocationResource> SetTags(global::System.Collections.Generic.IDictionary<global::System.String, global::System.String> p0, global::System.Threading.CancellationToken p1) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the AddTagAsync compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release. There is no replacement operation for `ExpressRoutePortsLocationResource.AddTagAsync`.", false)]
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.ExpressRoutePortsLocationResource>> AddTagAsync(global::System.String p0, global::System.String p1, global::System.Threading.CancellationToken p2) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the RemoveTagAsync compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release. There is no replacement operation for `ExpressRoutePortsLocationResource.RemoveTagAsync`.", false)]
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.ExpressRoutePortsLocationResource>> RemoveTagAsync(global::System.String p0, global::System.Threading.CancellationToken p1) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the SetTagsAsync compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release. There is no replacement operation for `ExpressRoutePortsLocationResource.SetTagsAsync`.", false)]
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.ExpressRoutePortsLocationResource>> SetTagsAsync(global::System.Collections.Generic.IDictionary<global::System.String, global::System.String> p0, global::System.Threading.CancellationToken p1) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
    }
}
