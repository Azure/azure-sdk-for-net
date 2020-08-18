// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Globalization;
using OpenTelemetry.Exporter.AzureMonitor.Models;
using OpenTelemetry.Trace;

namespace OpenTelemetry.Exporter.AzureMonitor
{
    internal static class ActivityExtensions
    {
        private static readonly string INVALID_SPAN_ID = default(ActivitySpanId).ToHexString();
        private static readonly string INVALID_TRACE_ID = default(ActivityTraceId).ToHexString();

        internal static string GetSpanId(this ActivitySpanId activitySpanId)
        {
            var spanId = activitySpanId.ToHexString();
            if (!string.Equals(spanId, INVALID_SPAN_ID, StringComparison.Ordinal))
            {
                return spanId;
            }

            return null;
        }

        internal static string GetTraceId(this ActivityTraceId activityTraceId)
        {
            var traceId = activityTraceId.ToHexString();
            if (!string.Equals(traceId, INVALID_TRACE_ID, StringComparison.Ordinal))
            {
                return traceId;
            }

            return null;
        }

        internal static TelemetryType GetTelemetryType(this Activity activity)
        {
            if (activity.Kind == ActivityKind.Server || activity.Kind == ActivityKind.Consumer)
            {
                return TelemetryType.Request;
            }
            else
            {
                // TODO: If there a need, extend for other telemetry types.
                return TelemetryType.Dependency;
            }
        }

        // TODO: Change the return type to integer once .NET support it.
        internal static string GetStatusCode(this Activity activity)
        {
            var status = activity.GetStatus().CanonicalCode switch
            {
                StatusCanonicalCode.Cancelled => 400,
                StatusCanonicalCode.Unknown => 0,
                StatusCanonicalCode.InvalidArgument => 400,
                StatusCanonicalCode.DeadlineExceeded => 504,
                StatusCanonicalCode.NotFound => 404,
                StatusCanonicalCode.AlreadyExists => 409,
                StatusCanonicalCode.PermissionDenied => 403,
                StatusCanonicalCode.ResourceExhausted => 409,
                StatusCanonicalCode.FailedPrecondition => 412,
                StatusCanonicalCode.Aborted => 0,
                StatusCanonicalCode.OutOfRange => 400,
                StatusCanonicalCode.Unimplemented => 501,
                StatusCanonicalCode.Internal => 500,
                StatusCanonicalCode.Unavailable => 503,
                StatusCanonicalCode.DataLoss => 0,
                StatusCanonicalCode.Unauthenticated => 401,
                StatusCanonicalCode.Ok => 200,
                _ => 0
            };

            return status.ToString(CultureInfo.InvariantCulture);
        }
    }
}
