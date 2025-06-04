// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Rl.Net;

namespace Azure.AI.Personalizer
{
    /// <summary> The Rl.Net Processor. </summary>
    internal class RlNetProcessor
    {
        private readonly LiveModelBase liveModel;
        internal PolicyRestClient RestClient { get; }

        /// <summary> Initializes a new instance of RlNetProcessor. </summary>
        public RlNetProcessor(LiveModelBase liveModel)
        {
            this.liveModel = liveModel;
        }

        /// <summary> Submit a Personalizer rank request. Receives a context and a list of actions. Returns which of the provided actions should be used by your application, in rewardActionId. </summary>
        /// <param name="options"> A Personalizer Rank request. </param>
        public Response<PersonalizerRankResult> Rank(PersonalizerRankOptions options)
        {
            string eventId = options.EventId;
            if (String.IsNullOrEmpty(eventId))
            {
                eventId = Guid.NewGuid().ToString("N", CultureInfo.InvariantCulture);
            }

            HashSet<string> excludedSet = new HashSet<string>(options.ExcludedActions);

            // Store the original action list
            List<PersonalizerRankableAction> originalActions = new List<PersonalizerRankableAction>();
            List<PersonalizerRankableAction> rankableActions = new List<PersonalizerRankableAction>();
            List<PersonalizerRankableAction> excludedActions = new List<PersonalizerRankableAction>();
            int idx = 0;
            foreach (var action in options.Actions)
            {
                PersonalizerRankableAction actionCopy = new PersonalizerRankableAction(action.Id, action.Features);
                actionCopy.Index = idx;
                originalActions.Add(actionCopy);
                if (excludedSet.Contains(actionCopy.Id))
                {
                    excludedActions.Add(actionCopy);
                }
                else
                {
                    rankableActions.Add(actionCopy);
                }
                ++idx;
            }

            // Convert options to the compatible parameter for ChooseRank
            var contextJson = RlObjectConverter.ConvertToContextJson(options.ContextFeatures.Select(f => BinaryData.FromObjectAsJson(f)).ToList(), rankableActions);
            ActionFlags flags = options.DeferActivation == true ? ActionFlags.Deferred : ActionFlags.Default;

            // Call ChooseRank of local RL.Net
            RankingResponseWrapper rankingResponseWrapper = liveModel.ChooseRank(eventId, contextJson, flags);

            // Convert response to PersonalizerRankResult
            var value = RlObjectConverter.GenerateRankResult(originalActions, rankableActions, excludedActions, rankingResponseWrapper, options.EventId);

            return Response.FromValue(value, default);
        }

        /// <summary> Submit a Personalizer rank request. Receives a context and a list of actions. Returns which of the provided actions should be used by your application, in rewardActionId. </summary>
        /// <param name="options"> A Personalizer multi-slot Rank request. </param>
        public Response<PersonalizerMultiSlotRankResult> Rank(PersonalizerRankMultiSlotOptions options)
        {
            string eventId = options.EventId;
            if (String.IsNullOrEmpty(eventId))
            {
                eventId = Guid.NewGuid().ToString("N", CultureInfo.InvariantCulture);
            }

            Dictionary<string, int> actionIdToActionIndex = RlObjectConverter.GetActionIdToIndexMapping(options.Actions);
            Dictionary<string, IList<object>> slotIdToFeatures = new Dictionary<string, IList<object>>();
            foreach (var slot in options.Slots)
            {
                slotIdToFeatures.Add(slot.Id, RlObjectConverter.GetIncludedActionsForSlot(slot, actionIdToActionIndex));
            }

            // Convert options to the compatible parameter for ChooseRank
            DecisionContext decisionContext = new DecisionContext(options, slotIdToFeatures);
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                Converters =
                {
                     new JsonBinaryDataConverter(),
                },
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            var contextJson = JsonSerializer.Serialize(decisionContext, jsonSerializerOptions);
            ActionFlags flags = options.DeferActivation == true ? ActionFlags.Deferred : ActionFlags.Default;
            int[] baselineActions = RlObjectConverter.ExtractBaselineActionsFromRankRequest(options);

            // Call ChooseRank of local RL.Net
            MultiSlotResponseDetailedWrapper multiSlotResponseDetailedWrapper = liveModel.RequestMultiSlotDecisionDetailed(eventId, contextJson, flags, baselineActions);

            // Convert response to PersonalizerRankResult
            var value = RlObjectConverter.GenerateMultiSlotRankResponse(options.Actions, multiSlotResponseDetailedWrapper, eventId);

            return Response.FromValue(value, default);
        }

        /// <summary> Submit a Personalizer reward request. </summary>
        /// <param name="eventId"> The event id this reward applies to. </param>
        /// <param name="reward"> The reward should be a floating point number, typically between 0 and 1. </param>
        public Response Reward(string eventId, float reward)
        {
            // Call QueueOutcomeEvent of local RL.Net
            liveModel.QueueOutcomeEvent(eventId, reward);

            // Use 204 as there is no return value
            return new EventResponse(204);
        }

        /// <summary> Submit a Personalizer reward multi-slot request. </summary>
        /// <param name="eventId"> The event id this reward applies to. </param>
        /// <param name="slotRewards"> List of slot id and reward values. </param>
        public Response RewardMultiSlot(string eventId, IList<PersonalizerSlotReward> slotRewards)
        {
            foreach (PersonalizerSlotReward slotReward in slotRewards)
            {
                // Call QueueOutcomeEvent of local RL.Net
                liveModel.QueueOutcomeEvent(eventId, slotReward.SlotId, slotReward.Value);
            }

            // Use 204 as there is no return value
            return new EventResponse(204);
        }

        /// <summary> Activate Event. </summary>
        /// <param name="eventId"> The event ID to be activated. </param>
        public Response Activate(string eventId)
        {
            // Call ReportActionTaken of local RL.Net
            liveModel.QueueActionTakenEvent(eventId);

            // Use 204 as there is no return value
            return new EventResponse(204);
        }
    }
}
