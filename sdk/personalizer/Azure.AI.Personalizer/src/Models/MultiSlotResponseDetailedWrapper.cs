﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Rl.Net;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Azure.AI.Personalizer
{
    /// <summary> The Wrapper for Rl.Net.MultiSlotResponseDetailed </summary>
    internal class MultiSlotResponseDetailedWrapper : IEnumerable<SlotRankingWrapper>
    {
        private readonly MultiSlotResponseDetailed _multiSlotResponse;

        /// <summary> Initializes a new instance of ActionProbabilityWrapper. </summary>
        public MultiSlotResponseDetailedWrapper()
        {
        }

        /// <summary> Initializes a new instance of ActionProbabilityWrapper. </summary>
        public MultiSlotResponseDetailedWrapper(MultiSlotResponseDetailed multiSlotResponse)
        {
            _multiSlotResponse = multiSlotResponse ?? throw new ArgumentNullException(nameof(multiSlotResponse));
        }

        /// <summary> Get the enumerator </summary>
        public virtual IEnumerator<SlotRankingWrapper> GetEnumerator()
        {
            var enu = _multiSlotResponse.GetEnumerator();
            while (enu.MoveNext())
            {
                yield return new SlotRankingWrapper(enu.Current);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
