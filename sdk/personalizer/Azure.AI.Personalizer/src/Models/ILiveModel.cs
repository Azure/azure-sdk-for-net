// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Rl.Net;
using System;

namespace Azure.AI.Personalizer
{
    /// <summary> An interface for Rl.Net.LiveModel </summary>
    public interface ILiveModel
    {
        /// <summary> Init LiveModel </summary>
        void Init();

        /// <summary> Wrapper method of ChooseRank </summary>
        RankingResponseWrapper ChooseRank(string eventId, string contextJson, ActionFlags flags);

        /// <summary> Wrapper method of RequestMultiSlotDecisionDetailed </summary>
        MultiSlotResponseDetailedWrapper RequestMultiSlotDecisionDetailed(string eventId, string contextJson, ActionFlags flags, int[] baselineActions);

        /// <summary> Wrapper method of QueueOutcomeEvent </summary>
        void QueueOutcomeEvent(string eventId, float outcome);

        /// <summary> Wrapper method of RequestMultiSlotDecisionDetailed </summary>
        void QueueOutcomeEvent(string eventId, string slotId, float outcome);

        /// <summary> Wrapper method of QueueActionTakenEvent </summary>
        void QueueActionTakenEvent(string eventId);
    }
}
