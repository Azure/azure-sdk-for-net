// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// The identifier of a Provider from Subscription.
    /// </summary>
    public class SubscriptionProviderIdentifier : TenantProviderIdentifier
    {
        internal SubscriptionProviderIdentifier(string subscriptionId) : base(subscriptionId)
        {
            SubscriptionId = subscriptionId;
        }

        internal SubscriptionProviderIdentifier(SubscriptionProviderIdentifier parent, string providerNamespace, ResourceType resourceType, string resourceName)
            : base(parent, providerNamespace, resourceType, resourceName)
        {
            Parent = parent;
            IsChild = true;
        }

        /// <summary>
        /// The subscription id (Guid) for this resource.
        /// </summary>
        public string SubscriptionId { get; internal set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionProviderIdentifier"/> class 
        /// for resources in the sanem namespace as their parent resource.
        /// </summary>
        /// <param name="parent"> The resource id of the parent resource. </param>
        /// <param name="childResourceType"> The simple type of this resource, for example 'subnets'. </param>
        /// <param name="childResourceName"> The name of this resource. </param>
        /// <returns> The resource identifier for the given child resource. </returns>
        internal SubscriptionProviderIdentifier(SubscriptionProviderIdentifier parent, string childResourceType, string childResourceName)
            : base(parent, childResourceType, childResourceName)
        {
            Parent = parent;
            IsChild = true;
        }

        /// <summary>
        /// Convert a string resource identifier into a TenantResourceIdentifier.
        /// </summary>
        /// <param name="other"> The string representation of a subscription resource identifier. </param>
        public static implicit operator SubscriptionProviderIdentifier(string other)
        {
            if (other is null)
                return null;
            SubscriptionProviderIdentifier id = ResourceIdentifier.Create(other) as SubscriptionProviderIdentifier;
            if (other is null)
                throw new ArgumentException("Not a valid tenant provider resource", nameof(other));
            return id;
        }
    }
}
