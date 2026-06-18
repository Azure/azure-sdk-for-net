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
    public partial class CustomEntityStoreAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource>, System.Collections.IEnumerable
    {
        protected CustomEntityStoreAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string customEntityStoreAssignmentName, Azure.ResourceManager.SecurityCenter.Models.CustomEntityStoreAssignmentCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string customEntityStoreAssignmentName, Azure.ResourceManager.SecurityCenter.Models.CustomEntityStoreAssignmentCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Response<bool> Exists(string customEntityStoreAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string customEntityStoreAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> Get(string customEntityStoreAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource>> GetAsync(string customEntityStoreAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> GetIfExists(string customEntityStoreAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource>> GetIfExistsAsync(string customEntityStoreAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource>.GetEnumerator() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
