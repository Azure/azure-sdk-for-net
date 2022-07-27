// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Azure.AI.Personalizer
{
    /// <summary> The Decision Context Document. </summary>
    internal class DecisionContextDocument
    {
        /// <summary> Initializes a new instance of DecisionContextDocument. </summary>
        /// <param name="id"> Id of the decision context document </param>
        /// <param name="actionFeatures"> The json list of action features </param>
        /// <param name="slotId"> The slot Id </param>
        /// <param name="slotFeatures"> The json list of slot features </param>
        public DecisionContextDocument(string id, IList<object> actionFeatures, string slotId, IList<object> slotFeatures)
        {
            Id = id;
            ActionFeatures = actionFeatures;
            SlotId = slotId;
            SlotFeatures = slotFeatures;
        }

        /// <summary>
        /// Supply _tag for online evaluation
        /// </summary>
        [JsonPropertyName("_tag")]
        public string Id { get; }

        /// <summary>
        /// A list of generic action feature jsons.
        /// </summary>
        [JsonPropertyName("j")]
        public IList<object> ActionFeatures { get; }

        /// <summary>
        /// Slot ID.
        /// </summary>
        [JsonPropertyName("_id")]
        public string SlotId { get; }

        /// <summary>
        /// A list of generic slot feature jsons.
        /// </summary>
        [JsonPropertyName("sj")]
        public IList<object> SlotFeatures { get; }
    }
}
