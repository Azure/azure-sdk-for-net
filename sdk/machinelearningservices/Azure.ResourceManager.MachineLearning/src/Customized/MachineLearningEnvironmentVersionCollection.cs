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
    /// A class representing a collection of <see cref="MachineLearningEnvironmentVersionResource" /> and their operations.
    /// Each <see cref="MachineLearningEnvironmentVersionResource" /> in the collection will belong to the same instance of <see cref="MachineLearningEnvironmentContainerResource" />.
    /// To get a <see cref="MachineLearningEnvironmentVersionCollection" /> instance call the GetMachineLearningEnvironmentVersions method from an instance of <see cref="MachineLearningEnvironmentContainerResource" />.
    /// </summary>
    public partial class MachineLearningEnvironmentVersionCollection : ArmCollection, IEnumerable<MachineLearningEnvironmentVersionResource>, IAsyncEnumerable<MachineLearningEnvironmentVersionResource>
    {
        /// <summary>
        /// List versions.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/environments/{name}/versions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>EnvironmentVersions_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="orderBy"> Ordering of list. </param>
        /// <param name="top"> Maximum number of records to return. </param>
        /// <param name="skip"> Continuation token for pagination. </param>
        /// <param name="listViewType"> View type for including/excluding (for example) archived entities. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="MachineLearningEnvironmentVersionResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<MachineLearningEnvironmentVersionResource> GetAllAsync(string orderBy, int? top, string skip, MachineLearningListViewType? listViewType, CancellationToken cancellationToken)
            => GetAllAsync(orderBy, top, skip, listViewType, null, cancellationToken);

        /// <summary>
        /// List versions.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/environments/{name}/versions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>EnvironmentVersions_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="orderBy"> Ordering of list. </param>
        /// <param name="top"> Maximum number of records to return. </param>
        /// <param name="skip"> Continuation token for pagination. </param>
        /// <param name="listViewType"> View type for including/excluding (for example) archived entities. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MachineLearningEnvironmentVersionResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<MachineLearningEnvironmentVersionResource> GetAll(string orderBy, int? top, string skip, MachineLearningListViewType? listViewType, CancellationToken cancellationToken)
            => GetAll(orderBy, top, skip, listViewType, null, cancellationToken);
    }
}
