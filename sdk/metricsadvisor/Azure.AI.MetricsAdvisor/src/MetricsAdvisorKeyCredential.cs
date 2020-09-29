// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor
{
    /// <summary>
    /// </summary>
    public class MetricsAdvisorKeyCredential
    {
        private string _subscriptionKey;

        private string _apiKey;

        /// <summary>
        /// </summary>
        public MetricsAdvisorKeyCredential(string subscriptionKey, string apiKey)
        {
            UpdateSubscriptionKey(subscriptionKey);
            UpdateApiKey(apiKey);
        }

        /// <summary>
        /// </summary>
        internal string SubscriptionKey
        {
            get => Volatile.Read(ref _subscriptionKey);
            private set => Volatile.Write(ref _subscriptionKey, value);
        }

        /// <summary>
        /// </summary>
        internal string ApiKey
        {
            get => Volatile.Read(ref _apiKey);
            private set => Volatile.Write(ref _apiKey, value);
        }

        /// <summary>
        /// </summary>
        public void UpdateSubscriptionKey(string key)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            SubscriptionKey = key;
        }

        /// <summary>
        /// </summary>
        public void UpdateApiKey(string key)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            ApiKey = key;
        }
    }
}
