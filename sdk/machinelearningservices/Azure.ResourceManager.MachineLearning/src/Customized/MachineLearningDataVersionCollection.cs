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
    /// A class representing a collection of <see cref="MachineLearningDataVersionResource" /> and their operations.
    /// Each <see cref="MachineLearningDataVersionResource" /> in the collection will belong to the same instance of <see cref="MachineLearningDataContainerResource" />.
    /// To get a <see cref="MachineLearningDataVersionCollection" /> instance call the GetMachineLearningDataVersions method from an instance of <see cref="MachineLearningDataContainerResource" />.
    /// </summary>
    public partial class MachineLearningDataVersionCollection : ArmCollection, IEnumerable<MachineLearningDataVersionResource>, IAsyncEnumerable<MachineLearningDataVersionResource>
    {
        /// <summary>
        /// List data versions in the data container
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/data/{name}/versions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DataVersions_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="orderBy"> Please choose OrderBy value from ['createdtime', 'modifiedtime']. </param>
        /// <param name="skip"> Continuation token for pagination. </param>
        /// <param name="top">
        /// Top count of results, top count cannot be greater than the page size.
        ///                               If topCount &gt; page size, results with be default page size count will be returned
        /// </param>
        /// <param name="tags"> Comma-separated list of tag names (and optionally values). Example: tag1,tag2=value2. </param>
        /// <param name="listViewType"> [ListViewType.ActiveOnly, ListViewType.ArchivedOnly, ListViewType.All]View type for including/excluding (for example) archived entities. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="MachineLearningDataVersionResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<MachineLearningDataVersionResource> GetAllAsync(string orderBy, string skip, int? top, string tags, MachineLearningListViewType? listViewType, CancellationToken cancellationToken)
            => GetAllAsync(orderBy, top, skip, tags, listViewType, cancellationToken);

        /// <summary>
        /// List data versions in the data container
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/data/{name}/versions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DataVersions_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="orderBy"> Please choose OrderBy value from ['createdtime', 'modifiedtime']. </param>
        ///  <param name="skip"> Continuation token for pagination. </param>
        /// <param name="top">
        /// Top count of results, top count cannot be greater than the page size.
        ///                               If topCount &gt; page size, results with be default page size count will be returned
        /// </param>
        /// <param name="tags"> Comma-separated list of tag names (and optionally values). Example: tag1,tag2=value2. </param>
        /// <param name="listViewType"> [ListViewType.ActiveOnly, ListViewType.ArchivedOnly, ListViewType.All]View type for including/excluding (for example) archived entities. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MachineLearningDataVersionResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<MachineLearningDataVersionResource> GetAll(string orderBy, string skip, int? top, string tags, MachineLearningListViewType? listViewType, CancellationToken cancellationToken)
            => GetAll(orderBy, top, skip, tags, listViewType, cancellationToken);
    }
}
