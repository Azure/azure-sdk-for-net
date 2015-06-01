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
    public static partial class DeploymentOperationOperationsExtensions
    {
            /// <summary>
            /// Get a list of deployments operations.
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
            /// <param name='operationId'>
            /// Operation Id.
            /// </param>
            public static DeploymentOperation Get(this IDeploymentOperationOperations operations, string resourceGroupName, string deploymentName, string operationId)
            {
                return Task.Factory.StartNew(s => ((IDeploymentOperationOperations)s).GetAsync(resourceGroupName, deploymentName, operationId), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get a list of deployments operations.
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
            /// <param name='operationId'>
            /// Operation Id.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<DeploymentOperation> GetAsync( this IDeploymentOperationOperations operations, string resourceGroupName, string deploymentName, string operationId, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<DeploymentOperation> result = await operations.GetWithOperationResponseAsync(resourceGroupName, deploymentName, operationId, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets a list of deployments operations.
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
            /// <param name='top'>
            /// Query parameters.
            /// </param>
            public static DeploymentOperationsListResult List(this IDeploymentOperationOperations operations, string resourceGroupName, string deploymentName, int? top = default(int?))
            {
                return Task.Factory.StartNew(s => ((IDeploymentOperationOperations)s).ListAsync(resourceGroupName, deploymentName, top), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of deployments operations.
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
            /// <param name='top'>
            /// Query parameters.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<DeploymentOperationsListResult> ListAsync( this IDeploymentOperationOperations operations, string resourceGroupName, string deploymentName, int? top = default(int?), CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<DeploymentOperationsListResult> result = await operations.ListWithOperationResponseAsync(resourceGroupName, deploymentName, top, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets a list of deployments operations.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='nextLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            public static DeploymentOperationsListResult ListNext(this IDeploymentOperationOperations operations, string nextLink)
            {
                return Task.Factory.StartNew(s => ((IDeploymentOperationOperations)s).ListNextAsync(nextLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of deployments operations.
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
            public static async Task<DeploymentOperationsListResult> ListNextAsync( this IDeploymentOperationOperations operations, string nextLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<DeploymentOperationsListResult> result = await operations.ListNextWithOperationResponseAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
