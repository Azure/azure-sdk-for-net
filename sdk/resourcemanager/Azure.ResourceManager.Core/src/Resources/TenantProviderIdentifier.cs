// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// The identifier of a Provider from Tenant
    /// </summary>
    public class TenantProviderIdentifier : TenantResourceIdentifier
    {
        internal TenantProviderIdentifier()
        {
        }

        /// <summary>
        /// Convert a string resource identifier into a TenantResourceIdentifier.
        /// </summary>
        /// <param name="other"> The string representation of a subscription resource identifier. </param>
        public static implicit operator TenantProviderIdentifier(string other)
        {
            if (other is null)
                return null;
            TenantProviderIdentifier id = CreateTenantProviderIdentifier(other) as TenantProviderIdentifier;
            if (id is null)
                throw new ArgumentException("Not a valid tenant level resource", nameof(other));
            return id;
        }

        private static TenantProviderIdentifier CreateTenantProviderIdentifier(string other)
        {
            if (resourceId is null)
                throw new ArgumentNullException(nameof(resourceId));
            if (!resourceId.StartsWith("/", StringComparison.InvariantCultureIgnoreCase))
                throw new ArgumentOutOfRangeException(nameof(resourceId), "Invalid resource id.");
            var parts = resourceId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (parts.Count < 2)
                throw new ArgumentOutOfRangeException(nameof(resourceId), "Invalid resource id.");
            switch (parts[0].ToLowerInvariant())
            {
                case SubscriptionsKey:
                    {
                        ResourceIdentifier id = CreateBaseSubscriptionIdentifier(parts[1], parts.Trim(2));
                        id.StringValue = resourceId;
                        return id;
                    }
                case ProvidersKey:
                    {
                        if (parts.Count > 3)
                        {
                            ResourceIdentifier id = CreateTenantIdentifier(new TenantResourceIdentifier(new ResourceType(parts[1], parts[2]), parts[3]), parts.Trim(4));
                            id.StringValue = resourceId;
                            return id;
                        }
                        throw new ArgumentOutOfRangeException(nameof(resourceId), "Invalid resource id.");
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(resourceId), "Invalid resource id.");
            }
        }
    }
}
