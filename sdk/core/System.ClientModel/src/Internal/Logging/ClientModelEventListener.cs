// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;

namespace System.ClientModel.Internal;

internal class ClientModelEventListener : EventListener
{
    private readonly List<EventSource> _eventSources = new List<EventSource>();
    private readonly Action<EventWrittenEventArgs, string> _log;

    /// <summary>
    /// Creates an instance of <see cref="ClientModelEventListener"/> that executes a <paramref name="log"/> callback every time event is written.
    /// </summary>
    /// <param name="log">The <see cref="System.Action{EventWrittenEventArgs, String}"/> to call when event is written. The second parameter is formatted message.</param>
    public ClientModelEventListener(Action<EventWrittenEventArgs, string> log)
    {
        _log = log ?? throw new ArgumentNullException(nameof(log));

        foreach (EventSource eventSource in _eventSources)
        {
            OnEventSourceCreated(eventSource);
        }

        _eventSources.Clear();
    }

    /// <inheritdoc />
    protected sealed override void OnEventSourceCreated(EventSource eventSource)
    {
        base.OnEventSourceCreated(eventSource);

        if (eventSource.Name == "System-ClientModel")
        {
            EnableEvents(eventSource, EventLevel.Verbose);
        }
    }

    /// <inheritdoc />
    protected sealed override void OnEventWritten(EventWrittenEventArgs eventData)
    {
        // Workaround https://github.com/dotnet/corefx/issues/42600
        if (eventData.EventId == -1)
        {
            return;
        }

        // There is a very tight race during the AzureEventSourceListener creation where EnableEvents was called
        // and the thread producing events not observing the `_log` field assignment
        _log?.Invoke(eventData, EventSourceEventFormatting.Format(eventData));
    }
}
