// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.Tracing;

namespace Azure.AI.VoiceLive.Tests
{
    /// <summary>
    /// EventListener that consumes events but doesn't process them.
    /// Used for performance testing to ensure events are consumed but not add processing overhead.
    /// </summary>
    internal class NullEventListener : EventListener
    {
        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            if (eventSource.Name == "Azure-VoiceLive")
            {
                EnableEvents(eventSource, EventLevel.Verbose);
            }
        }

        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            // Do nothing - just consume the events
        }
    }
}
