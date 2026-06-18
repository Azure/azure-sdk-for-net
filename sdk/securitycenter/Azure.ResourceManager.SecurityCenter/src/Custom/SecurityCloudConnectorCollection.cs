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
    public partial class SecurityCloudConnectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>, System.Collections.IEnumerable
    {
        protected SecurityCloudConnectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string connectorName, Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string connectorName, Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Response<bool> Exists(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> Get(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>> GetAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> GetIfExists(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>> GetIfExistsAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>.GetEnumerator() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
