// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.Exporter.Demo.Traces;

using Microsoft.Extensions.Logging;

using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Resources;

namespace Azure.Monitor.OpenTelemetry.Exporter.Demo.Logs
{
    /// <summary>
    /// Generates log traffic for several Application Insights components from a single exporter, to
    /// exercise multi-tenant log routing end to end. Mirrors <see cref="MultiTenantTraceDemo"/> but
    /// for <see cref="LogRecord"/>s.
    /// </summary>
    /// <remarks>
    /// The switch this depends on is read once into a static, so
    /// <see cref="MultiTenantTraceDemo.EnableMultiTenantExport"/> has to run before any exporter type
    /// is touched.
    /// </remarks>
    internal sealed class MultiTenantLogDemo : IDisposable
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly TenantRoutingLogProcessor _routingProcessor;

        public MultiTenantLogDemo(string exporterConnectionString, IReadOnlyList<MultiTenantTraceDemo.TenantRoute> routes, string runId, bool faultTenantEndpoints = false)
        {
            _routingProcessor = new TenantRoutingLogProcessor(routes, runId);

            var resourceBuilder = ResourceBuilder.CreateDefault().AddAttributes(new Dictionary<string, object>
            {
                { "service.name", "multi-tenant-demo" },
                { "service.version", "1.0.0-demo" },
            });

            _loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.SetResourceBuilder(resourceBuilder);

                    // Availability/event bodies are surfaced from the formatted message, so it has to
                    // be captured rather than dropped.
                    options.IncludeFormattedMessage = true;

                    // Stamp the routing tags onto every LogRecord before the exporter's own
                    // processor sees it, the same way the trace demo stamps Activity tags.
                    options.AddProcessor(_routingProcessor);

                    options.AddAzureMonitorLogExporter(o =>
                    {
                        o.ConnectionString = exporterConnectionString;

                        if (faultTenantEndpoints)
                        {
                            o.AddPolicy(new MultiTenantTraceDemo.FaultInjectionPolicy(routes), HttpPipelinePosition.PerRetry);
                        }

                        o.AddPolicy(new MultiTenantTraceDemo.IngestionLoggingPolicy(), HttpPipelinePosition.PerCall);
                    });
                });
            });
        }

        // Attribute keys the exporter recognizes to classify a LogRecord into a specific Application
        // Insights telemetry type. Kept in sync with LogsHelper's constants.
        private const string CustomEventNameAttribute = "microsoft.custom_event.name";
        private const string AvailabilityIdAttribute = "microsoft.availability.id";
        private const string AvailabilityNameAttribute = "microsoft.availability.name";
        private const string AvailabilityDurationAttribute = "microsoft.availability.duration";
        private const string AvailabilitySuccessAttribute = "microsoft.availability.success";
        private const string AvailabilityRunLocationAttribute = "microsoft.availability.runLocation";

        public IReadOnlyDictionary<string, int> GeneratedPerTenant => _routingProcessor.Counts;

        /// <summary>
        /// Emits every telemetry shape the log exporter can produce - trace (message), exception,
        /// custom event, and availability - cycling through them so a routed batch carries a mix.
        /// The classifying attributes are attached through a list-valued log state, which the SDK
        /// surfaces verbatim as <see cref="LogRecord.Attributes"/>; the routing processor then appends
        /// the tenant tags in its OnEnd.
        /// </summary>
        public void GenerateLogs(int count)
        {
            var logger = _loggerFactory.CreateLogger<MultiTenantLogDemo>();

            for (int i = 0; i < count; i++)
            {
                switch (i % 4)
                {
                    case 0:
                        // Trace / MessageData: an ordinary structured log with no special attributes.
                        logger.LogInformation("MultiTenantTrace-{iteration} from {source}.", i, "demo");
                        break;

                    case 1:
                        // ExceptionData: any LogRecord carrying an exception becomes an exception.
                        try
                        {
                            throw new InvalidOperationException($"Injected failure #{i}");
                        }
                        catch (Exception ex)
                        {
                            logger.LogError(ex, "MultiTenantException-{iteration} failed.", i);
                        }
                        break;

                    case 2:
                        // EventData: the microsoft.custom_event.name attribute names a custom event.
                        Emit(
                            logger,
                            LogLevel.Information,
                            $"MultiTenantEvent-{i}",
                            exception: null,
                            new KeyValuePair<string, object?>(CustomEventNameAttribute, "MultiTenantDemoEvent"),
                            new KeyValuePair<string, object?>("demo.iteration", i));
                        break;

                    default:
                        // AvailabilityData: requires id, name, duration, and success together.
                        Emit(
                            logger,
                            LogLevel.Information,
                            $"MultiTenantAvailability-{i}",
                            exception: null,
                            new KeyValuePair<string, object?>(AvailabilityIdAttribute, Guid.NewGuid().ToString("N")),
                            new KeyValuePair<string, object?>(AvailabilityNameAttribute, "MultiTenantDemoTest"),
                            new KeyValuePair<string, object?>(AvailabilityDurationAttribute, "00:00:01.500"),
                            new KeyValuePair<string, object?>(AvailabilitySuccessAttribute, i % 8 != 3),
                            new KeyValuePair<string, object?>(AvailabilityRunLocationAttribute, "demo-region"));
                        break;
                }

                if (i % 250 == 0)
                {
                    Thread.Sleep(10);
                }
            }
        }

        /// <summary>
        /// Logs with an explicit list-valued state so arbitrary attribute keys (including the
        /// dotted <c>microsoft.*</c> classifiers, which are not valid message-template placeholders)
        /// land verbatim on <see cref="LogRecord.Attributes"/>.
        /// </summary>
        private static void Emit(ILogger logger, LogLevel level, string message, Exception? exception, params KeyValuePair<string, object?>[] attributes)
        {
            var state = new List<KeyValuePair<string, object?>>(attributes);
            logger.Log(level, new EventId(0), state, exception, (_, _) => message);
        }

        public void Dispose() => _loggerFactory.Dispose();

        /// <summary>
        /// Stamps each <see cref="LogRecord"/> with a randomly chosen tenant's routing attributes, so
        /// one process feeds all components and every export batch spans several ingestion endpoints.
        /// Attributes are the routing input for logs (scopes are not consulted), so they must land in
        /// <see cref="LogRecord.Attributes"/> before the exporter runs.
        /// </summary>
        private sealed class TenantRoutingLogProcessor : BaseProcessor<LogRecord>
        {
            private const string InstrumentationKeyAttributeName = "microsoft.instrumentation_key";
            private const string IngestionEndpointAttributeName = "microsoft.ingestion_endpoint";

            private readonly IReadOnlyList<MultiTenantTraceDemo.TenantRoute> _routes;
            private readonly string _runId;
            private readonly Random _random = new(Seed: 42);
            private readonly Dictionary<string, int> _counts = new(StringComparer.Ordinal);
            private readonly object _lock = new();

            internal TenantRoutingLogProcessor(IReadOnlyList<MultiTenantTraceDemo.TenantRoute> routes, string runId)
            {
                _routes = routes;
                _runId = runId;

                foreach (var route in routes)
                {
                    _counts[route.Name] = 0;
                }
            }

            internal IReadOnlyDictionary<string, int> Counts => _counts;

            public override void OnEnd(LogRecord logRecord)
            {
                MultiTenantTraceDemo.TenantRoute route;

                lock (_lock)
                {
                    route = _routes[_random.Next(_routes.Count)];
                    _counts[route.Name]++;
                }

                var attributes = new List<KeyValuePair<string, object?>>();

                if (logRecord.Attributes != null)
                {
                    attributes.AddRange(logRecord.Attributes);
                }

                attributes.Add(new KeyValuePair<string, object?>(InstrumentationKeyAttributeName, route.InstrumentationKey));
                attributes.Add(new KeyValuePair<string, object?>(IngestionEndpointAttributeName, route.IngestionEndpoint));

                // Survives into customDimensions, so a query can count what actually arrived.
                attributes.Add(new KeyValuePair<string, object?>("demo.run_id", _runId));
                attributes.Add(new KeyValuePair<string, object?>("demo.tenant", route.Name));

                logRecord.Attributes = attributes;
            }
        }
    }
}
