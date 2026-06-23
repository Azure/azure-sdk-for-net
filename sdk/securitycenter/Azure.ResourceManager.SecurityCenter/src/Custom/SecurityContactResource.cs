// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter
{
    // Generated code only emits operations whose resource scope and request path still exist in TypeSpec; this previous GA method used an old operation path, scope, or overload that no longer maps to a generated request. Keep a hidden ApiCompat shim and fail the unsupported operation explicitly.
    /// <summary>
    /// Provides a compatibility shim for the SecurityContactResource class.
    /// </summary>
    public partial class SecurityContactResource
    {
        /// <summary>
        /// Provides a compatibility shim for the CreateResourceIdentifier operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionId">The value preserved for API compatibility.</param>
        /// <param name="securityContactName">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use SecurityContactResource.CreateResourceIdentifier(ResourceIdentifier scope, SecurityContactName securityContactName) instead.")]
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string securityContactName) { throw new System.NotSupportedException("This API is no longer supported by the service. Use SecurityContactResource.CreateResourceIdentifier(ResourceIdentifier scope, SecurityContactName securityContactName) instead."); }
    }
}
