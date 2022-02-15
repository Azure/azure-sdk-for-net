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
        /// <param name="actionFeatureJsonList"> The json list of action features </param>
        /// <param name="slotId"> The slot Id </param>
        /// <param name="slotFeatureJsonList"> The json list of slot features </param>
        public DecisionContextDocument(string id, List<string> actionFeatureJsonList, string slotId, List<string> slotFeatureJsonList)
        {
            Id = id;
            ActionFeatureJsonList = actionFeatureJsonList;
            SlotId = slotId;
            SlotFeatureJsonList = slotFeatureJsonList;
        }

        /// <summary>
        /// Supply _tag for online evaluation
        /// </summary>
        [JsonPropertyName("_tag")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Id { get; }

        /// <summary>
        /// A list of generic action feature jsons.
        /// </summary>
        [JsonPropertyName("j")]
        [JsonConverter(typeof(JsonRawStringListConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string> ActionFeatureJsonList { get; }

        /// <summary>
        /// Slot ID.
        /// </summary>
        [JsonPropertyName("_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string SlotId { get; }

        /// <summary>
        /// A list of generic slot feature jsons.
        /// </summary>
        [JsonPropertyName("sj")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonConverter(typeof(JsonRawStringListConverter))]
        public List<string> SlotFeatureJsonList { get; }
    }
}
