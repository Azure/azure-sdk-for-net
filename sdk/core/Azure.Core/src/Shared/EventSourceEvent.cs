// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

namespace Azure.Core.Shared
{
    internal readonly struct EventSourceEvent: IReadOnlyList<KeyValuePair<string, object>>
    {
        public EventWrittenEventArgs EventData { get; }

        public EventSourceEvent(EventWrittenEventArgs eventData)
        {
            EventData = eventData;
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return new KeyValuePair<string, object>(EventData.PayloadNames[i], EventData.Payload[i]);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count => EventData.PayloadNames.Count;

        public string Format()
        {
            return EventSourceEventFormatting.Format(EventData);
        }

        public KeyValuePair<string, object> this[int index] => new KeyValuePair<string, object>(EventData.PayloadNames[index], EventData.Payload[index]);
    }
}
