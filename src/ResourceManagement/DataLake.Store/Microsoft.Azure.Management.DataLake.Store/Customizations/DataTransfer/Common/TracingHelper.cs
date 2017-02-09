// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest;
using System;

namespace Microsoft.Azure.Management.DataLake.Store
{
    internal static class TracingHelper
    {
        private static bool shouldTrace { get; set; }
        private static string invocationId { get; set; }
        static TracingHelper()
        {
            shouldTrace = ServiceClientTracing.IsEnabled;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
            }
        }

        internal static void LogInfo(string message, params object[] parameters)
        {
            if (shouldTrace)
            {
                ServiceClientTracing.Information(message, parameters);
            }
        }

        internal static void LogError(Exception ex)
        {
            if (shouldTrace)
            {
                ServiceClientTracing.Error(invocationId, ex);
            }
        }
    }
}
