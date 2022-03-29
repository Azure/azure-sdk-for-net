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
        private Tuple<string, string> _keyPair;

        /// <summary>
        /// Initializes a new instance of the <see cref="MetricsAdvisorKeyCredential"/> class.
        /// </summary>
        /// <param name="subscriptionKey">The subscription key to use to authenticate with the Azure service.</param>
        /// <param name="apiKey">The API key to use to authenticate the user with the Metrics Advisor service. Used to differentiate administrators and viewers.</param>
        /// <exception cref="ArgumentNullException"><paramref name="subscriptionKey"/> or <paramref name="apiKey"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="subscriptionKey"/> or <paramref name="apiKey"/> is empty.</exception>
        public MetricsAdvisorKeyCredential(string subscriptionKey, string apiKey)
        {
            Update(subscriptionKey, apiKey);
        }

        internal Tuple<string, string> KeyPair
        {
            get => Volatile.Read(ref _keyPair);
            private set => Volatile.Write(ref _keyPair, value);
        }

        /// <summary>
        /// Updates the subscription and API keys. This is intended to be used when you've regenerated
        /// your keys and want to update long lived clients.
        /// </summary>
        /// <param name="subscriptionKey">The subscription key to authenticate the service against.</param>
        /// <param name="apiKey">The API key to use to authenticate the user with the Metrics Advisor service. Used to differentiate administrators and viewers.</param>
        /// <exception cref="ArgumentNullException"><paramref name="subscriptionKey"/> or <paramref name="apiKey"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="subscriptionKey"/> or <paramref name="apiKey"/> is empty.</exception>
        public void Update(string subscriptionKey, string apiKey)
        {
            Argument.AssertNotNullOrEmpty(subscriptionKey, nameof(subscriptionKey));
            Argument.AssertNotNullOrEmpty(apiKey, nameof(apiKey));

            KeyPair = Tuple.Create(subscriptionKey, apiKey);
        }
    }
}
