using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;
using System.Linq.Expressions;
using Microsoft.Azure;
using Microsoft.Azure.Management.Resources.Models;

namespace Microsoft.Azure.Management.Resources
{
    public static partial class ResourceGroupsOperationsExtensions
    {
            /// <summary>
            /// Get all of the resources under a subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// Query parameters. If null is passed returns all resource groups.
            /// </param>
            /// <param name='filter'>
            /// The filter to apply on the operation.
            /// </param>
            /// <param name='top'>
            /// Query parameters. If null is passed returns all resource groups.
            /// </param>
            public static ResourceListResult ListResources(this IResourceGroupsOperations operations, string resourceGroupName, Expression<Func<GenericResourceExtendedFilter, bool>> filter = default(Expression<Func<GenericResourceExtendedFilter, bool>>), int? top = default(int?))
            {
                return Task.Factory.StartNew(s => ((IResourceGroupsOperations)s).ListResourcesAsync(resourceGroupName, filter, top), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get all of the resources under a subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// Query parameters. If null is passed returns all resource groups.
            /// </param>
            /// <param name='filter'>
            /// The filter to apply on the operation.
            /// </param>
            /// <param name='top'>
            /// Query parameters. If null is passed returns all resource groups.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<ResourceListResult> ListResourcesAsync( this IResourceGroupsOperations operations, string resourceGroupName, Expression<Func<GenericResourceExtendedFilter, bool>> filter = default(Expression<Func<GenericResourceExtendedFilter, bool>>), int? top = default(int?), CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<ResourceListResult> result = await operations.ListResourcesWithOperationResponseAsync(resourceGroupName, filter, top, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Checks whether resource group exists.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group to check. The name is case insensitive.
            /// </param>
            public static bool? CheckExistence(this IResourceGroupsOperations operations, string resourceGroupName)
            {
                return Task.Factory.StartNew(s => ((IResourceGroupsOperations)s).CheckExistenceAsync(resourceGroupName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Checks whether resource group exists.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group to check. The name is case insensitive.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<bool?> CheckExistenceAsync( this IResourceGroupsOperations operations, string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<bool?> result = await operations.CheckExistenceWithOperationResponseAsync(resourceGroupName, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Create a resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group to be created or updated.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the create or update resource group service
            /// operation.
            /// </param>
            public static ResourceGroupExtended CreateOrUpdate(this IResourceGroupsOperations operations, string resourceGroupName, ResourceGroup parameters)
            {
                return Task.Factory.StartNew(s => ((IResourceGroupsOperations)s).CreateOrUpdateAsync(resourceGroupName, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Create a resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group to be created or updated.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the create or update resource group service
            /// operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<ResourceGroupExtended> CreateOrUpdateAsync( this IResourceGroupsOperations operations, string resourceGroupName, ResourceGroup parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<ResourceGroupExtended> result = await operations.CreateOrUpdateWithOperationResponseAsync(resourceGroupName, parameters, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Delete resource group and all of its resources.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group to be deleted. The name is case insensitive.
            /// </param>
            public static void Delete(this IResourceGroupsOperations operations, string resourceGroupName)
            {
                Task.Factory.StartNew(s => ((IResourceGroupsOperations)s).DeleteAsync(resourceGroupName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Delete resource group and all of its resources.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group to be deleted. The name is case insensitive.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task DeleteAsync( this IResourceGroupsOperations operations, string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteWithOperationResponseAsync(resourceGroupName, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete resource group and all of its resources.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group to be deleted. The name is case insensitive.
            /// </param>
            public static void BeginDelete(this IResourceGroupsOperations operations, string resourceGroupName)
            {
                Task.Factory.StartNew(s => ((IResourceGroupsOperations)s).BeginDeleteAsync(resourceGroupName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Delete resource group and all of its resources.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group to be deleted. The name is case insensitive.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task BeginDeleteAsync( this IResourceGroupsOperations operations, string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.BeginDeleteWithOperationResponseAsync(resourceGroupName, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Get a resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group to get. The name is case insensitive.
            /// </param>
            public static ResourceGroupExtended Get(this IResourceGroupsOperations operations, string resourceGroupName)
            {
                return Task.Factory.StartNew(s => ((IResourceGroupsOperations)s).GetAsync(resourceGroupName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get a resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group to get. The name is case insensitive.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<ResourceGroupExtended> GetAsync( this IResourceGroupsOperations operations, string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<ResourceGroupExtended> result = await operations.GetWithOperationResponseAsync(resourceGroupName, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Resource groups can be updated through a simple PATCH operation to a group
            /// address. The format of the request is the same as that for creating a
            /// resource groups, though if a field is unspecified current value will be
            /// carried over.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group to be created or updated. The name is case
            /// insensitive.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the update state resource group service operation.
            /// </param>
            public static ResourceGroupExtended Patch(this IResourceGroupsOperations operations, string resourceGroupName, ResourceGroup parameters)
            {
                return Task.Factory.StartNew(s => ((IResourceGroupsOperations)s).PatchAsync(resourceGroupName, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Resource groups can be updated through a simple PATCH operation to a group
            /// address. The format of the request is the same as that for creating a
            /// resource groups, though if a field is unspecified current value will be
            /// carried over.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group to be created or updated. The name is case
            /// insensitive.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the update state resource group service operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<ResourceGroupExtended> PatchAsync( this IResourceGroupsOperations operations, string resourceGroupName, ResourceGroup parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<ResourceGroupExtended> result = await operations.PatchWithOperationResponseAsync(resourceGroupName, parameters, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets a collection of resource groups.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='filter'>
            /// The filter to apply on the operation.
            /// </param>
            /// <param name='top'>
            /// Query parameters. If null is passed returns all resource groups.
            /// </param>
            public static ResourceGroupListResult List(this IResourceGroupsOperations operations, Expression<Func<ResourceGroupExtendedFilter, bool>> filter = default(Expression<Func<ResourceGroupExtendedFilter, bool>>), int? top = default(int?))
            {
                return Task.Factory.StartNew(s => ((IResourceGroupsOperations)s).ListAsync(filter, top), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a collection of resource groups.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='filter'>
            /// The filter to apply on the operation.
            /// </param>
            /// <param name='top'>
            /// Query parameters. If null is passed returns all resource groups.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<ResourceGroupListResult> ListAsync( this IResourceGroupsOperations operations, Expression<Func<ResourceGroupExtendedFilter, bool>> filter = default(Expression<Func<ResourceGroupExtendedFilter, bool>>), int? top = default(int?), CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<ResourceGroupListResult> result = await operations.ListWithOperationResponseAsync(filter, top, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Get all of the resources under a subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='nextLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            public static ResourceListResult ListResourcesNext(this IResourceGroupsOperations operations, string nextLink)
            {
                return Task.Factory.StartNew(s => ((IResourceGroupsOperations)s).ListResourcesNextAsync(nextLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get all of the resources under a subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='nextLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<ResourceListResult> ListResourcesNextAsync( this IResourceGroupsOperations operations, string nextLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<ResourceListResult> result = await operations.ListResourcesNextWithOperationResponseAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets a collection of resource groups.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='nextLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            public static ResourceGroupListResult ListNext(this IResourceGroupsOperations operations, string nextLink)
            {
                return Task.Factory.StartNew(s => ((IResourceGroupsOperations)s).ListNextAsync(nextLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a collection of resource groups.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='nextLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<ResourceGroupListResult> ListNextAsync( this IResourceGroupsOperations operations, string nextLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<ResourceGroupListResult> result = await operations.ListNextWithOperationResponseAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
