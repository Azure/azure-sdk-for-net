// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Tracing;

namespace Azure.AI.VoiceLive.Tests
{
    /// <summary>
    /// Represents a captured event in a structured format for testing.
    /// </summary>
    internal class CapturedEvent
    {
        public string Source { get; set; } = "";
        public DateTime Timestamp { get; set; }
        public EventLevel Level { get; set; }
        public string EventType { get; set; } = "";
        public string? ConnectionId { get; set; }
        public string? Endpoint { get; set; }
        public string? MessageType { get; set; }
        public string? Content { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
