// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

#nullable enable

namespace Azure.Core
{
    /// <summary>
    /// Implementation of an exponential polling strategy. Starting from 1 second, up to 32 seconds.
    /// </summary>
    internal class ExponentialPollingStrategy : IOperationPollingStrategy
    {
        private static readonly TimeSpan maxPollingInterval = TimeSpan.FromSeconds(32);

        private TimeSpan _pollingInterval = TimeSpan.FromSeconds(1);

        /// <summary>
        /// Gets the polling interval. Starting from 1 second, up to 32 seconds.
        /// </summary>
        public TimeSpan PollingInterval
        {
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
