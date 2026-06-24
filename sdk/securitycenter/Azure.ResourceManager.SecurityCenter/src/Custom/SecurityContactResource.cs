// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter
{
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
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string securityContactName)
            => CreateResourceIdentifier(subscriptionId, new Azure.ResourceManager.SecurityCenter.Models.SecurityContactName(securityContactName));
    }
}
