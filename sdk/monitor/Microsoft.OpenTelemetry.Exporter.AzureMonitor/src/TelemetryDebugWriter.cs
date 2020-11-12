// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if DEBUG

using System.Diagnostics;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor
{
    internal class TelemetryDebugWriter
    {
        internal static void WriteTelemetry(string message)
        {
            if (message == null)
            {
                return;
            }

            if (Debugger.IsAttached && Debugger.IsLogging())
            {
                Debugger.Log(0, null,  message);
            }
        }
    }
}

#endif
