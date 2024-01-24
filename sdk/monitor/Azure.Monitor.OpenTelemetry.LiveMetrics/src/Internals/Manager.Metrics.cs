// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals
{
    /// <summary>
    /// This partial class encapsulates all the metrics that are tracked and reported to the Live Metrics service.
    /// </summary>
    internal partial class Manager
    {
        internal readonly DoubleBuffer _documentBuffer = new();
        internal static bool? s_isAzureWebApp = null;

        private readonly PerformanceCounter _performanceCounter_ProcessorTime = new(categoryName: "Processor", counterName: "% Processor Time", instanceName: "_Total");
        private readonly PerformanceCounter _performanceCounter_CommittedBytes = new(categoryName: "Memory", counterName: "Committed Bytes");

        public MonitoringDataPoint GetDataPoint()
        {
            var dataPoint = new MonitoringDataPoint
            {
                Version = SdkVersionUtils.s_sdkVersion.Truncate(SchemaConstants.Tags_AiInternalSdkVersion_MaxLength),
                InvariantVersion = 5,
                Instance = LiveMetricsResource?.RoleInstance ?? "UNKNOWN_INSTANCE",
                RoleName = LiveMetricsResource?.RoleName,
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

            LiveMetricsBuffer liveMetricsBuffer = new();
            DocumentBuffer filledBuffer = _documentBuffer.FlipDocumentBuffers();
            foreach (var item in filledBuffer.ReadAllAndClear())
            {
                dataPoint.Documents.Add(item);

                if (item.DocumentType == DocumentIngressDocumentType.Request)
                {
                    // Export needs to divide by count to get the average.
                    // this.AIRequestDurationAveInMs = requestCount > 0 ? (double)requestDurationInTicks / TimeSpan.TicksPerMillisecond / requestCount : 0;
                    if (item.Extension_IsSuccess)
                    {
                        liveMetricsBuffer.RecordRequestSucceeded(item.Extension_Duration);
                    }
                    else
                    {
                        liveMetricsBuffer.RecordRequestFailed(item.Extension_Duration);
                    }
                }
                else if (item.DocumentType == DocumentIngressDocumentType.RemoteDependency)
                {
                    // Export needs to divide by count to get the average.
                    // this.AIDependencyCallDurationAveInMs = dependencyCount > 0 ? (double)dependencyDurationInTicks / TimeSpan.TicksPerMillisecond / dependencyCount : 0;
                    // Export DependencyDurationLiveMetric, Meter: LiveMetricMeterName
                    // (2023 - 11 - 03T23: 20:56.0282406Z, 2023 - 11 - 03T23: 21:00.9830153Z] Histogram Value: Sum: 798.9463000000001 Count: 7 Min: 4.9172 Max: 651.8997
                    if (item.Extension_IsSuccess)
                    {
                        liveMetricsBuffer.RecordDependencySucceeded(item.Extension_Duration);
                    }
                    else
                    {
                        liveMetricsBuffer.RecordDependencyFailed(item.Extension_Duration);
                    }
                }
                else if (item.DocumentType == DocumentIngressDocumentType.Exception)
                {
                    liveMetricsBuffer.RecordException();
                }
                else
                {
                    Debug.WriteLine($"Unknown DocumentType: {item.DocumentType}");
                }
            }

            foreach (var metricPoint in liveMetricsBuffer.GetMetricPoints())
            {
                dataPoint.Metrics.Add(metricPoint);
            }

            foreach (var metricPoint in CollectPerfCounters())
            {
                dataPoint.Metrics.Add(metricPoint);
            }

            return dataPoint;
        }

        public IEnumerable<Models.MetricPoint> CollectPerfCounters()
        {
            // PERFORMANCE COUNTERS
            yield return new Models.MetricPoint
            {
                Name = LiveMetricConstants.MetricId.MemoryCommittedBytesMetricIdValue,
                Value = _performanceCounter_CommittedBytes.NextValue(),
                Weight = 1
            };

            yield return new Models.MetricPoint
            {
                Name = LiveMetricConstants.MetricId.ProcessorTimeMetricIdValue,
                Value = _performanceCounter_ProcessorTime.NextValue(),
                Weight = 1
            };
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
                catch (System.Exception ex)
                {
                    LiveMetricsExporterEventSource.Log.AccessingEnvironmentVariableFailedWarning(WebSiteEnvironmentVariable, ex);
                    return false;
                }
            }

            return s_isAzureWebApp;
        }
    }
}
