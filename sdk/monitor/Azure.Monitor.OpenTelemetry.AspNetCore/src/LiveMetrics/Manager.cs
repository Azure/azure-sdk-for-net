// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.AspNetCore.LiveMetrics;
using Azure.Monitor.OpenTelemetry.AspNetCore.LiveMetrics.Filtering;
using Azure.Monitor.OpenTelemetry.AspNetCore.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Internals.LiveMetrics
{
    internal sealed partial class Manager : IDisposable
    {
        private readonly LiveMetricsRestAPIsForClientSDKsRestClient _quickPulseSDKClientAPIsRestClient;
        private readonly ConnectionVars _connectionVars;
        private readonly bool _isAadEnabled;
        private readonly string _streamId = Guid.NewGuid().ToString(); // StreamId should be unique per application instance.
        private LiveMetricsResource? _liveMetricsResource;
        private bool _disposedValue;

        public Manager(AzureMonitorOptions options, IPlatform platform)
        {
            options.Retry.MaxRetries = 0; // prevent Azure.Core from automatically retrying.

            _connectionVars = InitializeConnectionVars(options, platform);
            _quickPulseSDKClientAPIsRestClient = InitializeRestClient(options, _connectionVars, out _isAadEnabled);

            _collectionConfigurationInfo = new CollectionConfigurationInfo();
            _collectionConfiguration = new CollectionConfiguration(_collectionConfigurationInfo, out _);

            if (options.EnableLiveMetrics)
            {
                InitializeState();
            }
        }

        private LiveMetricsResource? LiveMetricsResource => _liveMetricsResource ??= LiveMetricsResourceFunc?.Invoke();

        public Func<LiveMetricsResource?>? LiveMetricsResourceFunc { get; set; }

        internal static ConnectionVars InitializeConnectionVars(AzureMonitorOptions options, IPlatform platform)
        {
            if (options.ConnectionString == null)
            {
                var connectionString = platform.GetEnvironmentVariable(EnvironmentVariableConstants.APPLICATIONINSIGHTS_CONNECTION_STRING);

                if (!string.IsNullOrWhiteSpace(connectionString))
                {
                    return ConnectionStringParser.GetValues(connectionString!);
                }
            }
            else
            {
                return ConnectionStringParser.GetValues(options.ConnectionString);
            }

            throw new InvalidOperationException("A connection string was not found. Please set your connection string.");
        }

        private static LiveMetricsRestAPIsForClientSDKsRestClient InitializeRestClient(AzureMonitorOptions options, ConnectionVars connectionVars, out bool isAadEnabled)
        {
            HttpPipeline pipeline;

            if (options.Credential != null)
            {
                var scope = AadHelper.GetScope(connectionVars.AadAudience);
                var httpPipelinePolicy = new HttpPipelinePolicy[]
                {
                    new BearerTokenAuthenticationPolicy(options.Credential, scope),
                    new LiveMetricsRedirectPolicy(),
                };

                isAadEnabled = true;
                pipeline = HttpPipelineBuilder.Build(options, httpPipelinePolicy);
                AzureMonitorAspNetCoreEventSource.Log.SetAADCredentialsToPipeline(options.Credential.GetType().Name, scope);
            }
            else
            {
                isAadEnabled = false;
                var httpPipelinePolicy = new HttpPipelinePolicy[] { new LiveMetricsRedirectPolicy() };
                pipeline = HttpPipelineBuilder.Build(options, httpPipelinePolicy);
            }

            return new LiveMetricsRestAPIsForClientSDKsRestClient(new ClientDiagnostics(options), pipeline, connectionVars: connectionVars);
        }

        public void Dispose()
        {
            if (!_disposedValue)
            {
                ShutdownState();
                _disposedValue = true;
            }
        }
    }
}
