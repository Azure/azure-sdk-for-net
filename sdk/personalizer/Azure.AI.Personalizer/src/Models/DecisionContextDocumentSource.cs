// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.AI.Personalizer
{
    /// <summary> The Decision Context Document Source. </summary>
    public class DecisionContextDocumentSource
    {
        /// <summary> The set. </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Set { get; set; }

        /// <summary> The parameter. </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Parameter { get; set; }
    }
}
