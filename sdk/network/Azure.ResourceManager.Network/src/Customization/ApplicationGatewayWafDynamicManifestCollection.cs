// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <inheritdoc/>
    public partial class ApplicationGatewayWafDynamicManifestCollection : global::Azure.ResourceManager.ArmCollection, global::System.Collections.Generic.IEnumerable<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource>, global::System.Collections.Generic.IAsyncEnumerable<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource>
    {
        /// <inheritdoc/>
        protected ApplicationGatewayWafDynamicManifestCollection() { }
        /// <inheritdoc/>
        public virtual global::Azure.AsyncPageable<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource> GetAllAsync(global::System.Threading.CancellationToken p0 = default) => default;
        /// <inheritdoc/>
        public virtual global::Azure.Pageable<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource> GetAll(global::System.Threading.CancellationToken p0 = default) => default;
        /// <inheritdoc/>
        public virtual global::Azure.NullableResponse<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource> GetIfExists(global::System.Threading.CancellationToken p0 = default) => default;
        /// <inheritdoc/>
        public virtual global::Azure.NullableResponse<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource> GetIfExists(global::System.String p0, global::System.Threading.CancellationToken p1 = default) => GetIfExists(p1);
        /// <inheritdoc/>
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource> Get(global::System.Threading.CancellationToken p0 = default) => default;
        /// <inheritdoc/>
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource> Get(global::System.String p0, global::System.Threading.CancellationToken p1 = default) => Get(p1);
        /// <inheritdoc/>
        public virtual global::Azure.Response<global::System.Boolean> Exists(global::System.Threading.CancellationToken p0 = default) => default;
        /// <inheritdoc/>
        public virtual global::Azure.Response<global::System.Boolean> Exists(global::System.String p0, global::System.Threading.CancellationToken p1 = default) => Exists(p1);
        /// <inheritdoc/>
        public virtual global::System.Threading.Tasks.Task<global::Azure.NullableResponse<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource>> GetIfExistsAsync(global::System.Threading.CancellationToken p0 = default) => default;
        /// <inheritdoc/>
        public virtual global::System.Threading.Tasks.Task<global::Azure.NullableResponse<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource>> GetIfExistsAsync(global::System.String p0, global::System.Threading.CancellationToken p1 = default) => GetIfExistsAsync(p1);
        /// <inheritdoc/>
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource>> GetAsync(global::System.Threading.CancellationToken p0 = default) => default;
        /// <inheritdoc/>
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource>> GetAsync(global::System.String p0, global::System.Threading.CancellationToken p1 = default) => GetAsync(p1);
        /// <inheritdoc/>
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::System.Boolean>> ExistsAsync(global::System.Threading.CancellationToken p0 = default) => default;
        /// <inheritdoc/>
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::System.Boolean>> ExistsAsync(global::System.String p0, global::System.Threading.CancellationToken p1 = default) => ExistsAsync(p1);
        global::System.Collections.Generic.IAsyncEnumerator<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource> global::System.Collections.Generic.IAsyncEnumerable<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource>.GetAsyncEnumerator(global::System.Threading.CancellationToken p0) => default;
        global::System.Collections.Generic.IEnumerator<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource> global::System.Collections.Generic.IEnumerable<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource>.GetEnumerator() => default;
        global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator() => default;
    }
}
