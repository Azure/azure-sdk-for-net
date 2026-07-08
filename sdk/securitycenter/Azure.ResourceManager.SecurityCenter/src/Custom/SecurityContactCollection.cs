// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter
{
    /// <summary>
    /// Provides a compatibility shim for the SecurityContactCollection class.
    /// </summary>
    public partial class SecurityContactCollection
    {
        /// <summary>
        /// Provides a compatibility shim for the CreateOrUpdate operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="securityContactName">The value preserved for API compatibility.</param>
        /// <param name="data">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityContactResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string securityContactName, Azure.ResourceManager.SecurityCenter.SecurityContactData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => CreateOrUpdate(waitUntil, new Azure.ResourceManager.SecurityCenter.Models.SecurityContactName(securityContactName), data, cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the CreateOrUpdateAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="securityContactName">The value preserved for API compatibility.</param>
        /// <param name="data">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityContactResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string securityContactName, Azure.ResourceManager.SecurityCenter.SecurityContactData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => CreateOrUpdateAsync(waitUntil, new Azure.ResourceManager.SecurityCenter.Models.SecurityContactName(securityContactName), data, cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the Exists operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="securityContactName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Response<bool> Exists(string securityContactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Exists(new Azure.ResourceManager.SecurityCenter.Models.SecurityContactName(securityContactName), cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the ExistsAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="securityContactName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string securityContactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => ExistsAsync(new Azure.ResourceManager.SecurityCenter.Models.SecurityContactName(securityContactName), cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the Get operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="securityContactName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityContactResource> Get(string securityContactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Get(new Azure.ResourceManager.SecurityCenter.Models.SecurityContactName(securityContactName), cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the GetAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="securityContactName">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityContactResource>> GetAsync(string securityContactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetAsync(new Azure.ResourceManager.SecurityCenter.Models.SecurityContactName(securityContactName), cancellationToken);
    }
}
