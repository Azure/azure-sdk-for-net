// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System.Linq;
    using System.Net.Http;

    /// <summary>
    /// Defines an extension method for obtaining a pre-configured SearchIndexClient from the Indexes property
    /// of a SearchServiceClient.
    /// </summary>
    public static class IndexesGetClientExtensions
    {
        /// <summary>
        /// Creates a new index client for querying and managing documents in a given index.
        /// </summary>
        /// <param name="operations">The operation group for indexes of the Search service.</param>
        /// <param name="indexName">The name of the index.</param>
        /// <returns>A new <see cref="Microsoft.Azure.Search.SearchIndexClient" /> instance.</returns>
        /// <remarks>
        /// The new client is configured with full read-write access to the index. If you are only planning to use the
        /// client for query operations, we recommend directly creating a 
        /// <see cref="Microsoft.Azure.Search.SearchIndexClient" /> instance instead.
        /// </remarks>
        public static ISearchIndexClient GetClient(this IIndexesOperations operations, string indexName)
        {
            // Argument checking is done by the SearchIndexClient constructor. Note that HttpClient can't be shared in
            // case it has already been used (SearchIndexClient will attempt to set the Timeout property on it).
            SearchServiceClient serviceClient = operations.Client;
            var rootHandler = serviceClient.HttpMessageHandlers.OfType<HttpClientHandler>().SingleOrDefault();
            var indexClient =
                new SearchIndexClient(serviceClient.SearchServiceName, indexName, serviceClient.SearchCredentials, rootHandler)
                {
                    SearchDnsSuffix = serviceClient.SearchDnsSuffix
                };

            indexClient.HttpClient.Timeout = serviceClient.HttpClient.Timeout;
            return indexClient;
        }
    }
}
