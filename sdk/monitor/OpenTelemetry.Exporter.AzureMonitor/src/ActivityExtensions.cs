// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using OpenTelemetry.Trace;

namespace OpenTelemetry.Exporter.AzureMonitor
{
    internal static class ActivityExtensions
    {
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

        internal static TelemetryType GetTelemetryType(this Activity activity)
        {
            var kind = activity.Kind switch
            {
                ActivityKind.Server => TelemetryType.Request,
                ActivityKind.Client => TelemetryType.Dependency,
                ActivityKind.Producer => TelemetryType.Dependency,
                ActivityKind.Consumer => TelemetryType.Request,
                _ => TelemetryType.Dependency
            };

            return kind;
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
