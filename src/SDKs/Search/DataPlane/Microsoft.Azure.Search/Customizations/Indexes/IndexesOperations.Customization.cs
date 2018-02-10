// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Rest.Azure;

    internal partial class IndexesOperations
    {
        /// <inheritdoc />
        public Task<AzureOperationResponse<Index>> CreateOrUpdateWithHttpMessagesAsync(Index index, bool? allowIndexDowntime = default(bool?), SearchRequestOptions searchRequestOptions = default(SearchRequestOptions), AccessCondition accessCondition = default(AccessCondition), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return CreateOrUpdateWithHttpMessagesAsync(index != null ? index.Name : null, index, allowIndexDowntime, searchRequestOptions, accessCondition, customHeaders, cancellationToken);
        }
        
        /// <inheritdoc />
        public Task<AzureOperationResponse<bool>> ExistsWithHttpMessagesAsync(
            string indexName,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return ExistsHelper.ExistsFromGetResponse(() =>
                this.GetWithHttpMessagesAsync(indexName, searchRequestOptions, customHeaders, cancellationToken));
        }

        /// <inheritdoc />
        public ISearchIndexClient GetClient(string indexName)
        {
            // Argument checking is done by the SearchIndexClient constructor. Note that HttpClient can't be shared in
            // case it has already been used (SearchIndexClient will attempt to set the Timeout property on it).
            var rootHandler = Client.HttpMessageHandlers.OfType<HttpClientHandler>().SingleOrDefault();
            var indexClient =
                new SearchIndexClient(Client.SearchServiceName, indexName, Client.SearchCredentials, rootHandler)
                {
                    SearchDnsSuffix = Client.SearchDnsSuffix
                };

            indexClient.HttpClient.Timeout = Client.HttpClient.Timeout;
            return indexClient;
        }
    }
}
