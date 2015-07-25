namespace Microsoft.Azure.Management.Resources
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using System.Linq.Expressions;
    using Microsoft.Rest.Azure;
    using Models;

    public static partial class DeploymentOperationsOperationsExtensions
    {
            /// <summary>
            /// Get a list of deployments operations.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
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
            public static DeploymentOperation Get(this IDeploymentOperationsOperations operations, string resourceGroupName, string deploymentName, string operationId)
            {
                return Task.Factory.StartNew(s => ((IDeploymentOperationsOperations)s).GetAsync(resourceGroupName, deploymentName, operationId), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get a list of deployments operations.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
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
            public static async Task<DeploymentOperation> GetAsync( this IDeploymentOperationsOperations operations, string resourceGroupName, string deploymentName, string operationId, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<DeploymentOperation> result = await operations.GetWithHttpMessagesAsync(resourceGroupName, deploymentName, operationId, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets a list of deployments operations.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
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
            public static Page<DeploymentOperation> List(this IDeploymentOperationsOperations operations, string resourceGroupName, string deploymentName, int? top = default(int?))
            {
                return Task.Factory.StartNew(s => ((IDeploymentOperationsOperations)s).ListAsync(resourceGroupName, deploymentName, top), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of deployments operations.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
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
            public static async Task<Page<DeploymentOperation>> ListAsync( this IDeploymentOperationsOperations operations, string resourceGroupName, string deploymentName, int? top = default(int?), CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<Page<DeploymentOperation>> result = await operations.ListWithHttpMessagesAsync(resourceGroupName, deploymentName, top, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets a list of deployments operations.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            public static Page<DeploymentOperation> ListNext(this IDeploymentOperationsOperations operations, string nextPageLink)
            {
                return Task.Factory.StartNew(s => ((IDeploymentOperationsOperations)s).ListNextAsync(nextPageLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of deployments operations.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<Page<DeploymentOperation>> ListNextAsync( this IDeploymentOperationsOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<Page<DeploymentOperation>> result = await operations.ListNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
