// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using System.Text.Json.Serialization;

namespace Azure.AI.Personalizer
{
    /// <summary> The converter between objects for Rl.Net objects and the sdk </summary>
    internal static class RlObjectConverter
    {
        /// <summary>
        /// Convert PersonalizerRankOptions object to a json context string for Rl.Net
        /// </summary>
        public static string ConvertToContextJson(IList<BinaryData> contextFeatures, List<PersonalizerRankableAction> rankableActions)
        {
            DecisionContext decisionContext = new DecisionContext(contextFeatures, rankableActions);
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                Converters =
                {
                     new JsonBinaryDataConverter(),
                },
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            return JsonSerializer.Serialize(decisionContext, jsonSerializerOptions);
        }

        /// <summary>
        /// Create rank result based on Rl.Net response
        /// </summary>
        public static PersonalizerRankResult GenerateRankResult(List<PersonalizerRankableAction> originalActions,
            List<PersonalizerRankableAction> rankableActions, List<PersonalizerRankableAction> excludedActions,
            RankingResponseWrapper rankingResponse, string eventId)
        {
            var rankedIndices = rankingResponse?.Select(actionProbability => ((int)actionProbability.ActionIndex + 1)).ToArray();

            var rankingProbabilities = rankingResponse?.Select(actionProbability =>
                actionProbability.Probability).ToArray();

            return GenerateRankResultInner(originalActions, rankableActions, excludedActions, rankedIndices, rankingProbabilities, eventId);
        }

        private static PersonalizerRankResult GenerateRankResultInner(List<PersonalizerRankableAction> originalActions,
            List<PersonalizerRankableAction> rankableActions, List<PersonalizerRankableAction> excludedActions, int[] rankedIndices, float[] rankingProbabilities, string eventId)
        {
            // excluded actions are not passed into VW
            // rankedIndices[0] is the index of the VW chosen action (1 based index)
            int chosenActionIndex = rankedIndices[0] - 1;

            // take care of actions that are excluded in their original positions
            if (excludedActions != null && excludedActions.Count > 0)
            {
                var newRanking = new int[originalActions.Count];
                var probabilities = new float[originalActions.Count];

                // at the original position
                // point the original position of ranked item
                for (int i = 0; i < rankableActions.Count; i++)
                {
                    //RankableActions is Actions - ExcludedActions
                    newRanking[rankableActions[i].Index] = rankableActions[rankedIndices[i] - 1].Index + 1;
                    probabilities[rankableActions[i].Index] = rankingProbabilities[i];
                }

                // update excluded positions
                foreach (var l in excludedActions)
                    newRanking[l.Index] = l.Index + 1;

                rankedIndices = newRanking;
                rankingProbabilities = probabilities;
            }

            // finalize decision response ranking
            var rankings = rankedIndices?.Select((index, i) =>
            {
                var action = originalActions[index - 1];
                return new PersonalizerRankedAction(action.Id, rankingProbabilities[i]);
            }).ToList();

            // setting RewardActionId to be the VW chosen action.
            var personalizerRankResult = new PersonalizerRankResult(rankings, eventId, rankableActions.ElementAt(chosenActionIndex)?.Id);

            return personalizerRankResult;
        }

        public static PersonalizerMultiSlotRankResult GenerateMultiSlotRankResponse(IList<PersonalizerRankableAction> actions, MultiSlotResponseDetailedWrapper multiSlotResponse, string eventId)
        {
            Dictionary<long, string> actionIndexToActionId = actions
                .Select((action, index) => new { action, index = (long)index })
                .ToDictionary(obj => obj.index, obj => obj.action.Id);

            List<PersonalizerSlotResult> slots = multiSlotResponse
                .Select(slotRanking => new PersonalizerSlotResult(slotRanking.SlotId, actionIndexToActionId[slotRanking.ChosenAction]))
                .ToList();

            return new PersonalizerMultiSlotRankResult(slots, eventId);
        }

        public static int[] ExtractBaselineActionsFromRankRequest(PersonalizerRankMultiSlotOptions request)
        {
            Dictionary<string, int> actionIdToIndex = GetActionIdToIndexMapping(request.Actions);
            return request.Slots
                .Select(slot => actionIdToIndex[slot.BaselineAction]).ToArray();
        }

        public static Dictionary<string, int> GetActionIdToIndexMapping(IList<PersonalizerRankableAction> actions)
        {
            return actions
                .Select((action, index) => new { action, index })
                .ToDictionary(obj => obj.action.Id, obj => obj.index);
        }

        public static IList<object> GetIncludedActionsForSlot(PersonalizerSlotOptions slot, Dictionary<string, int> actionIdToActionIndex)
        {
            IList<object> res = new ChangeTrackingList<object>();
            if (slot.Features != null)
            {
                foreach (object feature in slot.Features)
                {
                    res.Add(feature);
                }
            }
            if (slot.ExcludedActions != null)
            {
                List<int> excludeActionIndices = slot.ExcludedActions.Select(id => actionIdToActionIndex[id]).ToList();
                var allActionIndices = new HashSet<int>(actionIdToActionIndex.Values);
                List<int> includedActionIndices = allActionIndices.Except(excludeActionIndices).ToList();
                var includedActions = (new { _inc = includedActionIndices });
                res.Add(includedActions);
            }

            return res;
        }
    }
}
