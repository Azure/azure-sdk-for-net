// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Globalization;

namespace System.ClientModel.Diagnostics;

/// <summary>
/// Implementation of <see cref="EventListener"/> that listens to events produced by Azure SDK client libraries.
/// </summary>
public class ClientEventSourceListener : EventListener
{
    /// <summary>
    /// The trait name that has to be present on all event sources collected by this listener.
    /// </summary>
    public const string TraitName = "ClientEventSource";
    /// <summary>
    /// The trait value that has to be present on all event sources collected by this listener.
    /// </summary>
    public const string TraitValue = "true";
    private readonly List<EventSource> _eventSources = new List<EventSource>();

    private readonly Action<EventWrittenEventArgs, string> _log;
    private readonly EventLevel _level;

    /// <summary>
    /// Creates an instance of <see cref="ClientEventSourceListener"/> that executes a <paramref name="log"/> callback every time event is written.
    /// </summary>
    /// <param name="log">The <see cref="System.Action{EventWrittenEventArgs, String}"/> to call when event is written. The second parameter is formatted message.</param>
    /// <param name="level">The level of events to enable.</param>
    public ClientEventSourceListener(Action<EventWrittenEventArgs, string> log, EventLevel level)
    {
        _log = log ?? throw new ArgumentNullException(nameof(log));

        _level = level;

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

        if (_log == null)
        {
            _eventSources.Add(eventSource);
        }

        if (eventSource.GetTrait(TraitName) == TraitValue)
        {
            EnableEvents(eventSource, _level);
        }
    }

    /// <inheritdoc />
    protected sealed override void OnEventWritten(EventWrittenEventArgs eventData)
    {
        // Workaround to https://github.com/dotnet/runtime/issues/31927
        if (eventData.EventId == -1)
        {
            return;
        }

        // There is a very tight race during the AzureEventSourceListener creation where EnableEvents was called
        // and the thread producing events not observing the `_log` field assignment
        _log?.Invoke(eventData, ClientEventSourceEventFormatting.Format(eventData));
    }

    /// <summary>
    /// Creates a new instance of <see cref="ClientEventSourceEventFormatting"/> that forwards events to <see cref="Console.WriteLine(string)"/>.
    /// </summary>
    /// <param name="level">The level of events to enable.</param>
    public static ClientEventSourceListener CreateConsoleLogger(EventLevel level = EventLevel.Informational)
    {
        return new ClientEventSourceListener((eventData, text) => Console.WriteLine("[{1}] {0}: {2}", eventData.EventSource.Name, eventData.Level, text), level);
    }

    /// <summary>
    /// Creates a new instance of <see cref="ClientEventSourceListener"/> that forwards events to <see cref="Trace.WriteLine(object)"/>.
    /// </summary>
    /// <param name="level">The level of events to enable.</param>
    public static ClientEventSourceListener CreateTraceLogger(EventLevel level = EventLevel.Informational)
    {
        return new ClientEventSourceListener(
            (eventData, text) => Trace.WriteLine(string.Format(CultureInfo.InvariantCulture, "[{0}] {1}", eventData.Level, text), eventData.EventSource.Name), level);
    }
}
