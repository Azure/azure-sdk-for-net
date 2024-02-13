// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#nullable enable

using System.Diagnostics.Tracing;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Internals.Profiling
{
    /// <summary>
    /// An EventSource that can be enabled by profilers when profiling is
    /// active. It's an unusual EventSource because it doesn't emit any events.
    /// Communication from the profiler is via command arguments included when
    /// enabling the EventSource via an EventListener, an ETW provider or via
    /// EventPipe. Profilers should use the command to notify applications of
    /// a profiling session ID. The session ID will be included as an
    /// attribute on any application telemetry generated while profiling is
    /// active. This session ID may be later used to correlate telemetry with
    /// the resulting profiler artifact.
    /// The GUID of this event source is 15ec0b5c-cb74-5fec-5d64-609c0a49ff31
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
        /// Name of the EventSource.
        /// </summary>
        public const string EventSourceName = "Azure-Monitor-ProfilingSession";

        /// <summary>
        /// Gets the singleton instance of this <see cref="EventSource"/>.
        /// </summary>
        public static ProfilingSessionEventSource Current { get; } = new();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        private ProfilingSessionEventSource() : base(EventSourceName, EventSourceSettings.Default)
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
        public string? SessionId { get; private set; }
    }
}
