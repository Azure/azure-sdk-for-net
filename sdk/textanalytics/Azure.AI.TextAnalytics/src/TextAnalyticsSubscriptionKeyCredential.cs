// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A <see cref="TextAnalyticsSubscriptionKeyCredential"/> is a subscription key use to authenticate
    /// against a Cognitive Service.
    /// </summary>
    public class TextAnalyticsSubscriptionKeyCredential
    {
        private string _subscriptionKey;

        /// <summary>
        /// Service subscription key.
        /// </summary>
        internal string SubscriptionKey
        {
            get => Volatile.Read(ref _subscriptionKey);
            private set => Volatile.Write(ref _subscriptionKey, value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextAnalyticsSubscriptionKeyCredential"/> class.
        /// </summary>
        /// <param name="subscriptionKey">Subscription key to athenticate the service against.</param>
        public TextAnalyticsSubscriptionKeyCredential(string subscriptionKey)
        {
            UpdateCredential(subscriptionKey);
        }

        /// <summary>
        /// Updates the Cognitive Service subscription key.
        /// This is intended to be used when you've regenerated your service subscription key
        /// and want to update long lived clients.
        /// </summary>
        /// <param name="subscriptionKey">Subscription key to athenticate the service against.</param>
        public void UpdateCredential(string subscriptionKey) =>
            SubscriptionKey = subscriptionKey;
    }
}
