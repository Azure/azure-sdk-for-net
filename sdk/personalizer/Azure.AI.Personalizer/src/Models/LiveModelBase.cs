// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Rl.Net;
using System;

namespace Azure.AI.Personalizer
{
    /// <summary> An abstract class for Rl.Net.LiveModel </summary>
    internal abstract class LiveModelBase
    {
        /// <summary> Init LiveModel </summary>
        public abstract void Init();

        /// <summary> Wrapper method of ChooseRank </summary>
        public abstract RankingResponseWrapper ChooseRank(string eventId, string contextJson, ActionFlags flags);

        /// <summary> Wrapper method of RequestMultiSlotDecisionDetailed </summary>
        public abstract MultiSlotResponseDetailedWrapper RequestMultiSlotDecisionDetailed(string eventId, string contextJson, ActionFlags flags, int[] baselineActions);

        /// <summary> Wrapper method of QueueOutcomeEvent </summary>
        public abstract void QueueOutcomeEvent(string eventId, float outcome);

        /// <summary> Wrapper method of RequestMultiSlotDecisionDetailed </summary>
        public abstract void QueueOutcomeEvent(string eventId, string slotId, float outcome);

        /// <summary> Wrapper method of QueueActionTakenEvent </summary>
        public abstract void QueueActionTakenEvent(string eventId);
    }
}
