// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.AI.Personalizer
{
    /// <summary> The Decision Context Document. </summary>
    public class DecisionContextDocumentId
    {
        /// <summary>
        /// Required for --marginal
        /// </summary>
        [JsonPropertyName("constant")]
        public int Constant { get; set; } = 1;

        /// <summary>
        /// Included for offline analysis.
        /// </summary>
        [JsonPropertyName("id")]
        public string ID { get; set; }
    }
}
