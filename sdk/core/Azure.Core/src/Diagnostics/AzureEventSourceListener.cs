// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Globalization;
using Azure.Core.Shared;

namespace Azure.Core.Diagnostics
{
    /// <summary>
    /// Implementation of <see cref="EventListener"/> that listens to events produced by Azure SDK client libraries.
    /// </summary>
    public class AzureEventSourceListener: EventListener
    {
        /// <summary>
        /// The trait name that has to be present on all event sources collected by this listener.
        /// </summary>
        public const string TraitName = "AzureEventSource";
        /// <summary>
        /// The trait value that has to be present on all event sources collected by this listener.
        /// </summary>
        public const string TraitValue = "true";
        private readonly List<EventSource> _eventSources = new List<EventSource>();

        private readonly Action<EventWrittenEventArgs> _log;
        private readonly EventLevel _level;

        /// <summary>
        /// Creates an instance of <see cref="AzureEventSourceListener"/> that executes a <paramref name="log"/> callback every time event is written.
        /// </summary>
        /// <param name="log">The <see cref="System.Action{EventWrittenEventArgs}"/> to call when event is written.</param>
        /// <param name="level">The level of events to enable.</param>
        public AzureEventSourceListener(Action<EventWrittenEventArgs> log, EventLevel level)
        {
            _log = log ?? throw new ArgumentNullException(nameof(log));

            _level = level;

            foreach (EventSource eventSource in _eventSources)
            {
                OnEventSourceCreated(eventSource);
            }

            _eventSources.Clear();
        }

        /// <summary>
        /// Creates an instance of <see cref="AzureEventSourceListener"/> that executes a <paramref name="log"/> callback every time event is written.
        /// </summary>
        /// <param name="log">The <see cref="System.Action{EventWrittenEventArgs, String}"/> to call when event is written. The second parameter is the formatted message.</param>
        /// <param name="level">The level of events to enable.</param>
        public AzureEventSourceListener(Action<EventWrittenEventArgs, string> log, EventLevel level) : this(e => log(e, EventSourceEventFormatting.Format(e)), level)
        {
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
            // Workaround https://github.com/dotnet/corefx/issues/42600
            if (eventData.EventId == -1)
            {
                return;
            }

            // There is a very tight race during the AzureEventSourceListener creation where EnableEvents was called
            // and the thread producing events not observing the `_log` field assignment
            _log?.Invoke(eventData);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AzureEventSourceListener"/> that forwards events to <see cref="Console.WriteLine(string)"/>.
        /// </summary>
        /// <param name="level">The level of events to enable.</param>
        public static AzureEventSourceListener CreateConsoleLogger(EventLevel level = EventLevel.Informational)
        {
            return new AzureEventSourceListener((eventData, text) => Console.WriteLine("[{1}] {0}: {2}", eventData.EventSource.Name, eventData.Level, text), level);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AzureEventSourceListener"/> that forwards events to <see cref="Trace.WriteLine(object)"/>.
        /// </summary>
        /// <param name="level">The level of events to enable.</param>
        public static AzureEventSourceListener CreateTraceLogger(EventLevel level = EventLevel.Informational)
        {
            return new AzureEventSourceListener(
                (eventData, text) => Trace.WriteLine(string.Format(CultureInfo.InvariantCulture, "[{0}] {1}", eventData.Level, text), eventData.EventSource.Name), level);
        }
    }
}
