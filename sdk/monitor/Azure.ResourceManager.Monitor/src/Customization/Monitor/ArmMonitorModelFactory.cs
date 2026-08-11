// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Monitor.Models;

namespace Azure.ResourceManager.Monitor.Models
{
#pragma warning disable CS0618 // This partial class intentionally exposes obsolete workspace-redirect compatibility members.
    public static partial class ArmMonitorModelFactory
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MonitorWorkspaceDefaultIngestionSettings"/>.
        /// </summary>
        /// <remarks>This API has moved to Azure.ResourceManager.Monitor.Workspaces.</remarks>
        [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        // TODO: Remove these compatibility parameter mappings after https://github.com/Azure/azure-sdk-for-net/issues/61815 is fixed.
        public static MonitorWorkspaceDefaultIngestionSettings MonitorWorkspaceDefaultIngestionSettings(ResourceIdentifier dataCollectionRuleResourceId, ResourceIdentifier dataCollectionEndpointResourceId)
            => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        /// <summary>
        /// Initializes a new instance of <see cref="MonitorWorkspaceIngestionSettings"/>.
        /// </summary>
        /// <remarks>This API has moved to Azure.ResourceManager.Monitor.Workspaces.</remarks>
        [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MonitorWorkspaceIngestionSettings MonitorWorkspaceIngestionSettings(ResourceIdentifier dataCollectionRuleResourceId, ResourceIdentifier dataCollectionEndpointResourceId)
            => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        /// <summary>
        /// Initializes a new instance of <see cref="MonitorWorkspaceMetricProperties"/>.
        /// </summary>
        /// <remarks>This API has moved to Azure.ResourceManager.Monitor.Workspaces.</remarks>
        [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MonitorWorkspaceMetricProperties MonitorWorkspaceMetricProperties(string prometheusQueryEndpoint, string internalId)
            => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        /// <summary>
        /// Initializes a new instance of <see cref="MonitorWorkspaceMetrics"/>.
        /// </summary>
        /// <remarks>This API has moved to Azure.ResourceManager.Monitor.Workspaces.</remarks>
        [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MonitorWorkspaceMetrics MonitorWorkspaceMetrics(string prometheusQueryEndpoint, string internalId)
            => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        /// <summary>
        /// Initializes a new instance of <see cref="MonitorWorkspacePrivateEndpointConnection"/>.
        /// </summary>
        /// <remarks>This API has moved to Azure.ResourceManager.Monitor.Workspaces.</remarks>
        [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MonitorWorkspacePrivateEndpointConnection MonitorWorkspacePrivateEndpointConnection(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IEnumerable<string> groupIds, ResourceIdentifier privateEndpointId, MonitorPrivateLinkServiceConnectionState connectionState, MonitorPrivateEndpointConnectionProvisioningState? provisioningState)
            => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        /// <summary>
        /// Initializes a new instance of <see cref="MonitorWorkspaceResourceData"/>.
        /// </summary>
        /// <remarks>This API has moved to Azure.ResourceManager.Monitor.Workspaces.</remarks>
        [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Monitor.MonitorWorkspaceResourceData MonitorWorkspaceResourceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ETag? etag, string accountId, MonitorWorkspaceMetrics metrics, MonitorProvisioningState? provisioningState, MonitorWorkspaceDefaultIngestionSettings defaultIngestionSettings, IEnumerable<MonitorWorkspacePrivateEndpointConnection> privateEndpointConnections, MonitorWorkspacePublicNetworkAccess? publicNetworkAccess)
            => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");
    }
#pragma warning restore CS0618
}
