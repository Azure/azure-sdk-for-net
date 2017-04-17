// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using Newtonsoft.Json;
    using Serialization;

    /// <summary>
    /// Encapsulates state required to continue fetching search results. This is necessary when Azure Search cannot
    /// fulfill a search request with a single response.
    /// </summary>
    [JsonConverter(typeof(SearchContinuationTokenConverter))]
    public class SearchContinuationToken
    {
        internal SearchContinuationToken(string nextLink, SearchParametersPayload nextPageParameters)
        {
            Throw.IfArgumentNullOrEmpty(nextLink, "nextLink");

            this.NextLink = nextLink;
            this.NextPageParameters = nextPageParameters;    // Will be null for GET responses.
        }

        internal string NextLink { get; private set; }

        internal SearchParametersPayload NextPageParameters { get; private set; }
    }
}
