// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.Tracing;
using OpenTelemetry;
using OpenTelemetry.Resources;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Internals.Profiling
{
    /// <summary>
    /// An OpenTelemetry trace processor that tags activities with a session ID
    /// if a profiling session is active. This enables correlation between
    /// traces and profiler artifacts.
    /// </summary>
    internal sealed class ProfilingSessionTraceProcessor : BaseProcessor<Activity>
    {
        /// <summary>
        /// Name of the Tag (and subsequent OpenTelemetry attribute) that
        /// records the profiling session ID.
        /// </summary>
        /// <remarks>
        /// Experimental until formalization of OTEP profiles data format.
        /// See <see href="https://github.com/open-telemetry/oteps/pull/239" />.
        /// </remarks>
        internal const string TagName = "profile_id_experimental";

        private readonly ProfilingSessionEventSource _eventSource = ProfilingSessionEventSource.Current;

        /// <summary>
        /// Indicates if we should write resource attributes, when available.
        /// </summary>
        private bool _writeResourceAttributesPending;

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ProfilingSessionTraceProcessor()
        {
            _eventSource.SessionIdChanged += OnSessionIdChanged;
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            _eventSource.SessionIdChanged -= OnSessionIdChanged;

            if (_writeResourceAttributesPending)
            {
                TryWriteResourceAttributes();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Callback from the <see cref="ProfilingSessionEventSource"/> when a profiling
        /// session starts or stops.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="sessionId">The new session ID. Null if the session has stopped.</param>
        private void OnSessionIdChanged(object? sender, string? sessionId)
        {
            // We don't write the resource attributes here because this may be
            // called early in startup, before the ParentProvider has been
            // initialized. Instead, we defer writing the resource until the
            // first activity. If there are no activities, we'll also try to
            // write the resource attributes in Dispose.
            _writeResourceAttributesPending = sessionId != null &&
                _eventSource.IsEnabled(EventLevel.Informational, ProfilingSessionEventSource.Keywords.ResourceAttributes);
        }

        /// <inheritdoc/>
        public override void OnStart(Activity activity)
        {
            if (_writeResourceAttributesPending && TryWriteResourceAttributes())
            {
                _writeResourceAttributesPending = false;
            }
        }

        /// <inheritdoc/>
        public override void OnEnd(Activity activity)
        {
            string? sessionId = _eventSource.SessionId;
            if (!string.IsNullOrEmpty(sessionId))
            {
                activity.SetTag(TagName, sessionId);
            }
        }

        /// <summary>
        /// Try to write the resource attributes to the event source.
        /// </summary>
        /// <returns>True if the resource attributes were written.</returns>
        private bool TryWriteResourceAttributes()
        {
            Resource? resource = ParentProvider?.GetResource();
            if (resource == null)
            {
                return false;
            }

            _eventSource.WriteResourceAttributes(resource);
            return true;
        }
    }
}
