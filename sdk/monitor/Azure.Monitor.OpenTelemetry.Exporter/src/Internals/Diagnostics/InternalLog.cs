// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.Tracing;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics
{
    internal static class InternalLog
    {
        /// <summary>
        /// This is an example of how I expect this class to be used.
        /// Currently, classes call AzureMonitorExporterEventSource.Log directly.
        /// My plan is to migrate all logs to this class instead.
        /// This gives us a central place to manage logs and gets us future ready for
        /// Complie-time logging source generation.
        /// </summary>
        private static void ExampleWarning(string someString, int someInt)
        {
            if (AzureMonitorExporterEventSource.Log.IsEnabled(EventLevel.Warning))
            {
                AzureMonitorExporterEventSource.Log.WriteWarning("ExampleWarning", $"This is an example {someString} {someInt}");
            }
        }
    }
}
