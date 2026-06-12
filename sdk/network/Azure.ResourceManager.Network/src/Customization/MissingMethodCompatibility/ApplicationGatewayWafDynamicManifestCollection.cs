// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network
{
    public partial class ApplicationGatewayWafDynamicManifestCollection : global::Azure.ResourceManager.ArmCollection, global::System.Collections.Generic.IEnumerable<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource>, global::System.Collections.Generic.IAsyncEnumerable<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource>
    {
        protected ApplicationGatewayWafDynamicManifestCollection() { }
        public virtual global::Azure.AsyncPageable<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource> GetAllAsync(global::System.Threading.CancellationToken p0) => default;
        public virtual global::Azure.Pageable<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource> GetAll(global::System.Threading.CancellationToken p0) => default;
        public virtual global::Azure.NullableResponse<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource> GetIfExists(global::System.Threading.CancellationToken p0) => default;
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource> Get(global::System.Threading.CancellationToken p0) => default;
        public virtual global::Azure.Response<global::System.Boolean> Exists(global::System.Threading.CancellationToken p0) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.NullableResponse<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource>> GetIfExistsAsync(global::System.Threading.CancellationToken p0) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource>> GetAsync(global::System.Threading.CancellationToken p0) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::System.Boolean>> ExistsAsync(global::System.Threading.CancellationToken p0) => default;
        global::System.Collections.Generic.IAsyncEnumerator<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource> global::System.Collections.Generic.IAsyncEnumerable<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource>.GetAsyncEnumerator(global::System.Threading.CancellationToken p0) => default;
        global::System.Collections.Generic.IEnumerator<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource> global::System.Collections.Generic.IEnumerable<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource>.GetEnumerator() => default;
        global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator() => default;
    }
}
