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
    public static partial class ManagementLockOperationsExtensions
    {
            /// <summary>
            /// Create or update a management lock at the resource group level.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name.
            /// </param>
            /// <param name='lockName'>
            /// The lock name.
            /// </param>
            /// <param name='parameters'>
            /// The management lock parameters.
            /// </param>
            public static ManagementLockObject CreateOrUpdateAtResourceGroupLevel(this IManagementLockOperations operations, string resourceGroupName, string lockName, ManagementLockProperties parameters)
            {
                return Task.Factory.StartNew(s => ((IManagementLockOperations)s).CreateOrUpdateAtResourceGroupLevelAsync(resourceGroupName, lockName, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Create or update a management lock at the resource group level.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name.
            /// </param>
            /// <param name='lockName'>
            /// The lock name.
            /// </param>
            /// <param name='parameters'>
            /// The management lock parameters.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<ManagementLockObject> CreateOrUpdateAtResourceGroupLevelAsync( this IManagementLockOperations operations, string resourceGroupName, string lockName, ManagementLockProperties parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<ManagementLockObject> result = await operations.CreateOrUpdateAtResourceGroupLevelWithOperationResponseAsync(resourceGroupName, lockName, parameters, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Create or update a management lock at the resource level or any level
            /// below resource.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
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
            /// <param name='lockName'>
            /// The name of lock.
            /// </param>
            /// <param name='parameters'>
            /// Create or update management lock parameters.
            /// </param>
            public static ManagementLockObject CreateOrUpdateAtResourceLevel(this IManagementLockOperations operations, string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string lockName, ManagementLockProperties parameters)
            {
                return Task.Factory.StartNew(s => ((IManagementLockOperations)s).CreateOrUpdateAtResourceLevelAsync(resourceGroupName, resourceProviderNamespace, parentResourcePath, resourceType, resourceName, lockName, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Create or update a management lock at the resource level or any level
            /// below resource.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
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
            /// <param name='lockName'>
            /// The name of lock.
            /// </param>
            /// <param name='parameters'>
            /// Create or update management lock parameters.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<ManagementLockObject> CreateOrUpdateAtResourceLevelAsync( this IManagementLockOperations operations, string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string lockName, ManagementLockProperties parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<ManagementLockObject> result = await operations.CreateOrUpdateAtResourceLevelWithOperationResponseAsync(resourceGroupName, resourceProviderNamespace, parentResourcePath, resourceType, resourceName, lockName, parameters, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Deletes the management lock of a resource or any level below resource.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
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
            /// <param name='lockName'>
            /// The name of lock.
            /// </param>
            public static void DeleteAtResourceLevel(this IManagementLockOperations operations, string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string lockName)
            {
                Task.Factory.StartNew(s => ((IManagementLockOperations)s).DeleteAtResourceLevelAsync(resourceGroupName, resourceProviderNamespace, parentResourcePath, resourceType, resourceName, lockName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes the management lock of a resource or any level below resource.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
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
            /// <param name='lockName'>
            /// The name of lock.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task DeleteAtResourceLevelAsync( this IManagementLockOperations operations, string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string lockName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteAtResourceLevelWithOperationResponseAsync(resourceGroupName, resourceProviderNamespace, parentResourcePath, resourceType, resourceName, lockName, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Create or update a management lock at the subscription level.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='lockName'>
            /// The name of lock.
            /// </param>
            /// <param name='parameters'>
            /// The management lock parameters.
            /// </param>
            public static ManagementLockObject CreateOrUpdateAtSubscriptionLevel(this IManagementLockOperations operations, string lockName, ManagementLockProperties parameters)
            {
                return Task.Factory.StartNew(s => ((IManagementLockOperations)s).CreateOrUpdateAtSubscriptionLevelAsync(lockName, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Create or update a management lock at the subscription level.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='lockName'>
            /// The name of lock.
            /// </param>
            /// <param name='parameters'>
            /// The management lock parameters.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<ManagementLockObject> CreateOrUpdateAtSubscriptionLevelAsync( this IManagementLockOperations operations, string lockName, ManagementLockProperties parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<ManagementLockObject> result = await operations.CreateOrUpdateAtSubscriptionLevelWithOperationResponseAsync(lockName, parameters, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Deletes the management lock of a subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='lockName'>
            /// The name of lock.
            /// </param>
            public static void DeleteAtSubscriptionLevel(this IManagementLockOperations operations, string lockName)
            {
                Task.Factory.StartNew(s => ((IManagementLockOperations)s).DeleteAtSubscriptionLevelAsync(lockName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes the management lock of a subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='lockName'>
            /// The name of lock.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task DeleteAtSubscriptionLevelAsync( this IManagementLockOperations operations, string lockName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteAtSubscriptionLevelWithOperationResponseAsync(lockName, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Gets the management lock of a scope.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='lockName'>
            /// Name of the management lock.
            /// </param>
            public static ManagementLockObject Get(this IManagementLockOperations operations, string lockName)
            {
                return Task.Factory.StartNew(s => ((IManagementLockOperations)s).GetAsync(lockName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets the management lock of a scope.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='lockName'>
            /// Name of the management lock.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<ManagementLockObject> GetAsync( this IManagementLockOperations operations, string lockName, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<ManagementLockObject> result = await operations.GetWithOperationResponseAsync(lockName, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Deletes the management lock of a resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroup'>
            /// The resource group names.
            /// </param>
            /// <param name='lockName'>
            /// The name of lock.
            /// </param>
            public static void DeleteAtResourceGroupLevel(this IManagementLockOperations operations, string resourceGroup, string lockName)
            {
                Task.Factory.StartNew(s => ((IManagementLockOperations)s).DeleteAtResourceGroupLevelAsync(resourceGroup, lockName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes the management lock of a resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroup'>
            /// The resource group names.
            /// </param>
            /// <param name='lockName'>
            /// The name of lock.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task DeleteAtResourceGroupLevelAsync( this IManagementLockOperations operations, string resourceGroup, string lockName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteAtResourceGroupLevelWithOperationResponseAsync(resourceGroup, lockName, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Gets all the management locks of a resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// Resource group name.
            /// </param>
            /// <param name='filter'>
            /// The filter to apply on the operation.
            /// </param>
            public static ManagementLockListResult ListAtResourceGroupLevel(this IManagementLockOperations operations, string resourceGroupName, Expression<Func<ManagementLockObject, bool>> filter = default(Expression<Func<ManagementLockObject, bool>>))
            {
                return Task.Factory.StartNew(s => ((IManagementLockOperations)s).ListAtResourceGroupLevelAsync(resourceGroupName, filter), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets all the management locks of a resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// Resource group name.
            /// </param>
            /// <param name='filter'>
            /// The filter to apply on the operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<ManagementLockListResult> ListAtResourceGroupLevelAsync( this IManagementLockOperations operations, string resourceGroupName, Expression<Func<ManagementLockObject, bool>> filter = default(Expression<Func<ManagementLockObject, bool>>), CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<ManagementLockListResult> result = await operations.ListAtResourceGroupLevelWithOperationResponseAsync(resourceGroupName, filter, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets all the management locks of a resource or any level below resource.
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
            /// <param name='filter'>
            /// The filter to apply on the operation.
            /// </param>
            public static ManagementLockListResult ListAtResourceLevel(this IManagementLockOperations operations, string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, Expression<Func<ManagementLockObject, bool>> filter = default(Expression<Func<ManagementLockObject, bool>>))
            {
                return Task.Factory.StartNew(s => ((IManagementLockOperations)s).ListAtResourceLevelAsync(resourceGroupName, resourceProviderNamespace, parentResourcePath, resourceType, resourceName, filter), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets all the management locks of a resource or any level below resource.
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
            /// <param name='filter'>
            /// The filter to apply on the operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<ManagementLockListResult> ListAtResourceLevelAsync( this IManagementLockOperations operations, string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, Expression<Func<ManagementLockObject, bool>> filter = default(Expression<Func<ManagementLockObject, bool>>), CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<ManagementLockListResult> result = await operations.ListAtResourceLevelWithOperationResponseAsync(resourceGroupName, resourceProviderNamespace, parentResourcePath, resourceType, resourceName, filter, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Get a list of management locks at resource level or below.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='nextLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            public static ManagementLockListResult ListNext(this IManagementLockOperations operations, string nextLink)
            {
                return Task.Factory.StartNew(s => ((IManagementLockOperations)s).ListNextAsync(nextLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get a list of management locks at resource level or below.
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
            public static async Task<ManagementLockListResult> ListNextAsync( this IManagementLockOperations operations, string nextLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<ManagementLockListResult> result = await operations.ListNextWithOperationResponseAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets all the management locks of a subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='filter'>
            /// The filter to apply on the operation.
            /// </param>
            public static ManagementLockListResult ListAtSubscriptionLevel(this IManagementLockOperations operations, Expression<Func<ManagementLockObject, bool>> filter = default(Expression<Func<ManagementLockObject, bool>>))
            {
                return Task.Factory.StartNew(s => ((IManagementLockOperations)s).ListAtSubscriptionLevelAsync(filter), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets all the management locks of a subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='filter'>
            /// The filter to apply on the operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<ManagementLockListResult> ListAtSubscriptionLevelAsync( this IManagementLockOperations operations, Expression<Func<ManagementLockObject, bool>> filter = default(Expression<Func<ManagementLockObject, bool>>), CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<ManagementLockListResult> result = await operations.ListAtSubscriptionLevelWithOperationResponseAsync(filter, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets all the management locks of a resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='nextLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            public static ManagementLockListResult ListAtResourceGroupLevelNext(this IManagementLockOperations operations, string nextLink)
            {
                return Task.Factory.StartNew(s => ((IManagementLockOperations)s).ListAtResourceGroupLevelNextAsync(nextLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets all the management locks of a resource group.
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
            public static async Task<ManagementLockListResult> ListAtResourceGroupLevelNextAsync( this IManagementLockOperations operations, string nextLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<ManagementLockListResult> result = await operations.ListAtResourceGroupLevelNextWithOperationResponseAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets all the management locks of a resource or any level below resource.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='nextLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            public static ManagementLockListResult ListAtResourceLevelNext(this IManagementLockOperations operations, string nextLink)
            {
                return Task.Factory.StartNew(s => ((IManagementLockOperations)s).ListAtResourceLevelNextAsync(nextLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets all the management locks of a resource or any level below resource.
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
            public static async Task<ManagementLockListResult> ListAtResourceLevelNextAsync( this IManagementLockOperations operations, string nextLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<ManagementLockListResult> result = await operations.ListAtResourceLevelNextWithOperationResponseAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Get a list of management locks at resource level or below.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='nextLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            public static ManagementLockListResult ListNextNext(this IManagementLockOperations operations, string nextLink)
            {
                return Task.Factory.StartNew(s => ((IManagementLockOperations)s).ListNextNextAsync(nextLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get a list of management locks at resource level or below.
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
            public static async Task<ManagementLockListResult> ListNextNextAsync( this IManagementLockOperations operations, string nextLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<ManagementLockListResult> result = await operations.ListNextNextWithOperationResponseAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets all the management locks of a subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='nextLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            public static ManagementLockListResult ListAtSubscriptionLevelNext(this IManagementLockOperations operations, string nextLink)
            {
                return Task.Factory.StartNew(s => ((IManagementLockOperations)s).ListAtSubscriptionLevelNextAsync(nextLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets all the management locks of a subscription.
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
            public static async Task<ManagementLockListResult> ListAtSubscriptionLevelNextAsync( this IManagementLockOperations operations, string nextLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<ManagementLockListResult> result = await operations.ListAtSubscriptionLevelNextWithOperationResponseAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
