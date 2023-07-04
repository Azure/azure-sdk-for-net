// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Text;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics
{
    internal static class TelemetryDebugWriter
    {
        public static void WriteMessage(string message)
        {
            if (message == null)
            {
                return;
            }

            if (Debugger.IsAttached && Debugger.IsLogging())
            {
                Debugger.Log(0, null, message + "\n");
            }
        }

        public static void WriteTelemetry(NDJsonWriter content)
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

        public static void WriteTelemetryFromStorage(ReadOnlyMemory<byte> content)
        {
            if (Debugger.IsAttached && Debugger.IsLogging())
            {
                Debugger.Log(0, null, "(TRANSMITTING TELEMETRY FROM STORAGE)\n" + Encoding.UTF8.GetString(content.ToArray()));
            }
        }
    }
}
