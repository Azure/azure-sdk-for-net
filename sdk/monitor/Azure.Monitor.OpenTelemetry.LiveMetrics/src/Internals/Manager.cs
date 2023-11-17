// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals
{
    internal partial class Manager
    {
        private readonly QuickPulseSDKClientAPIsRestClient _quickPulseSDKClientAPIsRestClient;
        private readonly ConnectionVars _connectionVars;
        private readonly bool _isAadEnabled;
        private readonly string _streamId = Guid.NewGuid().ToString();
        private Timer _timer;
        private string _etag = string.Empty;
        private Action<object> _callbackAction = obj => { };

        public Manager(LiveMetricsExporterOptions options, IPlatform platform)
        {
            options.Retry.MaxRetries = 0; // prevent Azure.Core from automatically retrying.

            _connectionVars = InitializeConnectionVars(options, platform);
            _quickPulseSDKClientAPIsRestClient = InitializeRestClient(options, _connectionVars, out _isAadEnabled);

            _timer = new Timer(callback: OnCallback, state: null, dueTime: Timeout.Infinite, period: Timeout.Infinite);

            if (options.EnableLiveMetrics)
            {
                SetPingTimer();
            }

            InitializeMetrics();
        }

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

        private void SetPingTimer()
        {
            _callbackAction = OnPing;
            _timer.Change(dueTime: 0, period: 5000);
        }

        private void SetPostTimer()
        {
            _callbackAction = OnPost;
            _timer.Change(dueTime: 0, period: 1000);
        }

        private void OnCallback(object state) => _callbackAction.Invoke(state);

        private void OnPing(object state)
        {
            try
            {
                Debug.WriteLine($"{DateTime.Now}: OnPing invoked.");

                var response = _quickPulseSDKClientAPIsRestClient.PingCustom(
                    ikey: _connectionVars.InstrumentationKey,
                    apikey: null,
                    xMsQpsTransmissionTime: null,
                    xMsQpsMachineName: "Desktop-Name",
                    xMsQpsInstanceName: "Desktop-Name",
                    xMsQpsStreamId: _streamId,
                    xMsQpsRoleName: null,
                    xMsQpsInvariantVersion: "5",
                    xMsQpsConfigurationEtag: _etag,
                    monitoringDataPoint: null,
                    cancellationToken: default);

                if (response.GetRawResponse().Headers.TryGetValue("x-ms-qps-configuration-etag", out string? etagValue) && etagValue != _etag)
                {
                    Debug.WriteLine($"OnPing: updated etag: {etagValue}");
                    _etag = etagValue;
                }

                if (response.GetRawResponse().Headers.TryGetValue("x-ms-qps-subscribed", out string? subscribedValue) && Convert.ToBoolean(subscribedValue))
                {
                    Debug.WriteLine($"OnPing: Subscribed: {subscribedValue}");
                    SetPostTimer();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Send data to LiveMetrics service.
        /// </summary>
        /// <param name="state"></param>
        /// <remarks>
        /// dataPoint.Metrics.Add(new MetricPoint { Name = "\\ApplicationInsights\\Requests/Sec", Value = 0, Weight = 1 });
        /// dataPoint.Metrics.Add(new MetricPoint { Name = "\\ApplicationInsights\\Request Duration", Value = 0, Weight = 0 });
        /// dataPoint.Metrics.Add(new MetricPoint { Name = "\\ApplicationInsights\\Requests Failed/Sec", Value = 0, Weight = 1 });
        /// dataPoint.Metrics.Add(new MetricPoint { Name = "\\ApplicationInsights\\Requests Succeeded/Sec", Value = 0, Weight = 1 });
        /// dataPoint.Metrics.Add(new MetricPoint { Name = "\\ApplicationInsights\\Dependency Calls/Sec", Value = 0, Weight = 1 });
        /// dataPoint.Metrics.Add(new MetricPoint { Name = "\\ApplicationInsights\\Dependency Call Duration", Value = 0, Weight = 0 });
        /// dataPoint.Metrics.Add(new MetricPoint { Name = "\\ApplicationInsights\\Dependency Calls Failed/Sec", Value = 0, Weight = 1 });
        /// dataPoint.Metrics.Add(new MetricPoint { Name = "\\ApplicationInsights\\Dependency Calls Succeeded/Sec", Value = 0, Weight = 1 });
        /// dataPoint.Metrics.Add(new MetricPoint { Name = "\\ApplicationInsights\\Exceptions/Sec", Value = 0, Weight = 1 });
        /// dataPoint.Metrics.Add(new MetricPoint { Name = "\\Memory\\Committed Bytes", Value = 41372430336, Weight = 1 });
        /// dataPoint.Metrics.Add(new MetricPoint { Name = "\\Processor(_Total)\\% Processor Time", Value = 14.1891f, Weight = 1 });.
        /// </remarks>
        private void OnPost(object state)
        {
            try
            {
                Debug.WriteLine($"{DateTime.Now}: OnPost invoked.");

                var dataPoint = new MonitoringDataPoint
                {
                    Version = "DotNetLiveMetricsPOC", // sdk version
                    MachineName = "Desktop-Name",
                    Instance = "Desktop-Name",
                    InvariantVersion = 5,
                    Timestamp = DateTime.UtcNow,
                    PerformanceCollectionSupported = false,
                    IsWebApp = false,
                    RoleName = null,
                    StreamId = _streamId,
                    TransmissionTime = DateTime.UtcNow,
                };

                var metricPoints = CollectMetrics();
                foreach (var metricPoint in metricPoints)
                {
                    dataPoint.Metrics.Add(metricPoint);
                }

                var response = _quickPulseSDKClientAPIsRestClient.PostCustom(
                    ikey: _connectionVars.InstrumentationKey,
                    apikey: null,
                    xMsQpsConfigurationEtag: _etag,
                    xMsQpsTransmissionTime: null,
                    monitoringDataPoints: new MonitoringDataPoint[] { dataPoint },
                    cancellationToken: default);

                if (response.GetRawResponse().Headers.TryGetValue("x-ms-qps-configuration-etag", out string? etagValue) && etagValue != _etag)
                {
                    Debug.WriteLine($"OnPost: updated etag: {etagValue}");
                    _etag = etagValue;
                }

                if (response.GetRawResponse().Headers.TryGetValue("x-ms-qps-subscribed", out string? subscribedValue) && !Convert.ToBoolean(subscribedValue))
                {
                    Debug.WriteLine($"OnPost: Subscribed: {subscribedValue}");
                    _etag = string.Empty;
                    SetPingTimer();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
