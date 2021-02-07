// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor
{
    internal class TelemetryDebugWriter
    {
        internal static void WriteMessage(string message)
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

        internal static void WriteTelemetry(NDJsonWriter content)
        {
            if (content == null)
            {
                return;
            }

            if (Debugger.IsAttached && Debugger.IsLogging())
            {
                Debugger.Log(0, null, content.ToString());
            }
        }
    }
}
