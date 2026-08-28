// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure;
using Azure.ResourceManager.MachineLearning.Models;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: preserve previous collection GetAll overload shapes.
    public partial class MachineLearningWorkspaceConnectionCollection
    {
        // Customized: preserve the previous list overload shape.
        /// <summary> Lists all the available machine learning workspace connections under the specified workspace. <list type="bullet"> <item> <term> Request Path. </term> <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/connections. </description> </item> <item> <term> Operation Id. </term> <description> WorkspaceConnectionPropertiesV2BasicResources_List. </description> </item> <item> <term> Default Api Version. </term> <description> 2026-03-15-preview. </description> </item> </list> </summary>
        public virtual AsyncPageable<MachineLearningWorkspaceConnectionResource> GetAllAsync(string target, string category, CancellationToken cancellationToken)
            => GetAllAsync(target, category, default, cancellationToken);

        // Customized: preserve the previous list overload shape.
        /// <summary> Lists all the available machine learning workspace connections under the specified workspace. <list type="bullet"> <item> <term> Request Path. </term> <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/connections. </description> </item> <item> <term> Operation Id. </term> <description> WorkspaceConnectionPropertiesV2BasicResources_List. </description> </item> <item> <term> Default Api Version. </term> <description> 2026-03-15-preview. </description> </item> </list> </summary>
        public virtual Pageable<MachineLearningWorkspaceConnectionResource> GetAll(string target, string category, CancellationToken cancellationToken)
            => GetAll(target, category, default, cancellationToken);
    }
}
