// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// The identifier of a Provider from Tenant.
    /// </summary>
    public class TenantProviderIdentifier : ResourceIdentifier
    {
        internal TenantProviderIdentifier(string nameSpace)
        {
            NameSpace = nameSpace;
        }

        internal TenantProviderIdentifier(TenantProviderIdentifier parent, string providerNamespace, ResourceType resourceType, string resourceName)
            : base(new ResourceType(providerNamespace, resourceType), resourceName)
        {
            Parent = parent;
            IsChild = true;
        }

        /// <summary>
        /// Gets the NameSpace for the current ProviderIdentifier.
        /// </summary>
        public string NameSpace { get; } // rename to Provider

        /// <summary>
        /// Convert a string resource identifier into a TenantResourceIdentifier.
        /// </summary>
        /// <param name="other"> The string representation of a subscription resource identifier. </param>
        public static implicit operator TenantProviderIdentifier(string other)
        {
            if (other is null)
                return null;
            TenantProviderIdentifier id = ResourceIdentifier.Create(other) as TenantProviderIdentifier;
            if (other is null)
                throw new ArgumentException("Not a valid tenant provider resource", nameof(other));
            return id;
        }
    }
}
