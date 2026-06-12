// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Monitor
{
    /// <summary> An Azure Monitor Workspace resource data. </summary>
    [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
    public partial class MonitorWorkspaceResourceData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of <see cref="MonitorWorkspaceResourceData"/>. </summary>
        /// <param name="location"> The location. </param>
        public MonitorWorkspaceResourceData(AzureLocation location) : base(location)
        {
        }
    }
}
