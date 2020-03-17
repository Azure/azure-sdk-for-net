// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;

namespace Azure.Core
{
    /// <summary>
    /// API key credential used to authenticate to an Azure Service.
    /// It provides the ability to update the API key without creating a new client.
    /// </summary>
    public class AzureKeyCredential
    {
        private string _apiKey;

        /// <summary>
        /// API key used to authenticate to an Azure service.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ApiKey
        {
            get => Volatile.Read(ref _apiKey);
            private set => Volatile.Write(ref _apiKey, value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureKeyCredential"/> class.
        /// </summary>
        /// <param name="apiKey">API key to use to authenticate with the Azure service.</param>
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
        public AzureKeyCredential(string apiKey) => SetApiKey(apiKey);
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

        /// <summary>
        /// Updates the service API key.
        /// This is intended to be used when you've regenerated your service API key
        /// and want to update long lived clients.
        /// </summary>
        /// <param name="apiKey">API key to authenticate the service against.</param>
        public void UpdateCredential(string apiKey) => SetApiKey(apiKey);

        private void SetApiKey(string apiKey)
        {
            Argument.AssertNotNullOrEmpty(apiKey, nameof(apiKey));
            ApiKey = apiKey;
        }
    }
}
