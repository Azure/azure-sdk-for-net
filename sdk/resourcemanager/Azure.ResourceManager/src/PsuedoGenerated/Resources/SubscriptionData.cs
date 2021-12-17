// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// A class representing the subscription data model.
    /// </summary>
    public partial class SubscriptionData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionData"/> class.
        /// </summary>
        /// <param name="id"> The subscription id. </param>
        /// <param name="subscriptionId"> The subscription ID. </param>
        /// <param name="displayName"> The subscription name. </param>
        /// <param name="tenantId"> The subscription tenant ID. </param>
        /// <param name="state"> The subscription state. Possible values are Enabled, Warned, PastDue, Disabled, and Deleted. </param>
        /// <param name="subscriptionPolicies"> The subscription policies. </param>
        /// <param name="authorizationSource"> The authorization source of the request. Valid values are one or more combinations of Legacy, RoleBased, Bypassed, Direct and Management. For example, &apos;Legacy, RoleBased&apos;. </param>
        /// <param name="managedByTenants"> An array containing the tenants managing the subscription. </param>
        /// <param name="tags"> The tags attached to the subscription. </param>
        internal SubscriptionData(ResourceIdentifier id,
            string displayName,
            string subscriptionId,
            string tenantId,
            SubscriptionState? state,
            SubscriptionPolicies subscriptionPolicies,
            string authorizationSource,
            IReadOnlyList<ManagedByTenant> managedByTenants,
            IDictionary<string, string> tags)
        {
            SubscriptionGuid = subscriptionId;
            DisplayName = displayName;
            State = state;
            TenantId = tenantId;
            SubscriptionPolicies = subscriptionPolicies;
            AuthorizationSource = authorizationSource;
            ManagedByTenants = managedByTenants;
            Tags = tags;
            Id = id;
        }

        /// <summary>
        /// Gets the Id of the Subscription.
        /// </summary>
        public string SubscriptionGuid { get; }

        /// <summary>
        /// Gets the display name of the subscription.
        /// </summary>
        public string DisplayName { get; }

        /// <summary>
        /// The subscription tenant ID.
        /// </summary>
        public string TenantId { get; }

        /// <summary>
        /// Gets the state of the subscription.
        /// </summary>
        public SubscriptionState? State { get; }

        /// <summary>
        /// Gets the policies of the subscription.
        /// </summary>
        public SubscriptionPolicies SubscriptionPolicies { get; }

        /// <summary>
        /// Gets the authorization source of the subscription.
        /// </summary>
        public string AuthorizationSource { get; }

        /// <summary>
        /// Gets an array containing the tenants managing the subscription.
        /// </summary>
        public IReadOnlyList<ManagedByTenant> ManagedByTenants { get; }

        /// <summary> Resource tags. </summary>
        public IDictionary<string, string> Tags { get; }

        /// <summary>
        /// Gets the ARM resource identifier.
        /// </summary>
        public virtual ResourceIdentifier Id { get; }
    }
}
