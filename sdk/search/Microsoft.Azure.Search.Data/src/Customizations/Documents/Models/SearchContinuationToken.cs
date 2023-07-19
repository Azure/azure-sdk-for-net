// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Search.Common;
using Microsoft.Azure.Search.Serialization;
using Newtonsoft.Json;

namespace Microsoft.Azure.Search.Models
{
    /// <summary>
    /// Encapsulates state required to continue fetching search results. This is necessary when Azure Cognitive Search cannot
    /// fulfill a search request with a single response.
    /// </summary>
    /// <remarks>
    /// This class supports using <see cref="JsonConvert" /> to convert to and from a JSON payload. This can be useful if you
    /// call Azure Cognitive Search from a web application and you need to exchange continuation tokens with a browser or mobile client while paging
    /// through search results.
    /// </remarks>
    [JsonConverter(typeof(SearchContinuationTokenConverter))]
    public class SearchContinuationToken
    {
        internal SearchContinuationToken(string nextLink, SearchRequest nextPageParameters)
        {
            Throw.IfArgumentNullOrEmpty(nextLink, nameof(nextLink));

            NextLink = nextLink;
            NextPageParameters = nextPageParameters;    // Will be null for GET responses.
        }

        internal string NextLink { get; }

        internal SearchRequest NextPageParameters { get; }

        /// <summary>
        /// Creates a new <see cref="SearchContinuationToken" /> for test purposes.
        /// </summary>
        /// <param name="nextLink">The @odata.nextLink of the continuation token.</param>
        /// <returns>A new continuation token for test purposes only.</returns>
        public static SearchContinuationToken CreateTestToken(string nextLink) => CreateTestToken(nextLink, null, null);

        /// <summary>
        /// Creates a new <see cref="SearchContinuationToken" /> for test purposes.
        /// </summary>
        /// <param name="nextLink">The @odata.nextLink of the continuation token.</param>
        /// <param name="searchText">Optional; The search text of the request represented by this token.</param>
        /// <param name="searchParameters">Optional; Search parameters of the request represented by this token.</param>
        /// <returns>A new continuation token for test purposes only.</returns>
        public static SearchContinuationToken CreateTestToken(string nextLink, string searchText, SearchParameters searchParameters) =>
            new SearchContinuationToken(nextLink, searchParameters?.ToRequest(searchText));
    }
}
