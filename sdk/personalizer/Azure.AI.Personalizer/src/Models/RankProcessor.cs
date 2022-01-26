// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Rl.Net;

namespace Azure.AI.Personalizer
{
    /// <summary> The Rank Processor. </summary>
    internal class RankProcessor
    {
        private readonly LiveModel _liveModel;
        internal PolicyRestClient RestClient { get; }

        /// <summary> Initializes a new instance of RankProcessor. </summary>
        public RankProcessor(LiveModel liveModel)
        {
            this._liveModel = liveModel;
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
            var contextJson = RlObjectConverter.ConvertToContextJson(options.ContextFeatures, rankableActions);
            ActionFlags flags = options.DeferActivation == true ? ActionFlags.Deferred : ActionFlags.Default;

            // Call ChooseRank of local RL.Net
            RankingResponse rankingResponse = _liveModel.ChooseRank(eventId, contextJson, flags);

            // Convert response to PersonalizerRankResult
             var value = RlObjectConverter.GenerateRankResult(originalActions, rankableActions, excludedActions, rankingResponse, options.EventId);

            return Response.FromValue(value, default);
        }
    }
}
