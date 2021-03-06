// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Avs
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for ClustersOperations.
    /// </summary>
    public static partial class ClustersOperationsExtensions
    {
            /// <summary>
            /// List clusters in a private cloud
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='privateCloudName'>
            /// Name of the private cloud
            /// </param>
            public static IPage<Cluster> List(this IClustersOperations operations, string resourceGroupName, string privateCloudName)
            {
                return operations.ListAsync(resourceGroupName, privateCloudName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// List clusters in a private cloud
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='privateCloudName'>
            /// Name of the private cloud
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<Cluster>> ListAsync(this IClustersOperations operations, string resourceGroupName, string privateCloudName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListWithHttpMessagesAsync(resourceGroupName, privateCloudName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get a cluster by name in a private cloud
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='privateCloudName'>
            /// Name of the private cloud
            /// </param>
            /// <param name='clusterName'>
            /// Name of the cluster in the private cloud
            /// </param>
            public static Cluster Get(this IClustersOperations operations, string resourceGroupName, string privateCloudName, string clusterName)
            {
                return operations.GetAsync(resourceGroupName, privateCloudName, clusterName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get a cluster by name in a private cloud
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='privateCloudName'>
            /// Name of the private cloud
            /// </param>
            /// <param name='clusterName'>
            /// Name of the cluster in the private cloud
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Cluster> GetAsync(this IClustersOperations operations, string resourceGroupName, string privateCloudName, string clusterName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, privateCloudName, clusterName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Create or update a cluster in a private cloud
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='privateCloudName'>
            /// The name of the private cloud.
            /// </param>
            /// <param name='clusterName'>
            /// Name of the cluster in the private cloud
            /// </param>
            /// <param name='cluster'>
            /// A cluster in the private cloud
            /// </param>
            public static Cluster CreateOrUpdate(this IClustersOperations operations, string resourceGroupName, string privateCloudName, string clusterName, Cluster cluster)
            {
                return operations.CreateOrUpdateAsync(resourceGroupName, privateCloudName, clusterName, cluster).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Create or update a cluster in a private cloud
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='privateCloudName'>
            /// The name of the private cloud.
            /// </param>
            /// <param name='clusterName'>
            /// Name of the cluster in the private cloud
            /// </param>
            /// <param name='cluster'>
            /// A cluster in the private cloud
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Cluster> CreateOrUpdateAsync(this IClustersOperations operations, string resourceGroupName, string privateCloudName, string clusterName, Cluster cluster, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, privateCloudName, clusterName, cluster, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Update a cluster in a private cloud
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='privateCloudName'>
            /// Name of the private cloud
            /// </param>
            /// <param name='clusterName'>
            /// Name of the cluster in the private cloud
            /// </param>
            /// <param name='clusterUpdate'>
            /// The cluster properties to be updated
            /// </param>
            public static Cluster Update(this IClustersOperations operations, string resourceGroupName, string privateCloudName, string clusterName, ClusterUpdate clusterUpdate)
            {
                return operations.UpdateAsync(resourceGroupName, privateCloudName, clusterName, clusterUpdate).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Update a cluster in a private cloud
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='privateCloudName'>
            /// Name of the private cloud
            /// </param>
            /// <param name='clusterName'>
            /// Name of the cluster in the private cloud
            /// </param>
            /// <param name='clusterUpdate'>
            /// The cluster properties to be updated
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Cluster> UpdateAsync(this IClustersOperations operations, string resourceGroupName, string privateCloudName, string clusterName, ClusterUpdate clusterUpdate, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.UpdateWithHttpMessagesAsync(resourceGroupName, privateCloudName, clusterName, clusterUpdate, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Delete a cluster in a private cloud
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='privateCloudName'>
            /// Name of the private cloud
            /// </param>
            /// <param name='clusterName'>
            /// Name of the cluster in the private cloud
            /// </param>
            public static void Delete(this IClustersOperations operations, string resourceGroupName, string privateCloudName, string clusterName)
            {
                operations.DeleteAsync(resourceGroupName, privateCloudName, clusterName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Delete a cluster in a private cloud
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='privateCloudName'>
            /// Name of the private cloud
            /// </param>
            /// <param name='clusterName'>
            /// Name of the cluster in the private cloud
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteAsync(this IClustersOperations operations, string resourceGroupName, string privateCloudName, string clusterName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.DeleteWithHttpMessagesAsync(resourceGroupName, privateCloudName, clusterName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Create or update a cluster in a private cloud
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='privateCloudName'>
            /// The name of the private cloud.
            /// </param>
            /// <param name='clusterName'>
            /// Name of the cluster in the private cloud
            /// </param>
            /// <param name='cluster'>
            /// A cluster in the private cloud
            /// </param>
            public static Cluster BeginCreateOrUpdate(this IClustersOperations operations, string resourceGroupName, string privateCloudName, string clusterName, Cluster cluster)
            {
                return operations.BeginCreateOrUpdateAsync(resourceGroupName, privateCloudName, clusterName, cluster).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Create or update a cluster in a private cloud
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='privateCloudName'>
            /// The name of the private cloud.
            /// </param>
            /// <param name='clusterName'>
            /// Name of the cluster in the private cloud
            /// </param>
            /// <param name='cluster'>
            /// A cluster in the private cloud
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Cluster> BeginCreateOrUpdateAsync(this IClustersOperations operations, string resourceGroupName, string privateCloudName, string clusterName, Cluster cluster, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginCreateOrUpdateWithHttpMessagesAsync(resourceGroupName, privateCloudName, clusterName, cluster, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Update a cluster in a private cloud
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='privateCloudName'>
            /// Name of the private cloud
            /// </param>
            /// <param name='clusterName'>
            /// Name of the cluster in the private cloud
            /// </param>
            /// <param name='clusterUpdate'>
            /// The cluster properties to be updated
            /// </param>
            public static Cluster BeginUpdate(this IClustersOperations operations, string resourceGroupName, string privateCloudName, string clusterName, ClusterUpdate clusterUpdate)
            {
                return operations.BeginUpdateAsync(resourceGroupName, privateCloudName, clusterName, clusterUpdate).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Update a cluster in a private cloud
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='privateCloudName'>
            /// Name of the private cloud
            /// </param>
            /// <param name='clusterName'>
            /// Name of the cluster in the private cloud
            /// </param>
            /// <param name='clusterUpdate'>
            /// The cluster properties to be updated
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Cluster> BeginUpdateAsync(this IClustersOperations operations, string resourceGroupName, string privateCloudName, string clusterName, ClusterUpdate clusterUpdate, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginUpdateWithHttpMessagesAsync(resourceGroupName, privateCloudName, clusterName, clusterUpdate, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Delete a cluster in a private cloud
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='privateCloudName'>
            /// Name of the private cloud
            /// </param>
            /// <param name='clusterName'>
            /// Name of the cluster in the private cloud
            /// </param>
            public static void BeginDelete(this IClustersOperations operations, string resourceGroupName, string privateCloudName, string clusterName)
            {
                operations.BeginDeleteAsync(resourceGroupName, privateCloudName, clusterName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Delete a cluster in a private cloud
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='privateCloudName'>
            /// Name of the private cloud
            /// </param>
            /// <param name='clusterName'>
            /// Name of the cluster in the private cloud
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task BeginDeleteAsync(this IClustersOperations operations, string resourceGroupName, string privateCloudName, string clusterName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.BeginDeleteWithHttpMessagesAsync(resourceGroupName, privateCloudName, clusterName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// List clusters in a private cloud
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            public static IPage<Cluster> ListNext(this IClustersOperations operations, string nextPageLink)
            {
                return operations.ListNextAsync(nextPageLink).GetAwaiter().GetResult();
            }

            /// <summary>
            /// List clusters in a private cloud
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<Cluster>> ListNextAsync(this IClustersOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
