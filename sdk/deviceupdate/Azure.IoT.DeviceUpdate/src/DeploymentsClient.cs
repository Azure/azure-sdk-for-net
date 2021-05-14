// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.IoT.DeviceUpdate.Models;

namespace Azure.IoT.DeviceUpdate
{
    /// <summary>
    /// Deployment management service client.
    /// </summary>
    public partial class DeploymentsClient
    {
        protected DeploymentsClient()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeploymentsClient"/>.
        /// </summary>
        public DeploymentsClient(string accountEndpoint, string instanceId, TokenCredential credential)
            : this(accountEndpoint, instanceId, credential, new DeviceUpdateClientOptions())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeploymentsClient"/>.
        /// </summary>
        public DeploymentsClient(string accountEndpoint, string instanceId, TokenCredential credential, DeviceUpdateClientOptions options)
            : this(
                new ClientDiagnostics(options),
                HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, "6ee392c4-d339-4083-b04d-6b7947c6cf78/.default")),
                accountEndpoint,
                instanceId)
        {
        }

        /// <summary>
        /// Cancel active deployment.
        /// </summary>
        /// <param name="deploymentId">Deployment identifier.</param>
        /// <param name="cancellationToken">(Optional) The cancellation token to use.</param>
        /// <returns>
        /// The canceled deployment.
        /// </returns>
        public virtual async Task<Response<Deployment>> CancelDeploymentAsync(string deploymentId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DeploymentsClient.CancelDeployment");
            scope.Start();
            try
            {
                return await RestClient.CancelDeploymentAsync(deploymentId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Cancel active deployment.
        /// </summary>
        /// <param name="deploymentId">Deployment identifier.</param>
        /// <param name="cancellationToken">(Optional) The cancellation token to use.</param>
        /// <returns>
        /// The canceled deployment.
        /// </returns>
        public virtual Response<Deployment> CancelDeployment(string deploymentId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DeploymentsClient.CancelDeployment");
            scope.Start();
            try
            {
                return RestClient.CancelDeployment(deploymentId, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retry active deployment.
        /// </summary>
        /// <param name="deploymentId">Deployment identifier.</param>
        /// <param name="cancellationToken">(Optional) The cancellation token to use.</param>
        /// <returns>
        /// The retried deployment.
        /// </returns>
        public virtual async Task<Response<Deployment>> RetryDeploymentAsync(string deploymentId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DeploymentsClient.RetryDeployment");
            scope.Start();
            try
            {
                return await RestClient.RetryDeploymentAsync(deploymentId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retry active deployment.
        /// </summary>
        /// <param name="deploymentId">Deployment identifier.</param>
        /// <param name="cancellationToken">(Optional) The cancellation token to use.</param>
        /// <returns>
        /// The retried deployment.
        /// </returns>
        public virtual Response<Deployment> RetryDeployment(string deploymentId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DeploymentsClient.RetryDeployment");
            scope.Start();
            try
            {
                return RestClient.RetryDeployment(deploymentId, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
