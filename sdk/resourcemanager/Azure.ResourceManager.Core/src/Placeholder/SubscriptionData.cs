// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Resources.Models;
using System.Collections.Generic;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing the subscription data model.
    /// </summary>
    public class SubscriptionData : Resource<SubscriptionResourceIdentifier>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionData"/> class.
        /// </summary>
        /// <param name="subscription"> The subscription model. </param>
        public SubscriptionData(ResourceManager.Resources.Models.Subscription subscription)
        {
            Name = subscription.DisplayName;
            SubscriptionGuid = subscription.SubscriptionId;
            DisplayName = subscription.DisplayName;
            State = subscription.State;
            SubscriptionPolicies = subscription.SubscriptionPolicies;
            AuthorizationSource = subscription.AuthorizationSource;
            Id = new SubscriptionResourceIdentifier(subscription.Id);
            ManagedByTenants = subscription.ManagedByTenants;
            Tags = subscription.Tags;
        }

        /// <summary>
        /// Gets the subscription id.
        /// </summary>
        public override string Name { get; }

        /// <summary>
        /// Gets the Id of the Subscription.
        /// </summary>
        public string SubscriptionGuid { get; }

        /// <summary>
        /// Gets the display name of the subscription.
        /// </summary>
        public string DisplayName { get; }

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

        /// <inheritdoc/>
        public override SubscriptionResourceIdentifier Id { get; protected set; }

        /// <summary>
        /// Gets an array containing the tenants managing the subscription.
        /// </summary>
        public IReadOnlyList<ManagedByTenant> ManagedByTenants { get; }

        /// <summary>
        /// Gets the tags attached to the subscription.
        /// </summary>
        public IReadOnlyDictionary<string, string> Tags { get; }
    }
}
