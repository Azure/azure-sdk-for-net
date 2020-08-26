// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using OpenTelemetry.Trace;

namespace OpenTelemetry.Exporter.AzureMonitor
{
    internal static class ActivityExtensions
    {
        private static readonly string INVALID_SPAN_ID = default(ActivitySpanId).ToHexString();
        private static readonly string INVALID_TRACE_ID = default(ActivityTraceId).ToHexString();

        private const string StatusCode_0 = "0";
        private const string StatusCode_200 = "200";
        private const string StatusCode_400 = "400";
        private const string StatusCode_401 = "401";
        private const string StatusCode_403 = "403";
        private const string StatusCode_404 = "404";
        private const string StatusCode_409 = "409";
        private const string StatusCode_412 = "412";
        private const string StatusCode_500 = "500";
        private const string StatusCode_501 = "501";
        private const string StatusCode_503 = "503";
        private const string StatusCode_504 = "504";

        internal static string GetSpanId(this Activity activity)
        {
            var spanId = activity.SpanId.ToHexString();
            if (!string.Equals(spanId, INVALID_SPAN_ID, StringComparison.Ordinal))
            {
                return spanId;
            }

            return string.Empty;
        }

        internal static string GetTraceId(this Activity activity)
        {
            var traceId = activity.TraceId.ToHexString();
            if (!string.Equals(traceId, INVALID_TRACE_ID, StringComparison.Ordinal))
            {
                return traceId;
            }

            return string.Empty;
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
                StatusCanonicalCode.Cancelled => StatusCode_400,
                StatusCanonicalCode.InvalidArgument => StatusCode_400,
                StatusCanonicalCode.DeadlineExceeded => StatusCode_504,
                StatusCanonicalCode.NotFound => StatusCode_404,
                StatusCanonicalCode.AlreadyExists => StatusCode_409,
                StatusCanonicalCode.PermissionDenied => StatusCode_403,
                StatusCanonicalCode.ResourceExhausted => StatusCode_409,
                StatusCanonicalCode.FailedPrecondition => StatusCode_412,
                StatusCanonicalCode.OutOfRange => StatusCode_400,
                StatusCanonicalCode.Unimplemented => StatusCode_501,
                StatusCanonicalCode.Internal => StatusCode_500,
                StatusCanonicalCode.Unavailable => StatusCode_503,
                StatusCanonicalCode.Unauthenticated => StatusCode_401,
                StatusCanonicalCode.Ok => StatusCode_200,
                _ => StatusCode_0
            };

            return status;
        }
    }
}
