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

        public virtual Response<MetricQueryResult> Query(string resource, DateTimeOffset startTime, DateTimeOffset endTime, TimeSpan interval, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsClient)}.{nameof(Query)}");
            scope.Start();
            try
            {
                return _metricsRestClient.List(resource, GetTimespan(startTime, endTime), interval, cancellationToken: cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<Response<MetricQueryResult>> QueryAsync(string resource, DateTimeOffset startTime, DateTimeOffset endTime, TimeSpan interval, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsClient)}.{nameof(Query)}");
            scope.Start();
            try
            {
                return await _metricsRestClient.ListAsync(resource, GetTimespan(startTime, endTime), interval, cancellationToken: cancellationToken).ConfigureAwait(false);
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

        private static string GetTimespan(DateTimeOffset startTime, DateTimeOffset endTime)
        {
            return $"{TypeFormatters.ToString(startTime, "o")}/{TypeFormatters.ToString(endTime, "o")}";
        }
    }
}