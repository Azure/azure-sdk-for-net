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

        public IReadOnlyDictionary<string, int> GeneratedPerTenant => _routingProcessor.Counts;

        public void GenerateLogs(int count)
        {
            var logger = _loggerFactory.CreateLogger<MultiTenantLogDemo>();

            for (int i = 0; i < count; i++)
            {
                logger.LogInformation("MultiTenantLog-{iteration} from {name}.", i, "demo");

                if (i % 250 == 0)
                {
                    Thread.Sleep(10);
                }
            }
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
