namespace Microsoft.Azure.Management.Resources
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using System.Linq;
    using System.Linq.Expressions;
    using Microsoft.Rest.Azure.OData;
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// ManagementLocksOperations operations.
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
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<ManagementLock>> CreateOrUpdateAtResourceGroupLevelWithHttpMessagesAsync(string resourceGroupName, string lockName, ManagementLock parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
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
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<ManagementLock>> CreateOrUpdateAtResourceLevelWithHttpMessagesAsync(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string lockName, ManagementLock parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
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
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse> DeleteAtResourceLevelWithHttpMessagesAsync(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string lockName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Create or update a management lock at the subscription level.
        /// </summary>
        /// <param name='lockName'>
        /// The name of lock.
        /// </param>
        /// <param name='parameters'>
        /// The management lock parameters.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<ManagementLock>> CreateOrUpdateAtSubscriptionLevelWithHttpMessagesAsync(string lockName, ManagementLock parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Deletes the management lock of a subscription.
        /// </summary>
        /// <param name='lockName'>
        /// The name of lock.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse> DeleteAtSubscriptionLevelWithHttpMessagesAsync(string lockName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets the management lock of a scope.
        /// </summary>
        /// <param name='lockName'>
        /// Name of the management lock.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<ManagementLock>> GetWithHttpMessagesAsync(string lockName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Deletes the management lock of a resource group.
        /// </summary>
        /// <param name='resourceGroup'>
        /// The resource group names.
        /// </param>
        /// <param name='lockName'>
        /// The name of lock.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse> DeleteAtResourceGroupLevelWithHttpMessagesAsync(string resourceGroup, string lockName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets all the management locks of a resource group.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Resource group name.
        /// </param>
        /// <param name='filter'>
        /// The filter to apply on the operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<Page<ManagementLock>>> ListAtResourceGroupLevelWithHttpMessagesAsync(string resourceGroupName, Expression<Func<ManagementLock, bool>> filter = default(Expression<Func<ManagementLock, bool>>), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
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
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<Page<ManagementLock>>> ListAtResourceLevelWithHttpMessagesAsync(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, Expression<Func<ManagementLock, bool>> filter = default(Expression<Func<ManagementLock, bool>>), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get a list of management locks at resource level or below.
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<Page<ManagementLock>>> ListNextWithHttpMessagesAsync(string nextLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets all the management locks of a subscription.
        /// </summary>
        /// <param name='filter'>
        /// The filter to apply on the operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<Page<ManagementLock>>> ListAtSubscriptionLevelWithHttpMessagesAsync(Expression<Func<ManagementLock, bool>> filter = default(Expression<Func<ManagementLock, bool>>), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets all the management locks of a resource group.
        /// </summary>
        /// <param name='nextPageLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<Page<ManagementLock>>> ListAtResourceGroupLevelNextWithHttpMessagesAsync(string nextPageLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets all the management locks of a resource or any level below
        /// resource.
        /// </summary>
        /// <param name='nextPageLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<Page<ManagementLock>>> ListAtResourceLevelNextWithHttpMessagesAsync(string nextPageLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get a list of management locks at resource level or below.
        /// </summary>
        /// <param name='nextPageLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<Page<ManagementLock>>> ListNextNextWithHttpMessagesAsync(string nextPageLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets all the management locks of a subscription.
        /// </summary>
        /// <param name='nextPageLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<Page<ManagementLock>>> ListAtSubscriptionLevelNextWithHttpMessagesAsync(string nextPageLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
