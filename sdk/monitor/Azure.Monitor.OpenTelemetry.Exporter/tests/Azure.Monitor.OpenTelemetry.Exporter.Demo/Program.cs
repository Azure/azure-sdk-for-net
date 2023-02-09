// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Identity;
using Azure.Monitor.OpenTelemetry.Exporter.Demo.Logs;
using Azure.Monitor.OpenTelemetry.Exporter.Demo.Metrics;
using Azure.Monitor.OpenTelemetry.Exporter.Demo.Traces;

namespace Azure.Monitor.OpenTelemetry.Exporter.Demo
{
    public class Program
    {
        private const string ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";

        public static void Main()
        {
            var credential = new DefaultAzureCredential();
            using var traceDemo = new TraceDemo(ConnectionString, credential);
            traceDemo.GenerateTraces();

            using var metricDemo = new MetricDemo(ConnectionString, credential);
            metricDemo.GenerateMetrics();

            using var logDemo = new LogDemo(ConnectionString, credential);
            logDemo.GenerateLogs();

            Console.WriteLine("Press Enter key to exit.");
            Console.ReadLine();
        }
    }
}
