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
    public class SequentialDelayStrategy : DelayStrategy
    {
        private readonly IEnumerable<TimeSpan>? _sequence;

        private static readonly TimeSpan[] s_defaultPollingSequence = new TimeSpan[]
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
        private static readonly TimeSpan _maxDelay = s_defaultPollingSequence[s_defaultPollingSequence.Length - 1];

        /// <summary>
        ///
        /// </summary>
        /// <param name="sequence"></param>
        public SequentialDelayStrategy(IEnumerable<TimeSpan>? sequence = default)
        {
            _sequence = sequence ?? s_defaultPollingSequence;
        }

        /// <summary>
        /// Get the next delay from the sequence.
        /// </summary>
        /// <param name="response">Service response.</param>
        /// <param name="attempt"></param>
        /// <param name="delayHint">Suggested delay.</param>
        public override TimeSpan GetNextDelay(Response? response, int attempt, TimeSpan? delayHint)
        {
            if (attempt >= s_defaultPollingSequence.Length)
            {
                return _maxDelay;
            }
            return s_defaultPollingSequence[attempt];
        }
    }
}
