// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.ResourceManager.MachineLearning.Models;
using System.Threading;

namespace Azure.ResourceManager.MachineLearning
{
    public partial class MachineLearningOnlineEndpointCollection
    {
        /// <summary>
        /// List Online Endpoints.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/onlineEndpoints</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>OnlineEndpoints_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Name of the endpoint. </param>
        /// <param name="count"> Number of endpoints to be retrieved in a page of results. </param>
        /// <param name="computeType"> EndpointComputeType to be filtered by. </param>
        /// <param name="skip"> Continuation token for pagination. </param>
        /// <param name="tags"> A set of tags with which to filter the returned models. It is a comma separated string of tags key or tags key=value. Example: tagKey1,tagKey2,tagKey3=value3 . </param>
        /// <param name="properties"> A set of properties with which to filter the returned models. It is a comma separated string of properties key and/or properties key=value Example: propKey1,propKey2,propKey3=value3 . </param>
        /// <param name="orderBy"> The option to order the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="MachineLearningOnlineEndpointResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<MachineLearningOnlineEndpointResource> GetAllAsync(string name = null, int? count = null, MachineLearningEndpointComputeType? computeType = null, string skip = null, string tags = null, string properties = null, MachineLearningOrderString? orderBy = null, CancellationToken cancellationToken = default)
        {
            MachineLearningOnlineEndpointCollectionGetAllOptions options = new MachineLearningOnlineEndpointCollectionGetAllOptions();
            options.Name = name;
            options.Count = count;
            options.ComputeType = computeType;
            options.Skip = skip;
            options.Tags = tags;
            options.Properties = properties;
            options.OrderBy = orderBy;

            return GetAllAsync(options, cancellationToken);
        }

        /// <summary>
        /// List Online Endpoints.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/onlineEndpoints</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>OnlineEndpoints_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Name of the endpoint. </param>
        /// <param name="count"> Number of endpoints to be retrieved in a page of results. </param>
        /// <param name="computeType"> EndpointComputeType to be filtered by. </param>
        /// <param name="skip"> Continuation token for pagination. </param>
        /// <param name="tags"> A set of tags with which to filter the returned models. It is a comma separated string of tags key or tags key=value. Example: tagKey1,tagKey2,tagKey3=value3 . </param>
        /// <param name="properties"> A set of properties with which to filter the returned models. It is a comma separated string of properties key and/or properties key=value Example: propKey1,propKey2,propKey3=value3 . </param>
        /// <param name="orderBy"> The option to order the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MachineLearningOnlineEndpointResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<MachineLearningOnlineEndpointResource> GetAll(string name = null, int? count = null, MachineLearningEndpointComputeType? computeType = null, string skip = null, string tags = null, string properties = null, MachineLearningOrderString? orderBy = null, CancellationToken cancellationToken = default)
        {
            MachineLearningOnlineEndpointCollectionGetAllOptions options = new MachineLearningOnlineEndpointCollectionGetAllOptions();
            options.Name = name;
            options.Count = count;
            options.ComputeType = computeType;
            options.Skip = skip;
            options.Tags = tags;
            options.Properties = properties;
            options.OrderBy = orderBy;

            return GetAll(options, cancellationToken);
        }
    }
}
