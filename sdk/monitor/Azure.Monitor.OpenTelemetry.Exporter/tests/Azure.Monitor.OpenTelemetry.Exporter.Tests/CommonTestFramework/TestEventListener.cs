// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Copied from: https://github.com/open-telemetry/opentelemetry-dotnet/blob/main/test/OpenTelemetry.Tests/Shared/TestEventListener.cs
// Which was copied from: https://github.com/microsoft/ApplicationInsights-dotnet/blob/main/BASE/Test/TestFramework/Shared/TestEventListener.cs

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Threading;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;

internal class TestEventListener : EventListener
{
    /// <summary>Unique Id used to identify events from the test thread.</summary>
    private readonly Guid activityId;

    /// <summary>A queue of events that have been logged.</summary>
    private readonly List<EventWrittenEventArgs> events;

    /// <summary>
    /// Lock for event writing tracking.
    /// </summary>
    private readonly AutoResetEvent eventWritten;

    /// <summary>
    /// Initializes a new instance of the <see cref="TestEventListener"/> class.
    /// </summary>
    public TestEventListener()
    {
        this.activityId = Guid.NewGuid();
        EventSource.SetCurrentThreadActivityId(this.activityId);

        this.events = new List<EventWrittenEventArgs>();
        this.eventWritten = new AutoResetEvent(false);
        this.OnOnEventWritten = e =>
        {
            this.events.Add(e);
            this.eventWritten.Set();
        };
    }

    /// <summary>Gets or sets the handler for event source writes.</summary>
    public Action<EventWrittenEventArgs> OnOnEventWritten { get; set; }

    /// <summary>Gets the events that have been written.</summary>
    public IList<EventWrittenEventArgs> Messages
    {
        get
        {
            if (this.events.Count == 0)
            {
                this.eventWritten.WaitOne(TimeSpan.FromSeconds(5));
            }

            return this.events;
        }
    }

    /// <summary>
    /// Clears all event messages so that testing can assert expected counts.
    /// </summary>
    public void ClearMessages()
    {
        this.events.Clear();
    }

    /// <summary>Handler for event source writes.</summary>
    /// <param name="eventData">The event data that was written.</param>
    protected override void OnEventWritten(EventWrittenEventArgs eventData)
    {
        if (eventData.ActivityId == this.activityId)
        {
            this.OnOnEventWritten(eventData);
        }
    }
}
