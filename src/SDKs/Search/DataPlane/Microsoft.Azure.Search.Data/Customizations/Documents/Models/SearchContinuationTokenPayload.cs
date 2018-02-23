// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using Newtonsoft.Json;

    internal class SearchContinuationTokenPayload
    {
        [JsonProperty("@odata.nextLink")]
        public string NextLink { get; set; }

        [JsonProperty("@search.nextPageParameters")]
        public SearchParametersPayload NextPageParameters { get; set; }
    }
}
