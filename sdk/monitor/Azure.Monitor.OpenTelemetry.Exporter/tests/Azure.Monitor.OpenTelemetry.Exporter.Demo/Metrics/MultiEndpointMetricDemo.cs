// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;

using Azure.Core;
using Azure.Monitor.OpenTelemetry.Exporter.Demo.Traces;

using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;

namespace Azure.Monitor.OpenTelemetry.Exporter.Demo.Metrics
{
    /// <summary>
    /// Generates metric traffic for several Application Insights components from a single exporter,
    /// to exercise multi-endpoint metric routing end to end.
    /// </summary>
    /// <remarks>
    /// Unlike traces and logs, routing values cannot be stamped by a processor after the fact: a
    /// metric's dimensions are part of its aggregation key, so they must be supplied at measurement
    /// time. Each destination therefore becomes its own time series, and the export carries one
    /// <c>MetricPoint</c> per destination per instrument.
    /// <para/>
    /// The switch this depends on is read once into a static, so
    /// <see cref="MultiEndpointTraceDemo.EnableMultiEndpointRouting"/> has to run before any exporter
    /// type is touched.
    /// </remarks>
    internal sealed class MultiEndpointMetricDemo : IDisposable
    {
        private const string InstrumentationKeyAttribute = "microsoft.instrumentation_key";
        private const string IngestionEndpointAttribute = "microsoft.ingestion_endpoint";
        private const string CloudRoleAttribute = "microsoft.multi_endpoint_cloud_role";

        /// <summary>One measurement in this many is left unroutable, to prove it is dropped.</summary>
        private const int UnroutableEvery = 10;

        private readonly MeterProvider _meterProvider;
        private readonly Meter _meter;
        private readonly Counter<long> _requestCount;
        private readonly Histogram<double> _requestDuration;
        private readonly IReadOnlyList<MultiEndpointTraceDemo.EndpointRoute> _routes;
        private readonly string _runId;
        private readonly Random _random = new(Seed: 42);
        private readonly Dictionary<string, int> _counts = new(StringComparer.Ordinal);
        private readonly Dictionary<string, int> _unroutableCounts = new(StringComparer.Ordinal);

        public MultiEndpointMetricDemo(string exporterConnectionString, IReadOnlyList<MultiEndpointTraceDemo.EndpointRoute> routes, string runId, bool faultRoutedEndpoints = false)
        {
            _routes = routes;
            _runId = runId;

            foreach (var route in routes)
            {
                _counts[route.Name] = 0;
            }

            var meterName = $"MultiEndpointMetricDemo.{runId}";
            _meter = new Meter(new MeterOptions(meterName));
            _requestCount = _meter.CreateCounter<long>("demo.request.count");
            _requestDuration = _meter.CreateHistogram<double>("demo.request.duration");

            var resourceBuilder = ResourceBuilder.CreateDefault().AddAttributes(new Dictionary<string, object>
            {
                { "service.name", "multi-endpoint-demo" },
                { "service.version", "1.0.0-demo" },
            });

            _meterProvider = Sdk.CreateMeterProviderBuilder()
                .SetResourceBuilder(resourceBuilder)
                .AddMeter(meterName)
                .AddAzureMonitorMetricExporter(o =>
                {
                    o.ConnectionString = exporterConnectionString;

                    if (faultRoutedEndpoints)
                    {
                        o.AddPolicy(new MultiEndpointTraceDemo.FaultInjectionPolicy(routes), HttpPipelinePosition.PerRetry);
                    }

                    o.AddPolicy(new MultiEndpointTraceDemo.IngestionLoggingPolicy(), HttpPipelinePosition.PerCall);
                })
                .Build()!;
        }

        public IReadOnlyDictionary<string, int> GeneratedPerRoute => _counts;

        /// <summary>Expected rejection counts, to compare against what arrived.</summary>
        public IReadOnlyDictionary<string, int> UnroutableCounts => _unroutableCounts;

        /// <summary>
        /// Records measurements against a randomly chosen destination, so one process feeds every
        /// component and a single export spans several ingestion endpoints.
        /// </summary>
        public void GenerateMetrics(int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (i % UnroutableEvery == 0)
                {
                    RecordUnroutable(i / UnroutableEvery);
                    continue;
                }

                var route = _routes[_random.Next(_routes.Count)];
                _counts[route.Name]++;

                // demo.run_id and demo.route survive into customDimensions, so a query can count
                // what actually arrived. The three routing dimensions are consumed by the exporter.
                var tags = new TagList
                {
                    { InstrumentationKeyAttribute, route.InstrumentationKey },
                    { IngestionEndpointAttribute, route.IngestionEndpoint },
                    { CloudRoleAttribute, route.Name },
                    { "demo.run_id", _runId },
                    { "demo.route", route.Name },
                };

                _requestCount.Add(1, tags);
                _requestDuration.Record(_random.Next(1, 500), tags);
            }
        }

        /// <summary>Records a measurement that cannot be routed, cycling through the ways it can fail.</summary>
        private void RecordUnroutable(int flavour)
        {
            var reason = (flavour % 4) switch
            {
                0 => "MissingInstrumentationKey",
                1 => "MissingIngestionEndpoint",
                2 => "IngestionEndpointMalformed",
                _ => "IngestionEndpointNotHttps",
            };

            var tags = new TagList { { "demo.run_id", _runId } };

            switch (flavour % 4)
            {
                case 0:
                    // Endpoint without a key.
                    tags.Add(IngestionEndpointAttribute, _routes[0].IngestionEndpoint);
                    break;

                case 1:
                    // Key without an endpoint.
                    tags.Add(InstrumentationKeyAttribute, _routes[0].InstrumentationKey);
                    break;

                case 2:
                    tags.Add(InstrumentationKeyAttribute, _routes[0].InstrumentationKey);
                    tags.Add(IngestionEndpointAttribute, "not-a-uri");
                    break;

                default:
                    tags.Add(InstrumentationKeyAttribute, _routes[0].InstrumentationKey);
                    tags.Add(IngestionEndpointAttribute, _routes[0].IngestionEndpoint.Replace("https://", "http://"));
                    break;
            }

            _unroutableCounts[reason] = _unroutableCounts.TryGetValue(reason, out var seen) ? seen + 1 : 1;

            _requestCount.Add(1, tags);
        }

        public void Dispose()
        {
            _meterProvider.Dispose();
            _meter.Dispose();
        }
    }
}
