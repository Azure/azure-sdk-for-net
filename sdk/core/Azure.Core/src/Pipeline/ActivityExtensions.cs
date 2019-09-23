// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Reflection;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// HACK HACK HACK. Some runtime environments like Azure.Functions downgrade System.Diagnostic.DiagnosticSource package version causing method not found exceptions in customer apps
    /// This type is a temporary workaround to avoid the issue
    /// </summary>
    internal static class ActivityExtensions
    {
        private static readonly MethodInfo? s_setIdFormatMethod = typeof(Activity).GetMethod("SetIdFormat");
        private static readonly MethodInfo? s_getIdFormatMethod = typeof(Activity).GetProperty("IdFormat")?.GetMethod;
        private static readonly MethodInfo? s_getTraceStateStringMethod = typeof(Activity).GetProperty("TraceStateString")?.GetMethod;

        public static bool SetW3CFormat(this Activity activity)
        {
            if (s_setIdFormatMethod == null)
                return false;

            s_setIdFormatMethod.Invoke(activity, new object[] { 2 /* ActivityIdFormat.W3C */});

            return true;
        }

        public static bool IsW3CFormat(this Activity activity)
        {
            if (s_getIdFormatMethod == null)
                return false;

            object result = s_getIdFormatMethod.Invoke(activity, Array.Empty<object>());

            return (int)result == 2 /* ActivityIdFormat.W3C */;
        }

        public static bool TryGetTraceState(this Activity activity, out string? traceState)
        {
            traceState = null;

            if (s_getTraceStateStringMethod == null)
                return false;

            traceState = s_getTraceStateStringMethod.Invoke(activity, Array.Empty<object>()) as string;

            return true;
        }
    }
}
