// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Globalization;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Primitives;
using Microsoft.Azure.WebJobs.EventHubs.Processor;

namespace Microsoft.Azure.WebJobs.EventHubs
{
    // The core object we get when an EventHub is triggered.
    // This gets converted to the user type (EventData, string, poco, etc)
    internal sealed class EventHubTriggerInput
    {
        // If != -1, then only process a single event in this batch.
        private int _selector = -1;

        internal EventData[] Events { get; set; }

        internal EventProcessorHostPartition ProcessorPartition { get; set; }

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
                ProcessorPartition = null,
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
                ProcessorPartition = this.ProcessorPartition,
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

            string offset, offsetString, enqueueTimeUtc, sequenceNumber;
            if (IsSingleDispatch)
            {
                if (!long.TryParse(Events[0].OffsetString, NumberStyles.Integer, CultureInfo.InvariantCulture, out var offsetLong))
                {
                    // Default to "beginning of stream" if parsing fails.  This will result in duplicates,
                    // but ensures no data loss.

                    offsetLong = -1;
                }

                offset = offsetLong.ToString(CultureInfo.InvariantCulture);
                offsetString = Events[0].OffsetString;
                enqueueTimeUtc = Events[0].EnqueuedTime.ToString("o", CultureInfo.InvariantCulture);
                sequenceNumber = Events[0].SequenceNumber.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                EventData first = Events[0];
                EventData last = Events[Events.Length - 1];

                offset = $"{first.OffsetString}-{last.OffsetString}";
                offsetString = $"{first.OffsetString}-{last.OffsetString}";
                enqueueTimeUtc = $"{first.EnqueuedTime.ToString("o", CultureInfo.InvariantCulture)}-{last.EnqueuedTime.ToString("o", CultureInfo.InvariantCulture)}";
                sequenceNumber = $"{first.SequenceNumber}-{last.SequenceNumber}";
            }

            return new Dictionary<string, string>()
            {
                { "PartitionId", context.PartitionId },
                { "OffsetString", offsetString },
                { "EnqueueTimeUtc", enqueueTimeUtc },
                { "SequenceNumber", sequenceNumber },
                { "Count", Events.Length.ToString(CultureInfo.InvariantCulture)},

                // Preserve a numeric offset for compatibility with existing code.  It is immportant
                // to note that this does not conform to the Event Hubs service contract and may not
                // reflect the actual offset of the event in the stream.  In the case that the
                // offset is not a valid numeric value, it will default to -1 which would position
                // readers at the beginning of the stream, causing duplicates but preventing data loss.
                { "Offset", offset },

                // Preserve a misspelling that existed in the original code, as
                // there may be applications relying on this.
                { "PartionId", context.PartitionId }
            };
        }
    }
}