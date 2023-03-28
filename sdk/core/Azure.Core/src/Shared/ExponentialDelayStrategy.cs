// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;

#nullable enable

namespace Azure.Core
{
    /// <summary>
    /// Implementation of a <see cref="DelayStrategy"/>. Polling interval changes according to
    /// the sequence {1, 1, 1, 2, 4, ...32}.
    /// </summary>
    /// <remarks>Polling interval always follows the given sequence.</remarks>
    internal class ExponentialDelayStrategy : DelayStrategy
    {
        private static readonly TimeSpan[] _pollingSequence = new TimeSpan[]
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
        private static readonly TimeSpan _maxDelay = _pollingSequence[_pollingSequence.Length - 1];

        private int _index;

        /// <summary>
        /// Get the polling interval from {1, 1, 1, 2, 4, ...32}.
        /// </summary>
        /// <param name="response">Service response.</param>
        /// <param name="suggestedInterval">Suggested pollingInterval.</param>
        public override TimeSpan GetNextDelay(Response response, TimeSpan? suggestedInterval)
        {
            if (_index >= _pollingSequence.Length)
            {
                return _maxDelay;
            }
            return _pollingSequence[_index++];
        }
    }
}