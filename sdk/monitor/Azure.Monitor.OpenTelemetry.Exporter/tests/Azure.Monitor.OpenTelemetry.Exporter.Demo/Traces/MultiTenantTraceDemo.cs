// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

using Azure.Core;
using Azure.Core.Pipeline;

using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Azure.Monitor.OpenTelemetry.Exporter.Demo.Traces
{
    /// <summary>
    /// Generates traffic for three Application Insights components in three regions from a single
    /// exporter, to exercise multi-tenant routing end to end.
    /// </summary>
    /// <remarks>
    /// The switch this depends on is read once into a static, so
    /// <see cref="EnableMultiTenantExport"/> has to run before any exporter type is touched.
    /// </remarks>
    internal sealed class MultiTenantTraceDemo : IDisposable
    {
        internal const string ActivitySourceName = "MultiTenant.Demo";

        private static readonly ActivitySource s_activitySource = new(ActivitySourceName);

        private readonly TracerProvider? _tracerProvider;
        private readonly TenantRoutingProcessor _routingProcessor;

        public MultiTenantTraceDemo(string exporterConnectionString, IReadOnlyList<TenantRoute> routes, string runId, bool faultTenantEndpoints = false)
        {
            _routingProcessor = new TenantRoutingProcessor(routes, runId);

            var resourceBuilder = ResourceBuilder.CreateDefault().AddAttributes(new Dictionary<string, object>
            {
                { "service.name", "multi-tenant-demo" },
                { "service.version", "1.0.0-demo" },
            });

            _tracerProvider = Sdk.CreateTracerProviderBuilder()
                .SetResourceBuilder(resourceBuilder)
                .AddSource(ActivitySourceName)
                .AddProcessor(_routingProcessor)
                .AddAzureMonitorTraceExporter(o =>
                {
                    o.ConnectionString = exporterConnectionString;

                    // Rate-limited sampling is the default at 5 traces/second and takes precedence
                    // over SamplingRatio, which would drop almost everything this demo generates.
                    o.TracesPerSecond = null;
                    o.SamplingRatio = 1.0F;

                    if (faultTenantEndpoints)
                    {
                        o.AddPolicy(new FaultInjectionPolicy(routes), HttpPipelinePosition.PerRetry);
                    }

                    o.AddPolicy(new IngestionLoggingPolicy(), HttpPipelinePosition.PerCall);
                })
                .Build();
        }

        public static void EnableMultiTenantExport()
            => AppContext.SetSwitch("Azure.Monitor.OpenTelemetry.EnableMultiTenantExport", true);

        public IReadOnlyDictionary<string, int> GeneratedPerTenant => _routingProcessor.Counts;

        public void GenerateTraces(int count)
        {
            for (int i = 0; i < count; i++)
            {
                using (var activity = s_activitySource.StartActivity($"MultiTenantRequest-{i}", ActivityKind.Server))
                {
                    activity?.SetTag("demo.iteration", i);
                    activity?.SetStatus(ActivityStatusCode.Ok);

                    using var dependency = s_activitySource.StartActivity($"MultiTenantDependency-{i}", ActivityKind.Client);
                    dependency?.SetTag("demo.iteration", i);
                    dependency?.SetStatus(ActivityStatusCode.Ok);
                }

                if (i % 250 == 0)
                {
                    Thread.Sleep(10);
                }
            }
        }

        public void Dispose() => _tracerProvider?.Dispose();

        /// <summary>
        /// Answers 503 for the tenant stamps without going to the network, so the exporter takes its
        /// retriable-failure path: back off the endpoint and persist the batch to that endpoint's
        /// partition. Statsbeat and any other host traffic is left alone.
        /// </summary>
        private sealed class FaultInjectionPolicy : HttpPipelinePolicy
        {
            private readonly HashSet<string> _faultedHosts = new(StringComparer.OrdinalIgnoreCase);

            internal FaultInjectionPolicy(IReadOnlyList<TenantRoute> routes)
            {
                foreach (var route in routes)
                {
                    _faultedHosts.Add(new Uri(route.IngestionEndpoint).Host);
                }
            }

            public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                if (!TryFault(message))
                {
                    ProcessNext(message, pipeline);
                }
            }

            public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                return TryFault(message) ? default : ProcessNextAsync(message, pipeline);
            }

            private bool TryFault(HttpMessage message)
            {
                var host = message.Request.Uri.Host;

                if (host == null || !_faultedHosts.Contains(host))
                {
                    return false;
                }

                message.Response = new ServiceUnavailableResponse();

                return true;
            }

            private sealed class ServiceUnavailableResponse : Response
            {
                public override int Status => 503;

                public override string ReasonPhrase => "Service Unavailable (injected)";

                public override Stream? ContentStream { get; set; } = new MemoryStream(Array.Empty<byte>());

                public override string ClientRequestId { get; set; } = string.Empty;

                public override void Dispose() => ContentStream?.Dispose();

                protected override bool ContainsHeader(string name) => false;

                protected override IEnumerable<HttpHeader> EnumerateHeaders() => Array.Empty<HttpHeader>();

                protected override bool TryGetHeader(string name, out string value)
                {
                    value = null!;
                    return false;
                }

                protected override bool TryGetHeaderValues(string name, out IEnumerable<string> values)
                {
                    values = null!;
                    return false;
                }
            }
        }

        /// <summary>Reports where each batch went and what ingestion said about it.</summary>
        private sealed class IngestionLoggingPolicy : HttpPipelinePolicy
        {
            public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                ProcessNext(message, pipeline);
                Report(message);
            }

            public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
                Report(message);
            }

            private static void Report(HttpMessage message)
            {
                var status = message.HasResponse ? message.Response.Status.ToString() : "no response";
                var body = string.Empty;

                if (message.HasResponse)
                {
                    try
                    {
                        body = message.Response.Content.ToString();
                    }
                    catch (Exception ex)
                    {
                        body = $"(unreadable: {ex.GetType().Name})";
                    }
                }

                Console.WriteLine($"  POST {message.Request.Uri} -> {status} {body}");
            }
        }

        /// <summary>An ingestion target: what the routing tags on an Activity will point at.</summary>
        internal sealed class TenantRoute
        {
            public TenantRoute(string name, string instrumentationKey, string ingestionEndpoint)
            {
                Name = name;
                InstrumentationKey = instrumentationKey;
                IngestionEndpoint = ingestionEndpoint;
            }

            public string Name { get; }

            public string InstrumentationKey { get; }

            public string IngestionEndpoint { get; }
        }

        /// <summary>
        /// Stamps each Activity with a randomly chosen tenant's routing tags, so one process feeds
        /// all three components and every export batch spans several ingestion endpoints.
        /// </summary>
        private sealed class TenantRoutingProcessor : BaseProcessor<Activity>
        {
            private readonly IReadOnlyList<TenantRoute> _routes;
            private readonly string _runId;
            private readonly Random _random = new(Seed: 42);
            private readonly Dictionary<string, int> _counts = new(StringComparer.Ordinal);
            private readonly object _lock = new();

            internal TenantRoutingProcessor(IReadOnlyList<TenantRoute> routes, string runId)
            {
                _routes = routes;
                _runId = runId;

                foreach (var route in routes)
                {
                    _counts[route.Name] = 0;
                }
            }

            internal IReadOnlyDictionary<string, int> Counts => _counts;

            public override void OnEnd(Activity data)
            {
                TenantRoute route;

                lock (_lock)
                {
                    route = _routes[_random.Next(_routes.Count)];
                    _counts[route.Name]++;
                }

                data.SetTag("microsoft.instrumentation_key", route.InstrumentationKey);
                data.SetTag("microsoft.ingestion_endpoint", route.IngestionEndpoint);

                // Survives into customDimensions, so a query can count what actually arrived.
                data.SetTag("demo.run_id", _runId);
                data.SetTag("demo.tenant", route.Name);
            }
        }
    }
}
