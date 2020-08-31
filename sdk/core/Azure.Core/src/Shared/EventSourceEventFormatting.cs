// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Linq;
using System.Text;
using Azure.Core.Diagnostics;

namespace Azure.Core.Shared
{
    internal static class EventSourceEventFormatting
    {
        public static string Format(EventWrittenEventArgs eventData)
        {
            var payloadArray = eventData.Payload.ToArray();

            ProcessPayloadArray(payloadArray);

            if (eventData.Message != null)
            {
                try
                {
                    return string.Format(CultureInfo.InvariantCulture, eventData.Message, payloadArray);
                }
                catch (FormatException)
                {
                    EventSourceEventFormattingEventSource.Singleton.EventMessageFailedFormatting(eventData.EventSource.Name, eventData.EventName, eventData.Message);
                }
            }

            var stringBuilder = new StringBuilder();
            stringBuilder.Append(eventData.EventName);

            if (!string.IsNullOrWhiteSpace(eventData.Message))
            {
                stringBuilder.AppendLine();
                stringBuilder.Append(nameof(eventData.Message)).Append(" = ").Append(eventData.Message);
            }

            for (int i = 0; i < eventData.PayloadNames.Count; i++)
            {
                stringBuilder.AppendLine();
                stringBuilder.Append(eventData.PayloadNames[i]).Append(" = ").Append(payloadArray[i]);
            }

            return stringBuilder.ToString();
        }

        private static void ProcessPayloadArray(object[] payloadArray)
        {
            for (int i = 0; i < payloadArray.Length; i++)
            {
                payloadArray[i] = FormatValue(payloadArray[i]);
            }
        }

        private static object FormatValue(object o)
        {
            if (o is byte[] bytes)
            {
                var stringBuilder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0:X2}", b);
                }

                return stringBuilder.ToString();
            }

            return o;
        }

        [EventSource(Name = EventSourceName)]
        private class EventSourceEventFormattingEventSource : EventSource
        {
            private const string EventSourceName = "Event-Source-Event-Formatting";

            private EventSourceEventFormattingEventSource() : base(EventSourceName, EventSourceSettings.Default, AzureEventSourceListener.TraitName, AzureEventSourceListener.TraitValue) {}

            public static EventSourceEventFormattingEventSource Singleton { get; } = new EventSourceEventFormattingEventSource();

            [Event(1, Level = EventLevel.Warning)]
            public void EventMessageFailedFormatting(string eventSourceName, string eventName, string message)
            {
                WriteEvent(1,eventSourceName,eventName,message);
            }
        }
    }
}
