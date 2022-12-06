// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System;

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
        public DecisionContext(IList<BinaryData> contextFeatures, List<PersonalizerRankableAction> rankableActions)
        {
            this.ContextFeatures = contextFeatures;
            this.Documents = rankableActions
                .Select(action =>
                {
                    IList<BinaryData> actionFeatures = action.Features.Select(f => BinaryData.FromObjectAsJson(f)).ToList();

                    return new DecisionContextDocument(action.Id, actionFeatures, null, null);
                }).ToArray();
        }

        /// <summary> Initializes a new instance of DecisionContext. </summary>
        /// <param name="rankRequest"> Personalizer multi-slot rank options </param>
        /// <param name="slotIdToFeatures"> A map from slot id to its features </param>
        public DecisionContext(PersonalizerRankMultiSlotOptions rankRequest, Dictionary<string, IList<object>> slotIdToFeatures)
        {
            this.ContextFeatures = rankRequest.ContextFeatures.Select(f => BinaryData.FromObjectAsJson(f)).ToList();

            this.Documents = rankRequest.Actions
                .Select(action =>
                {
                    IList<BinaryData> actionFeatures = action.Features.Select(f => BinaryData.FromObjectAsJson(f)).ToList();

                    return new DecisionContextDocument(action.Id, actionFeatures, null, null);
                }).ToList();
            this.Slots = rankRequest.Slots?
                .Select(
                    slot => new DecisionContextDocument(null, null, slot.Id, serializeFeatures(slotIdToFeatures[slot.Id]))
                ).ToList();
        }

        /// <summary> Properties from url </summary>
        [JsonPropertyName("FromUrl")]
        public IList<BinaryData> ContextFeatures { get; }

        /// <summary> Properties of documents </summary>
        [JsonPropertyName("_multi")]
        public IList<DecisionContextDocument> Documents { get; }

        /// <summary> Properties of slots </summary>
        [JsonPropertyName("_slots")]
        public IList<DecisionContextDocument> Slots { get; }

        private static IList<BinaryData> serializeFeatures(IList<object> features)
        {
            IList<BinaryData> result = new List<BinaryData>();
            foreach (object feature in features)
            {
                result.Add(BinaryData.FromObjectAsJson(feature));
            }

            return result;
        }
    }
}
