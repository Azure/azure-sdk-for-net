// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Diagnostics.Tracing;
using System.Threading;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal sealed class StandardMetricsExtractionProcessor : BaseProcessor<Activity>
    {
        [ThreadStatic] private static bool t_handlingFirstChanceException;
        private bool _disposed;
        private AzureMonitorResource? _resource;

        internal readonly MeterProvider? _meterProvider;
        private readonly Meter _standardMetricMeter;
        private readonly Meter _perfCounterMeter;

        private readonly Histogram<double> _requestDuration;
        private readonly Histogram<double> _dependencyDuration;

        private readonly ObservableGauge<long> _processPrivateBytesGauge;
        private readonly ObservableGauge<double> _processCpuGauge;
        private readonly ObservableGauge<double> _processCpuNormalizedGauge;
        private readonly ObservableGauge<double> _requestRateGauge;
        private readonly ObservableGauge<double> _exceptionRateGauge;

        private readonly Process _process = Process.GetCurrentProcess();
        private readonly int _processorCount = Environment.ProcessorCount;
        private DateTimeOffset _cachedCollectedTime = DateTimeOffset.MinValue;
        private long _cachedCollectedValue = 0;

        private DateTimeOffset _lastCpuCalculationTime = DateTimeOffset.MinValue;
        private double _cachedRawCpuValue = 0;
        private double _cachedNormalizedCpuValue = 0;
        private bool _cpuCalculationValid = false;

        // Request rate tracking
        private long _requestCount = 0;
        private DateTimeOffset _lastRequestRateCalculationTime = DateTimeOffset.UtcNow;
        private long _lastRequestCount = 0;

        // Exception rate tracking
        private long _exceptionCount = 0;
        private DateTimeOffset _lastExceptionRateCalculationTime = DateTimeOffset.UtcNow;
        private long _lastExceptionCount = 0;

        internal static readonly IReadOnlyDictionary<string, string> s_standardMetricNameMapping = new Dictionary<string, string>()
        {
            [StandardMetricConstants.RequestDurationInstrumentName] = StandardMetricConstants.RequestDurationMetricIdValue,
            [StandardMetricConstants.DependencyDurationInstrumentName] = StandardMetricConstants.DependencyDurationMetricIdValue,

            [PerfCounterConstants.RequestRateInstrumentationName] = PerfCounterConstants.RequestRateMetricIdValue,
            [PerfCounterConstants.ProcessPrivateBytesInstrumentationName] = PerfCounterConstants.ProcessPrivateBytesMetricIdValue,
            [PerfCounterConstants.ExceptionRateName] = PerfCounterConstants.ExceptionRateMetricIdValue,
            [PerfCounterConstants.ProcessCpuInstrumentationName] = PerfCounterConstants.ProcessCpuMetricIdValue,
            [PerfCounterConstants.ProcessCpuNormalizedInstrumentationName] = PerfCounterConstants.ProcessCpuNormalizedMetricIdValue,
        };

        internal AzureMonitorResource? StandardMetricResource => _resource ??= ParentProvider?.GetResource().CreateAzureMonitorResource();

        internal StandardMetricsExtractionProcessor(AzureMonitorMetricExporter metricExporter)
        {
            _meterProvider = Sdk.CreateMeterProviderBuilder()
                .AddMeter(StandardMetricConstants.StandardMetricMeterName)
                .AddMeter(PerfCounterConstants.PerfCounterMeterName)
                .AddMeter("System.Runtime")
                .AddReader(new PeriodicExportingMetricReader(metricExporter)
                { TemporalityPreference = MetricReaderTemporalityPreference.Delta })
                .Build();

            _standardMetricMeter = new Meter(StandardMetricConstants.StandardMetricMeterName);
            _requestDuration = _standardMetricMeter.CreateHistogram<double>(StandardMetricConstants.RequestDurationInstrumentName);
            _dependencyDuration = _standardMetricMeter.CreateHistogram<double>(StandardMetricConstants.DependencyDurationInstrumentName);

            _perfCounterMeter = new Meter(PerfCounterConstants.PerfCounterMeterName);
            _requestRateGauge = _perfCounterMeter.CreateObservableGauge<double>(PerfCounterConstants.RequestRateInstrumentationName, () => GetRequestRate());
            _processPrivateBytesGauge = _perfCounterMeter.CreateObservableGauge<long>(PerfCounterConstants.ProcessPrivateBytesInstrumentationName, () => GetProcessPrivateBytes());
            _processCpuGauge = _perfCounterMeter.CreateObservableGauge<double>(PerfCounterConstants.ProcessCpuInstrumentationName, () => GetProcessCPU());
            _processCpuNormalizedGauge = _perfCounterMeter.CreateObservableGauge<double>(PerfCounterConstants.ProcessCpuNormalizedInstrumentationName, () => GetProcessCPUNormalized());
            _exceptionRateGauge = _perfCounterMeter.CreateObservableGauge<double>(PerfCounterConstants.ExceptionRateName, () => GetExceptionRate());

            AppDomain.CurrentDomain.FirstChanceException += (source, e) =>
            {
                // Avoid recursion if the listener itself throws an exception while recording the measurement
                // in its `OnMeasurementRecorded` callback.
                if (t_handlingFirstChanceException)
                    return;

                t_handlingFirstChanceException = true;

                // Increment exception count for rate calculation
                Interlocked.Increment(ref _exceptionCount);

                t_handlingFirstChanceException = false;
            };

            InitializeCpuBaseline();
        }

        public override void OnEnd(Activity activity)
        {
            if (activity.Kind == ActivityKind.Server || activity.Kind == ActivityKind.Consumer)
            {
                if (_requestDuration.Enabled)
                {
                    activity.SetTag("_MS.ProcessedByMetricExtractors", "(Name: X,Ver:'1.1')");
                    ReportRequestDurationMetric(activity);
                }

                // Increment request count for rate calculation
                Interlocked.Increment(ref _requestCount);
            }
            if (activity.Kind == ActivityKind.Client || activity.Kind == ActivityKind.Internal || activity.Kind == ActivityKind.Producer)
            {
                if (_dependencyDuration.Enabled)
                {
                    activity.SetTag("_MS.ProcessedByMetricExtractors", "(Name: X,Ver:'1.1')");
                    ReportDependencyDurationMetric(activity);
                }
            }
        }

        private void ReportRequestDurationMetric(Activity activity)
        {
            string? statusCodeAttributeValue = null;
            foreach (ref readonly var tag in activity.EnumerateTagObjects())
            {
                if (tag.Key == SemanticConventions.AttributeHttpResponseStatusCode || tag.Key == SemanticConventions.AttributeHttpStatusCode)
                {
                    statusCodeAttributeValue = tag.Value?.ToString();
                    break;
                }
            }

            TagList tags = default;
            tags.Add(new KeyValuePair<string, object?>(StandardMetricConstants.RequestResultCodeKey, statusCodeAttributeValue ?? "0"));
            tags.Add(new KeyValuePair<string, object?>(StandardMetricConstants.MetricIdKey, StandardMetricConstants.RequestDurationMetricIdValue));
            tags.Add(new KeyValuePair<string, object?>(StandardMetricConstants.IsAutoCollectedKey, "True"));
            tags.Add(new KeyValuePair<string, object?>(StandardMetricConstants.CloudRoleInstanceKey, StandardMetricResource?.RoleInstance));
            tags.Add(new KeyValuePair<string, object?>(StandardMetricConstants.CloudRoleNameKey, StandardMetricResource?.RoleName));
            tags.Add(new KeyValuePair<string, object?>(StandardMetricConstants.RequestSuccessKey, RequestData.IsSuccess(activity, statusCodeAttributeValue, OperationType.Http)));

            // Report metric
            _requestDuration.Record(activity.Duration.TotalMilliseconds, tags);
        }

        private void ReportDependencyDurationMetric(Activity activity)
        {
            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);

            string? dependencyTarget;
            string? statusCode;

            if (activityTagsProcessor.activityType.HasFlag(OperationType.V2))
            {
                // Reverting it for dependency type checks below
                activityTagsProcessor.activityType &= ~OperationType.V2;

                dependencyTarget = activityTagsProcessor.MappedTags.GetNewSchemaDependencyTarget(activityTagsProcessor.activityType);

                statusCode = AzMonList.GetTagValue(ref activityTagsProcessor.MappedTags, SemanticConventions.AttributeHttpResponseStatusCode)?.ToString();
            }
            else
            {
                dependencyTarget = activityTagsProcessor.MappedTags.GetDependencyTarget(activityTagsProcessor.activityType);

                statusCode = AzMonList.GetTagValue(ref activityTagsProcessor.MappedTags, SemanticConventions.AttributeHttpStatusCode)?.ToString();
            }

            string? dependencyType;
            if (activityTagsProcessor.AzureNamespace != null)
            {
                dependencyType = TraceHelper.GetAzureSDKDependencyType(activity.Kind, activityTagsProcessor.AzureNamespace);
            }
            else
            {
                dependencyType = activity.Kind == ActivityKind.Internal ? "InProc" : activityTagsProcessor.MappedTags.GetDependencyType(activityTagsProcessor.activityType);
            }

            TagList tags = default;
            tags.Add(new KeyValuePair<string, object?>(StandardMetricConstants.DependencyTargetKey, dependencyTarget));
            tags.Add(new KeyValuePair<string, object?>(StandardMetricConstants.DependencyResultCodeKey, statusCode ?? "0"));
            tags.Add(new KeyValuePair<string, object?>(StandardMetricConstants.MetricIdKey, StandardMetricConstants.DependencyDurationMetricIdValue));
            tags.Add(new KeyValuePair<string, object?>(StandardMetricConstants.IsAutoCollectedKey, "True"));
            tags.Add(new KeyValuePair<string, object?>(StandardMetricConstants.CloudRoleInstanceKey, StandardMetricResource?.RoleInstance));
            tags.Add(new KeyValuePair<string, object?>(StandardMetricConstants.CloudRoleNameKey, StandardMetricResource?.RoleName));
            tags.Add(new KeyValuePair<string, object?>(StandardMetricConstants.DependencySuccessKey, activity.Status != ActivityStatusCode.Error));
            tags.Add(new KeyValuePair<string, object?>(StandardMetricConstants.DependencyTypeKey, dependencyType));

            // Report metric
            _dependencyDuration.Record(activity.Duration.TotalMilliseconds, tags);

            activityTagsProcessor.Return();
        }

        private long GetProcessPrivateBytes()
        {
            try
            {
                return _process.PrivateMemorySize64;
            }
            catch (Exception ex)
            {
                // Log to event source.
                AzureMonitorExporterEventSource.Log.FailedToCollectProcessPrivateBytes(ex);
                return 0;
            }
        }

        private double GetProcessCPU()
        {
            EnsureCpuCalculation();
            return _cachedRawCpuValue;
        }

        private double GetProcessCPUNormalized()
        {
            EnsureCpuCalculation();
            return _cachedNormalizedCpuValue;
        }

        private double GetRequestRate()
        {
            try
            {
                var now = DateTimeOffset.UtcNow;
                var currentRequestCount = Interlocked.Read(ref _requestCount);

                // Calculate rate for the duration since last calculation
                var timeDifferenceSeconds = (now - _lastRequestRateCalculationTime).TotalSeconds;
                var requestDifference = currentRequestCount - _lastRequestCount;

                double currentRate = 0;
                if (timeDifferenceSeconds > 0)
                {
                    currentRate = requestDifference / timeDifferenceSeconds;
                }

                // Update for next calculation
                _lastRequestRateCalculationTime = now;
                _lastRequestCount = currentRequestCount;

                return Math.Max(0, currentRate);
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.FailedToCalculateRequestRate(ex);
                return 0;
            }
        }

        private double GetExceptionRate()
        {
            try
            {
                var now = DateTimeOffset.UtcNow;
                var currentExceptionCount = Interlocked.Read(ref _exceptionCount);

                // Calculate rate for the duration since last calculation
                var timeDifferenceSeconds = (now - _lastExceptionRateCalculationTime).TotalSeconds;
                var exceptionDifference = currentExceptionCount - _lastExceptionCount;

                double currentRate = 0;
                if (timeDifferenceSeconds > 0)
                {
                    currentRate = exceptionDifference / timeDifferenceSeconds;
                }

                // Update for next calculation
                _lastExceptionRateCalculationTime = now;
                _lastExceptionCount = currentExceptionCount;

                return Math.Max(0, currentRate);
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.FailedToCalculateExceptionRate(ex);
                return 0;
            }
        }

        private void EnsureCpuCalculation()
        {
            var now = DateTimeOffset.UtcNow;

            // Check if we need to recalculate (59-second cache to align with ~60-second collection intervals)
            if (!_cpuCalculationValid || (now - _lastCpuCalculationTime).TotalSeconds > 59)
            {
                try
                {
                    if (TryCalculateCPUCounter(out double rawValue, out double normalizedValue))
                    {
                        _cachedRawCpuValue = rawValue;
                        _cachedNormalizedCpuValue = normalizedValue;
                        _cpuCalculationValid = true;
                    }
                    else
                    {
                        _cachedRawCpuValue = 0;
                        _cachedNormalizedCpuValue = 0;
                        _cpuCalculationValid = false;
                    }
                }
                catch
                {
                    _cachedRawCpuValue = 0;
                    _cachedNormalizedCpuValue = 0;
                    _cpuCalculationValid = false;
                }

                _lastCpuCalculationTime = now;
            }
        }

        private bool TryCalculateCPUCounter(out double rawValue, out double normalizedValue)
        {
            var previousCollectedValue = _cachedCollectedValue;
            var previousCollectedTime = _cachedCollectedTime;

            // Refresh process data to get current CPU time
            _process.Refresh();

            var recentCollectedValue = _cachedCollectedValue = _process.TotalProcessorTime.Ticks;
            var recentCollectedTime = _cachedCollectedTime = DateTimeOffset.UtcNow;

            if (previousCollectedTime == DateTimeOffset.MinValue)
            {
                rawValue = default;
                normalizedValue = default;
                return false;
            }

            var period = recentCollectedTime.Ticks - previousCollectedTime.Ticks;
            if (period <= 0)
            {
                AzureMonitorExporterEventSource.Log.ProcessCountersUnexpectedNegativeTimeSpan(
                    previousCollectedTime: previousCollectedTime.Ticks,
                    recentCollectedTime: recentCollectedTime.Ticks);

                rawValue = default;
                normalizedValue = default;
                return false;
            }

            var diff = recentCollectedValue - previousCollectedValue;
            if (diff < 0)
            {
                AzureMonitorExporterEventSource.Log.ProcessCountersUnexpectedNegativeValue(
                    previousCollectedValue: previousCollectedValue,
                    recentCollectedValue: recentCollectedValue);

                rawValue = default;
                normalizedValue = default;
                return false;
            }

            // Calculate raw CPU percentage (can exceed 100% on multi-core systems)
            rawValue = (double)diff * 100.0 / period;

            // Calculate normalized CPU percentage (0-100%)
            normalizedValue = rawValue / _processorCount;

            // Clamp to reasonable bounds
            rawValue = Math.Max(0, Math.Min(100 * _processorCount, rawValue));
            normalizedValue = Math.Max(0, Math.Min(100, normalizedValue));

            AzureMonitorExporterEventSource.Log.ProcessCountersCpuCounter(
                period: period,
                diffValue: diff,
                calculatedValue: rawValue,
                processorCount: _processorCount,
                normalizedValue: normalizedValue);

            return true;
        }

        private void InitializeCpuBaseline()
        {
            try
            {
                _process.Refresh();
                _cachedCollectedValue = _process.TotalProcessorTime.Ticks;
                _cachedCollectedTime = DateTimeOffset.UtcNow;
            }
            catch
            {
                // If initialization fails, keep defaults and let first measurement be zero
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    try
                    {
                        _meterProvider?.Dispose();
                        _standardMetricMeter?.Dispose();
                        _perfCounterMeter?.Dispose();
                        _process?.Dispose();
                    }
                    catch (Exception)
                    {
                    }
                }

                _disposed = true;
            }

            base.Dispose(disposing);
        }
    }
}
