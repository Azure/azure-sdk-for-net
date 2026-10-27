// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.Tracing;
using Azure.Core.Diagnostics;

namespace Azure.AI.Projects;

[EventSource(Name = "Azure-AI-Projects-Realtime")]
internal sealed class VoiceAgentRealtimeEventSource : AzureEventSource
{
    internal static readonly VoiceAgentRealtimeEventSource Log = new();

    private VoiceAgentRealtimeEventSource() : base("Azure-AI-Projects-Realtime")
    {
    }

    [Event(1, Level = EventLevel.Informational, Message = "Voice Agent connection {0}; trace={1}; span={2}.")]
    public void ConnectionState(string state, string traceId, string spanId)
    {
        if (IsEnabled(EventLevel.Informational, EventKeywords.None))
        {
            WriteEvent(1, state, traceId, spanId);
        }
    }

    [Event(2, Level = EventLevel.Verbose, Message = "Voice Agent event {0}; trace={1}; span={2}.")]
    public void ProtocolEvent(string eventName, string traceId, string spanId)
    {
        if (IsEnabled(EventLevel.Verbose, EventKeywords.None))
        {
            WriteEvent(2, eventName, traceId, spanId);
        }
    }

    [Event(3, Level = EventLevel.Warning, Message = "Voice Agent failure {0}; trace={1}; span={2}.")]
    public void Failure(string errorType, string traceId, string spanId)
    {
        if (IsEnabled(EventLevel.Warning, EventKeywords.None))
        {
            WriteEvent(3, errorType, traceId, spanId);
        }
    }
}
