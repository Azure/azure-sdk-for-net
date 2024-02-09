// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.Filtering;
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
                StreamId = _streamId,
                Timestamp = DateTime.UtcNow, // Represents timestamp sample was created
                TransmissionTime = DateTime.UtcNow, // represents timestamp transmission was sent
                IsWebApp = IsWebAppRunningInAzure(),
                PerformanceCollectionSupported = true,
                // AI SDK relies on PerformanceCounter to collect CPU and Memory metrics.
                // Follow up with service team to get this removed for OTEL based live metrics.
                // TopCpuProcesses = null,
                // TODO: Configuration errors are thrown when filter is applied.
                // CollectionConfigurationErrors = null,
            };

            CollectionConfigurationError[] filteringErrors;
            string projectionError = string.Empty;
            Dictionary<string, AccumulatedValues> metricAccumulators = CreateMetricAccumulators(_collectionConfiguration);
            LiveMetricsBuffer liveMetricsBuffer = new();
            DocumentBuffer filledBuffer = _documentBuffer.FlipDocumentBuffers();
            foreach (var item in filledBuffer.ReadAllAndClear())
            {
                // TODO: item.DocumentStreamIds = new List<string> { "" }; - Will add the identifier for the specific filtering rules (if applicable). See also "matchingDocumentStreamIds" in AI SDK.

                dataPoint.Documents.Add(item);

                if (item is Request request)
                {
                    ApplyFilters(metricAccumulators, _collectionConfiguration.RequestMetrics, request, out filteringErrors, ref projectionError);
                    if (item.Extension_IsSuccess)
                    {
                        liveMetricsBuffer.RecordRequestSucceeded(item.Extension_Duration);
                    }
                    else
                    {
                        liveMetricsBuffer.RecordRequestFailed(item.Extension_Duration);
                    }
                }
                else if (item is RemoteDependency remoteDependency)
                {
                    ApplyFilters(metricAccumulators, _collectionConfiguration.DependencyMetrics, remoteDependency, out filteringErrors, ref projectionError);
                    if (item.Extension_IsSuccess)
                    {
                        liveMetricsBuffer.RecordDependencySucceeded(item.Extension_Duration);
                    }
                    else
                    {
                        liveMetricsBuffer.RecordDependencyFailed(item.Extension_Duration);
                    }
                }
                else if (item is Models.Exception exception)
                {
                    ApplyFilters(metricAccumulators, _collectionConfiguration.ExceptionMetrics, exception, out filteringErrors, ref projectionError);
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

            foreach (var metricPoint in CreateCalculatedMetrics(metricAccumulators))
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

        private static IEnumerable<MetricPoint> CreateCalculatedMetrics(Dictionary<string, AccumulatedValues> metricAccumulators)
        {
            var metrics = new List<MetricPoint>();

            foreach (AccumulatedValues metricAccumulatedValues in metricAccumulators.Values)
            {
                try
                {
                    MetricPoint metricPoint = new MetricPoint
                    {
                        Name = metricAccumulatedValues.MetricId,
                        Value = (float)metricAccumulatedValues.CalculateAggregation(out long count),
                        Weight = (int)count,
                    };

                    metrics.Add(metricPoint);
                }
                catch (System.Exception)
                {
                    // skip this metric
                    // TODO: log unknown error
                    // QuickPulseEventSource.Log.UnknownErrorEvent(e.ToString());
                }
            }

            return metrics;
        }

        private Dictionary<string, AccumulatedValues> CreateMetricAccumulators(CollectionConfiguration collectionConfiguration)
        {
            Dictionary<string, AccumulatedValues> metricAccumulators = new();

            // prepare the accumulators based on the collection configuration
            IEnumerable<Tuple<string, DerivedMetricInfoAggregation?>> allMetrics = collectionConfiguration.TelemetryMetadata;
            foreach (Tuple<string, DerivedMetricInfoAggregation?> metricId in allMetrics ?? Enumerable.Empty<Tuple<string, DerivedMetricInfoAggregation?>>())
            {
                var derivedMetricInfoAggregation = metricId.Item2;
                if (!derivedMetricInfoAggregation.HasValue)
                {
                    continue;
                }

                if (Enum.TryParse(derivedMetricInfoAggregation.ToString(), out AggregationType aggregationType))
                {
                    var accumulatedValues = new AccumulatedValues(metricId.Item1, aggregationType);

                    metricAccumulators.Add(metricId.Item1, accumulatedValues);
                }
            }
            return metricAccumulators;
        }

        private void ApplyFilters<TTelemetry>(
            Dictionary<string, AccumulatedValues> metricAccumulators,
            IEnumerable<DerivedMetric<TTelemetry>> metrics,
            TTelemetry telemetry,
            out CollectionConfigurationError[] filteringErrors,
            ref string projectionError)
        {
            filteringErrors = Array.Empty<CollectionConfigurationError>();

            foreach (DerivedMetric<TTelemetry> metric in metrics)
            {
                if (metric.CheckFilters(telemetry, out filteringErrors))
                {
                    // the telemetry document has passed the filters, count it in and project
                    try
                    {
                        double projection = metric.Project(telemetry);

                        metricAccumulators[metric.Id].AddValue(projection);
                    }
                    catch (System.Exception e)
                    {
                        // most likely the projection did not result in a value parsable by double.Parse()
                        projectionError = e.ToString();
                    }
                }
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
                    // can be read using regular mechanism and hence this method returns false for
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
