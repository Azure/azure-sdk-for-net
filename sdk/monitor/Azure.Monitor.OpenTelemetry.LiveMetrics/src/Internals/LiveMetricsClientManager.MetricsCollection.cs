// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using System;
using System.Collections.Generic;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals;
using System.Diagnostics;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.Filtering;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.DataCollection;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals
{
    /// <summary>
    /// This partial class encapsulates all the metrics that are tracked and reported to the Live Metrics service.
    /// </summary>
    internal partial class LiveMetricsClientManager
    {
        internal readonly DoubleBuffer _documentBuffer = new();

        private readonly int _processorCount = Environment.ProcessorCount;
        private readonly Process _process = Process.GetCurrentProcess();
        private DateTimeOffset _cachedCollectedTime = DateTimeOffset.MinValue;
        private long _cachedCollectedValue = 0;

        public MonitoringDataPoint GetDataPoint()
        {
            var dataPoint = new MonitoringDataPoint(
                version: SdkVersionUtils.s_sdkVersion.Truncate(SchemaConstants.Tags_AiInternalSdkVersion_MaxLength),
                invariantVersion: 5,
                instance: LiveMetricsResource?.RoleInstance ?? "UNKNOWN_INSTANCE",
                roleName: LiveMetricsResource?.RoleName ?? "UNKNOWN_NAME",
                machineName: Environment.MachineName, // TODO: MOVE TO PLATFORM
                streamId: _streamId,
                isWebApp: false,
                performanceCollectionSupported: true)
            {
                Timestamp = DateTime.UtcNow, // Represents timestamp sample was created
                TransmissionTime = DateTime.UtcNow, // represents timestamp transmission was sent
                //TopCpuProcesses = null, // TODO
            };

            // TODO: Configuration errors are thrown when filter is applied.
            // CollectionConfigurationErrors = null,

            CollectionConfigurationError[] filteringErrors;
            string projectionError = string.Empty;
            Dictionary<string, AccumulatedValues> metricAccumulators = CreateMetricAccumulators(_collectionConfiguration);
            LiveMetricsBuffer liveMetricsBuffer = new();
            IEnumerable<DocumentStream> documentStreams = _collectionConfiguration.DocumentStreams;

            ConcurrentQueue<DocumentIngress> filledBuffer = _documentBuffer.FlipDocumentBuffers();
            while (filledBuffer.TryDequeue(out DocumentIngress? item))
            {
                bool matchesDocumentStreamFilter = false;

                CollectionConfigurationError[] groupErrors;

                if (item is Request request)
                {
                    matchesDocumentStreamFilter = UpdateTelemetryDocumentIfInterested(request,
                        documentStreams,
                        documentStream => documentStream.RequestQuotaTracker,
                        documentStream => documentStream.CheckFilters(request, out groupErrors));
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
                    matchesDocumentStreamFilter = UpdateTelemetryDocumentIfInterested(remoteDependency,
                        documentStreams,
                        documentStream => documentStream.DependencyQuotaTracker,
                        documentStream => documentStream.CheckFilters(remoteDependency, out groupErrors));
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
                    matchesDocumentStreamFilter = UpdateTelemetryDocumentIfInterested(exception,
                        documentStreams,
                        documentStream => documentStream.ExceptionQuotaTracker,
                        documentStream => documentStream.CheckFilters(exception, out groupErrors));
                    ApplyFilters(metricAccumulators, _collectionConfiguration.ExceptionMetrics, exception, out filteringErrors, ref projectionError);
                    liveMetricsBuffer.RecordException();
                }
                else if (item is Models.Trace trace)
                {
                    matchesDocumentStreamFilter = UpdateTelemetryDocumentIfInterested(trace,
                        documentStreams,
                        documentStream => documentStream.TraceQuotaTracker,
                        documentStream => documentStream.CheckFilters(trace, out groupErrors));
                    ApplyFilters(metricAccumulators, _collectionConfiguration.TraceMetrics, trace, out filteringErrors, ref projectionError);
                }
                else
                {
                    Debug.WriteLine($"Unknown DocumentType: {item.DocumentType}");
                }

                if (matchesDocumentStreamFilter)
                {
                    dataPoint.Documents.Add(item);
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
            _process.Refresh();

            // OLD METRIC NAME. TODO: Remove this after the UX is updated to use the new metrics
            yield return new Models.MetricPoint(name: LiveMetricConstants.MetricId.MemoryCommittedBytesMetricIdValue, value: _process.PrivateMemorySize64, weight: 1);

            yield return new Models.MetricPoint(name: LiveMetricConstants.MetricId.ProcessPhysicalBytesMetricIdValue, value: _process.PrivateMemorySize64, weight: 1);

            if (TryCalculateCPUCounter(out var processorValue))
            {
                // OLD METRIC NAME. TODO: Remove this after the UX is updated to use the new metrics
                yield return new Models.MetricPoint(name: LiveMetricConstants.MetricId.ProcessorTimeMetricIdValue, value: Convert.ToSingle(processorValue), weight: 1);

                yield return new Models.MetricPoint(name: LiveMetricConstants.MetricId.ProcessProcessorTimeNormalizedMetricIdValue, value: Convert.ToSingle(processorValue), weight: 1);
            }
        }

        private void ResetCachedValues()
        {
            _cachedCollectedTime = DateTimeOffset.MinValue;
            _cachedCollectedValue = 0;
        }

        private static IEnumerable<MetricPoint> CreateCalculatedMetrics(Dictionary<string, AccumulatedValues> metricAccumulators)
        {
            var metrics = new List<MetricPoint>();

            foreach (AccumulatedValues metricAccumulatedValues in metricAccumulators.Values)
            {
                try
                {
                    MetricPoint metricPoint = new MetricPoint(name: metricAccumulatedValues.MetricId, value: (float)metricAccumulatedValues.CalculateAggregation(out long count), weight: (int)count);
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
            IEnumerable<Tuple<string, AggregationType?>> allMetrics = collectionConfiguration.TelemetryMetadata;
            foreach (Tuple<string, AggregationType?> metricId in allMetrics)
            {
                var derivedMetricInfoAggregation = metricId.Item2;
                if (!derivedMetricInfoAggregation.HasValue)
                {
                    continue;
                }

                if (Enum.TryParse(derivedMetricInfoAggregation.ToString(), out AggregationTypeEnum aggregationType))
                {
                    var accumulatedValues = new AccumulatedValues(metricId.Item1, aggregationType);

                    metricAccumulators.Add(metricId.Item1, accumulatedValues);
                }
            }
            return metricAccumulators;
        }

        private void ApplyFilters<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] TTelemetry>(
            Dictionary<string, AccumulatedValues> metricAccumulators,
            IEnumerable<DerivedMetric<TTelemetry>> metrics,
            TTelemetry telemetry,
            out CollectionConfigurationError[] filteringErrors,
            ref string projectionError)
            where TTelemetry : DocumentIngress
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
                AzureMonitorLiveMetricsEventSource.Log.ProcessCountersUnexpectedNegativeTimeSpan(
                    previousCollectedTime: previousCollectedTime.Ticks,
                    recentCollectedTime: recentCollectedTime.Ticks);

                Debug.WriteLine($"{nameof(TryCalculateCPUCounter)} period less than zero");
                normalizedValue = default;
                return false;
            }

            var diff = recentCollectedValue - previousCollectedValue;
            if (diff < 0)
            {
                AzureMonitorLiveMetricsEventSource.Log.ProcessCountersUnexpectedNegativeValue(
                    previousCollectedValue: previousCollectedValue,
                    recentCollectedValue: recentCollectedValue);

                Debug.WriteLine($"{nameof(TryCalculateCPUCounter)} diff less than zero");
                normalizedValue = default;
                return false;
            }

            period = period != 0 ? period : 1;
            calculatedValue = diff * 100.0 / period;
            normalizedValue = calculatedValue / _processorCount;

            AzureMonitorLiveMetricsEventSource.Log.ProcessCountersCpuCounter(
                period: previousCollectedValue,
                diffValue: recentCollectedValue,
                calculatedValue: calculatedValue,
                processorCount: _processorCount,
                normalizedValue: normalizedValue);

            return true;
        }

        private bool UpdateTelemetryDocumentIfInterested(
            DocumentIngress telemetry,
            IEnumerable<DocumentStream> documentStreams,
            Func<DocumentStream, QuickPulseQuotaTracker> getQuotaTracker,
            Func<DocumentStream, bool> checkDocumentStreamFilters)
        {
            // check which document streams are interested in this telemetry
            var interested = false;

            foreach (DocumentStream matchingDocumentStream in documentStreams.Where(checkDocumentStreamFilters))
            {
                // for each interested document stream only let the document through if there's quota available for that stream
                if (getQuotaTracker(matchingDocumentStream).ApplyQuota())
                {
                    interested = true;

                    // this document stream is interested in this telemetry
                    telemetry.DocumentStreamIds.Add(matchingDocumentStream.Id);
                }
            }

            return interested;
        }
    }
}
