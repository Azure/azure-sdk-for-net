namespace Microsoft.Azure.Management.Resources
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using System.Linq.Expressions;
    using Microsoft.Azure;
    using Models;

    public static partial class ResourcesOperationsExtensions
    {
            /// <summary>
            /// Move resources within or across subscriptions.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='sourceResourceGroupName'>
            /// Source resource group name.
            /// </param>
            /// <param name='parameters'>
            /// move resources' parameters.
            /// </param>
            public static void MoveResources(this IResourcesOperations operations, string sourceResourceGroupName, ResourcesMoveInfo parameters)
            {
                Task.Factory.StartNew(s => ((IResourcesOperations)s).MoveResourcesAsync(sourceResourceGroupName, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Move resources within or across subscriptions.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='sourceResourceGroupName'>
            /// Source resource group name.
            /// </param>
            /// <param name='parameters'>
            /// move resources' parameters.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task MoveResourcesAsync( this IResourcesOperations operations, string sourceResourceGroupName, ResourcesMoveInfo parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.MoveResourcesWithOperationResponseAsync(sourceResourceGroupName, parameters, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Get all of the resources under a subscription.
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
            public static ResourceListResult List(this IResourcesOperations operations, Expression<Func<GenericResourceExtendedFilter, bool>> filter = default(Expression<Func<GenericResourceExtendedFilter, bool>>), int? top = default(int?))
            {
                return Task.Factory.StartNew(s => ((IResourcesOperations)s).ListAsync(filter, top), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get all of the resources under a subscription.
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
            public static async Task<ResourceListResult> ListAsync( this IResourcesOperations operations, Expression<Func<GenericResourceExtendedFilter, bool>> filter = default(Expression<Func<GenericResourceExtendedFilter, bool>>), int? top = default(int?), CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<ResourceListResult> result = await operations.ListWithOperationResponseAsync(filter, top, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Checks whether resource exists.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='resourceProviderNamespace'>
            /// Resource identity.
            /// </param>
            /// <param name='parentResourcePath'>
            /// Resource identity.
            /// </param>
            /// <param name='resourceType'>
            /// Resource identity.
            /// </param>
            /// <param name='resourceName'>
            /// Resource identity.
            /// </param>
            /// <param name='apiVersion'>
            /// </param>
            public static bool? CheckExistence(this IResourcesOperations operations, string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string apiVersion)
            {
                return Task.Factory.StartNew(s => ((IResourcesOperations)s).CheckExistenceAsync(resourceGroupName, resourceProviderNamespace, parentResourcePath, resourceType, resourceName, apiVersion), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Checks whether resource exists.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='resourceProviderNamespace'>
            /// Resource identity.
            /// </param>
            /// <param name='parentResourcePath'>
            /// Resource identity.
            /// </param>
            /// <param name='resourceType'>
            /// Resource identity.
            /// </param>
            /// <param name='resourceName'>
            /// Resource identity.
            /// </param>
            /// <param name='apiVersion'>
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<bool?> CheckExistenceAsync( this IResourcesOperations operations, string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string apiVersion, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<bool?> result = await operations.CheckExistenceWithOperationResponseAsync(resourceGroupName, resourceProviderNamespace, parentResourcePath, resourceType, resourceName, apiVersion, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Delete resource and all of its resources.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='resourceProviderNamespace'>
            /// Resource identity.
            /// </param>
            /// <param name='parentResourcePath'>
            /// Resource identity.
            /// </param>
            /// <param name='resourceType'>
            /// Resource identity.
            /// </param>
            /// <param name='resourceName'>
            /// Resource identity.
            /// </param>
            /// <param name='apiVersion'>
            /// </param>
            public static void Delete(this IResourcesOperations operations, string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string apiVersion)
            {
                Task.Factory.StartNew(s => ((IResourcesOperations)s).DeleteAsync(resourceGroupName, resourceProviderNamespace, parentResourcePath, resourceType, resourceName, apiVersion), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Delete resource and all of its resources.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='resourceProviderNamespace'>
            /// Resource identity.
            /// </param>
            /// <param name='parentResourcePath'>
            /// Resource identity.
            /// </param>
            /// <param name='resourceType'>
            /// Resource identity.
            /// </param>
            /// <param name='resourceName'>
            /// Resource identity.
            /// </param>
            /// <param name='apiVersion'>
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task DeleteAsync( this IResourcesOperations operations, string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string apiVersion, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteWithOperationResponseAsync(resourceGroupName, resourceProviderNamespace, parentResourcePath, resourceType, resourceName, apiVersion, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a resource.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='resourceProviderNamespace'>
            /// Resource identity.
            /// </param>
            /// <param name='parentResourcePath'>
            /// Resource identity.
            /// </param>
            /// <param name='resourceType'>
            /// Resource identity.
            /// </param>
            /// <param name='resourceName'>
            /// Resource identity.
            /// </param>
            /// <param name='apiVersion'>
            /// </param>
            /// <param name='parameters'>
            /// Create or update resource parameters.
            /// </param>
            public static GenericResourceExtended CreateOrUpdate(this IResourcesOperations operations, string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string apiVersion, GenericResource parameters)
            {
                return Task.Factory.StartNew(s => ((IResourcesOperations)s).CreateOrUpdateAsync(resourceGroupName, resourceProviderNamespace, parentResourcePath, resourceType, resourceName, apiVersion, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Create a resource.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='resourceProviderNamespace'>
            /// Resource identity.
            /// </param>
            /// <param name='parentResourcePath'>
            /// Resource identity.
            /// </param>
            /// <param name='resourceType'>
            /// Resource identity.
            /// </param>
            /// <param name='resourceName'>
            /// Resource identity.
            /// </param>
            /// <param name='apiVersion'>
            /// </param>
            /// <param name='parameters'>
            /// Create or update resource parameters.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<GenericResourceExtended> CreateOrUpdateAsync( this IResourcesOperations operations, string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string apiVersion, GenericResource parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<GenericResourceExtended> result = await operations.CreateOrUpdateWithOperationResponseAsync(resourceGroupName, resourceProviderNamespace, parentResourcePath, resourceType, resourceName, apiVersion, parameters, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Returns a resource belonging to a resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='resourceProviderNamespace'>
            /// Resource identity.
            /// </param>
            /// <param name='parentResourcePath'>
            /// Resource identity.
            /// </param>
            /// <param name='resourceType'>
            /// Resource identity.
            /// </param>
            /// <param name='resourceName'>
            /// Resource identity.
            /// </param>
            /// <param name='apiVersion'>
            /// </param>
            public static GenericResourceExtended Get(this IResourcesOperations operations, string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string apiVersion)
            {
                return Task.Factory.StartNew(s => ((IResourcesOperations)s).GetAsync(resourceGroupName, resourceProviderNamespace, parentResourcePath, resourceType, resourceName, apiVersion), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns a resource belonging to a resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='resourceProviderNamespace'>
            /// Resource identity.
            /// </param>
            /// <param name='parentResourcePath'>
            /// Resource identity.
            /// </param>
            /// <param name='resourceType'>
            /// Resource identity.
            /// </param>
            /// <param name='resourceName'>
            /// Resource identity.
            /// </param>
            /// <param name='apiVersion'>
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<GenericResourceExtended> GetAsync( this IResourcesOperations operations, string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string apiVersion, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<GenericResourceExtended> result = await operations.GetWithOperationResponseAsync(resourceGroupName, resourceProviderNamespace, parentResourcePath, resourceType, resourceName, apiVersion, cancellationToken).ConfigureAwait(false);
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
            public static ResourceListResult ListNext(this IResourcesOperations operations, string nextLink)
            {
                return Task.Factory.StartNew(s => ((IResourcesOperations)s).ListNextAsync(nextLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
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
            public static async Task<ResourceListResult> ListNextAsync( this IResourcesOperations operations, string nextLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<ResourceListResult> result = await operations.ListNextWithOperationResponseAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
