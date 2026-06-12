// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
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
        public virtual AlertRuleResource GetAlertRuleResource(ResourceIdentifier id) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets an object representing a <see cref="DiagnosticSettingsCategoryResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DiagnosticSettingsCategoryResource"/> object. </returns>
        [Obsolete("This API is no longer supported.", false)]
        public virtual DiagnosticSettingsCategoryResource GetDiagnosticSettingsCategoryResource(ResourceIdentifier id) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets a collection of <see cref="DiagnosticSettingsCategoryResource"/> objects within the specified scope. </summary>
        /// <param name="scope"> The scope of the resource collection to get. </param>
        /// <returns> Returns a collection of <see cref="DiagnosticSettingsCategoryResource"/> objects. </returns>
        [Obsolete("This API is no longer supported.", false)]
        public virtual DiagnosticSettingsCategoryCollection GetDiagnosticSettingsCategories(ResourceIdentifier scope) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets a diagnostic settings category. </summary>
        /// <param name="scope"> The scope of the resource collection to get. </param>
        /// <param name="name"> The diagnostic settings category name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The diagnostic settings category resource. </returns>
        [Obsolete("This API is no longer supported.", false)]
        [ForwardsClientCalls]
        public virtual Response<DiagnosticSettingsCategoryResource> GetDiagnosticSettingsCategory(ResourceIdentifier scope, string name, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets a diagnostic settings category. </summary>
        /// <param name="scope"> The scope of the resource collection to get. </param>
        /// <param name="name"> The diagnostic settings category name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The diagnostic settings category resource. </returns>
        [Obsolete("This API is no longer supported.", false)]
        [ForwardsClientCalls]
        public virtual Task<Response<DiagnosticSettingsCategoryResource>> GetDiagnosticSettingsCategoryAsync(ResourceIdentifier scope, string name, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets an object representing a <see cref="MonitorWorkspaceResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="MonitorWorkspaceResource"/> object. </returns>
        [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
        public virtual MonitorWorkspaceResource GetMonitorWorkspaceResource(ResourceIdentifier id) => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        /// <summary> Gets an object representing a <see cref="VmInsightsOnboardingStatusResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VmInsightsOnboardingStatusResource"/> object. </returns>
        [Obsolete("This API is no longer supported.", false)]
        public virtual VmInsightsOnboardingStatusResource GetVmInsightsOnboardingStatusResource(ResourceIdentifier id) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets an object representing a <see cref="VmInsightsOnboardingStatusResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <returns> Returns a <see cref="VmInsightsOnboardingStatusResource"/> object. </returns>
        [Obsolete("This API is no longer supported.", false)]
        public virtual VmInsightsOnboardingStatusResource GetVmInsightsOnboardingStatus(ResourceIdentifier scope) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets metric baselines for a resource. </summary>
        public virtual Pageable<MonitorSingleMetricBaseline> GetMonitorMetricBaselines(ResourceIdentifier scope, ArmResourceGetMonitorMetricBaselinesOptions options, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets metric baselines for a resource. </summary>
        public virtual AsyncPageable<MonitorSingleMetricBaseline> GetMonitorMetricBaselinesAsync(ResourceIdentifier scope, ArmResourceGetMonitorMetricBaselinesOptions options, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets metrics for a resource. </summary>
        public virtual Pageable<MonitorMetric> GetMonitorMetrics(ResourceIdentifier scope, ArmResourceGetMonitorMetricsOptions options, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets metrics for a resource. </summary>
        public virtual AsyncPageable<MonitorMetric> GetMonitorMetricsAsync(ResourceIdentifier scope, ArmResourceGetMonitorMetricsOptions options, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");
    }
}
