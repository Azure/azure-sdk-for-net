// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Azure.AI.Personalizer
{
    /// <summary> The Decision Context Document. </summary>
    public class DecisionContextDocument
    {
        /// <summary> Initializes a new instance of DecisionContextDocument. </summary>
        /// <param name="id"> Id of the decision context document </param>
        /// <param name="Json"> The json features </param>
        public DecisionContextDocument(string id, List<string> Json)
        {
            ID = id;
            JSON = Json;
        }
            /// <summary>
            /// Supply _tag for online evaluation
            /// </summary>
            [JsonPropertyName("_tag")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ID
        {
            get;
            set;
        }

        /// <summary>
        /// Provide source set feature.
        /// </summary>
        [JsonPropertyName("s")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DecisionContextDocumentSource Source { get; set; }

        /// <summary>
        /// Generic json features.
        /// </summary>
        [JsonPropertyName("j")]
        [JsonConverter(typeof(JsonRawStringListConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string> JSON { get; }

        /// <summary>
        /// Keep as float[] arrays to improve marshalling speed.
        /// </summary>
        [JsonPropertyName("f")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dictionary<string, float[]> FloatFeatures { get; }

        /// <summary>
        /// Slot ID.
        /// </summary>
        [JsonPropertyName("_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string SlotId { get; set; }

        /// <summary>
        /// Generic slot json features.
        /// </summary>
        [JsonPropertyName("sj")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonConverter(typeof(JsonRawStringListConverter))]
        public List<string> SlotJson { get; }
    }
}
