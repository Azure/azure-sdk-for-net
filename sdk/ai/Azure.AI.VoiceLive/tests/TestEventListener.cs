// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

namespace Azure.AI.VoiceLive.Tests
{
    /// <summary>
    /// Test EventListener that captures events for verification.
    /// </summary>
    internal class TestEventListener : EventListener
    {
        private readonly List<EventWrittenEventArgs> _capturedEvents;

        public TestEventListener(List<EventWrittenEventArgs> capturedEvents)
        {
            _capturedEvents = capturedEvents ?? throw new ArgumentNullException(nameof(capturedEvents));
        }

        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            // Listen to Azure-VoiceLive events at Verbose level to capture content
            if (eventSource.Name == "Azure-VoiceLive")
            {
                EnableEvents(eventSource, EventLevel.Verbose);
            }
        }

        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            // Capture all events for later verification
            _capturedEvents.Add(eventData);
        }
    }
}
