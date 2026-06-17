// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618 // This file intentionally exposes obsolete removed-type compatibility signatures.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Monitor.Models;

namespace Azure.ResourceManager.Monitor.Mocking
{
    public partial class MockableMonitorResourceGroupResource
    {
        /// <summary> Gets a collection of <see cref="AlertRuleResource"/> objects in the resource group. </summary>
        /// <returns> Returns a collection of <see cref="AlertRuleResource"/> objects. </returns>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AlertRuleCollection GetAlertRules() => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets an alert rule. </summary>
        /// <param name="ruleName"> The rule name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The alert rule resource. </returns>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<AlertRuleResource> GetAlertRule(string ruleName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets an alert rule. </summary>
        /// <param name="ruleName"> The rule name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The alert rule resource. </returns>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<Response<AlertRuleResource>> GetAlertRuleAsync(string ruleName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets a collection of <see cref="MonitorWorkspaceResource"/> objects in the resource group. </summary>
        /// <returns> Returns a collection of <see cref="MonitorWorkspaceResource"/> objects. </returns>
        [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual MonitorWorkspaceResourceCollection GetMonitorWorkspaceResources() => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        /// <summary> Gets a MonitorWorkspace resource. </summary>
        /// <param name="azureMonitorWorkspaceName"> The Azure Monitor workspace name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The MonitorWorkspace resource. </returns>
        [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<MonitorWorkspaceResource> GetMonitorWorkspaceResource(string azureMonitorWorkspaceName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        /// <summary> Gets a MonitorWorkspace resource. </summary>
        /// <param name="azureMonitorWorkspaceName"> The Azure Monitor workspace name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The MonitorWorkspace resource. </returns>
        [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<Response<MonitorWorkspaceResource>> GetMonitorWorkspaceResourceAsync(string azureMonitorWorkspaceName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        /// <summary> Gets private link scope operation status. </summary>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<MonitorPrivateLinkScopeOperationStatus> GetPrivateLinkScopeOperationStatus(string asyncOperationId, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets private link scope operation status. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This API is no longer supported.", false)]
        public virtual Task<Response<MonitorPrivateLinkScopeOperationStatus>> GetPrivateLinkScopeOperationStatusAsync(string asyncOperationId, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");
    }
}
