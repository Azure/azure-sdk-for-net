// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#nullable enable

using OpenTelemetry;

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

        /// <inheritdoc/>
        public override void OnEnd(Activity activity)
        {
            string? sessionId = ProfilingSessionEventSource.Current.SessionId;
            if (!string.IsNullOrEmpty(sessionId))
            {
                activity.SetTag(TagName, sessionId);
            }
        }
    }
}
