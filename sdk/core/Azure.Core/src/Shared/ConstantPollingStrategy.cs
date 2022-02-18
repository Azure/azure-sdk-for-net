// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

#nullable enable

namespace Azure.Core
{
    /// <summary>
    /// Implementation of a <see cref="OperationPollingStrategy"/> with constant polling interval.
    /// </summary>
    /// <remarks>Polling interval is always equal to the given polling interval.</remarks>
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

        /// <summary>
        /// Get the polling interval from the max value of <see cref="PollingInterval"/> and <paramref name="suggestedInterval"/>.
        /// </summary>
        /// <param name="response">Service response.</param>
        /// <param name="suggestedInterval">Suggested pollingInterval.</param>
        /// <returns>Max value of <see cref="PollingInterval"/> and <paramref name="suggestedInterval"/>.</returns>
        public override TimeSpan GetNextWait(Response response, TimeSpan suggestedInterval) => Max(PollingInterval, suggestedInterval);
    }
}
