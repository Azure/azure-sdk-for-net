// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Azure.Core;

namespace Azure.AI.VoiceLive.Tests
{
    /// <summary>
    /// Raw event listener for capturing EventWrittenEventArgs directly.
    /// </summary>
    internal class RawEventListener : EventListener
    {
        private readonly List<EventWrittenEventArgs> _capturedEvents;

        public RawEventListener(List<EventWrittenEventArgs> capturedEvents)
        {
            _capturedEvents = capturedEvents ?? throw new ArgumentNullException(nameof(capturedEvents));
        }

        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            if (eventSource.Name == "Azure-VoiceLive")
            {
                EnableEvents(eventSource, EventLevel.Verbose);
            }
        }

        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            _capturedEvents.Add(eventData);
        }
    }
}
