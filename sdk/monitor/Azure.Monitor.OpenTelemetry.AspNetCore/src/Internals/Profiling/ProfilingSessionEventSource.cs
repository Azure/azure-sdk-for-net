// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#nullable enable

using System.Diagnostics.Tracing;
using OpenTelemetry.Resources;
using static System.Globalization.CultureInfo;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Internals.Profiling
{
    /// <summary>
    /// An EventSource to be used by profilers when profiling is active.
    /// Communication from the profiler is via command arguments included when
    /// enabling the EventSource via an EventListener, an ETW provider or via
    /// EventPipe. Profilers should use the command to notify applications of
    /// a profiling session ID. The session ID will be included as an
    /// attribute on any application telemetry generated while profiling is
    /// active. This session ID may be later used to correlate telemetry with
    /// the resulting profiler artifact.
    /// The GUID of this event source is 15ec0b5c-cb74-5fec-5d64-609c0a49ff31
    /// The following keywords are supported:
    /// <list type="bullet">
    /// <item>ResourceAttributes: Emits OpenTelemetry resource attributes.</item>
    /// <item>Activities: Emits start/stop events for activities.</item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// PerfView instructions:
    /// <code>PerfView.exe collect -MaxCollectSec:300 -NoGui /Providers:"*Azure-Monitor-ProfilingSession:::SessionId=SESSIONID"</code>
    /// Dotnet-Trace instructions:
    /// <code>dotnet-trace collect -p PID --providers Azure-Monitor-ProfilingSession:::SessionId=SESSIONID</code>
    /// </remarks>
    [EventSource(Name = EventSourceName)]
    internal class ProfilingSessionEventSource : EventSource
    {
        /// <summary>
        /// The current session ID. May be null if there is no active session.
        /// </summary>
        private string? _sessionId;

        /// <summary>
        /// Event handler to call when the session ID changes.
        /// </summary>
        private EventHandler<string?>? _sessionIdChanged;

        /// <summary>
        /// Name of the EventSource.
        /// </summary>
        public const string EventSourceName = "Azure-Monitor-ProfilingSession";

        /// <summary>
        /// Gets the singleton instance of this <see cref="EventSource"/>.
        /// </summary>
        public static ProfilingSessionEventSource Current { get; } = new();

        /// <summary>
        /// Keywords
        /// </summary>
        public static class Keywords
        {
            /// <summary>
            /// Emits the OpenTelemetry Resource attributes. These attributes
            /// are emitted exactly once at Informational level.
            /// </summary>
            public const EventKeywords ResourceAttributes = (EventKeywords)0b_1;

            /// <summary>
            /// Emits start/stop events for activities.
            /// </summary>
            public const EventKeywords Activities = (EventKeywords)0b_10;
        }

        public static class EventIds
        {
            /// <summary>
            /// Open Telemetry Resource attributes.
            /// </summary>
            public const int ResourceAttributes = 1;

            /// <summary>
            /// An Activity is starting.
            /// </summary>
            public const int ActivityStart = 2;

            /// <summary>
            /// An Activity is stopping.
            /// </summary>
            public const int ActivityStop = 3;
        }

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        private ProfilingSessionEventSource() : base(EventSourceSettings.EtwSelfDescribingEventFormat)
        {
        }

        /// <summary>
        /// Called when the listener (or ETW provider) is enabled, disabled
        /// or updated with a filter command.
        /// </summary>
        /// <param name="command">The command.</param>
        protected override void OnEventCommand(EventCommandEventArgs command)
        {
            switch (command.Command)
            {
                case EventCommand.Disable:
                    SessionId = null;
                    return;

                case EventCommand.Enable:
                case EventCommand.Update:
                    break;

                default:
                    return;
            }

            IDictionary<string, string?>? arguments = command.Arguments;
            if (arguments is null)
            {
                return;
            }

            if (!arguments.TryGetValue("SessionId", out string? sessionId))
            {
                return;
            }

            SessionId = sessionId;
        }

        /// <summary>
        /// Gets or sets the active profiling session ID.
        /// The value will be null if there is no active session.
        /// </summary>
        public string? SessionId
        {
            [NonEvent]
            get => _sessionId;

            [NonEvent]
            private set
            {
                if (_sessionId != value)
                {
                    _sessionId = value;
                    _sessionIdChanged?.Invoke(this, value);
                }
            }
        }

        /// <summary>
        /// Occurs when the session ID has changed, meaning either a session has started or stopped.
        /// </summary>
        /// <remarks>
        /// If you subscribe to this event when a session has already started, then your handler
        /// will be called immediately.
        /// </remarks>
        public event EventHandler<string?> SessionIdChanged
        {
            [NonEvent]
            add
            {
                _sessionIdChanged += value;

                // New subscribers are notified of an active session right away.
                if (SessionId != null)
                {
                    value.Invoke(this, SessionId);
                }
            }

            [NonEvent]
            remove
            {
                _sessionIdChanged -= value;
            }
        }

        /// <summary>
        /// Write the attributes of a <see cref="Resource"/>.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <exception cref="ArgumentNullException"><paramref name="resource"/> is null.</exception>
        [NonEvent]
        public void WriteResourceAttributes(Resource resource)
        {
            if (resource is null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            if (IsEnabled(EventLevel.Informational, Keywords.ResourceAttributes))
            {
                IEnumerable<KeyValuePair<string, object>> attributes = resource.Attributes;
                WriteResourceAttributes(attributes.Select(kvp => new KeyValuePair<string, string>(kvp.Key, Convert.ToString(kvp.Value, InvariantCulture))));
            }
        }

        [Event(EventIds.ResourceAttributes, Keywords = Keywords.ResourceAttributes, Level = EventLevel.Informational)]
        private void WriteResourceAttributes(IEnumerable<KeyValuePair<string, string>> attributes)
        {
            WriteEvent(EventIds.ResourceAttributes, attributes);
        }

        /// <summary>
        /// Write an activity start event.
        /// </summary>
        /// <param name="activity">The activity.</param>
        /// <exception cref="ArgumentNullException"><paramref name="activity"/> is null.</exception>
        [NonEvent]
        public void ActivityStart(Activity activity)
        {
            if (activity is null)
            {
                throw new ArgumentNullException(nameof(activity));
            }

            if (IsEnabled(EventLevel.Informational, Keywords.Activities))
            {
                ActivityStart(activity.Source.Name, activity.SpanId.ToHexString(), activity.DisplayName);
            }
        }

        [Event(EventIds.ActivityStart, Keywords = Keywords.Activities, Level = EventLevel.Informational, Opcode = EventOpcode.Start)]
        private void ActivityStart(string source, string spanId, string displayName)
        {
            WriteEvent(EventIds.ActivityStart, source, spanId, displayName);
        }

        /// <summary>
        /// Write an activity stop event.
        /// </summary>
        /// <param name="activity">The activity.</param>
        /// <exception cref="ArgumentNullException"><paramref name="activity"/> is null.</exception>
        [NonEvent]
        public void ActivityStop(Activity activity)
        {
            if (activity is null)
            {
                throw new ArgumentNullException(nameof(activity));
            }

            if (IsEnabled(EventLevel.Informational, Keywords.Activities))
            {
                ActivityStop(activity.Source.Name, activity.SpanId.ToHexString(), activity.DisplayName);
            }
        }

        [Event(EventIds.ActivityStop, Keywords = Keywords.Activities, Level = EventLevel.Informational, Opcode = EventOpcode.Stop)]
        private void ActivityStop(string source, string spanId, string displayName)
        {
            WriteEvent(EventIds.ActivityStop, source, spanId, displayName);
        }
    }
}
