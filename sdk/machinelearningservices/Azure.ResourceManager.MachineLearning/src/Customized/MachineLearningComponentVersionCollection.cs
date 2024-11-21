// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.MachineLearning.Models;

namespace Azure.ResourceManager.MachineLearning
{
    /// <summary>
    /// A class representing a collection of <see cref="MachineLearningComponentVersionResource" /> and their operations.
    /// Each <see cref="MachineLearningComponentVersionResource" /> in the collection will belong to the same instance of <see cref="MachineLearningComponentContainerResource" />.
    /// To get a <see cref="MachineLearningComponentVersionCollection" /> instance call the GetMachineLearningComponentVersions method from an instance of <see cref="MachineLearningComponentContainerResource" />.
    /// </summary>
    public partial class MachineLearningComponentVersionCollection : ArmCollection, IEnumerable<MachineLearningComponentVersionResource>, IAsyncEnumerable<MachineLearningComponentVersionResource>
    {
        /// <summary>
        /// List component versions.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/components/{name}/versions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ComponentVersions_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="orderBy"> Ordering of list. </param>
        /// <param name="skip"> Continuation token for pagination. </param>
        /// <param name="listViewType"> View type for including/excluding (for example) archived entities. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="MachineLearningComponentVersionResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<MachineLearningComponentVersionResource> GetAllAsync(string orderBy, string skip, MachineLearningListViewType? listViewType, CancellationToken cancellationToken)
            => GetAllAsync(orderBy, null, skip, listViewType, cancellationToken);

        /// <summary>
        /// List component versions.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/components/{name}/versions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ComponentVersions_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="orderBy"> Ordering of list. </param>
        /// <param name="skip"> Continuation token for pagination. </param>
        /// <param name="listViewType"> View type for including/excluding (for example) archived entities. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MachineLearningComponentVersionResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<MachineLearningComponentVersionResource> GetAll(string orderBy, string skip, MachineLearningListViewType? listViewType, CancellationToken cancellationToken)
            => GetAll(orderBy, null, skip, listViewType, cancellationToken);
    }
}
