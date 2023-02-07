// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable // TODO: remove and fix errors

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal class StandardMetricsExtractionProcessor : BaseProcessor<Activity>
    {
        private bool _disposed;
        private AzureMonitorResource _resource;
        private readonly Meter _meter;
        private readonly Counter<double> _requestDuration;
        private readonly MeterProvider _meterprovider;

        private const string StandardMetricMeterName = "StandardMetricMeter";
        private const string RequestDurationMetricName = "RequestDurationStandardMetric";
        private const string RequestDurationStandardMetricName = "requests/duration";

        internal static readonly IReadOnlyDictionary<string, string> s_standardMetricNameMapping = new Dictionary<string, string>()
        {
            [RequestDurationMetricName] = RequestDurationStandardMetricName,
        };

        internal AzureMonitorResource StandardMetricResource => _resource ??= ParentProvider.GetResource().UpdateRoleNameAndInstance();

        public StandardMetricsExtractionProcessor(string connectionString)
        {
            _meter = new Meter(StandardMetricMeterName);
            _requestDuration = _meter.CreateCounter<double>(RequestDurationMetricName);
            _meterprovider = Sdk.CreateMeterProviderBuilder()
                .AddMeter(StandardMetricMeterName)
                .AddAzureMonitorMetricExporter(o => o.ConnectionString = connectionString)
                .Build();
        }

        public override void OnEnd(Activity activity)
        {
            activity.SetTag("_MS.ProcessedByMetricExtractors", "(Name: X,Ver:'1.1')");

            if (activity.Kind == ActivityKind.Server)
            {
                ReportRequestDurationMetric(activity, SemanticConventions.AttributeHttpStatusCode);
            }
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
            tags.Add(new KeyValuePair<string, object>("request/resultCode", statusCodeAttributeValue));
            tags.Add(new KeyValuePair<string, object>("_MS.MetricId", RequestDurationStandardMetricName));
            tags.Add(new KeyValuePair<string, object>("_MS.IsAutocollected", "True"));
            tags.Add(new KeyValuePair<string, object>("operation/synthetic", "False"));
            tags.Add(new KeyValuePair<string, object>("cloud/roleInstance", StandardMetricResource.RoleInstance));
            tags.Add(new KeyValuePair<string, object>("cloud/rolename", StandardMetricResource.RoleName));
            tags.Add(new KeyValuePair<string, object>("Request.Success", RequestData.isSuccess(activity, statusCodeAttributeValue, OperationType.Http)));

            // Report metric
            _requestDuration.Add(activity.Duration.TotalMilliseconds, tags);
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    try
                    {
                        _meterprovider.Dispose();
                        _meter.Dispose();
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
