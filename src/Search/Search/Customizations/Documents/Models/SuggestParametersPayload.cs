// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using Newtonsoft.Json;

    internal class SuggestParametersPayload
    {
        [JsonProperty("filter")]
        public string Filter { get; set; }

        [JsonProperty("fuzzy")]
        public bool? Fuzzy { get; set; }

        [JsonProperty("highlightPostTag")]
        public string HighlightPostTag { get; set; }

        [JsonProperty("highlightPreTag")]
        public string HighlightPreTag { get; set; }

        [JsonProperty("minimumCoverage")]
        public double? MinimumCoverage { get; set; }

        [JsonProperty("orderby")]
        public string OrderBy { get; set; }

        [JsonProperty("search")]
        public string Search { get; set; }

        [JsonProperty("searchFields")]
        public string SearchFields { get; set; }

        [JsonProperty("select")]
        public string Select { get; set; }

        [JsonProperty("suggesterName")]
        public string SuggesterName { get; set; }

        [JsonProperty("top")]
        public int? Top { get; set; }
    }
}
