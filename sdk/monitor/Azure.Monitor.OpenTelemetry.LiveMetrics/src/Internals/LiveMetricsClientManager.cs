// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.Filtering;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals
{
    internal sealed partial class LiveMetricsClientManager : IDisposable
    {
        private readonly LiveMetricsRestAPIsForClientSDKsRestClient _quickPulseSDKClientAPIsRestClient;
        private readonly ConnectionVars _connectionVars;
        private readonly bool _isAadEnabled;
        private readonly bool _enableLiveMetrics;
        private readonly string _streamId = Guid.NewGuid().ToString(); // StreamId should be unique per application instance.
        private readonly object _lifecycleLock = new();
        private LiveMetricsResource? _liveMetricsResource;
        private bool _disposedValue;
        private int _started; // 0 = not started, 1 = started, 2 = disposed

        public LiveMetricsClientManager(AzureMonitorLiveMetricsOptions options, IPlatform platform)
        {
            options.Retry.MaxRetries = 0; // prevent Azure.Core from automatically retrying.

            _enableLiveMetrics = options.EnableLiveMetrics;
            _connectionVars = InitializeConnectionVars(options, platform);
            _quickPulseSDKClientAPIsRestClient = InitializeRestClient(options, _connectionVars, out _isAadEnabled);

            _collectionConfigurationInfo = new CollectionConfigurationInfo();
            _collectionConfiguration = new CollectionConfiguration(_collectionConfigurationInfo, out _);
        }

        /// <summary>
        /// Starts the LiveMetrics background ping thread.
        /// This is safe to call multiple times; only the first call has effect.
        /// No-op after Dispose.
        /// </summary>
        internal void Start()
        {
            if (!_enableLiveMetrics)
            {
                return;
            }

            lock (_lifecycleLock)
            {
                if (_started != 0)
                {
                    return;
                }

                _started = 1;
                InitializeState();
            }
        }

        private LiveMetricsResource? LiveMetricsResource => _liveMetricsResource ??= LiveMetricsResourceFunc?.Invoke();

        public Func<LiveMetricsResource?>? LiveMetricsResourceFunc { get; set; }

        internal static ConnectionVars InitializeConnectionVars(AzureMonitorLiveMetricsOptions options, IPlatform platform)
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

        private static LiveMetricsRestAPIsForClientSDKsRestClient InitializeRestClient(AzureMonitorLiveMetricsOptions options, ConnectionVars connectionVars, out bool isAadEnabled)
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
                AzureMonitorLiveMetricsEventSource.Log.SetAADCredentialsToPipeline(options.Credential.GetType().Name, scope);
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
            lock (_lifecycleLock)
            {
                if (_disposedValue)
                {
                    return;
                }

                _disposedValue = true;
                var wasStarted = _started == 1;
                _started = 2;

                if (wasStarted)
                {
                    ShutdownState();
                }
            }
        }
    }
}
