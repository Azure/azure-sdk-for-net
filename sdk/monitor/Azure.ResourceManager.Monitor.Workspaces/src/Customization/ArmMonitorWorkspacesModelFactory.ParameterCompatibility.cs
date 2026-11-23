// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Monitor.Workspaces.Models
{
    [CodeGenSuppress(
        "MonitorWorkspaceProperties",
        typeof(string),
        typeof(MonitorWorkspaceMetrics),
        typeof(MonitorWorkspaceProvisioningState?),
        typeof(MonitorWorkspaceDefaultIngestionSettings),
        typeof(Uri),
        typeof(IEnumerable<MonitorWorkspacePrivateEndpointConnection>),
        typeof(MonitorWorkspacePublicNetworkAccess?),
        typeof(IEnumerable<DefaultActionGroupReference>))]
    public static partial class ArmMonitorWorkspacesModelFactory
    {
        /// <summary> Properties of an Azure Monitor Workspace. </summary>
        /// <param name="accountId"> The immutable Id of the Azure Monitor Workspace. This property is read-only. </param>
        /// <param name="metrics"> Properties related to the metrics container in the Azure Monitor Workspace. </param>
        /// <param name="provisioningState"> The provisioning state of the Azure Monitor Workspace. Set to Succeeded if everything is healthy. </param>
        /// <param name="defaultIngestionSettings"> The Data Collection Rule and Endpoint used for ingestion by default. </param>
        /// <param name="queryEndpoint"> The query endpoint for the Azure Monitor Workspace. </param>
        /// <param name="privateEndpointConnections"> List of private endpoint connections. </param>
        /// <param name="publicNetworkAccess"> Gets or sets allow or disallow public network access to Azure Monitor Workspace. </param>
        /// <param name="actionsDefaultActionGroups"> The default action groups associated with the Azure Monitor Workspace. </param>
        /// <returns> A new <see cref="global::Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProperties"/> instance for mocking. </returns>
        public static MonitorWorkspaceProperties MonitorWorkspaceProperties(
            string accountId = default,
            MonitorWorkspaceMetrics metrics = default,
            MonitorWorkspaceProvisioningState? provisioningState = default,
            MonitorWorkspaceDefaultIngestionSettings defaultIngestionSettings = default,
            Uri queryEndpoint = default,
            IEnumerable<MonitorWorkspacePrivateEndpointConnection> privateEndpointConnections = default,
            MonitorWorkspacePublicNetworkAccess? publicNetworkAccess = default,
            IEnumerable<DefaultActionGroupReference> actionsDefaultActionGroups = default)
        {
            privateEndpointConnections ??= new ChangeTrackingList<MonitorWorkspacePrivateEndpointConnection>();

            return new MonitorWorkspaceProperties(
                accountId,
                metrics,
                provisioningState,
                defaultIngestionSettings,
                queryEndpoint is null ? default : new AzureMonitorWorkspaceEndpoints(queryEndpoint, default),
                privateEndpointConnections.ToList(),
                publicNetworkAccess,
                actionsDefaultActionGroups is null
                    ? default
                    : new AzureMonitorWorkspaceActions(
                        (actionsDefaultActionGroups ?? new ChangeTrackingList<DefaultActionGroupReference>()).ToList(),
                        default),
                default);
        }

        /// <summary> Properties of an Azure Monitor Workspace. </summary>
        /// <param name="accountId"> The immutable Id of the Azure Monitor Workspace. This property is read-only. </param>
        /// <param name="metrics"> Properties related to the metrics container in the Azure Monitor Workspace. </param>
        /// <param name="provisioningState"> The provisioning state of the Azure Monitor Workspace. Set to Succeeded if everything is healthy. </param>
        /// <param name="defaultIngestionSettings"> The Data Collection Rule and Endpoint used for ingestion by default. </param>
        /// <param name="privateEndpointConnections"> List of private endpoint connections. </param>
        /// <returns> A new <see cref="global::Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MonitorWorkspaceProperties MonitorWorkspaceProperties<TPrivateEndpointConnections>(
            string accountId,
            MonitorWorkspaceMetrics metrics,
            MonitorWorkspaceProvisioningState? provisioningState,
            MonitorWorkspaceDefaultIngestionSettings defaultIngestionSettings,
            TPrivateEndpointConnections privateEndpointConnections)
            where TPrivateEndpointConnections : IEnumerable<MonitorWorkspacePrivateEndpointConnection>
        {
            return MonitorWorkspaceProperties(
                accountId,
                metrics,
                provisioningState,
                defaultIngestionSettings,
                privateEndpointConnections,
                default);
        }
    }
}
