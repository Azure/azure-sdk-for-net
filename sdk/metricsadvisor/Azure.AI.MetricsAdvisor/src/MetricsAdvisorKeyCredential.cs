// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor
{
    /// <summary>
    /// Key credential used to authenticate to the Metrics Advisor service. It provides the ability
    /// to update its keys without creating a new client.
    /// </summary>
    public class MetricsAdvisorKeyCredential
    {
        private string _subscriptionKey;

        private string _apiKey;

        /// <summary>
        /// Creates a new instance of the <see cref="MetricsAdvisorKeyCredential"/> class.
        /// </summary>
        /// <param name="subscriptionKey">Key to use to authenticate with the Azure service.</param>
        /// <param name="apiKey">Key to use to authenticate the user with the Metrics Advisor service. Used to identify administrators.</param>
        /// <exception cref="ArgumentNullException"><paramref name="subscriptionKey"/> or <paramref name="apiKey"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="subscriptionKey"/> or <paramref name="apiKey"/> is empty.</exception>
        public MetricsAdvisorKeyCredential(string subscriptionKey, string apiKey)
        {
            UpdateSubscriptionKey(subscriptionKey);
            UpdateApiKey(apiKey);
        }

        internal string SubscriptionKey
        {
            get => Volatile.Read(ref _subscriptionKey);
            private set => Volatile.Write(ref _subscriptionKey, value);
        }

        internal string ApiKey
        {
            get => Volatile.Read(ref _apiKey);
            private set => Volatile.Write(ref _apiKey, value);
        }

        /// <summary>
        /// Updates the service key. This is intended to be used when you've regenerated
        /// your service key and want to update long lived clients.
        /// </summary>
        /// <param name="key">Key to authenticate the service against.</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="key"/> is empty.</exception>
        public void UpdateSubscriptionKey(string key)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            SubscriptionKey = key;
        }

        /// <summary>
        /// Updates the API key. This is intended to be used when you've regenerated your
        /// API key and want to update long lived clients.
        /// </summary>
        /// <param name="key">Key to use to authenticate the user with the Metrics Advisor service. Used to identify administrators.</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="key"/> is empty.</exception>
        public void UpdateApiKey(string key)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            ApiKey = key;
        }
    }
}
