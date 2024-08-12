// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Rl.Net;
using System;

namespace Azure.AI.Personalizer
{
    /// <summary> An adapter class of Rl.Net.LiveModel </summary>
    internal class LiveModelAdapter : LiveModelBase
    {
        private readonly LiveModel liveModel;

        /// <summary> Initializes a new instance of LiveModelAdapter. </summary>
        internal LiveModelAdapter(LiveModel liveModel)
        {
            this.liveModel = liveModel ?? throw new ArgumentNullException(nameof(liveModel));
        }

        /// <summary> Init LiveModel </summary>
        public override void Init()
        {
            liveModel.Init();
        }

        /// <summary> Wrapper method of ChooseRank </summary>
        public override RankingResponseWrapper ChooseRank(string eventId, string contextJson, ActionFlags actionFlags)
        {
            RankingResponse rankingResponse = liveModel.ChooseRank(eventId, contextJson, actionFlags);
            RankingResponseWrapper rankingResponseWrapper = rankingResponse == null ? null : new RankingResponseWrapper(rankingResponse);

            return rankingResponseWrapper;
        }

        /// <summary> Wrapper method of RequestMultiSlotDecisionDetailed </summary>
        public override MultiSlotResponseDetailedWrapper RequestMultiSlotDecisionDetailed(string eventId, string contextJson, ActionFlags flags, int[] baselineActions)
        {
            MultiSlotResponseDetailed multiSlotResponse = liveModel.RequestMultiSlotDecisionDetailed(eventId, contextJson, flags, baselineActions);
            MultiSlotResponseDetailedWrapper multiSlotResponseDetailedWrapper = multiSlotResponse == null ? null : new MultiSlotResponseDetailedWrapper(multiSlotResponse);
            return multiSlotResponseDetailedWrapper;
        }

        /// <summary> Wrapper method of QueueOutcomeEvent </summary>
        public override void QueueOutcomeEvent(string eventId, float outcome)
        {
            liveModel.QueueOutcomeEvent(eventId, outcome);
        }

        /// <summary> Wrapper method of RequestMultiSlotDecisionDetailed </summary>
        public override void QueueOutcomeEvent(string eventId, string slotId, float outcome)
        {
            liveModel.QueueOutcomeEvent(eventId, slotId, outcome);
        }

        /// <summary> Wrapper method of QueueActionTakenEvent </summary>
        public override void QueueActionTakenEvent(string eventId)
        {
            liveModel.QueueActionTakenEvent(eventId);
        }

        /// <summary> Dispose liveModel </summary>
        protected override void DisposeManagedObjects()
        {
            liveModel.Dispose();
            base.DisposeManagedObjects();
        }
    }
}
