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
        /// <param name="json"> The json features </param>
        /// <param name="slotId"> The slot Id </param>
        /// <param name="slotJson"> The slot json features </param>
        public DecisionContextDocument(string id, List<string> json, string slotId, List<string> slotJson)
        {
            ID = id;
            JSON = json;
            SlotId = slotId;
            SlotJson = slotJson;
        }

        /// <summary>
        /// Supply _tag for online evaluation
        /// </summary>
        [JsonPropertyName("_tag")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ID
        {
            get { return this?.Marginal?.ID; }
            set
            {
                this.Marginal = value == null ? null : new DecisionContextDocumentId
                {
                    ID = value
                };
            }
        }

        /// <summary>
        /// Provide feature for marginal feature based on document id.
        /// </summary>
        [JsonPropertyName("i")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DecisionContextDocumentId Marginal { get; set; }

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
        public List<string> SlotJson { get; set; }
    }
}
