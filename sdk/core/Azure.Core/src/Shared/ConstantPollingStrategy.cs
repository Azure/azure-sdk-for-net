// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

#nullable enable

namespace Azure.Core
{
    /// <summary>
    /// Implementation of a constant polling interval strategy. Polling interval is always equal to the given polling interval,
    /// unless interval is returned in server response header. In such cases, the max value will be adopted.
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

        public override TimeSpan GetNextWait(Response response)
        {
            return GetMaxIntervalFromResponseAndIntrinsic(response, PollingInterval);
        }
    }
}
