// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal class TelemetryDebugWriter : IDebugWritter
    {
        public static IDebugWritter Writer = new TelemetryDebugWriter();

        public void WriteMessage(string message)
        {
            if (message == null)
            {
                return;
            }

            if (Debugger.IsAttached && Debugger.IsLogging())
            {
                Debugger.Log(0, null, message);
            }
        }

        public void WriteTelemetry(NDJsonWriter content)
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

    internal interface IDebugWritter
    {
        void WriteMessage(string message);

        void WriteTelemetry(NDJsonWriter content);
    }
}
