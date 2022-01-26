// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.Personalizer
{
    /// <summary> The Decision Context. </summary>
    public class DecisionContext
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
            this.ContextFeatures = contextFeatures.Select(f => JsonSerializer.Serialize(f)).ToList();
            this.Documents = rankableActions
                .Select(action =>
                {
                    List<string> actionFeatures = action.Features.Select(f => JsonSerializer.Serialize(f)).ToList();

                    return new DecisionContextDocument(action.Id, actionFeatures);
                }).ToArray();
        }

        /// <summary> Properties from url </summary>
        [JsonPropertyName("FromUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonConverter(typeof(JsonRawStringListConverter))]
        public List<string> ContextFeatures { get; }

        /// <summary> Properties of documents </summary>
        [JsonPropertyName("_multi")]
        public DecisionContextDocument[] Documents { get; set; }

        /// <summary> Properties of slots </summary>
        [JsonPropertyName("_slots")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DecisionContextDocument[] Slots { get; set; }
    }
}
