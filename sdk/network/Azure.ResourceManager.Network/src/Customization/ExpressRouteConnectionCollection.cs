// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ExpressRouteConnectionCollection type. </summary>
    public partial class ExpressRouteConnectionCollection : global::System.Collections.Generic.IEnumerable<global::Azure.ResourceManager.Network.ExpressRouteConnectionResource>, global::System.Collections.Generic.IAsyncEnumerable<global::Azure.ResourceManager.Network.ExpressRouteConnectionResource>
    {
        /// <summary> Invokes the GetAllAsync compatibility operation. </summary>
        public virtual global::Azure.AsyncPageable<global::Azure.ResourceManager.Network.ExpressRouteConnectionResource> GetAllAsync(global::System.Threading.CancellationToken p0 = default) => default;
        /// <summary> Invokes the GetAll compatibility operation. </summary>
        public virtual global::Azure.Pageable<global::Azure.ResourceManager.Network.ExpressRouteConnectionResource> GetAll(global::System.Threading.CancellationToken p0 = default) => default;
        global::System.Collections.Generic.IAsyncEnumerator<global::Azure.ResourceManager.Network.ExpressRouteConnectionResource> global::System.Collections.Generic.IAsyncEnumerable<global::Azure.ResourceManager.Network.ExpressRouteConnectionResource>.GetAsyncEnumerator(global::System.Threading.CancellationToken p0) => default;
        global::System.Collections.Generic.IEnumerator<global::Azure.ResourceManager.Network.ExpressRouteConnectionResource> global::System.Collections.Generic.IEnumerable<global::Azure.ResourceManager.Network.ExpressRouteConnectionResource>.GetEnumerator() => default;
        global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator() => default;
    }
}
