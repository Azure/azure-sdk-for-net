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
        internal readonly bool _isAzureWebApp;

        private readonly int _processorCount = Environment.ProcessorCount;
        private readonly Process _process = Process.GetCurrentProcess();
        private DateTimeOffset _cachedCollectedTime = DateTimeOffset.MinValue;
        private long _cachedCollectedValue = 0;

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

            foreach (var metricPoint in CollectProcessMetrics())
            {
                dataPoint.Metrics.Add(metricPoint);
            }

            return dataPoint;
        }

        /// <remarks>
        /// <para>
        /// For Memory:
        /// <see href="https://learn.microsoft.com/dotnet/api/system.diagnostics.process.privatememorysize64"/>.
        /// "The amount of memory, in bytes, allocated for the associated process that cannot be shared with other processes.".
        /// </para>
        /// <para>
        /// For CPU:
        /// <see href="https://learn.microsoft.com/dotnet/api/system.diagnostics.process.totalprocessortime"/>.
        /// "A TimeSpan that indicates the amount of time that the associated process has spent utilizing the CPU. This value is the sum of the UserProcessorTime and the PrivilegedProcessorTime.".
        /// </para>
        /// </remarks>
        public IEnumerable<Models.MetricPoint> CollectProcessMetrics()
        {
            yield return new Models.MetricPoint
            {
                Name = LiveMetricConstants.MetricId.MemoryCommittedBytesMetricIdValue,
                Value = _process.PrivateMemorySize64,
                Weight = 1
            };

            if (TryCalculateCPUCounter(out var processorValue))
            {
                yield return new Models.MetricPoint
                {
                    Name = LiveMetricConstants.MetricId.ProcessorTimeMetricIdValue,
                    Value = Convert.ToSingle(processorValue),
                    Weight = 1
                };
            }
        }

        private void ResetCachedValues()
        {
            _cachedCollectedTime = DateTimeOffset.MinValue;
            _cachedCollectedValue = 0;
        }

        /// <summary>
        /// Calcualte the CPU usage as the diff between two ticks divided by the period of time, and then divided by the number of processors.
        /// <code>((change in ticks / period) / number of processors)</code>
        /// </summary>
        private bool TryCalculateCPUCounter(out double normalizedValue)
        {
            var previousCollectedValue = _cachedCollectedValue;
            var previousCollectedTime = _cachedCollectedTime;

            var recentCollectedValue = _cachedCollectedValue = _process.TotalProcessorTime.Ticks;
            var recentCollectedTime = _cachedCollectedTime = DateTimeOffset.UtcNow;

            double calculatedValue;

            if (previousCollectedTime == DateTimeOffset.MinValue)
            {
                Debug.WriteLine($"{nameof(TryCalculateCPUCounter)} DateTimeOffset.MinValue");
                normalizedValue = default;
                return false;
            }

            var period = recentCollectedTime.Ticks - previousCollectedTime.Ticks;
            if (period < 0)
            {
                // Not likely to happen but being safe here incase of clock issues in multi-core.
                LiveMetricsExporterEventSource.Log.ProcessCountersUnexpectedNegativeTimeSpan(
                    previousCollectedTime: previousCollectedTime.Ticks,
                    recentCollectedTime: recentCollectedTime.Ticks);
                Debug.WriteLine($"{nameof(TryCalculateCPUCounter)} period less than zero");
                normalizedValue = default;
                return false;
            }

            var diff = recentCollectedValue - previousCollectedValue;
            if (diff < 0)
            {
                LiveMetricsExporterEventSource.Log.ProcessCountersUnexpectedNegativeValue(
                    previousCollectedValue: previousCollectedValue,
                    recentCollectedValue: recentCollectedValue);
                Debug.WriteLine($"{nameof(TryCalculateCPUCounter)} diff less than zero");
                normalizedValue = default;
                return false;
            }

            period = period != 0 ? period : 1;
            calculatedValue = diff * 100.0 / period;
            normalizedValue = calculatedValue / _processorCount;
            LiveMetricsExporterEventSource.Log.ProcessCountersCpuCounter(
                period: previousCollectedValue,
                diffValue: recentCollectedValue,
                calculatedValue: calculatedValue,
                processorCount: _processorCount,
                normalizedValue: normalizedValue);
            return true;
        }
    }
}
