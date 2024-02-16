// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.PerformanceCounters;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals
{
    /// <summary>
    /// This partial class encapsulates all the metrics that are tracked and reported to the Live Metrics service.
    /// </summary>
    internal partial class Manager
    {
        internal readonly DoubleBuffer _documentBuffer = new();
        internal bool? _isAzureWebApp = null;
        private IPerformanceCounterCollector? _performanceCounterCollector;

        public void InitializeMetrics(IPlatform platform)
        {
            _isAzureWebApp = !string.IsNullOrEmpty(platform.GetEnvironmentVariable(EnvironmentVariableConstants.WEBSITE_SITE_NAME));

            // TODO: ENABLE THIS AFTER IMPLEMENTING OTHER CLASSES
            // PerformanceCounterCollectorFactory.TryGetInstance(platform, _isAzureWebApp, out _performanceCounterCollector);
            _performanceCounterCollector = null;
        }

        public MonitoringDataPoint GetDataPoint()
        {
            var dataPoint = new MonitoringDataPoint
            {
                Version = SdkVersionUtils.s_sdkVersion.Truncate(SchemaConstants.Tags_AiInternalSdkVersion_MaxLength),
                InvariantVersion = 5,
                Instance = LiveMetricsResource?.RoleInstance ?? "UNKNOWN_INSTANCE",
                RoleName = LiveMetricsResource?.RoleName,
                MachineName = Environment.MachineName, // TODO: MOVE TO PLATFORM
                StreamId = _streamId,
                Timestamp = DateTime.UtcNow, // Represents timestamp sample was created
                TransmissionTime = DateTime.UtcNow, // represents timestamp transmission was sent
                IsWebApp = _isAzureWebApp,
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
                // TODO: Filtering would be taken into account here before adding a document to the dataPoint.
                // TODO: item.DocumentStreamIds = new List<string> { "" }; - Will add the identifier for the specific filtering rules (if applicable). See also "matchingDocumentStreamIds" in AI SDK.
                //TODO: Apply filters
                //foreach (CalculatedMetric<TTelemetry> metric in metrics)
                //    if (metric.CheckFilters(telemetry, out filteringErrors))

                dataPoint.Documents.Add(item);

                if (item.DocumentType == DocumentIngressDocumentType.Request)
                {
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

            if (_performanceCounterCollector != null)
            {
                foreach (var metricPoint in _performanceCounterCollector.Collect())
                {
                    dataPoint.Metrics.Add(metricPoint);
                }
            }

            return dataPoint;
        }
    }
}
