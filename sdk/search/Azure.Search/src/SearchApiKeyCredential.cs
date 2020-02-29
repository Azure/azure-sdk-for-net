// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core;

namespace Azure.Search
{
    /// <summary>
    /// API key credential used to authenticate to the Search Service.  It can
    /// be used with either a query key or admin key.
    /// </summary>
    /// <remarks>
    /// See <see href="https://docs.microsoft.com/azure/search/search-security-api-keys"/>
    /// for more information about API keys in Azure Cognitive Search.
    /// </remarks>
    public class SearchApiKeyCredential
    {
        /// <summary>
        /// API key used to authenticate to a search service.
        /// </summary>
        private string _apiKey;

        /// <summary>
        /// API key used to authenticate to a search service.
        /// </summary>
        internal string ApiKey
        {
            get => Volatile.Read(ref _apiKey);
            private set => Volatile.Write(ref _apiKey, value);
        }

        /// <summary>
        /// Initializes a new instance of the SearchApiKeyCredential class with
        /// either a query key or an admin key.  Use a query key if your
        /// application does not require write access to the Search Service or
        /// index.
        /// </summary>
        /// <param name="apiKey">
        /// API key used to authenticate to the search service.
        /// </param>
        /// <remarks>
        /// If your application performs only query operations on an index, we
        /// recommend passing a query key for the <paramref name="apiKey"/>
        /// parameter. This ensures that you have read-only access to the
        /// index, which is consistent with the principle of least privilege.
        /// </remarks>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when the <paramref name="apiKey"/> is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the <paramref name="apiKey"/> is empty.
        /// </exception>
        public SearchApiKeyCredential(string apiKey) => SetApiKey(apiKey);

        /// <summary>
        /// Refreshes the API key with a new query key or an admin key.  Use a
        /// query key if your application does not require write access to the
        /// Search Service or index.  This method is intended to be used when
        /// you've regenerated your Search Service's API keys and want to
        /// update long lived clients.
        /// </summary>
        /// <param name="apiKey">
        /// API key used to authenticate to the search service.
        /// </param>
        /// <remarks>
        /// If your application performs only query operations on an index, we
        /// recommend passing a query key for the <paramref name="apiKey"/>
        /// parameter. This ensures that you have read-only access to the
        /// index, which is consistent with the principle of least privilege.
        /// </remarks>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when the <paramref name="apiKey"/> is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the <paramref name="apiKey"/> is empty.
        /// </exception>
        public void Refresh(string apiKey) => SetApiKey(apiKey);

        /// <summary>
        /// Validate and set the API key.
        /// </summary>
        /// <param name="apiKey">
        /// API key used to authenticate to the search service.
        /// </param>
        private void SetApiKey(string apiKey)
        {
            Argument.AssertNotNullOrEmpty(apiKey, nameof(apiKey));
            ApiKey = apiKey;
        }
    }
}
