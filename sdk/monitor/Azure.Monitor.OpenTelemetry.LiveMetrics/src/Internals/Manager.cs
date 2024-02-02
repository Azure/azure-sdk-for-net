// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.Diagnostics;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals
{
    internal sealed partial class Manager : IDisposable
    {
        private readonly QuickPulseSDKClientAPIsRestClient _quickPulseSDKClientAPIsRestClient;
        private readonly ConnectionVars _connectionVars;
        private readonly bool _isAadEnabled;
        private readonly string _streamId = Guid.NewGuid().ToString(); // StreamId should be unique per application instance.
        private bool _disposedValue;

        public Manager(LiveMetricsExporterOptions options, IPlatform platform)
        {
            options.Retry.MaxRetries = 0; // prevent Azure.Core from automatically retrying.

            _connectionVars = InitializeConnectionVars(options, platform);
            _quickPulseSDKClientAPIsRestClient = InitializeRestClient(options, _connectionVars, out _isAadEnabled);

            if (options.EnableLiveMetrics)
            {
                InitializeState();
            }
        }

        public LiveMetricsResource? LiveMetricsResource { get; set; }

        internal static ConnectionVars InitializeConnectionVars(LiveMetricsExporterOptions options, IPlatform platform)
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

        private static QuickPulseSDKClientAPIsRestClient InitializeRestClient(LiveMetricsExporterOptions options, ConnectionVars connectionVars, out bool isAadEnabled)
        {
            HttpPipeline pipeline;

            if (options.Credential != null)
            {
                var scope = AadHelper.GetScope(connectionVars.AadAudience);
                var httpPipelinePolicy = new HttpPipelinePolicy[]
                {
                    new BearerTokenAuthenticationPolicy(options.Credential, scope),
                };

                isAadEnabled = true;
                pipeline = HttpPipelineBuilder.Build(options, httpPipelinePolicy);
                LiveMetricsExporterEventSource.Log.SetAADCredentialsToPipeline(options.Credential.GetType().Name, scope);
            }
            else
            {
                isAadEnabled = false;
                pipeline = HttpPipelineBuilder.Build(options);
            }

            return new QuickPulseSDKClientAPIsRestClient(new ClientDiagnostics(options), pipeline, host: connectionVars.LiveEndpoint);
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
