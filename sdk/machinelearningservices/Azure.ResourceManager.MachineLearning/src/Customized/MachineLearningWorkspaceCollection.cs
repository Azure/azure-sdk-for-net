// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure;
using Azure.ResourceManager.MachineLearning.Models;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: preserve previous collection GetAll overload shapes.
    public partial class MachineLearningWorkspaceCollection
    {
        // Customized: preserve the previous list overload shape.
        /// <summary> Lists all the available machine learning workspaces under the specified resource group. <list type="bullet"> <item> <term> Request Path. </term> <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces. </description> </item> <item> <term> Operation Id. </term> <description> Workspaces_ListByResourceGroup. </description> </item> <item> <term> Default Api Version. </term> <description> 2026-03-15-preview. </description> </item> </list> </summary>
        public virtual AsyncPageable<MachineLearningWorkspaceResource> GetAllAsync(string kind, CancellationToken cancellationToken)
            => GetAllAsync(kind, default, default, cancellationToken);

        // Customized: preserve the previous list overload shape.
        /// <summary> Lists all the available machine learning workspaces under the specified resource group. <list type="bullet"> <item> <term> Request Path. </term> <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces. </description> </item> <item> <term> Operation Id. </term> <description> Workspaces_ListByResourceGroup. </description> </item> <item> <term> Default Api Version. </term> <description> 2026-03-15-preview. </description> </item> </list> </summary>
        public virtual Pageable<MachineLearningWorkspaceResource> GetAll(string kind, CancellationToken cancellationToken)
            => GetAll(kind, default, default, cancellationToken);
    }
}
