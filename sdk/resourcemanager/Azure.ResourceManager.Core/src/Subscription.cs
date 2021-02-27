// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing a Subscription along with the instance operations that can be performed on it.
    /// </summary>
    public class Subscription : SubscriptionOperations
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Subscription"/> class.
        /// </summary>
        /// <param name="subscription"> The subscription operations to copy the client options from. </param>
        /// <param name="subscriptionData"> The resource data model. </param>
        internal Subscription(SubscriptionOperations subscription, SubscriptionData subscriptionData)
            : base(subscription, subscriptionData.Id)
        {
            Data = subscriptionData;
        }

        /// <summary>
        /// Gets the subscription data model.
        /// </summary>
        public SubscriptionData Data { get; }

        /// <inheritdoc />
        protected override Subscription GetResource()
        {
            return this;
        }

        /// <inheritdoc />
        protected override Task<Subscription> GetResourceAsync()
        {
            return Task.FromResult(this);
        }
    }
}
