// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable

namespace Azure.Core
{
    /// <summary>
    /// Implementation of a <see cref="DelayStrategy"/>. Polling interval is based on the specified sequence.
    /// Defaults to {1s, 1s, 1s, 2s, 4s, 8s, 16s, 32s}.
    /// </summary>
    /// <remarks>Polling interval always follows the given sequence.</remarks>
    internal class SequentialDelayStrategy : DelayStrategy
    {
        private static readonly TimeSpan[] s_pollingSequence = new TimeSpan[]
        {
            TimeSpan.FromSeconds(1),
            TimeSpan.FromSeconds(1),
            TimeSpan.FromSeconds(1),
            TimeSpan.FromSeconds(2),
            TimeSpan.FromSeconds(4),
            TimeSpan.FromSeconds(8),
            TimeSpan.FromSeconds(16),
            TimeSpan.FromSeconds(32)
        };
        private static readonly TimeSpan _maxDelay = s_pollingSequence[s_pollingSequence.Length - 1];

        public SequentialDelayStrategy() : base(_maxDelay, 1.0, 1.0)
        {
        }

        protected override TimeSpan GetNextDelayCore(Response? response, int retryNumber)
        {
            return retryNumber >= s_pollingSequence.Length ? _maxDelay : s_pollingSequence[retryNumber];
        }
    }
}
