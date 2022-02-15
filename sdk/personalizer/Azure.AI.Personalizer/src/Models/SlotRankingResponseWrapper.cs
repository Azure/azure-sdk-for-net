// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Rl.Net;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Azure.AI.Personalizer
{
    /// <summary> The Wrapper for Rl.Net.SlotRankingResponse </summary>
    public class SlotRankingResponseWrapper : IEnumerable<ActionProbabilityWrapper>
    {
        private readonly SlotRanking _slotRanking;

        /// <summary> Initializes a new instance of SlotRankingResponseWrapper. </summary>
        public SlotRankingResponseWrapper()
        {}

        /// <summary> Initializes a new instance of SlotRankingResponseWrapper. </summary>
        public SlotRankingResponseWrapper(SlotRanking slotRanking)
        {
            _slotRanking = slotRanking ?? throw new ArgumentNullException(nameof(slotRanking));
        }

        /// <summary> Id of the slot ranking </summary>
        public virtual string SlotId { get { return _slotRanking.SlotId; } }

        /// <summary> The chosen action id </summary>
        public virtual long ChosenAction { get { return _slotRanking.ChosenAction; } }

        /// <summary> The count of the slot ranking </summary>
        public virtual long Count { get { return _slotRanking.Count; } }

        /// <summary> The enumerator </summary>
        public virtual IEnumerator<ActionProbabilityWrapper> GetEnumerator()
        {
            var enu = _slotRanking.GetEnumerator();
            while (enu.MoveNext())
            {
                yield return new ActionProbabilityWrapper(enu.Current);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
