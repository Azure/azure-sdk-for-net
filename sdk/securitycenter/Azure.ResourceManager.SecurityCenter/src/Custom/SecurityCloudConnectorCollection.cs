// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter
{
    // Generated code only emits operations whose resource scope and request path still exist in TypeSpec; this previous GA method used an old operation path, scope, or overload that no longer maps to a generated request. Keep a hidden ApiCompat shim and fail the unsupported operation explicitly.
    /// <summary>
    /// Provides a compatibility shim for the SecurityCloudConnectorCollection class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [System.Obsolete("This API is no longer supported by the service. No direct replacement is available.")]
    public partial class SecurityCloudConnectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>, System.Collections.IEnumerable
    {
        private const string UnsupportedMessage = "This API is no longer supported by the service. No direct replacement is available.";

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityCloudConnectorCollection"/> type for compatibility with the previous public API surface.
        /// </summary>
        protected SecurityCloudConnectorCollection() { throw new System.NotSupportedException(UnsupportedMessage); }
        /// <summary>
        /// Provides a compatibility shim for the CreateOrUpdate operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="connectorName">The value preserved for API compatibility.</param>
        /// <param name="data">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [System.Obsolete("This API is no longer supported by the service. No direct collection replacement is available.")]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string connectorName, Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct collection replacement is available."); }
        /// <summary>
        /// Provides a compatibility shim for the CreateOrUpdateAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="connectorName">The value preserved for API compatibility.</param>
        /// <param name="data">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [System.Obsolete("This API is no longer supported by the service. No direct collection replacement is available.")]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string connectorName, Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct collection replacement is available."); }
        /// <summary>
        /// Provides a compatibility shim for the Exists operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="connectorName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [System.Obsolete("This API is no longer supported by the service. No direct collection replacement is available.")]
        public virtual Azure.Response<bool> Exists(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct collection replacement is available."); }
        /// <summary>
        /// Provides a compatibility shim for the ExistsAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="connectorName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [System.Obsolete("This API is no longer supported by the service. No direct collection replacement is available.")]
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct collection replacement is available."); }
        /// <summary>
        /// Provides a compatibility shim for the Get operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="connectorName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [System.Obsolete("This API is no longer supported by the service. No direct collection replacement is available.")]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> Get(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct collection replacement is available."); }
        /// <summary>
        /// Provides a compatibility shim for the GetAll operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [System.Obsolete("This API is no longer supported by the service. No direct collection replacement is available.")]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct collection replacement is available."); }
        /// <summary>
        /// Provides a compatibility shim for the GetAllAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [System.Obsolete("This API is no longer supported by the service. No direct collection replacement is available.")]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct collection replacement is available."); }
        /// <summary>
        /// Provides a compatibility shim for the GetAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="connectorName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [System.Obsolete("This API is no longer supported by the service. No direct collection replacement is available.")]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>> GetAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct collection replacement is available."); }
        /// <summary>
        /// Provides a compatibility shim for the GetIfExists operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="connectorName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [System.Obsolete("This API is no longer supported by the service. No direct collection replacement is available.")]
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> GetIfExists(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct collection replacement is available."); }
        /// <summary>
        /// Provides a compatibility shim for the GetIfExistsAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="connectorName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [System.Obsolete("This API is no longer supported by the service. No direct collection replacement is available.")]
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>> GetIfExistsAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct collection replacement is available."); }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>.GetEnumerator() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
