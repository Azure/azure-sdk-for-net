// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure;
using Azure.ResourceManager.MachineLearning.Models;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: preserve previous collection GetAll overload shapes.
    public partial class MachineLearningFeatureSetContainerCollection
    {
        // Customized: preserve options-object overloads from the previous generated SDK.
        /// <summary> List featurestore entity containers. <list type="bullet"> <item> <term> Request Path. </term> <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/featuresets. </description> </item> <item> <term> Operation Id. </term> <description> FeaturesetContainers_List. </description> </item> <item> <term> Default Api Version. </term> <description> 2026-03-15-preview. </description> </item> </list> </summary>
        public virtual AsyncPageable<MachineLearningFeatureSetContainerResource> GetAllAsync(MachineLearningFeatureSetContainerCollectionGetAllOptions options, CancellationToken cancellationToken = default)
            => GetAllAsync(options?.Skip, options?.Tags, options?.ListViewType, options?.PageSize, options?.Name, options?.Description, options?.CreatedBy, cancellationToken);

        // Customized: preserve options-object overloads from the previous generated SDK.
        /// <summary> List featurestore entity containers. <list type="bullet"> <item> <term> Request Path. </term> <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/featuresets. </description> </item> <item> <term> Operation Id. </term> <description> FeaturesetContainers_List. </description> </item> <item> <term> Default Api Version. </term> <description> 2026-03-15-preview. </description> </item> </list> </summary>
        public virtual Pageable<MachineLearningFeatureSetContainerResource> GetAll(MachineLearningFeatureSetContainerCollectionGetAllOptions options, CancellationToken cancellationToken = default)
            => GetAll(options?.Skip, options?.Tags, options?.ListViewType, options?.PageSize, options?.Name, options?.Description, options?.CreatedBy, cancellationToken);
    }
}
