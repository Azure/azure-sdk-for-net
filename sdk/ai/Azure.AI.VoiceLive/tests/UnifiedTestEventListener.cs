// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

namespace Azure.AI.VoiceLive.Tests
{
    /// <summary>
    /// Test EventListener that captures events from multiple Azure EventSources.
    /// Simulates how a real unified listener would work.
    /// </summary>
    internal class UnifiedTestEventListener : EventListener
    {
        private readonly List<EventWrittenEventArgs> _capturedEvents;
        private readonly EventLevel _level;

        public UnifiedTestEventListener(List<EventWrittenEventArgs> capturedEvents, EventLevel level = EventLevel.Verbose)
        {
            _capturedEvents = capturedEvents ?? throw new ArgumentNullException(nameof(capturedEvents));
            _level = level;
        }

        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            // Listen to all Azure EventSources (simulating unified Azure SDK logging)
            if (eventSource.Name.StartsWith("Azure-"))
            {
                EnableEvents(eventSource, _level);
            }
        }

        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            // Capture all Azure events for verification
            if (eventData.EventSource.Name.StartsWith("Azure-"))
            {
                _capturedEvents.Add(eventData);
            }
        }
    }
}
