// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Helper class with the known keys in a dictionary for easy access.
    /// </summary>
    internal static class KnownKeys
    {
        /// <summary>
        /// Gets the key for Subscription.
        /// </summary>
        public static string Subscription => "subscriptions";

        /// <summary>
        /// Gets the key for Tenant.
        /// </summary>
        public static string Tenant => "tenants";

        /// <summary>
        /// Gets the key for Resource Group.
        /// </summary>
        public static string ResourceGroup => "resourcegroups";

        /// <summary>
        /// Gets the key for Location.
        /// </summary>
        public static string Location => "locations";

        /// <summary>
        /// Gets the key for Provider Namespace.
        /// </summary>
        public static string ProviderNamespace => "providers";

        /// <summary>
        /// Gets the key for Untracked Subresource.
        /// </summary>
        public static string UntrackedSubResource => Guid.NewGuid().ToString();
    }
}
