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

    public static partial class DeploymentsOperationsExtensions
    {
            /// <summary>
            /// Cancel a currently running template deployment.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='deploymentName'>
            /// The name of the deployment.
            /// </param>
            public static void Cancel(this IDeploymentsOperations operations, string resourceGroupName, string deploymentName)
            {
                Task.Factory.StartNew(s => ((IDeploymentsOperations)s).CancelAsync(resourceGroupName, deploymentName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Cancel a currently running template deployment.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='deploymentName'>
            /// The name of the deployment.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task CancelAsync( this IDeploymentsOperations operations, string resourceGroupName, string deploymentName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.CancelWithHttpMessagesAsync(resourceGroupName, deploymentName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Validate a deployment template.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='deploymentName'>
            /// The name of the deployment.
            /// </param>
            /// <param name='parameters'>
            /// Deployment to validate.
            /// </param>
            public static DeploymentValidateResult Validate(this IDeploymentsOperations operations, string resourceGroupName, string deploymentName, Deployment parameters)
            {
                return Task.Factory.StartNew(s => ((IDeploymentsOperations)s).ValidateAsync(resourceGroupName, deploymentName, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Validate a deployment template.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
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
            public static async Task<DeploymentValidateResult> ValidateAsync( this IDeploymentsOperations operations, string resourceGroupName, string deploymentName, Deployment parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<DeploymentValidateResult> result = await operations.ValidateWithHttpMessagesAsync(resourceGroupName, deploymentName, parameters, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Create a named template deployment using a template.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='deploymentName'>
            /// The name of the deployment.
            /// </param>
            /// <param name='parameters'>
            /// Additional parameters supplied to the operation.
            /// </param>
            public static DeploymentExtended CreateOrUpdate(this IDeploymentsOperations operations, string resourceGroupName, string deploymentName, Deployment parameters)
            {
                return Task.Factory.StartNew(s => ((IDeploymentsOperations)s).CreateOrUpdateAsync(resourceGroupName, deploymentName, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Create a named template deployment using a template.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
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
            public static async Task<DeploymentExtended> CreateOrUpdateAsync( this IDeploymentsOperations operations, string resourceGroupName, string deploymentName, Deployment parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<DeploymentExtended> result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, deploymentName, parameters, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Get a deployment.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group to get. The name is case insensitive.
            /// </param>
            /// <param name='deploymentName'>
            /// The name of the deployment.
            /// </param>
            public static DeploymentExtended Get(this IDeploymentsOperations operations, string resourceGroupName, string deploymentName)
            {
                return Task.Factory.StartNew(s => ((IDeploymentsOperations)s).GetAsync(resourceGroupName, deploymentName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get a deployment.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group to get. The name is case insensitive.
            /// </param>
            /// <param name='deploymentName'>
            /// The name of the deployment.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<DeploymentExtended> GetAsync( this IDeploymentsOperations operations, string resourceGroupName, string deploymentName, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<DeploymentExtended> result = await operations.GetWithHttpMessagesAsync(resourceGroupName, deploymentName, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Get a list of deployments.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group to filter by. The name is case insensitive.
            /// </param>
            /// <param name='filter'>
            /// The filter to apply on the operation.
            /// </param>
            /// <param name='top'>
            /// Query parameters. If null is passed returns all deployments.
            /// </param>
            public static DeploymentListResult List(this IDeploymentsOperations operations, string resourceGroupName, Expression<Func<DeploymentExtendedFilter, bool>> filter = default(Expression<Func<DeploymentExtendedFilter, bool>>), int? top = default(int?))
            {
                return Task.Factory.StartNew(s => ((IDeploymentsOperations)s).ListAsync(resourceGroupName, filter, top), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get a list of deployments.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group to filter by. The name is case insensitive.
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
            public static async Task<DeploymentListResult> ListAsync( this IDeploymentsOperations operations, string resourceGroupName, Expression<Func<DeploymentExtendedFilter, bool>> filter = default(Expression<Func<DeploymentExtendedFilter, bool>>), int? top = default(int?), CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<DeploymentListResult> result = await operations.ListWithHttpMessagesAsync(resourceGroupName, filter, top, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Get a list of deployments.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='nextLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            public static DeploymentListResult ListNext(this IDeploymentsOperations operations, string nextLink)
            {
                return Task.Factory.StartNew(s => ((IDeploymentsOperations)s).ListNextAsync(nextLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get a list of deployments.
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
            public static async Task<DeploymentListResult> ListNextAsync( this IDeploymentsOperations operations, string nextLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<DeploymentListResult> result = await operations.ListNextWithHttpMessagesAsync(nextLink, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
