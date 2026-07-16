// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter
{
    // Generated code only emits operations whose resource scope and request path still exist in TypeSpec; this previous GA method used an old operation path, scope, or overload that no longer maps to a generated request. Keep a hidden ApiCompat shim and fail the unsupported operation explicitly.
    /// <summary>
    /// Provides a compatibility shim for the AdaptiveApplicationControlGroupCollection class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class AdaptiveApplicationControlGroupCollection : Azure.ResourceManager.ArmCollection
    {
        private const string UnsupportedMessage = "This API is no longer supported by the service. No direct replacement is available.";

        /// <summary>
        /// Initializes a new instance of the <see cref="AdaptiveApplicationControlGroupCollection"/> type for compatibility with the previous public API surface.
        /// </summary>
        protected AdaptiveApplicationControlGroupCollection() { }
        /// <summary>
        /// Provides a compatibility shim for the CreateOrUpdate operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="groupName">The value preserved for API compatibility.</param>
        /// <param name="data">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string groupName, Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use SubscriptionResource.GetAdaptiveApplicationControlGroups() instead."); }
        /// <summary>
        /// Provides a compatibility shim for the CreateOrUpdateAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="groupName">The value preserved for API compatibility.</param>
        /// <param name="data">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string groupName, Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use SubscriptionResource.GetAdaptiveApplicationControlGroups() instead."); }
        /// <summary>
        /// Provides a compatibility shim for the Exists operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="groupName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use SubscriptionResource.GetAdaptiveApplicationControlGroups() instead."); }
        /// <summary>
        /// Provides a compatibility shim for the ExistsAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="groupName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use SubscriptionResource.GetAdaptiveApplicationControlGroups() instead."); }
        /// <summary>
        /// Provides a compatibility shim for the Get operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="groupName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use SubscriptionResource.GetAdaptiveApplicationControlGroups() instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="groupName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use SubscriptionResource.GetAdaptiveApplicationControlGroups() instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetIfExists operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="groupName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource> GetIfExists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use SubscriptionResource.GetAdaptiveApplicationControlGroups() instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetIfExistsAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="groupName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource>> GetIfExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use SubscriptionResource.GetAdaptiveApplicationControlGroups() instead."); }
    }
}
