// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.MachineLearning.Models;

namespace Azure.ResourceManager.MachineLearning
{
    /// <summary>
    /// A class representing a collection of <see cref="MachineLearningModelVersionResource" /> and their operations.
    /// Each <see cref="MachineLearningModelVersionResource" /> in the collection will belong to the same instance of <see cref="MachineLearningModelContainerResource" />.
    /// To get a <see cref="MachineLearningModelVersionCollection" /> instance call the GetMachineLearningModelVersions method from an instance of <see cref="MachineLearningModelContainerResource" />.
    /// </summary>
    public partial class MachineLearningModelVersionCollection : ArmCollection, IEnumerable<MachineLearningModelVersionResource>, IAsyncEnumerable<MachineLearningModelVersionResource>
    {
        /// <summary>
        /// List model versions.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/models/{name}/versions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ModelVersions_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="skip"> Continuation token for pagination. </param>
        /// <param name="orderBy"> Ordering of list. </param>
        /// <param name="top"> Maximum number of records to return. </param>
        /// <param name="version"> Model version. </param>
        /// <param name="description"> Model description. </param>
        /// <param name="offset"> Number of initial results to skip. </param>
        /// <param name="tags"> Comma-separated list of tag names (and optionally values). Example: tag1,tag2=value2. </param>
        /// <param name="properties"> Comma-separated list of property names (and optionally values). Example: prop1,prop2=value2. </param>
        /// <param name="feed"> Name of the feed. </param>
        /// <param name="listViewType"> View type for including/excluding (for example) archived entities. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="MachineLearningModelVersionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<MachineLearningModelVersionResource> GetAllAsync(string skip, string orderBy, int? top, string version, string description, int? offset, string tags, string properties, string feed, MachineLearningListViewType? listViewType, CancellationToken cancellationToken)
            => GetAllAsync(new MachineLearningModelVersionCollectionGetAllOptions() { Skip = skip, OrderBy = orderBy, Top = top, Version = version, Description = description, Offset = offset, Tags = tags, Properties = properties, Feed = feed, ListViewType = listViewType, Stage = null }, cancellationToken);

        /// <summary>
        /// List model versions.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/models/{name}/versions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ModelVersions_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="skip"> Continuation token for pagination. </param>
        /// <param name="orderBy"> Ordering of list. </param>
        /// <param name="top"> Maximum number of records to return. </param>
        /// <param name="version"> Model version. </param>
        /// <param name="description"> Model description. </param>
        /// <param name="offset"> Number of initial results to skip. </param>
        /// <param name="tags"> Comma-separated list of tag names (and optionally values). Example: tag1,tag2=value2. </param>
        /// <param name="properties"> Comma-separated list of property names (and optionally values). Example: prop1,prop2=value2. </param>
        /// <param name="feed"> Name of the feed. </param>
        /// <param name="listViewType"> View type for including/excluding (for example) archived entities. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MachineLearningModelVersionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<MachineLearningModelVersionResource> GetAll(string skip, string orderBy, int? top, string version, string description, int? offset, string tags, string properties, string feed, MachineLearningListViewType? listViewType, CancellationToken cancellationToken)
            => GetAll(new MachineLearningModelVersionCollectionGetAllOptions() { Skip = skip, OrderBy = orderBy, Top = top, Version = version, Description = description, Offset = offset, Tags = tags, Properties = properties, Feed = feed, ListViewType = listViewType, Stage = null }, cancellationToken);
    }
}
