// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using Newtonsoft.Json;

namespace Microsoft.Azure.Search.Models
{
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
