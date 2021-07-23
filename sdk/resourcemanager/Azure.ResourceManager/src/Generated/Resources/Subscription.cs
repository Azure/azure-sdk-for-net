// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing a Subscription along with the instance operations that can be performed on it.
    /// </summary>
    public class Subscription : SubscriptionOperations
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Subscription"/> class for mocking.
        /// </summary>
        protected Subscription()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Subscription"/> class.
        /// </summary>
        /// <param name="operations"> The operations object to copy the client parameters from. </param>
        /// <param name="subscriptionData"> The data model representing the generic azure resource. </param>
        internal Subscription(OperationsBase operations, SubscriptionData subscriptionData)
            : base(operations, subscriptionData.Id)
        {
            Data = subscriptionData;
        }

        /// <summary>
        /// Gets the subscription data model.
        /// </summary>
        public virtual SubscriptionData Data { get; }
    }
}
