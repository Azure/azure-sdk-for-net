// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing the subscription data model.
    /// </summary>
    public partial class FeatureResultData : TrackedResource<SubscriptionResourceIdentifier>
    {
        /// <summary> Initializes a new instance of <see cref="FeatureResultData"/> class. </summary>
        /// <param name="id"> The subscription id. </param>
        /// <param name="displayName"> The subscription name. </param>
        /// <param name="tags"> The tags attached to the subscription. </param>
        /// <param name="resourceType"> The subscription resource type. </param>
        internal FeatureResultData(string name, FeatureProperties properties, string id, string type = "Microsoft.Resources/subscriptions") : base(id, name, type, null, tags)
        {
            Properties = properties;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionData"/> class.
        /// </summary>
        /// <param name="id"> The subscription id. </param>
        /// <param name="subscriptionId"> The subscription ID. </param>
        /// <param name="displayName"> The subscription name. </param>
        /// <param name="resourceType"> The subscription resource type. </param>
        /// <param name="tenantId"> The subscription tenant ID. </param>
        /// <param name="state"> The subscription state. Possible values are Enabled, Warned, PastDue, Disabled, and Deleted. </param>
        /// <param name="subscriptionPolicies"> The subscription policies. </param>
        /// <param name="authorizationSource"> The authorization source of the request. Valid values are one or more combinations of Legacy, RoleBased, Bypassed, Direct and Management. For example, &apos;Legacy, RoleBased&apos;. </param>
        /// <param name="managedByTenants"> An array containing the tenants managing the subscription. </param>
        /// <param name="tags"> The tags attached to the subscription. </param>
        internal FeatureResultData(string id,
            string displayName,
            string subscriptionId,
            string tenantId,
            SubscriptionState? state,
            SubscriptionPolicies subscriptionPolicies,
            string authorizationSource,
            IReadOnlyList<ManagedByTenant> managedByTenants,
            IDictionary<string, string> tags,
            string resourceType = "Microsoft.Resources/subscriptions")
            : base(id, displayName, resourceType, null, tags)
        {
            Name = displayName;
            SubscriptionGuid = subscriptionId;
            DisplayName = displayName;
            State = state;
            TenantId = tenantId;
            SubscriptionPolicies = subscriptionPolicies;
            AuthorizationSource = authorizationSource;
            ManagedByTenants = managedByTenants;
        }

        /// <summary>
        /// Gets the subscription id.
        /// </summary>
        public override string Name { get; }

        /// <summary>
        /// Gets the Id of the Subscription.
        /// </summary>
        public FeatureProperties Properties { get; }

        /// <summary>
        /// Gets the display name of the subscription.
        /// </summary>
        public string Type { get; }
    }
}
