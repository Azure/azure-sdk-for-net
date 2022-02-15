// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Rl.Net;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Azure.AI.Personalizer
{
    /// <summary> A wrapper class of Rl.Net.RankingResponse </summary>
    public class RankingResponseWrapper : IEnumerable<ActionProbabilityWrapper>
    {
        private readonly RankingResponse _rankingResponse;

        /// <summary> Initializes a new instance of RankingResponseWrapper. </summary>
        public RankingResponseWrapper()
        {
        }

        /// <summary> Initializes a new instance of RankingResponseWrapper. </summary>
        /// <param name="rankResponse"> An rank response </param>
        public RankingResponseWrapper(RankingResponse rankResponse)
        {
            _rankingResponse = rankResponse ?? throw new ArgumentNullException(nameof(rankResponse));
        }

        /// <summary> Get the enumerator </summary>
        public virtual IEnumerator<ActionProbabilityWrapper> GetEnumerator()
        {
            var enu = _rankingResponse.GetEnumerator();
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
