// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618
#pragma warning disable CS1591
#pragma warning disable CS0169
#pragma warning disable SA1508
#pragma warning disable SA1516
#pragma warning disable CA1822

namespace Azure.ResourceManager.SecurityCenter
{
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class AdaptiveNetworkHardeningCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource>, System.Collections.IEnumerable
    {
        protected AdaptiveNetworkHardeningCollection() { }
        public virtual Azure.Response<bool> Exists(string adaptiveNetworkHardeningResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string adaptiveNetworkHardeningResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource> Get(string adaptiveNetworkHardeningResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource>> GetAsync(string adaptiveNetworkHardeningResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource> GetIfExists(string adaptiveNetworkHardeningResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource>> GetIfExistsAsync(string adaptiveNetworkHardeningResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource>.GetEnumerator() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
