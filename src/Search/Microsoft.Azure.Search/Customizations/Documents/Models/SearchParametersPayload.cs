// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    internal class SearchParametersPayload
    {
        [JsonProperty("count")]
        public bool? Count { get; set; }

        [JsonProperty("facets")]
        public IList<string> Facets { get; set; }

        [JsonProperty("filter")]
        public string Filter { get; set; }

        [JsonProperty("highlight")]
        public string Highlight { get; set; }

        [JsonProperty("highlightPostTag")]
        public string HighlightPostTag { get; set; }

        [JsonProperty("highlightPreTag")]
        public string HighlightPreTag { get; set; }

        [JsonProperty("minimumCoverage")]
        public double? MinimumCoverage { get; set; }

        [JsonProperty("orderby")]
        public string OrderBy { get; set; }

        [JsonProperty("scoringParameters")]
        public IList<string> ScoringParameters { get; set; }

        [JsonProperty("scoringProfile")]
        public string ScoringProfile { get; set; }

        [JsonProperty("search")]
        public string Search { get; set; }

        [JsonProperty("searchFields")]
        public string SearchFields { get; set; }

        [JsonProperty("searchMode")]
        public SearchMode? SearchMode { get; set; }

        [JsonProperty("select")]
        public string Select { get; set; }

        [JsonProperty("skip")]
        public int? Skip { get; set; }

        [JsonProperty("top")]
        public int? Top { get; set; }
    }
}
