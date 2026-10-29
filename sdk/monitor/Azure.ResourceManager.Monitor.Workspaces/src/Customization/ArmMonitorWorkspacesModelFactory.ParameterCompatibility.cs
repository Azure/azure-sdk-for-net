// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Monitor.Workspaces.Models
{
    public static partial class ArmMonitorWorkspacesModelFactory
    {
        /// <summary> Properties of an Azure Monitor Workspace. </summary>
        /// <param name="accountId"> The immutable Id of the Azure Monitor Workspace. This property is read-only. </param>
        /// <param name="metrics"> Properties related to the metrics container in the Azure Monitor Workspace. </param>
        /// <param name="provisioningState"> The provisioning state of the Azure Monitor Workspace. Set to Succeeded if everything is healthy. </param>
        /// <param name="defaultIngestionSettings"> The Data Collection Rule and Endpoint used for ingestion by default. </param>
        /// <param name="privateEndpointConnections"> List of private endpoint connections. </param>
        /// <returns> A new <see cref="global::Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MonitorWorkspaceProperties MonitorWorkspaceProperties(
            string accountId,
            MonitorWorkspaceMetrics metrics,
            MonitorWorkspaceProvisioningState? provisioningState,
            MonitorWorkspaceDefaultIngestionSettings defaultIngestionSettings,
            IEnumerable<MonitorWorkspacePrivateEndpointConnection> privateEndpointConnections)
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
