// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
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

        internal static bool? s_isAzureWebApp = null;

        internal readonly State _state = new();
        internal readonly MetricsContainer _metricsContainer; // TODO: WE COULD REMOVE THE READONLY AND DISPOSE THIS WHENEVER LIVEMETRICS IS OFF.

        public Manager(LiveMetricsExporterOptions options, IPlatform platform)
        {
            options.Retry.MaxRetries = 0; // prevent Azure.Core from automatically retrying.

            _connectionVars = InitializeConnectionVars(options, platform);
            _quickPulseSDKClientAPIsRestClient = InitializeRestClient(options, _connectionVars, out _isAadEnabled);

            _timer = new Timer(callback: OnCallback, state: null, dueTime: Timeout.Infinite, period: Timeout.Infinite);

            _metricsContainer = new MetricsContainer();

            if (options.EnableLiveMetrics)
            {
                SetPingTimer();
            }
        }

        public LiveMetricsResource? liveMetricsResource { get; set; }

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
            _state.Update(LiveMetricsState.Ping);
            _callbackAction = OnPing;
            _timer.Change(dueTime: 0, period: 5000);
        }

        private void SetPostTimer()
        {
            _state.Update(LiveMetricsState.Post);
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
                    Version = SdkVersionUtils.s_sdkVersion.Truncate(SchemaConstants.Tags_AiInternalSdkVersion_MaxLength),
                    InvariantVersion = 5,
                    Instance = liveMetricsResource?.RoleInstance ?? "UNKNOWN_INSTANCE",
                    RoleName = liveMetricsResource?.RoleName,
                    MachineName = Environment.MachineName, // TODO: MOVE TO PLATFORM
                    // TODO: Is the Stream ID expected to be unique per post? Testing suggests this is not necessary.
                    StreamId = _streamId,
                    Timestamp = DateTime.UtcNow,
                    //TODO: Provide feedback to service team to get this removed, it not a part of AI SDK.
                    TransmissionTime = DateTime.UtcNow,
                    IsWebApp = IsWebAppRunningInAzure(),
                    PerformanceCollectionSupported = true,
                    // AI SDK relies on PerformanceCounter to collect CPU and Memory metrics.
                    // Follow up with service team to get this removed for OTEL based live metrics.
                    // TopCpuProcesses = null,
                    // TODO: Configuration errors are thrown when filter is applied.
                    // CollectionConfigurationErrors = null,
                };

                DocumentBuffer filledBuffer = _metricsContainer._documentBuffer.FlipBuffers();
                foreach (var item in filledBuffer.ReadAllAndClear())
                {
                    dataPoint.Documents.Add(item);
                }

                var metricPoints = _metricsContainer.Collect();
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

        /// <summary>
        /// Searches for the environment variable specific to Azure Web App.
        /// </summary>
        /// <returns>Boolean, which is true if the current application is an Azure Web App.</returns>
        internal static bool? IsWebAppRunningInAzure()
        {
            const string WebSiteEnvironmentVariable = "WEBSITE_SITE_NAME";
            const string WebSiteIsolationEnvironmentVariable = "WEBSITE_ISOLATION";
            const string WebSiteIsolationHyperV = "hyperv";

            if (!s_isAzureWebApp.HasValue)
            {
                try
                {
                    // Presence of "WEBSITE_SITE_NAME" indicate web apps.
                    // "WEBSITE_ISOLATION"!="hyperv" indicate premium containers. In this case, perf counters
                    // can be read using regular mechanism and hence this method retuns false for
                    // premium containers.
                    // TODO: switch to platform. Not necessary for POC.
                    s_isAzureWebApp = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable(WebSiteEnvironmentVariable)) &&
                                    Environment.GetEnvironmentVariable(WebSiteIsolationEnvironmentVariable) != WebSiteIsolationHyperV;
                }
                catch (Exception ex)
                {
                    LiveMetricsExporterEventSource.Log.AccessingEnvironmentVariableFailedWarning(WebSiteEnvironmentVariable, ex);
                    return false;
                }
            }

            return s_isAzureWebApp;
        }
    }
}
