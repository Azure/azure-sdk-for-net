// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System;

    public partial interface ISearchIndexClient
    {
        /// <summary>
        /// Gets the credentials used to authenticate to an Azure Cognitive Search service. This can be either a query API key or an admin API key.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.microsoft.com/azure/search/search-security-api-keys">Create and manage api-keys for an Azure Cognitive Search service</see> for more information about API keys in Azure Cognitive Search.
        /// </remarks>
        SearchCredentials SearchCredentials { get; }

        /// <summary>
        /// Indicates whether the index client should use HTTP GET for making Search, Suggest, and Autocomplete requests to the
        /// Azure Cognitive Search REST API. The default is <c>false</c>, which indicates that HTTP POST will be used.
        /// </summary>
        bool UseHttpGetForQueries { get; set; }

        /// <summary>
        /// Changes the BaseUri of this client to target a different index in the same Azure Cognitive Search service. This method is NOT thread-safe; You
        /// must guarantee that no other threads are using the client before calling it.
        /// </summary>
        /// <param name="newIndexName">The name of the index to which all subsequent requests should be sent.</param>
        [Obsolete("This method is deprecated. Please set the IndexName property instead.")]
        void TargetDifferentIndex(string newIndexName);
    }
}
