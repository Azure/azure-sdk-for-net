// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

#nullable enable

namespace Azure.Core.Shared
{
    /// <summary>
    /// Wraps <see cref="EventWrittenEventArgs"/> into <see cref="IReadOnlyList{T}"/> simplifying iterating over
    /// payload properties and providing them to logging libraries in a structured way.
    /// </summary>
    internal readonly struct EventSourceEvent : IReadOnlyList<KeyValuePair<string, object?>>
    {
        /// <summary>
        /// Gets underlying EventSource event.
        /// </summary>
        public EventWrittenEventArgs EventData { get; }

        public EventSourceEvent(EventWrittenEventArgs eventData)
        {
            EventData = eventData;
        }

        /// <inheritdoc />
        public IEnumerator<KeyValuePair<string, object?>> GetEnumerator()
        {
            if (EventData.PayloadNames == null || EventData.Payload == null)
            {
                yield break;
            }

            for (int i = 0; i < Count; i++)
            {
                yield return new KeyValuePair<string, object?>(EventData.PayloadNames[i], EventData.Payload[i]);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Returns the count of payload properties in the Eventsource event.
        /// </summary>
        public int Count => EventData.PayloadNames?.Count ?? 0;

        /// <summary>
        /// Formats EventSource event as a string including all payload properties.
        /// </summary>
        public string Format()
        {
            return EventSourceEventFormatting.Format(EventData);
        }

        /// <inheritdoc />
        public KeyValuePair<string, object?> this[int index]
        {
            get
            {
                if (EventData.PayloadNames == null || EventData.Payload == null || index >= EventData.PayloadNames.Count || index < 0)
                {
                    throw new IndexOutOfRangeException("Index was out of range.");
                }

                return new KeyValuePair<string, object?>(EventData.PayloadNames[index], EventData.Payload[index]);
            }
        }
    }
}
