// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.MongoCluster.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.MongoCluster
{
    /// <summary>
    /// A class representing a MongoCluster along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="MongoClusterResource"/> from an instance of <see cref="ArmClient"/> using the GetResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource"/> using the GetMongoClusters method.
    /// </summary>
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetByParent", typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetByParentAsync", typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetByMongoCluster", typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetByMongoClusterAsync", typeof(CancellationToken))]
    public partial class MongoClusterResource : ArmResource
    {
        /// <summary>
        /// List all the replicas for the mongo cluster.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/mongoClusters/{mongoClusterName}/replicas. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Replicas_ListByParent. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-09-01. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="MongoClusterResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MongoClusterReplica"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<MongoClusterReplica> GetReplicasByParentAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new ReplicasGetByParentAsyncCollectionResultOfT(_replicasRestClient, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
        }

        /// <summary>
        /// List all the replicas for the mongo cluster.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/mongoClusters/{mongoClusterName}/replicas. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Replicas_ListByParent. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-09-01. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="MongoClusterResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MongoClusterReplica"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<MongoClusterReplica> GetReplicasByParent(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new ReplicasGetByParentCollectionResultOfT(_replicasRestClient, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
        }

        /// <summary>
        /// list private links on the given resource
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/mongoClusters/{mongoClusterName}/privateLinkResources. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> PrivateLinks_ListByMongoCluster. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-09-01. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="MongoClusterResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MongoClusterPrivateLinkResourceData"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<MongoClusterPrivateLinkResourceData> GetPrivateLinksAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PrivateLinksGetByMongoClusterAsyncCollectionResultOfT(_privateLinksRestClient, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
        }

        /// <summary>
        /// list private links on the given resource
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/mongoClusters/{mongoClusterName}/privateLinkResources. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> PrivateLinks_ListByMongoCluster. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-09-01. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="MongoClusterResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MongoClusterPrivateLinkResourceData"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<MongoClusterPrivateLinkResourceData> GetPrivateLinks(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PrivateLinksGetByMongoClusterCollectionResultOfT(_privateLinksRestClient, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
        }
    }
}
