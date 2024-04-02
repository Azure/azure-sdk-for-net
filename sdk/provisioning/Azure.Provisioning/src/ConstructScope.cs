// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning
{
    /// <summary>
    /// The resource scope of a construct.
    /// </summary>
    public enum ConstructScope
    {
        /// <summary>
        /// <see cref="ResourceManager.ResourceGroup"/> scope.
        /// </summary>
        ResourceGroup,
        /// <summary>
        /// <see cref="ResourceManager.Subscription"/> scope.
        /// </summary>
        Subscription,
        /// <summary>
        /// ManagementGroup scope.
        /// </summary>
        ManagementGroup,
        /// <summary>
        /// <see cref="ResourceManager.Tenant"/> scope.
        /// </summary>
        Tenant
    }
}
