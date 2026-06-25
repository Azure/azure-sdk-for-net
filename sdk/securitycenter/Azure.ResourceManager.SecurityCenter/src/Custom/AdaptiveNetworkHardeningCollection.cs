// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter
{
    // Generated code only emits operations whose resource scope and request path still exist in TypeSpec; this previous GA method used an old operation path, scope, or overload that no longer maps to a generated request. Keep a hidden ApiCompat shim and fail the unsupported operation explicitly.
    /// <summary>
    /// Provides a compatibility shim for the AdaptiveNetworkHardeningCollection class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [System.Obsolete("This API is no longer supported by the service. No direct replacement is available.")]
    public partial class AdaptiveNetworkHardeningCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource>, System.Collections.IEnumerable
    {
        private const string UnsupportedMessage = "This API is no longer supported by the service. No direct replacement is available.";

        /// <summary>
        /// Initializes a new instance of the <see cref="AdaptiveNetworkHardeningCollection"/> type for compatibility with the previous public API surface.
        /// </summary>
        protected AdaptiveNetworkHardeningCollection() { throw new System.NotSupportedException(UnsupportedMessage); }
        /// <summary>
        /// Provides a compatibility shim for the Exists operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="adaptiveNetworkHardeningResourceName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [System.Obsolete("This API is no longer supported by the service. No direct collection replacement is available.")]
        public virtual Azure.Response<bool> Exists(string adaptiveNetworkHardeningResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct collection replacement is available."); }
        /// <summary>
        /// Provides a compatibility shim for the ExistsAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="adaptiveNetworkHardeningResourceName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [System.Obsolete("This API is no longer supported by the service. No direct collection replacement is available.")]
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string adaptiveNetworkHardeningResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct collection replacement is available."); }
        /// <summary>
        /// Provides a compatibility shim for the Get operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="adaptiveNetworkHardeningResourceName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [System.Obsolete("This API is no longer supported by the service. No direct collection replacement is available.")]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource> Get(string adaptiveNetworkHardeningResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct collection replacement is available."); }
        /// <summary>
        /// Provides a compatibility shim for the GetAll operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [System.Obsolete("This API is no longer supported by the service. No direct collection replacement is available.")]
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct collection replacement is available."); }
        /// <summary>
        /// Provides a compatibility shim for the GetAllAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [System.Obsolete("This API is no longer supported by the service. No direct collection replacement is available.")]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct collection replacement is available."); }
        /// <summary>
        /// Provides a compatibility shim for the GetAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="adaptiveNetworkHardeningResourceName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [System.Obsolete("This API is no longer supported by the service. No direct collection replacement is available.")]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource>> GetAsync(string adaptiveNetworkHardeningResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct collection replacement is available."); }
        /// <summary>
        /// Provides a compatibility shim for the GetIfExists operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="adaptiveNetworkHardeningResourceName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [System.Obsolete("This API is no longer supported by the service. No direct collection replacement is available.")]
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource> GetIfExists(string adaptiveNetworkHardeningResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct collection replacement is available."); }
        /// <summary>
        /// Provides a compatibility shim for the GetIfExistsAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="adaptiveNetworkHardeningResourceName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [System.Obsolete("This API is no longer supported by the service. No direct collection replacement is available.")]
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource>> GetIfExistsAsync(string adaptiveNetworkHardeningResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct collection replacement is available."); }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource>.GetEnumerator() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
