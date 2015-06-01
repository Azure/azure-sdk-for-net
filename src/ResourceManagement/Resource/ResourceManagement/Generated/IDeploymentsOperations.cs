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
    public partial interface IDeploymentsOperations
    {
        /// <summary>
        /// Cancel a currently running template deployment.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name='deploymentName'>
        /// The name of the deployment.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> CancelWithOperationResponseAsync(string resourceGroupName, string deploymentName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Validate a deployment template.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name='deploymentName'>
        /// The name of the deployment.
        /// </param>
        /// <param name='parameters'>
        /// Deployment to validate.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<DeploymentValidateResponse>> ValidateWithOperationResponseAsync(string resourceGroupName, string deploymentName, Deployment parameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Create a named template deployment using a template.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name='deploymentName'>
        /// The name of the deployment.
        /// </param>
        /// <param name='parameters'>
        /// Additional parameters supplied to the operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<DeploymentExtended>> CreateOrUpdateWithOperationResponseAsync(string resourceGroupName, string deploymentName, Deployment parameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get a deployment.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group to get. The name is case
        /// insensitive.
        /// </param>
        /// <param name='deploymentName'>
        /// The name of the deployment.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<DeploymentExtended>> GetWithOperationResponseAsync(string resourceGroupName, string deploymentName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get a list of deployments.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group to filter by. The name is case
        /// insensitive.
        /// </param>
        /// <param name='filter'>
        /// The filter to apply on the operation.
        /// </param>
        /// <param name='top'>
        /// Query parameters. If null is passed returns all deployments.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<DeploymentListResult>> ListWithOperationResponseAsync(string resourceGroupName, Expression<Func<DeploymentExtendedFilter, bool>> filter = default(Expression<Func<DeploymentExtendedFilter, bool>>), int? top = default(int?), CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get a list of deployments.
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<DeploymentListResult>> ListNextWithOperationResponseAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));
    }
}
