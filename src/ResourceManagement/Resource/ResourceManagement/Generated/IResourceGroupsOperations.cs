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
    public partial interface IResourceGroupsOperations
    {
        /// <summary>
        /// Get all of the resources under a subscription.
        /// </summary>
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
        Task<AzureOperationResponse<ResourceListResult>> ListResourcesWithOperationResponseAsync(string resourceGroupName, Expression<Func<GenericResourceExtendedFilter, bool>> filter = default(Expression<Func<GenericResourceExtendedFilter, bool>>), int? top = default(int?), CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Checks whether resource group exists.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group to check. The name is case
        /// insensitive.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<bool>> CheckExistenceWithOperationResponseAsync(string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Create a resource group.
        /// </summary>
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
        Task<AzureOperationResponse<ResourceGroupExtended>> CreateOrUpdateWithOperationResponseAsync(string resourceGroupName, ResourceGroup parameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Delete resource group and all of its resources.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group to be deleted. The name is case
        /// insensitive.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> DeleteWithOperationResponseAsync(string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Delete resource group and all of its resources.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group to be deleted. The name is case
        /// insensitive.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> BeginDeleteWithOperationResponseAsync(string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get a resource group.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group to get. The name is case
        /// insensitive.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<ResourceGroupExtended>> GetWithOperationResponseAsync(string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Resource groups can be updated through a simple PATCH operation to
        /// a group address. The format of the request is the same as that
        /// for creating a resource groups, though if a field is unspecified
        /// current value will be carried over.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group to be created or updated. The name
        /// is case insensitive.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the update state resource group service
        /// operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<ResourceGroupExtended>> PatchWithOperationResponseAsync(string resourceGroupName, ResourceGroup parameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets a collection of resource groups.
        /// </summary>
        /// <param name='filter'>
        /// The filter to apply on the operation.
        /// </param>
        /// <param name='top'>
        /// Query parameters. If null is passed returns all resource groups.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<ResourceGroupListResult>> ListWithOperationResponseAsync(Expression<Func<ResourceGroupExtendedFilter, bool>> filter = default(Expression<Func<ResourceGroupExtendedFilter, bool>>), int? top = default(int?), CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get all of the resources under a subscription.
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<ResourceListResult>> ListResourcesNextWithOperationResponseAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets a collection of resource groups.
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<ResourceGroupListResult>> ListNextWithOperationResponseAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));
    }
}
