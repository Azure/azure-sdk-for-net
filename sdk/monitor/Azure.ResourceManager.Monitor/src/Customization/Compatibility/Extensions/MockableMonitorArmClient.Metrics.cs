// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Xml;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Monitor.Models;

namespace Azure.ResourceManager.Monitor.Mocking
{
    public partial class MockableMonitorArmClient
    {
        /// <summary> Gets metric baselines for a resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<MonitorSingleMetricBaseline> GetMonitorMetricBaselines(ResourceIdentifier scope, ArmResourceGetMonitorMetricBaselinesOptions options, CancellationToken cancellationToken = default)
            => GetMonitorMetricBaselines(
                scope,
                metricnames: options?.Metricnames,
                metricnamespace: options?.Metricnamespace,
                timespan: options?.Timespan,
                interval: options?.Interval,
                aggregation: options?.Aggregation,
                sensitivities: options?.Sensitivities,
                filter: options?.Filter,
                resultType: options?.ResultType,
                cancellationToken: cancellationToken);

        /// <summary> Gets metric baselines for a resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<MonitorSingleMetricBaseline> GetMonitorMetricBaselinesAsync(ResourceIdentifier scope, ArmResourceGetMonitorMetricBaselinesOptions options, CancellationToken cancellationToken = default)
            => GetMonitorMetricBaselinesAsync(
                scope,
                metricnames: options?.Metricnames,
                metricnamespace: options?.Metricnamespace,
                timespan: options?.Timespan,
                interval: options?.Interval,
                aggregation: options?.Aggregation,
                sensitivities: options?.Sensitivities,
                filter: options?.Filter,
                resultType: options?.ResultType,
                cancellationToken: cancellationToken);

        /// <summary> Gets metrics for a resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<MonitorMetric> GetMonitorMetrics(ResourceIdentifier scope, ArmResourceGetMonitorMetricsOptions options, CancellationToken cancellationToken = default)
        {
            var response = GetMonitorMetrics(
                scope,
                timespan: options?.Timespan,
                interval: FormatInterval(options?.Interval),
                metricnames: options?.Metricnames,
                aggregation: options?.Aggregation,
                top: options?.Top,
                orderby: options?.Orderby,
                filter: options?.Filter,
                resultType: options?.ResultType,
                metricnamespace: options?.Metricnamespace,
                autoAdjustTimegrain: options?.AutoAdjustTimegrain,
                validateDimensions: options?.ValidateDimensions,
                cancellationToken: cancellationToken);

            return Pageable<MonitorMetric>.FromPages(new[]
            {
                Page<MonitorMetric>.FromValues((IReadOnlyList<MonitorMetric>)response.Value.Value, null, response.GetRawResponse())
            });
        }

        /// <summary> Gets metrics for a resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<MonitorMetric> GetMonitorMetricsAsync(ResourceIdentifier scope, ArmResourceGetMonitorMetricsOptions options, CancellationToken cancellationToken = default)
            => new MonitorMetricsAsyncPageable(this, scope, options, cancellationToken);

        private static string FormatInterval(TimeSpan? interval)
            => interval.HasValue ? XmlConvert.ToString(interval.Value) : null;

        private sealed class MonitorMetricsAsyncPageable : AsyncPageable<MonitorMetric>
        {
            private readonly MockableMonitorArmClient _client;
            private readonly ResourceIdentifier _scope;
            private readonly ArmResourceGetMonitorMetricsOptions _options;
            private readonly CancellationToken _cancellationToken;

            public MonitorMetricsAsyncPageable(MockableMonitorArmClient client, ResourceIdentifier scope, ArmResourceGetMonitorMetricsOptions options, CancellationToken cancellationToken)
                : base(cancellationToken)
            {
                _client = client;
                _scope = scope;
                _options = options;
                _cancellationToken = cancellationToken;
            }

            public override async IAsyncEnumerable<Page<MonitorMetric>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                var response = await _client.GetMonitorMetricsAsync(
                    _scope,
                    timespan: _options?.Timespan,
                    interval: FormatInterval(_options?.Interval),
                    metricnames: _options?.Metricnames,
                    aggregation: _options?.Aggregation,
                    top: _options?.Top,
                    orderby: _options?.Orderby,
                    filter: _options?.Filter,
                    resultType: _options?.ResultType,
                    metricnamespace: _options?.Metricnamespace,
                    autoAdjustTimegrain: _options?.AutoAdjustTimegrain,
                    validateDimensions: _options?.ValidateDimensions,
                    cancellationToken: _cancellationToken).ConfigureAwait(false);

                yield return Page<MonitorMetric>.FromValues((IReadOnlyList<MonitorMetric>)response.Value.Value, null, response.GetRawResponse());
            }
        }
    }
}
