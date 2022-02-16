// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;

#nullable enable

namespace Azure.Core
{
    /// <summary>
    /// Implementation of an exponential polling strategy. Polling interval changes according to
    /// the sequence {1, 1, 1, 2, 4, ...32}, unless interval is returned in server response header.
    /// In such cases, the max value will be adopted.
    /// </summary>
    internal class ExponentialPollingStrategy : OperationPollingStrategy
    {
        private static readonly TimeSpan[] pollingSequence = new TimeSpan[]
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

        private int _index;

        private TimeSpan GetNextInterval()
        {
            if (_index >= pollingSequence.Length)
            {
                return pollingSequence.Last();
            }
            return pollingSequence[_index++];
        }

        public override TimeSpan GetNextWait(Response response)
        {
            return GetMaxIntervalFromResponseAndIntrinsic(response, GetNextInterval());
        }
    }
}
