// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A <see cref="TextAnalyticsApiKeyCredential"/> is an API key use to authenticate
    /// against the Text Analytics service.
    /// It provides the ability to update the API key
    /// without creating a new client.
    /// </summary>
    public class TextAnalyticsApiKeyCredential
    {
        private string _apiKey;

        /// <summary>
        /// Service API key.
        /// </summary>
        internal string ApiKey
        {
            get => Volatile.Read(ref _apiKey);
            private set => Volatile.Write(ref _apiKey, value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextAnalyticsApiKeyCredential"/> class.
        /// </summary>
        /// <param name="apiKey">API key to use to authenticate with the service.</param>
        public TextAnalyticsApiKeyCredential(string apiKey)
        {
            UpdateCredential(apiKey);
        }

        /// <summary>
        /// Updates the Cognitive Service API key.
        /// This is intended to be used when you've regenerated your service API key
        /// and want to update long lived clients.
        /// </summary>
        /// <param name="apiKey">API key to authenticate the service against.</param>
        public void UpdateCredential(string apiKey) =>
            ApiKey = apiKey;
    }
}
