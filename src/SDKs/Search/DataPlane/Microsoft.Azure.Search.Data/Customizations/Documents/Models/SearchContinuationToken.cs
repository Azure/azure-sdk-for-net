// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using Common;
    using Newtonsoft.Json;
    using Serialization;

    /// <summary>
    /// Encapsulates state required to continue fetching search results. This is necessary when Azure Search cannot
    /// fulfill a search request with a single response.
    /// </summary>
    /// <remarks>
    /// This class supports using <c cref="JsonConvert">JsonConvert</c> to convert to and from a JSON payload. This can be useful if you
    /// call Azure Search from a web application and you need to exchange continuation tokens with a browser or mobile client while paging
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
    }
}
