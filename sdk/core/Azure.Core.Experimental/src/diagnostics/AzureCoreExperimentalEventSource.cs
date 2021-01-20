// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.Tracing;

namespace Azure.Core.Diagnostics
{
    [EventSource(Name = EventSourceName)]
    internal sealed class AzureCoreExperimentalEventSource : EventSource
    {
        private const string EventSourceName = "Azure-Core-Experimental";

        private const int BackgroundRefreshFailedEvent = 19;

        private AzureCoreExperimentalEventSource() : base(EventSourceName, EventSourceSettings.Default, AzureEventSourceListener.TraitName, AzureEventSourceListener.TraitValue) { }

        public static AzureCoreExperimentalEventSource Singleton { get; } = new AzureCoreExperimentalEventSource();

        [Event(BackgroundRefreshFailedEvent, Level = EventLevel.Informational, Message = "Background token refresh [{0}] failed with exception {1}")]
        public void BackgroundRefreshFailed(string requestId, string exception)
        {
            WriteEvent(BackgroundRefreshFailedEvent, requestId, exception);
        }
    }
}
