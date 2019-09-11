// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Azure.Core.Shared;

namespace Azure.Core.Diagnostics
{
    public class AzureEventSourceListener: EventListener
    {
        private readonly List<EventSource> _eventSources = new List<EventSource>();

        private readonly Action<EventWrittenEventArgs, string> _log;
        private readonly EventLevel _level;

        public AzureEventSourceListener(Action<EventWrittenEventArgs, string> log, EventLevel level)
        {
            _log = log;
            _level = level;

            foreach (EventSource eventSource in _eventSources)
            {
                OnEventSourceCreated(eventSource);
            }

            _eventSources.Clear();
        }

        protected sealed override void OnEventSourceCreated(EventSource eventSource)
        {
            base.OnEventSourceCreated(eventSource);

            if (_log == null)
            {
                _eventSources.Add(eventSource);
            }

            if (eventSource.GetTrait("AzureEventSource") == "true")
            {
                EnableEvents(eventSource, _level);
            }
        }

        protected sealed override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            _log(eventData, EventSourceEventFormatting.Format(eventData));
        }

        public static AzureEventSourceListener CreateConsoleLogger(EventLevel level = EventLevel.Informational)
        {
            return new AzureEventSourceListener((eventData, text) => Console.WriteLine("[{1}] {0}: {2}", eventData.EventSource.Name, eventData.Level, text), level);
        }
    }
}
