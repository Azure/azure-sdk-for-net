// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618 // This file intentionally exposes obsolete removed-type compatibility signatures.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Monitor.Models;

namespace Azure.ResourceManager.Monitor.Mocking
{
    public partial class MockableMonitorArmClient
    {
        /// <summary> Gets an object representing an <see cref="AlertRuleResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns an <see cref="AlertRuleResource"/> object. </returns>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AlertRuleResource GetAlertRuleResource(ResourceIdentifier id) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets an object representing a <see cref="DiagnosticSettingResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DiagnosticSettingResource"/> object. </returns>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual DiagnosticSettingResource GetDiagnosticSettingResource(ResourceIdentifier id) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets a collection of <see cref="DiagnosticSettingResource"/> objects within the specified scope. </summary>
        /// <param name="scope"> The scope of the resource collection to get. </param>
        /// <returns> Returns a collection of <see cref="DiagnosticSettingResource"/> objects. </returns>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual DiagnosticSettingCollection GetDiagnosticSettings(ResourceIdentifier scope) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets a diagnostic setting. </summary>
        /// <param name="scope"> The scope of the resource collection to get. </param>
        /// <param name="name"> The diagnostic setting name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The diagnostic setting resource. </returns>
        [Obsolete("This API is no longer supported.", false)]
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DiagnosticSettingResource> GetDiagnosticSetting(ResourceIdentifier scope, string name, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets a diagnostic setting. </summary>
        /// <param name="scope"> The scope of the resource collection to get. </param>
        /// <param name="name"> The diagnostic setting name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The diagnostic setting resource. </returns>
        [Obsolete("This API is no longer supported.", false)]
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<DiagnosticSettingResource>> GetDiagnosticSettingAsync(ResourceIdentifier scope, string name, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets an object representing a <see cref="DiagnosticSettingsCategoryResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DiagnosticSettingsCategoryResource"/> object. </returns>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual DiagnosticSettingsCategoryResource GetDiagnosticSettingsCategoryResource(ResourceIdentifier id) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets a collection of <see cref="DiagnosticSettingsCategoryResource"/> objects within the specified scope. </summary>
        /// <param name="scope"> The scope of the resource collection to get. </param>
        /// <returns> Returns a collection of <see cref="DiagnosticSettingsCategoryResource"/> objects. </returns>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual DiagnosticSettingsCategoryCollection GetDiagnosticSettingsCategories(ResourceIdentifier scope) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets a diagnostic settings category. </summary>
        /// <param name="scope"> The scope of the resource collection to get. </param>
        /// <param name="name"> The diagnostic settings category name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The diagnostic settings category resource. </returns>
        [Obsolete("This API is no longer supported.", false)]
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DiagnosticSettingsCategoryResource> GetDiagnosticSettingsCategory(ResourceIdentifier scope, string name, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets a diagnostic settings category. </summary>
        /// <param name="scope"> The scope of the resource collection to get. </param>
        /// <param name="name"> The diagnostic settings category name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The diagnostic settings category resource. </returns>
        [Obsolete("This API is no longer supported.", false)]
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<DiagnosticSettingsCategoryResource>> GetDiagnosticSettingsCategoryAsync(ResourceIdentifier scope, string name, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets an object representing a <see cref="MonitorWorkspaceResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="MonitorWorkspaceResource"/> object. </returns>
        [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual MonitorWorkspaceResource GetMonitorWorkspaceResource(ResourceIdentifier id) => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        /// <summary> Gets an object representing a <see cref="VmInsightsOnboardingStatusResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VmInsightsOnboardingStatusResource"/> object. </returns>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual VmInsightsOnboardingStatusResource GetVmInsightsOnboardingStatusResource(ResourceIdentifier id) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets an object representing a <see cref="VmInsightsOnboardingStatusResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <returns> Returns a <see cref="VmInsightsOnboardingStatusResource"/> object. </returns>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual VmInsightsOnboardingStatusResource GetVmInsightsOnboardingStatus(ResourceIdentifier scope) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets metric baselines for a resource. </summary>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<MonitorSingleMetricBaseline> GetMonitorMetricBaselines(ResourceIdentifier scope, ArmResourceGetMonitorMetricBaselinesOptions options, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets metric baselines for a resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This API is no longer supported.", false)]
        public virtual AsyncPageable<MonitorSingleMetricBaseline> GetMonitorMetricBaselinesAsync(ResourceIdentifier scope, ArmResourceGetMonitorMetricBaselinesOptions options, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

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
