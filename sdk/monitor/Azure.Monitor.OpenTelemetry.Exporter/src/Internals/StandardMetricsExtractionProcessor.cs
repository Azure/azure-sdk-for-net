// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal sealed class StandardMetricsExtractionProcessor : BaseProcessor<Activity>
    {
        private bool _disposed;
        private AzureMonitorResource? _resource;
        internal readonly MeterProvider? _meterProvider;
        private readonly Meter _meter;
        private readonly Histogram<double> _requestDuration;
        private readonly Histogram<double> _dependencyDuration;
        private readonly PerformanceCounter _performanceCounter;
        private readonly PerfCounterItemCounts _itemCounts;

        internal static readonly IReadOnlyDictionary<string, string> s_standardMetricNameMapping = new Dictionary<string, string>()
        {
            [StandardMetricConstants.RequestDurationInstrumentName] = StandardMetricConstants.RequestDurationMetricIdValue,
            [StandardMetricConstants.DependencyDurationInstrumentName] = StandardMetricConstants.DependencyDurationMetricIdValue,
            [PerfCounterConstants.ExceptionRateInstrumentName] = PerfCounterConstants.ExceptionRateMetricIdValue,
            [PerfCounterConstants.RequestRateInstrumentName] = PerfCounterConstants.RequestRateMetricIdValue,
            [PerfCounterConstants.ProcessCpuInstrumentName] = PerfCounterConstants.ProcessCpuMetricIdValue,
            [PerfCounterConstants.ProcessCpuNormalizedInstrumentName] = PerfCounterConstants.ProcessCpuNormalizedMetricIdValue,
            [PerfCounterConstants.ProcessPrivateBytesInstrumentName] = PerfCounterConstants.ProcessPrivateBytesMetricIdValue,
        };

        internal AzureMonitorResource? StandardMetricResource => _resource ??= ParentProvider?.GetResource().CreateAzureMonitorResource();

        internal StandardMetricsExtractionProcessor(AzureMonitorMetricExporter metricExporter, PerfCounterItemCounts itemCounts)
        {
            _meterProvider = Sdk.CreateMeterProviderBuilder()
                .AddMeter(StandardMetricConstants.StandardMetricMeterName)
                .AddMeter(PerfCounterConstants.PerfCounterMeterName)
                .AddReader(new PeriodicExportingMetricReader(metricExporter)
                { TemporalityPreference = MetricReaderTemporalityPreference.Delta })
                .Build();
            _meter = new Meter(StandardMetricConstants.StandardMetricMeterName);
            _itemCounts = itemCounts;
            _performanceCounter = new PerformanceCounter(_meterProvider, _itemCounts);
            _requestDuration = _meter.CreateHistogram<double>(StandardMetricConstants.RequestDurationInstrumentName);
            _dependencyDuration = _meter.CreateHistogram<double>(StandardMetricConstants.DependencyDurationInstrumentName);
            
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
            }
            if (activity.Kind == ActivityKind.Client || activity.Kind == ActivityKind.Internal || activity.Kind == ActivityKind.Producer)
            {
                if (_dependencyDuration.Enabled)
                {
                    activity.SetTag("_MS.ProcessedByMetricExtractors", "(Name: X,Ver:'1.1')");
                    ReportDependencyDurationMetric(activity);
                }
            }
            if (activity.Events != null)
            {
                foreach (ref readonly var @event in activity.EnumerateEvents())
                {
                    if (@event.Name == SemanticConventions.AttributeExceptionEventName)
                    {
                       _itemCounts.IncrementExceptionCount();
                    }
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
            _itemCounts.IncrementRequestCount();
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

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    try
                    {
                        _meterProvider?.Dispose();
                        _meter?.Dispose();
                        _performanceCounter?.Dispose();
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
