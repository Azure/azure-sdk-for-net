// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.ResourceManager.MachineLearning.Models;
using System.Threading;

namespace Azure.ResourceManager.MachineLearning
{
    public partial class MachineLearningModelVersionCollection
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
        public virtual AsyncPageable<MachineLearningModelVersionResource> GetAllAsync(string skip = null, string orderBy = null, int? top = null, string version = null, string description = null, int? offset = null, string tags = null, string properties = null, string feed = null, MachineLearningListViewType? listViewType = null, CancellationToken cancellationToken = default)
        {
            MachineLearningModelVersionCollectionGetAllOptions options = new MachineLearningModelVersionCollectionGetAllOptions();
            options.Skip = skip;
            options.OrderBy = orderBy;
            options.Top = top;
            options.Version = version;
            options.Description = description;
            options.Offset = offset;
            options.Tags = tags;
            options.Properties = properties;
            options.Feed = feed;
            options.ListViewType = listViewType;

            return GetAllAsync(options, cancellationToken);
        }

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
        public virtual Pageable<MachineLearningModelVersionResource> GetAll(string skip = null, string orderBy = null, int? top = null, string version = null, string description = null, int? offset = null, string tags = null, string properties = null, string feed = null, MachineLearningListViewType? listViewType = null, CancellationToken cancellationToken = default)
        {
            MachineLearningModelVersionCollectionGetAllOptions options = new MachineLearningModelVersionCollectionGetAllOptions();
            options.Skip = skip;
            options.OrderBy = orderBy;
            options.Top = top;
            options.Version = version;
            options.Description = description;
            options.Offset = offset;
            options.Tags = tags;
            options.Properties = properties;
            options.Feed = feed;
            options.ListViewType = listViewType;

            return GetAll(options, cancellationToken);
        }
    }
}
