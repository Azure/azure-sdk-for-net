// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Threading;
using Azure.Core.Diagnostics;

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// An <see cref="EventListener"/> that forwards the events of Azure SDK event sources, but only enables each
    /// event source at the level that is requested for it, rather than always at the most verbose level.
    /// Events that would only be discarded are therefore never produced.
    /// </summary>
    internal sealed class LogForwarderEventListener : EventListener
    {
        // Note: These fields that are initialized inline are safe to use from OnEventSourceCreated,
        // which the EventListener base constructor invokes before the constructor of this type runs.
        private readonly object _gate = new object();
        private readonly object _refreshGate = new object();
        private readonly List<Entry> _entries = new List<Entry>();

        private readonly Action<EventWrittenEventArgs> _log;
        private readonly Func<string, EventLevel?> _getLevel;

        private int _refreshQueued;
        private volatile bool _started;
        private volatile bool _disposed;

        /// <param name="log">The delegate to invoke for each event that is written.</param>
        /// <param name="getLevel">A delegate that returns the level that an event source (by name) needs to be enabled at,
        /// or <see langword="null"/> if it does not need to be enabled.</param>
        public LogForwarderEventListener(Action<EventWrittenEventArgs> log, Func<string, EventLevel?> getLevel)
        {
            _log = log ?? throw new ArgumentNullException(nameof(log));
            _getLevel = getLevel ?? throw new ArgumentNullException(nameof(getLevel));

            _started = true;

            // The event sources that already existed were found by the base constructor, but not yet enabled.
            // This is not running under the EventListener lock, so it is safe to call into the logging providers.
            Refresh();
        }

        /// <summary>
        /// Requests that the level that each event source is enabled at is re-evaluated, for example
        /// because the logging configuration changed. The work is completed asynchronously.
        /// </summary>
        public void RequestRefresh() => QueueRefresh();

        /// <inheritdoc />
        public override void Dispose()
        {
            _disposed = true;
            base.Dispose();
        }

        /// <inheritdoc />
        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            base.OnEventSourceCreated(eventSource);

            if (eventSource.GetTrait(AzureEventSourceListener.TraitName) != AzureEventSourceListener.TraitValue)
            {
                return;
            }

            // This method is called while holding a global EventListener lock, so it must not call into the
            // logging providers (which can take their own locks and may create event sources of their own).
            //
            // If the listener is still being created the event source is enabled once that has completed.
            // Otherwise, enable it at the most verbose level for now, which is the level that would otherwise
            // always apply, and then narrow it down to the level that is needed once the lock has been released.
            var enabled = _started;

            if (enabled)
            {
                EnableEvents(eventSource, EventLevel.Verbose);
            }

            lock (_gate)
            {
                _entries.Add(new Entry(eventSource, enabled));
            }

            // Re-check in case the listener finished being created while the entry was being added
            if (_started)
            {
                QueueRefresh();
            }
        }

        /// <inheritdoc />
        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            // Workaround https://github.com/dotnet/corefx/issues/42600
            if (eventData.EventId == -1)
            {
                return;
            }

            // There is a very tight race during the creation of the listener where EnableEvents was called
            // and the thread producing events not observing the assignment of the field.
            _log?.Invoke(eventData);
        }

        private void QueueRefresh()
        {
            if (Interlocked.CompareExchange(ref _refreshQueued, 1, 0) == 0)
            {
                ThreadPool.UnsafeQueueUserWorkItem(static state => ((LogForwarderEventListener)state).Refresh(), this);
            }
        }

        private void Refresh()
        {
            lock (_refreshGate)
            {
                // Allow another refresh to be queued before the event sources are enumerated,
                // so that an event source created while this is running is never missed.
                Volatile.Write(ref _refreshQueued, 0);

                var entries = new List<(Entry Entry, EventSource EventSource)>();

                lock (_gate)
                {
                    _entries.RemoveAll((entry) =>
                    {
                        if (entry.EventSource.TryGetTarget(out var eventSource))
                        {
                            entries.Add((entry, eventSource));
                            return false;
                        }

                        return true;
                    });
                }

                foreach (var (entry, eventSource) in entries)
                {
                    Apply(entry, eventSource);
                }
            }
        }

        private void Apply(Entry entry, EventSource eventSource)
        {
            if (_disposed)
            {
                return;
            }

            try
            {
                var level = _getLevel(eventSource.Name);

                if (level is not EventLevel required)
                {
                    if (entry.Enabled)
                    {
                        DisableEvents(eventSource);
                        entry.Enabled = false;
                    }

                    return;
                }

                if (entry.Enabled && required < entry.Level)
                {
                    // An EventSource only ever increases the level that it considers itself to be enabled at
                    // (which is what is used to determine if an event is worth creating) when an event listener
                    // changes the level, and only recalculates it when events are disabled. To make the event
                    // source realize that it needs to produce fewer events, it has to be disabled first.
                    // This means events at the new level written on another thread in-between could be missed.
                    DisableEvents(eventSource);
                    entry.Enabled = false;
                }

                if (!entry.Enabled || required != entry.Level)
                {
                    EnableEvents(eventSource, required);
                    entry.Enabled = true;
                    entry.Level = required;
                }
            }
            catch (ObjectDisposedException)
            {
                // The listener was disposed of concurrently.
            }
            catch (Exception)
            {
                // Determining the level failed. Leave the event source as it is, which at worst
                // means that more events than are needed are produced, as would be the case without this logic.
                // This may be running on a thread pool thread, so it must not throw.
            }
        }

        private sealed class Entry
        {
            public Entry(EventSource eventSource, bool enabled)
            {
                EventSource = new WeakReference<EventSource>(eventSource);
                Enabled = enabled;
                Level = EventLevel.Verbose;
            }

            public WeakReference<EventSource> EventSource { get; }

            // Whether the event source is currently enabled, and at which level. Only accessed
            // from Refresh(), or before the entry is made visible to it, so does not need to be synchronized.
            public bool Enabled { get; set; }

            public EventLevel Level { get; set; }
        }
    }
}
