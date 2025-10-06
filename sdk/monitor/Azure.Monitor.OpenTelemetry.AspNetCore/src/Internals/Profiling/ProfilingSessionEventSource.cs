// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    /// The following keyword is supported:
    /// <list type="bullet">
    /// <item>ResourceAttributes: Emits OpenTelemetry resource attributes.</item>
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
        /// Keywords for this EventSource.
        /// </summary>
        public static class Keywords
        {
            /// <summary>
            /// Emits the OpenTelemetry Resource attributes. These attributes
            /// are emitted exactly once at Informational level.
            /// </summary>
            public const EventKeywords ResourceAttributes = (EventKeywords)0b_1;
        }

        /// <summary>
        /// Event IDs for this EventSource.
        /// </summary>
        public static class EventIds
        {
            /// <summary>
            /// Open Telemetry Resource attributes.
            /// </summary>
            public const int ResourceAttributes = 1;
        }

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <remarks>
        /// We need the self-describing format because the <see cref="ResourceAttributes(IEnumerable{KeyValuePair{string, string}})"/>
        /// method takes a non-primitive argument.
        /// </remarks>
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
        [NonEvent]
        public void WriteResourceAttributes(Resource resource)
        {
            if (resource is null)
            {
                return;
            }

            if (IsEnabled(EventLevel.Informational, Keywords.ResourceAttributes))
            {
                IEnumerable<KeyValuePair<string, object>> attributes = resource.Attributes;
                ResourceAttributes(attributes.Select(kvp => new KeyValuePair<string, string>(kvp.Key, SafeConvertToString(kvp.Value))));
            }

            // Safely convert an object to a string.
            // The ResourceBuilder won't allow a non-primitive type for an
            // attribute value but, just to be sure, catch any exceptions
            // and return an empty string.
            // Also truncates the value to a reasonable length.
            static string SafeConvertToString(object? value)
            {
                // The limit is somewhat arbitrary. We want to be able to
                // represent any *reasonable* attribute value without blowing
                // up the total event payload.
                const int maxSensibleLength = 200;
                try
                {
                    string converted = Convert.ToString(value, InvariantCulture) ?? string.Empty;
                    return converted.Length <= maxSensibleLength ? converted : converted.Substring(0, maxSensibleLength);
                }
                catch // In case value's ToString implementation throws.
                {
                    return string.Empty;
                }
            }
        }

        [Event(EventIds.ResourceAttributes, Keywords = Keywords.ResourceAttributes, Level = EventLevel.Informational)]
        private void ResourceAttributes(IEnumerable<KeyValuePair<string, string>> attributes)
        {
            WriteEvent(EventIds.ResourceAttributes, attributes);
        }
    }
}
