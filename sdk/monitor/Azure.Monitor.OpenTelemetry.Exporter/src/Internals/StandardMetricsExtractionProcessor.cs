// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable // TODO: remove and fix errors

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal class StandardMetricsExtractionProcessor : BaseProcessor<Activity>
    {
        private bool _disposed;
        private AzureMonitorResource _resource;
        private readonly Meter _meter;
        private readonly Histogram<double> _requestDuration;
        private readonly Histogram<double> _dependencyDuration;

        internal static readonly IReadOnlyDictionary<string, string> s_standardMetricNameMapping = new Dictionary<string, string>()
        {
            [StandardMetricConstants.RequestDurationInstrumentName] = StandardMetricConstants.RequestDurationMetricIdValue,
            [StandardMetricConstants.DependencyDurationInstrumentName] = StandardMetricConstants.DependencyDurationMetricIdValue,
        };

        internal AzureMonitorResource StandardMetricResource => _resource ??= ParentProvider.GetResource().UpdateRoleNameAndInstance();

        internal StandardMetricsExtractionProcessor()
        {
            _meter = new Meter(StandardMetricConstants.StandardMetricMeterName);
            _requestDuration = _meter.CreateHistogram<double>(StandardMetricConstants.RequestDurationInstrumentName);
            _dependencyDuration = _meter.CreateHistogram<double>(StandardMetricConstants.DependencyDurationInstrumentName);
        }

        public override void OnEnd(Activity activity)
        {
            if (activity.Kind == ActivityKind.Server)
            {
                if (_requestDuration.Enabled)
                {
                    activity.SetTag("_MS.ProcessedByMetricExtractors", "(Name: X,Ver:'1.1')");
                    ReportRequestDurationMetric(activity, SemanticConventions.AttributeHttpStatusCode);
                }
            }
            if (activity.Kind == ActivityKind.Client || activity.Kind == ActivityKind.Internal)
            {
                if (_dependencyDuration.Enabled)
                {
                    activity.SetTag("_MS.ProcessedByMetricExtractors", "(Name: X,Ver:'1.1')");
                    ReportDependencyDurationMetric(activity);
                }
            }

            // TODO: other activity kinds
        }

        private void ReportRequestDurationMetric(Activity activity, string statusCodeAttribute)
        {
            string statusCodeAttributeValue = null;
            foreach (var tag in activity.EnumerateTagObjects())
            {
                if (tag.Key == statusCodeAttribute)
                {
                    statusCodeAttributeValue = tag.Value.ToString();
                    break;
                }
            }

            TagList tags = default;
            tags.Add(new KeyValuePair<string, object>(StandardMetricConstants.RequestResultCodeKey, statusCodeAttributeValue));
            tags.Add(new KeyValuePair<string, object>(StandardMetricConstants.MetricIdKey, StandardMetricConstants.RequestDurationMetricIdValue));
            tags.Add(new KeyValuePair<string, object>(StandardMetricConstants.IsAutoCollectedKey, "True"));
            tags.Add(new KeyValuePair<string, object>(StandardMetricConstants.CloudRoleInstanceKey, StandardMetricResource.RoleInstance));
            tags.Add(new KeyValuePair<string, object>(StandardMetricConstants.CloudRoleNameKey, StandardMetricResource.RoleName));
            tags.Add(new KeyValuePair<string, object>(StandardMetricConstants.RequestSuccessKey, RequestData.isSuccess(activity, statusCodeAttributeValue, OperationType.Http)));

            // Report metric
            _requestDuration.Record(activity.Duration.TotalMilliseconds, tags);
        }

        private void ReportDependencyDurationMetric(Activity activity)
        {
            var monitorTags = TraceHelper.EnumerateActivityTags(activity);

            var dependencyTarget = monitorTags.MappedTags.GetDependencyTarget(monitorTags.activityType);

            var statusCode = AzMonList.GetTagValue(ref monitorTags.MappedTags, SemanticConventions.AttributeHttpStatusCode);

            var dependencyType = monitorTags.MappedTags.GetDependencyType(monitorTags.activityType);

            TagList tags = default;
            tags.Add(new KeyValuePair<string, object>(StandardMetricConstants.DependencyTargetKey, dependencyTarget));
            tags.Add(new KeyValuePair<string, object>(StandardMetricConstants.DependencyResultCodeKey, statusCode));
            tags.Add(new KeyValuePair<string, object>(StandardMetricConstants.MetricIdKey, StandardMetricConstants.DependencyDurationMetricIdValue));
            tags.Add(new KeyValuePair<string, object>(StandardMetricConstants.IsAutoCollectedKey, "True"));
            tags.Add(new KeyValuePair<string, object>(StandardMetricConstants.CloudRoleInstanceKey, StandardMetricResource.RoleInstance));
            tags.Add(new KeyValuePair<string, object>(StandardMetricConstants.CloudRoleNameKey, StandardMetricResource.RoleName));
            tags.Add(new KeyValuePair<string, object>(StandardMetricConstants.DependencySuccessKey, activity.Status != ActivityStatusCode.Error));
            tags.Add(new KeyValuePair<string, object>(StandardMetricConstants.DependencyTypeKey, dependencyType));

            // Report metric
            _dependencyDuration.Record(activity.Duration.TotalMilliseconds, tags);
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    try
                    {
                        _meter?.Dispose();
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
