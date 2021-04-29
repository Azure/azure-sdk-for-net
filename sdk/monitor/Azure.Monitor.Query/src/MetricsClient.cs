// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Monitor.Query.Models;

namespace Azure.Monitor.Query
{
    public class MetricsClient
    {
        private readonly MetricDefinitionsRestClient _metricDefinitionsClient;
        private readonly MetricsRestClient _metricsRestClient;
        private readonly MetricNamespacesRestClient _namespacesRestClient;
        private readonly ClientDiagnostics _clientDiagnostics;
        private HttpPipeline _pipeline;

        public MetricsClient(TokenCredential credential) : this(credential, null)
        {
        }

        public MetricsClient(TokenCredential credential, MetricsClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new MetricsClientOptions();

            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, "https://management.azure.com//.default"));
            _metricDefinitionsClient = new MetricDefinitionsRestClient(_clientDiagnostics, _pipeline);
            _metricsRestClient = new MetricsRestClient(_clientDiagnostics, _pipeline);
            _namespacesRestClient = new MetricNamespacesRestClient(_clientDiagnostics, _pipeline);
        }

        protected MetricsClient()
        {
        }

        public virtual Response<MetricQueryResult> Query(string resource, IEnumerable<string> metrics, MetricQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsClient)}.{nameof(Query)}");
            scope.Start();
            try
            {
                return _metricsRestClient.List(resource,
                    timespan: GetTimespan(options),
                    interval: options?.Interval,
                    filter: options?.Filter,
                    top: options?.Top,
                    aggregation: GetAggregation(options),
                    metricnames: string.Join(",", metrics),
                    orderby: options?.OrderBy,
                    metricnamespace: options?.MetricNamespace,
                    cancellationToken: cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<Response<MetricQueryResult>> QueryAsync(string resource, IEnumerable<string> metrics, MetricQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsClient)}.{nameof(Query)}");
            scope.Start();
            try
            {
                return await _metricsRestClient.ListAsync(resource,
                    timespan: GetTimespan(options),
                    interval: options?.Interval,
                    filter: options?.Filter,
                    top: options?.Top,
                    aggregation: GetAggregation(options),
                    metricnames: string.Join(",", metrics),
                    orderby: options?.OrderBy,
                    metricnamespace: options?.MetricNamespace,
                    cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Response<IReadOnlyList<MetricDefinition>> GetMetrics(string resource, string metricsNamespace, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsClient)}.{nameof(GetMetrics)}");
            scope.Start();
            try
            {
                var response = _metricDefinitionsClient.List(resource, metricsNamespace, cancellationToken);

                return Response.FromValue(response.Value.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<Response<IReadOnlyList<MetricDefinition>>> GetMetricsAsync(string resource, string metricsNamespace, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsClient)}.{nameof(GetMetrics)}");
            scope.Start();
            try
            {
                var response = await _metricDefinitionsClient.ListAsync(resource, metricsNamespace, cancellationToken).ConfigureAwait(false);

                return Response.FromValue(response.Value.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Response<IReadOnlyList<MetricNamespace>> GetMetricNamespaces(string resource, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsClient)}.{nameof(GetMetricNamespaces)}");
            scope.Start();
            try
            {
                var response = _namespacesRestClient.List(resource, cancellationToken: cancellationToken);

                return Response.FromValue(response.Value.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<Response<IReadOnlyList<MetricNamespace>>> GetMetricNamespacesAsync(string resource, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsClient)}.{nameof(GetMetricNamespaces)}");
            scope.Start();
            try
            {
                var response = await _namespacesRestClient.ListAsync(resource, cancellationToken: cancellationToken).ConfigureAwait(false);

                return Response.FromValue(response.Value.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private static string GetTimespan(MetricQueryOptions options)
        {
            var startTime = options?.StartTime != null ? TypeFormatters.ToString(options.StartTime.Value, "o") : null;
            var endTime = options?.EndTime != null ? TypeFormatters.ToString(options.EndTime.Value, "o") : null;
            var duration = options?.Duration != null ? TypeFormatters.ToString(options.Duration.Value, "P") : null;

            switch (startTime, endTime, duration)
            {
                case (null, null, string):
                    return duration;
                case (string, string, null):
                    return $"{startTime}/{endTime}";
                case (string, null, string):
                    return $"{startTime}/{duration}";
                case (null, string, string):
                    return $"{duration}/{endTime}";
                case (null, null, null):
                    return null;
                default:
                    throw new ArgumentException(
                        $"The following combinations of {nameof(MetricQueryOptions.Duration)}, {nameof(MetricQueryOptions.StartTime)}, {nameof(MetricQueryOptions.EndTime)} are allowed: " + Environment.NewLine +
                        $"  {nameof(MetricQueryOptions.Duration)}, " + Environment.NewLine +
                        $"  {nameof(MetricQueryOptions.StartTime)} + {nameof(MetricQueryOptions.Duration)}" + Environment.NewLine +
                        $"  {nameof(MetricQueryOptions.Duration)} + {nameof(MetricQueryOptions.EndTime)}" + Environment.NewLine +
                        $"  {nameof(MetricQueryOptions.StartTime)} + {nameof(MetricQueryOptions.EndTime)}");
            }
        }

        private static string GetAggregation(MetricQueryOptions options)
        {
            if (options?.Aggregations == null ||
                options.Aggregations.Count == 0)
            {
                return null;
            }
            return string.Join(",", options.Aggregations);
        }
    }
}