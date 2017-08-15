// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Search.Fluent.SearchService.Update
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Search.Fluent;

    /// <summary>
    /// The stage of the Search service update allowing to modify the number of partitions used.
    /// </summary>
    public interface IWithPartitionCount 
    {
        /// <summary>
        /// Specifies the Partitions count of the Search service.
        /// </summary>
        /// <param name="count">The partitions count; Partitions allow for scaling of document counts as well as faster data ingestion by spanning your index over multiple Azure Search Units (applies to Standard tiers only).</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Search.Fluent.SearchService.Update.IUpdate WithPartitionCount(int count);
    }

    /// <summary>
    /// The stage of the Search service update allowing to modify the number of replicas used.
    /// </summary>
    public interface IWithReplicaCount 
    {
        /// <summary>
        /// Specifies the replicas count of the Search service.
        /// </summary>
        /// <param name="count">The replicas count; replicas distribute workloads across the service. You need 2 or more to support high availability (applies to Basic and Standard tiers only).</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Search.Fluent.SearchService.Update.IUpdate WithReplicaCount(int count);
    }

    /// <summary>
    /// The template for a Search service update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Search.Fluent.ISearchService>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Search.Fluent.SearchService.Update.IUpdate>,
        Microsoft.Azure.Management.Search.Fluent.SearchService.Update.IWithReplicaCount,
        Microsoft.Azure.Management.Search.Fluent.SearchService.Update.IWithPartitionCount
    {
    }
}