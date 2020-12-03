// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Messaging.EventHubs;
using System.Collections.Generic;
using System.Globalization;
using Azure.Messaging.EventHubs.Primitives;

namespace Microsoft.Azure.WebJobs.EventHubs
{
    // The core object we get when an EventHub is triggered.
    // This gets converted to the user type (EventData, string, poco, etc)
    internal sealed class EventHubTriggerInput
    {
        // If != -1, then only process a single event in this batch.
        private int _selector = -1;

        internal EventData[] Events { get; set; }

        internal EventProcessorPartition PartitionContext { get; set; }

        public bool IsSingleDispatch
        {
            get
            {
                return _selector != -1;
            }
        }

        public static EventHubTriggerInput New(EventData eventData)
        {
            return new EventHubTriggerInput
            {
                PartitionContext = null,
                Events = new EventData[]
                {
                      eventData
                },
                _selector = 0,
            };
        }

        public EventHubTriggerInput GetSingleEventTriggerInput(int idx)
        {
            return new EventHubTriggerInput
            {
                Events = this.Events,
                PartitionContext = this.PartitionContext,
                _selector = idx
            };
        }

        public EventData GetSingleEventData()
        {
            return this.Events[this._selector];
        }

        public Dictionary<string, string> GetTriggerDetails(EventProcessorPartition context)
        {
            if (Events.Length == 0)
            {
                return new Dictionary<string, string>();
            }

            string offset, enqueueTimeUtc, sequenceNumber;
            if (IsSingleDispatch)
            {
                offset = Events[0].Offset.ToString(CultureInfo.InvariantCulture);
                enqueueTimeUtc = Events[0].EnqueuedTime.ToString("o", CultureInfo.InvariantCulture);
                sequenceNumber = Events[0].SequenceNumber.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                EventData first = Events[0];
                EventData last = Events[Events.Length - 1];

                offset = $"{first.Offset}-{last.Offset}";
                enqueueTimeUtc = $"{first.EnqueuedTime.ToString("o", CultureInfo.InvariantCulture)}-{last.EnqueuedTime.ToString("o", CultureInfo.InvariantCulture)}";
                sequenceNumber = $"{first.SequenceNumber}-{last.SequenceNumber}";
            }

            return new Dictionary<string, string>()
            {
                { "PartionId", context.PartitionId },
                { "Offset", offset },
                { "EnqueueTimeUtc", enqueueTimeUtc },
                { "SequenceNumber", sequenceNumber },
                { "Count", Events.Length.ToString(CultureInfo.InvariantCulture)}
            };
        }
    }
}