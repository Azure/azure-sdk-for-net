// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Rl.Net;
using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.Personalizer
{
    /// <summary> The converter between objects for Rl.Net objects and the sdk </summary>
    internal static class RlObjectConverter
    {
        /// <summary>
        /// Convert PersonalizerRankOptions object to a json context string for Rl.Net
        /// </summary>
        public static string ConvertToContextJson(IEnumerable<object> contextFeatures, List<PersonalizerRankableAction> rankableActions)
        {
            DecisionContext decisionContext = new DecisionContext(contextFeatures, rankableActions);
            return JsonSerializer.Serialize(decisionContext);
        }

        /// <summary>
        /// Create rank result based on Rl.Net response
        /// </summary>
        public static PersonalizerRankResult GenerateRankResult(List<PersonalizerRankableAction> originalActions,
            List<PersonalizerRankableAction> rankableActions, List<PersonalizerRankableAction> excludedActions,
            RankingResponse rankingResponse, string eventId)
        {
            var rankedIndices = rankingResponse?.Select(actionProbability => ((int)actionProbability.ActionIndex + 1)).ToArray();

            var rankingProbabilities = rankingResponse?.Select(actionProbability =>
                actionProbability.Probability).ToArray();

            return GenerateRankResultInner(originalActions, rankableActions, excludedActions, rankedIndices, rankingProbabilities, eventId);
        }

        private static PersonalizerRankResult GenerateRankResultInner(List<PersonalizerRankableAction> originalActions,
            List<PersonalizerRankableAction> rankableActions, List<PersonalizerRankableAction> excludedActions, int[] rankedIndices, float[] rankingProbabilities, string eventId, int multiSlotChosenActionIndex = -1)
        {
            // excluded actions are not passed into VW
            // rankedIndices[0] is the index of the VW chosen action (1 based index)
            // ccb response that is converted into a cb response: the chosen action index is a field in the vw response.
            // multiSlotChosenActionIndex is part of the multi slot response (0 based index)
            int chosenActionIndex = multiSlotChosenActionIndex == -1 ? rankedIndices[0] - 1 : multiSlotChosenActionIndex;

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

            var personalizerRankResult = new PersonalizerRankResult
            {
                EventId = eventId
            };
            // finalize decision response ranking
            personalizerRankResult.Ranking = rankedIndices?.Select((index, i) =>
            {
                var action = originalActions[index - 1];
                return new PersonalizerRankedAction()
                {
                    Id = action.Id,
                    Probability = rankingProbabilities[i]
                };
            }).ToList();

            //setting RewardActionId to be the VW chosen action.
            personalizerRankResult.RewardActionId = originalActions.ElementAt(chosenActionIndex)?.Id;

            return personalizerRankResult;
        }
    }
}
