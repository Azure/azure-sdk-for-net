// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

#nullable enable

namespace Azure.Core
{
    /// <summary>
    /// Implementation of a <see cref="OperationPollingStrategy"/> with constant polling interval.
    /// Polling interval is always equal to the given polling interval.
    /// </summary>
    internal class ConstantPollingStrategy : OperationPollingStrategy
    {
        public TimeSpan PollingInterval { get;  }

        /// <summary>
        /// Create a <see cref="ConstantPollingStrategy"/> with 1 second polling interval.
        /// </summary>
        public ConstantPollingStrategy() : this(TimeSpan.FromSeconds(1)) { }

        /// <summary>
        /// Create a <see cref="ConstantPollingStrategy"/> with given polling interval.
        /// </summary>
        /// <param name="interval">Polling interval.</param>
        public ConstantPollingStrategy(TimeSpan interval)
        {
            PollingInterval = interval;
        }

        public override TimeSpan GetNextWait(Response response) => PollingInterval;
    }
}
