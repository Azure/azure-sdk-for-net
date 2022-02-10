// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Internal
{
    /// <summary>
    /// Exponential polling stategy. Starting from 1 second, until 32 seconds.
    /// </summary>
    internal class ExponentialPollingStrategy
    {
        private static readonly TimeSpan maxPollingInterval = TimeSpan.FromSeconds(32);

        private TimeSpan _pollingInterval = TimeSpan.FromSeconds(1);

        /// <summary>
        /// Gets the polling interval.
        /// </summary>
        public TimeSpan PollingInterval {
            get
            {
                var returnValue = _pollingInterval;
                if (_pollingInterval < maxPollingInterval)
                {
                    _pollingInterval += _pollingInterval;
                }
                return returnValue;
            }
        }
    }
}
