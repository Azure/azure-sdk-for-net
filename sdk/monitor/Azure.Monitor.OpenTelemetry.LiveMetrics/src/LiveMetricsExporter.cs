// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;
using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics
{
    internal sealed class LiveMetricsExporter : BaseExporter<Metric>
    {
        public const int CurrentInvariantVersion = 5;
        private const string WebSiteEnvironmentVariable = "WEBSITE_SITE_NAME";
        private const string WebSiteIsolationEnvironmentVariable = "WEBSITE_ISOLATION";
        internal static bool? s_isAzureWebApp = null;
        private const string WebSiteIsolationHyperV = "hyperv";
        private readonly string _instrumentationKey;
        private readonly DoubleBuffer _doubleBuffer;
        private LiveMetricsResource? _resource;
        private bool _disposed;

        public LiveMetricsExporter(DoubleBuffer doubleBuffer, LiveMetricsExporterOptions options)
        {
            _instrumentationKey = "";
            _doubleBuffer = doubleBuffer;
        }

        internal LiveMetricsResource? MetricResource => _resource ??= ParentProvider?.GetResource().CreateAzureMonitorResource(_instrumentationKey);

        public override ExportResult Export(in Batch<Metric> batch)
        {
            DocumentBuffer filledBuffer = _doubleBuffer.FlipDocumentBuffers();
            MonitoringDataPoint monitoringDataPoint = new()
            {
                Version = SdkVersionUtils.s_sdkVersion.Truncate(SchemaConstants.Tags_AiInternalSdkVersion_MaxLength),
                InvariantVersion = CurrentInvariantVersion,
                Instance = MetricResource?.RoleInstance,
                RoleName = MetricResource?.RoleName,
                MachineName = Environment.MachineName,
                StreamId = GetStreamId(),
                Timestamp = DateTime.UtcNow,
                //TODO: Provide feedback to service team to get this removed, it not a part of AI SDK.
                // TransmissionTime = DateTime.UtcNow,
                IsWebApp = IsWebAppRunningInAzure(),
                PerformanceCollectionSupported = false,
                // AI SDK relies on PerformanceCounter to collect CPU and Memory metrics.
                // Follow up with service team to get this removed for OTEL based live metrics.
                // TopCpuProcesses = null,
                // TODO: Configuration errors are thrown when filter is applied.
                // CollectionConfigurationErrors = null,
            };

            foreach (var item in filledBuffer.ReadAllAndClear())
            {
                monitoringDataPoint.Documents.Add(item);
            }

            foreach (var metric in batch)
            {
                if (!LiveMetricsExtractionProcessor.s_liveMetricNameMapping.TryGetValue(metric.Name, out var metricName))
                {
                    continue;
                }

                var liveMetricPoint = new Models.MetricPoint
                {
                    Name = metricName
                };

                foreach (ref readonly var metricPoint in metric.GetMetricPoints())
                {
                    switch (metric.MetricType)
                    {
                        case MetricType.LongSum:
                            // potential for minor precision loss implicitly going from long->double
                            // see: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/numeric-conversions#implicit-numeric-conversions
                            liveMetricPoint.Value = metricPoint.GetSumLong();
                            liveMetricPoint.Weight = 1;
                            break;
                        case MetricType.Histogram:
                            long histogramCount = metricPoint.GetHistogramCount();
                            // When you convert double to float, the double value is rounded to the nearest float value.
                            // If the double value is too small or too large to fit into the float type, the result is zero or infinity.
                            // see: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/numeric-conversions#explicit-numeric-conversions
                            liveMetricPoint.Value = (float)(metricPoint.GetHistogramSum() / histogramCount);
                            liveMetricPoint.Weight = histogramCount <= int.MaxValue ? (int?)histogramCount : null;
                            break;
                    }

                    monitoringDataPoint.Metrics.Add(liveMetricPoint);
                }
            }

            // Send data.

            return ExportResult.Success;
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                }

                _disposed = true;
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Searches for the environment variable specific to Azure Web App.
        /// </summary>
        /// <returns>Boolean, which is true if the current application is an Azure Web App.</returns>
        internal static bool? IsWebAppRunningInAzure()
        {
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

        private static string GetStreamId()
        {
            return Guid.NewGuid().ToStringInvariant("N");
        }
    }
}
