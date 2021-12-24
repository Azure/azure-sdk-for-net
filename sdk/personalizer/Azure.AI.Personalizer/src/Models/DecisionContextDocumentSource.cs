// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace Azure.AI.Personalizer
{
    /// <summary> The Decision Context Document Source. </summary>
    public class DecisionContextDocumentSource
    {
        /// <summary> The set. </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Set { get; set; }

        /// <summary> The parameter. </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Parameter { get; set; }
    }
}
