// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.Personalizer
{
    /// <summary> The Decision Context. </summary>
    internal class DecisionContext
    {
        /// <summary> The Decision Context used to serialize an object. </summary>
        public DecisionContext()
        {
        }

        /// <summary> Initializes a new instance of DecisionContext. </summary>
        /// <param name="contextFeatures"> The context feature </param>
        /// <param name="rankableActions"> Rankable actions </param>
        public DecisionContext(IEnumerable<object> contextFeatures, List<PersonalizerRankableAction> rankableActions)
        {
            this.ContextFeatures = contextFeatures.ToList();
            this.Documents = rankableActions
                .Select(action =>
                {
                    IList<object> actionFeatures = action.Features.ToList();

                    return new DecisionContextDocument(action.Id, actionFeatures, null, null);
                }).ToArray();
        }

        /// <summary> Initializes a new instance of DecisionContext. </summary>
        /// <param name="rankRequest"> Personalizer multi-slot rank options </param>
        /// <param name="slotIdToFeatures"> A map from slot id to its features </param>
        public DecisionContext(PersonalizerRankMultiSlotOptions rankRequest, Dictionary<string, IList<object>> slotIdToFeatures)
        {
            this.ContextFeatures = rankRequest.ContextFeatures.ToList();

            this.Documents = rankRequest.Actions
                .Select(action =>
                {
                    IList<object> actionFeatures = action.Features.ToList();

                    return new DecisionContextDocument(action.Id, actionFeatures, null, null);
                }).ToList();
            this.Slots = rankRequest.Slots?
                .Select(
                    slot => new DecisionContextDocument(null, null, slot.Id, serializeFeatures(slotIdToFeatures[slot.Id]))
                ).ToList();
        }

        /// <summary> Properties from url </summary>
        [JsonPropertyName("FromUrl")]
        public IList<object> ContextFeatures { get; }

        /// <summary> Properties of documents </summary>
        [JsonPropertyName("_multi")]
        public IList<DecisionContextDocument> Documents { get; }

        /// <summary> Properties of slots </summary>
        [JsonPropertyName("_slots")]
        public IList<DecisionContextDocument> Slots { get; }

        private static IList<object> serializeFeatures(IList<object> features)
        {
            IList<object> result = new List<object>();
            foreach (object feature in features)
            {
                result.Add(feature);
            }

            return result;
        }
    }
}
