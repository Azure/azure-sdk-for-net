// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

#nullable enable

namespace Azure.Core
{
    /// <summary>
    /// A delay strategy that uses a fixed sequence of delays with no jitter applied. This is used by management LROs.
    /// </summary>
    internal class SequentialDelayStrategy : DelayStrategy
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

        public SequentialDelayStrategy() : base(_maxDelay, 0)
        {
        }

        protected override TimeSpan GetNextDelayCore(Response? response, int retryNumber)
        {
            int index = retryNumber - 1;
            return index >= _pollingSequence.Length ? _maxDelay : _pollingSequence[index];
        }
    }
}
