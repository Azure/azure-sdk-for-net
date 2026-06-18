// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.SecurityCenter
{
    // Compatibility customization: preserves Azure.ResourceManager.SecurityCenter 1.1.0 public API shape during the MPG migration.
    /// <summary>
    /// Provides a compatibility shim for the SubscriptionSecurityApplicationResource class.
    /// </summary>
    public partial class SubscriptionSecurityApplicationResource
    {
        /// <summary>
        /// Gets the Data value preserved from the previous public API surface.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual SecurityApplicationData Data => throw new System.NotSupportedException("This API is no longer supported by the service.");
        /// <summary>
        /// Provides a compatibility shim for the Update operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="data">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<SubscriptionSecurityApplicationResource> Update(WaitUntil waitUntil, SecurityApplicationData data, CancellationToken cancellationToken = default)
            => throw new System.NotSupportedException("This API is no longer supported by the service.");
        /// <summary>
        /// Provides a compatibility shim for the UpdateAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="data">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<SubscriptionSecurityApplicationResource>> UpdateAsync(WaitUntil waitUntil, SecurityApplicationData data, CancellationToken cancellationToken = default)
            => throw new System.NotSupportedException("This API is no longer supported by the service.");
    }
}
