// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// The identifier of a Provider from Tenant.
    /// </summary>
    public class TenantProviderIdentifier : TenantResourceIdentifier
    {
        internal TenantProviderIdentifier(TenantResourceIdentifier parent, string providerNamespace)
        {
            Parent = parent;
            Provider = providerNamespace;
            IsChild = true;
            ResourceType = ProviderOperations.ResourceType;
        }

        internal TenantProviderIdentifier(TenantProviderIdentifier parent, string providerNamespace, string typeName, string resourceName)
            : base(new ResourceType(providerNamespace, typeName), resourceName)
        {
            Parent = parent;
            Provider = parent.Provider;
            IsChild = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TenantProviderIdentifier"/> class
        /// for resources in the sanem namespace as their parent resource.
        /// </summary>
        /// <param name="parent"> The resource id of the parent resource. </param>
        /// <param name="typeName"> The simple type of this resource, for example 'subnets'. </param>
        /// <param name="resourceName"> The name of this resource. </param>
        /// <returns> The resource identifier for the given child resource. </returns>
        internal TenantProviderIdentifier(TenantProviderIdentifier parent, string typeName, string resourceName)
            : base(new ResourceType(parent.ResourceType, typeName), resourceName)
        {
            Parent = parent;
            Provider = parent.Provider;
            IsChild = true;
        }

        /// <summary>
        /// Gets the Provider for the current ProviderIdentifier.
        /// </summary>
        public string Provider { get; }

        /// <summary>
        /// Convert a string resource identifier into a TenantResourceIdentifier.
        /// </summary>
        /// <param name="other"> The string representation of a subscription resource identifier. </param>
        public static implicit operator TenantProviderIdentifier(string other)
        {
            if (other is null)
                return null;

            return ResourceIdentifier.Create(other) as TenantProviderIdentifier;
        }

        /// <inheritdoc/>
        public override bool TryGetProvider(out string providerId)
        {
            providerId = Provider;
            return true;
        }
    }
}
