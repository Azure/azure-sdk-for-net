// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.IO;
using System.Threading;
using Azure.Identity;
using Azure.Monitor.OpenTelemetry.Exporter.Demo.Logs;
using Azure.Monitor.OpenTelemetry.Exporter.Demo.Metrics;
using Azure.Monitor.OpenTelemetry.Exporter.Demo.Traces;

namespace Azure.Monitor.OpenTelemetry.Exporter.Demo
{
    public class Program
    {
        private const string ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";

        /// <summary>
        /// The exporter's own connection string for the multi-endpoint demo. Point this at a component
        /// that nothing is routed to: telemetry arriving there means routing fell back to the
        /// exporter's own configuration instead of failing closed.
        /// </summary>
        private const string HostConnectionStringVariable = "MULTIENDPOINT_HOST_CONNECTION_STRING";

        /// <summary>
        /// Comma-separated Application Insights connection strings, one per destination. Use components in
        /// different regions, otherwise they share an ingestion endpoint and collapse into one group.
        /// </summary>
        private const string RouteConnectionStringsVariable = "MULTIENDPOINT_ROUTE_CONNECTION_STRINGS";

        public static void Main(string[] args)
        {
            if (args.Length > 0 && string.Equals(args[0], "multiendpoint", StringComparison.OrdinalIgnoreCase))
            {
                var faultEndpoints = Array.Exists(args, a => string.Equals(a, "down", StringComparison.OrdinalIgnoreCase));
                var logs = Array.Exists(args, a => string.Equals(a, "logs", StringComparison.OrdinalIgnoreCase));
                var count = 1000;

                foreach (var arg in args)
                {
                    if (int.TryParse(arg, out var parsed))
                    {
                        count = parsed;
                        break;
                    }
                }

                if (logs)
                {
                    RunMultiEndpointLogDemo(count, faultEndpoints);
                }
                else
                {
                    RunMultiEndpointDemo(count, faultEndpoints);
                }

                return;
            }

            // To use AAD, setup your desired credential and provide to the demo class.
            // var credential = new DefaultAzureCredential();
            // using var traceDemo = new TraceDemo(ConnectionString, credential);

            using var traceDemo = new TraceDemo(ConnectionString);
            traceDemo.GenerateTraces();

            using var metricDemo = new MetricDemo(ConnectionString);
            metricDemo.GenerateMetrics();

            using var logDemo = new LogDemo(ConnectionString);
            logDemo.GenerateLogs();

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        private static void RunMultiEndpointDemo(int activityCount, bool faultEndpoints)
        {
            var hostConnectionString = Environment.GetEnvironmentVariable(HostConnectionStringVariable);
            var routes = ParseRoutes(Environment.GetEnvironmentVariable(RouteConnectionStringsVariable));

            if (string.IsNullOrWhiteSpace(hostConnectionString) || routes.Count == 0)
            {
                Console.WriteLine($"Set {HostConnectionStringVariable} to the exporter's own connection string,");
                Console.WriteLine($"and {RouteConnectionStringsVariable} to a comma-separated list of one connection");
                Console.WriteLine("string per destination, using components in different regions.");
                return;
            }

            // Before any exporter type is touched: the gate is read once into a static.
            MultiEndpointTraceDemo.EnableMultiEndpointRouting();

            using var listener = new ExporterEventListener();

            var runId = Guid.NewGuid().ToString("N");

            var distinctEndpoints = new HashSet<string>(routes.ConvertAll(r => r.IngestionEndpoint), StringComparer.Ordinal).Count;

            Console.WriteLine($"Run id     : {runId}");
            Console.WriteLine($"Activities : {activityCount} requests, each with one dependency");
            Console.WriteLine($"Routes     : {string.Join(", ", routes.ConvertAll(r => r.Name))}");
            Console.WriteLine($"Groups     : {distinctEndpoints} distinct endpoint(s), so expect {distinctEndpoints} routed POST(s) per export");
            Console.WriteLine($"Endpoints  : {(faultEndpoints ? "FAULTED (503 injected)" : "live")}");
            Console.WriteLine();

            ReportStoredBlobs("stored before");

            var stopwatch = Stopwatch.StartNew();

            using (var demo = new MultiEndpointTraceDemo(hostConnectionString, routes, runId, faultEndpoints))
            {
                demo.GenerateTraces(activityCount);

                Console.WriteLine("Generated, flushing...");

                foreach (var pair in demo.GeneratedPerRoute)
                {
                    Console.WriteLine($"  {pair.Key,-12} {pair.Value}");
                }

                Console.WriteLine("Unroutable, expected to be dropped and reported:");

                foreach (var pair in demo.UnroutablePerReason)
                {
                    Console.WriteLine($"  {pair.Key,-28} {pair.Value}");
                }

                if (!faultEndpoints)
                {
                    // Give the storage drain a chance to run before the provider is torn down.
                    Thread.Sleep(TimeSpan.FromSeconds(15));
                }
            }

            stopwatch.Stop();

            ReportStoredBlobs("stored after");

            Console.WriteLine();
            Console.WriteLine($"Done in {stopwatch.Elapsed.TotalSeconds:F1}s. Query each component for demo.run_id == '{runId}'.");
        }

        private static void RunMultiEndpointLogDemo(int logCount, bool faultEndpoints)
        {
            var hostConnectionString = Environment.GetEnvironmentVariable(HostConnectionStringVariable);
            var routes = ParseRoutes(Environment.GetEnvironmentVariable(RouteConnectionStringsVariable));

            if (string.IsNullOrWhiteSpace(hostConnectionString) || routes.Count == 0)
            {
                Console.WriteLine($"Set {HostConnectionStringVariable} to the exporter's own connection string,");
                Console.WriteLine($"and {RouteConnectionStringsVariable} to a comma-separated list of one connection");
                Console.WriteLine("string per destination, using components in different regions.");
                return;
            }

            // Before any exporter type is touched: the gate is read once into a static.
            MultiEndpointTraceDemo.EnableMultiEndpointRouting();

            using var listener = new ExporterEventListener();

            var runId = Guid.NewGuid().ToString("N");

            var distinctEndpoints = new HashSet<string>(routes.ConvertAll(r => r.IngestionEndpoint), StringComparer.Ordinal).Count;

            Console.WriteLine($"Run id     : {runId}");
            Console.WriteLine($"Logs       : {logCount} log records");
            Console.WriteLine($"Routes     : {string.Join(", ", routes.ConvertAll(r => r.Name))}");
            Console.WriteLine($"Groups     : {distinctEndpoints} distinct endpoint(s), so expect {distinctEndpoints} routed POST(s) per export");
            Console.WriteLine($"Endpoints  : {(faultEndpoints ? "FAULTED (503 injected)" : "live")}");
            Console.WriteLine();

            ReportStoredBlobs("stored before");

            var stopwatch = Stopwatch.StartNew();

            using (var demo = new MultiEndpointLogDemo(hostConnectionString, routes, runId, faultEndpoints))
            {
                demo.GenerateLogs(logCount);

                Console.WriteLine("Generated, flushing...");

                foreach (var pair in demo.GeneratedPerRoute)
                {
                    Console.WriteLine($"  {pair.Key,-12} {pair.Value}");
                }

                if (!faultEndpoints)
                {
                    // Give the storage drain a chance to run before the provider is torn down.
                    Thread.Sleep(TimeSpan.FromSeconds(15));
                }
            }

            stopwatch.Stop();

            ReportStoredBlobs("stored after");

            Console.WriteLine();
            Console.WriteLine($"Done in {stopwatch.Elapsed.TotalSeconds:F1}s. Query each component for demo.run_id == '{runId}'.");
        }

        /// <summary>
        /// Turns connection strings into routes, assigning each route a stable name based on its
        /// position in the configured list.
        /// </summary>
        private static List<MultiEndpointTraceDemo.EndpointRoute> ParseRoutes(string? connectionStrings)
        {
            var routes = new List<MultiEndpointTraceDemo.EndpointRoute>();

            if (string.IsNullOrWhiteSpace(connectionStrings))
            {
                return routes;
            }

            foreach (var connectionString in connectionStrings!.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                string? instrumentationKey = null;
                string? ingestionEndpoint = null;

                foreach (var part in connectionString.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    var separator = part.IndexOf('=');
                    if (separator < 0)
                    {
                        continue;
                    }

                    var key = part.Substring(0, separator).Trim();
                    var value = part.Substring(separator + 1).Trim();

                    if (string.Equals(key, "InstrumentationKey", StringComparison.OrdinalIgnoreCase))
                    {
                        instrumentationKey = value;
                    }
                    else if (string.Equals(key, "IngestionEndpoint", StringComparison.OrdinalIgnoreCase))
                    {
                        ingestionEndpoint = value;
                    }
                }

                if (instrumentationKey == null || ingestionEndpoint == null)
                {
                    continue;
                }

                var name = $"route{routes.Count + 1}";

                routes.Add(new MultiEndpointTraceDemo.EndpointRoute(name, instrumentationKey, ingestionEndpoint));
            }

            return routes;
        }

        private static void ReportStoredBlobs(string label)
        {
            var root = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Microsoft",
                "AzureMonitor");

            if (!Directory.Exists(root))
            {
                return;
            }

            Console.WriteLine($"{label}:");

            foreach (var partitionRoot in Directory.GetDirectories(root, "*.endpoints"))
            {
                foreach (var partition in Directory.GetDirectories(partitionRoot))
                {
                    // A leased blob is renamed to .lock, so counting only .blob reports an empty
                    // partition while a drain is holding its contents.
                    var blobs = Directory.GetFiles(partition, "*.blob", SearchOption.AllDirectories).Length;
                    var leased = Directory.GetFiles(partition, "*.lock", SearchOption.AllDirectories).Length;

                    Console.WriteLine($"  {Path.GetFileName(partition).Substring(0, 12)}  blobs={blobs} leased={leased}");
                }
            }
        }

        /// <summary>
        /// Prints the exporter's own events. The file-based self-diagnostics buffer is circular and
        /// gets flooded by Activity start/stop events long before a transmission result appears.
        /// </summary>
        private sealed class ExporterEventListener : EventListener
        {
            private const string ExporterEventSourceName = "OpenTelemetry-AzureMonitor-Exporter";

            protected override void OnEventSourceCreated(EventSource eventSource)
            {
                if (eventSource.Name == ExporterEventSourceName)
                {
                    EnableEvents(eventSource, EventLevel.Verbose, EventKeywords.All);
                }
            }

            protected override void OnEventWritten(EventWrittenEventArgs eventData)
            {
                var payload = eventData.Payload == null
                    ? string.Empty
                    : string.Join(" | ", eventData.Payload);

                Console.WriteLine($"  [{eventData.Level}] {eventData.EventName}: {payload}");
            }
        }
    }
}
