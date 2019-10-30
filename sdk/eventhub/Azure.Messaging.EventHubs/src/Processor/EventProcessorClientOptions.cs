// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   The baseline set of options that can be specified when creating a <see cref="EventProcessor" />
    ///   to configure its behavior.
    /// </summary>
    ///
    public class EventProcessorClientOptions
    {
        /// <summary>The maximum number of messages to receive in every receive attempt.</summary>
        private int _maximumMessageCount = 10;

        /// <summary>The maximum amount of time to wait to build up the requested message count in every receive attempt.</summary>
        private TimeSpan? _maximumReceiveWaitTime = null;

        /// <summary>
        ///   The maximum number of messages to receive in every receive attempt.
        /// </summary>
        ///
        public int MaximumMessageCount
        {
            get => _maximumMessageCount;

            set
            {
                Argument.AssertInRange(value, 1, int.MaxValue, nameof(MaximumMessageCount));
                _maximumMessageCount = value;
            }
        }

        /// <summary>
        ///   The maximum amount of time to wait to build up the requested message count in every receive attempt.
        /// </summary>
        ///
        public TimeSpan? MaximumReceiveWaitTime
        {
            get => _maximumReceiveWaitTime;

            set
            {
                if (value.HasValue)
                {
                    Argument.AssertNotNegative(value.Value, nameof(MaximumReceiveWaitTime));
                }

                _maximumReceiveWaitTime = value;
            }
        }

        /// <summary>
        ///   Creates a new copy of the current <see cref="EventProcessorClientOptions" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <returns>A new copy of <see cref="EventProcessorClientOptions" />.</returns>
        ///
        /// <remarks>
        ///   The members of an <see cref="EventPosition" /> are internal and can't be modified by the user after its
        ///   creation.
        /// </remarks>
        ///
        internal EventProcessorClientOptions Clone() =>
            new EventProcessorClientOptions
            {
                MaximumMessageCount = MaximumMessageCount,
                MaximumReceiveWaitTime = MaximumReceiveWaitTime
            };
    }
}
