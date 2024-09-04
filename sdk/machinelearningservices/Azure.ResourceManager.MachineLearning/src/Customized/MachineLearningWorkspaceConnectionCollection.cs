// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.MachineLearning
{
    /// <summary>
    /// A class representing a collection of <see cref="MachineLearningWorkspaceConnectionResource"/> and their operations.
    /// Each <see cref="MachineLearningWorkspaceConnectionResource"/> in the collection will belong to the same instance of <see cref="MachineLearningWorkspaceResource"/>.
    /// To get a <see cref="MachineLearningWorkspaceConnectionCollection"/> instance call the GetMachineLearningWorkspaceConnections method from an instance of <see cref="MachineLearningWorkspaceResource"/>.
    /// </summary>
    public partial class MachineLearningWorkspaceConnectionCollection : ArmCollection, IEnumerable<MachineLearningWorkspaceConnectionResource>, IAsyncEnumerable<MachineLearningWorkspaceConnectionResource>
    {
        /// <summary>
        /// Lists all the available machine learning workspaces connections under the specified workspace.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/connections</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkspaceConnections_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MachineLearningWorkspaceConnectionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="target"> Target of the workspace connection. </param>
        /// <param name="category"> Category of the workspace connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="MachineLearningWorkspaceConnectionResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<MachineLearningWorkspaceConnectionResource> GetAllAsync(string target, string category, CancellationToken cancellationToken = default) => GetAllAsync(target, category, null, cancellationToken);

        /// <summary>
        /// Lists all the available machine learning workspaces connections under the specified workspace.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/connections</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkspaceConnections_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MachineLearningWorkspaceConnectionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="target"> Target of the workspace connection. </param>
        /// <param name="category"> Category of the workspace connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MachineLearningWorkspaceConnectionResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<MachineLearningWorkspaceConnectionResource> GetAll(string target, string category, CancellationToken cancellationToken = default) => GetAll(target, category, null, cancellationToken);
    }
}
