using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;
using Microsoft.Azure.OData;
using System.Linq.Expressions;
using Microsoft.Azure;
using Microsoft.Azure.Management.Resources.Models;

namespace Microsoft.Azure.Management.Resources
{
    /// <summary>
    /// </summary>
    public partial interface IManagementLocksOperations
    {
        /// <summary>
        /// Create or update a management lock at the resource group level.
        /// </summary>
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
        Task<AzureOperationResponse<ManagementLockObject>> CreateOrUpdateAtResourceGroupLevelWithOperationResponseAsync(string resourceGroupName, string lockName, ManagementLockProperties parameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Create or update a management lock at the resource level or any
        /// level below resource.
        /// </summary>
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
        Task<AzureOperationResponse<ManagementLockObject>> CreateOrUpdateAtResourceLevelWithOperationResponseAsync(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string lockName, ManagementLockProperties parameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Deletes the management lock of a resource or any level below
        /// resource.
        /// </summary>
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
        Task<AzureOperationResponse> DeleteAtResourceLevelWithOperationResponseAsync(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string lockName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Create or update a management lock at the subscription level.
        /// </summary>
        /// <param name='lockName'>
        /// The name of lock.
        /// </param>
        /// <param name='parameters'>
        /// The management lock parameters.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<ManagementLockObject>> CreateOrUpdateAtSubscriptionLevelWithOperationResponseAsync(string lockName, ManagementLockProperties parameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Deletes the management lock of a subscription.
        /// </summary>
        /// <param name='lockName'>
        /// The name of lock.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> DeleteAtSubscriptionLevelWithOperationResponseAsync(string lockName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets the management lock of a scope.
        /// </summary>
        /// <param name='lockName'>
        /// Name of the management lock.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<ManagementLockObject>> GetWithOperationResponseAsync(string lockName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Deletes the management lock of a resource group.
        /// </summary>
        /// <param name='resourceGroup'>
        /// The resource group names.
        /// </param>
        /// <param name='lockName'>
        /// The name of lock.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> DeleteAtResourceGroupLevelWithOperationResponseAsync(string resourceGroup, string lockName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets all the management locks of a resource group.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Resource group name.
        /// </param>
        /// <param name='filter'>
        /// The filter to apply on the operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<ManagementLockListResult>> ListAtResourceGroupLevelWithOperationResponseAsync(string resourceGroupName, Expression<Func<ManagementLockObject, bool>> filter = default(Expression<Func<ManagementLockObject, bool>>), CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets all the management locks of a resource or any level below
        /// resource.
        /// </summary>
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
        Task<AzureOperationResponse<ManagementLockListResult>> ListAtResourceLevelWithOperationResponseAsync(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, Expression<Func<ManagementLockObject, bool>> filter = default(Expression<Func<ManagementLockObject, bool>>), CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get a list of management locks at resource level or below.
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<ManagementLockListResult>> ListNextWithOperationResponseAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets all the management locks of a subscription.
        /// </summary>
        /// <param name='filter'>
        /// The filter to apply on the operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<ManagementLockListResult>> ListAtSubscriptionLevelWithOperationResponseAsync(Expression<Func<ManagementLockObject, bool>> filter = default(Expression<Func<ManagementLockObject, bool>>), CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets all the management locks of a resource group.
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<ManagementLockListResult>> ListAtResourceGroupLevelNextWithOperationResponseAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets all the management locks of a resource or any level below
        /// resource.
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<ManagementLockListResult>> ListAtResourceLevelNextWithOperationResponseAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get a list of management locks at resource level or below.
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<ManagementLockListResult>> ListNextNextWithOperationResponseAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets all the management locks of a subscription.
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<ManagementLockListResult>> ListAtSubscriptionLevelNextWithOperationResponseAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));
    }
}
