// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.Projects
{
    public partial class AIProjectDeploymentsOperations
    {
        /// <summary>
        /// [Protocol Method] Get a deployed model.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Name of the deployment. </param>
        /// <param name="clientRequestId"> An opaque, globally-unique, client-generated string identifier for the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete as the clientRequestId parameter is not used. Please use GetDeployment(string name, RequestOptions options) instead.")]
        public virtual ClientResult GetDeployment(string name, string clientRequestId, RequestOptions options)
        {
            return GetDeployment(name, options);
        }

        /// <summary>
        /// [Protocol Method] Get a deployed model.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Name of the deployment. </param>
        /// <param name="clientRequestId"> An opaque, globally-unique, client-generated string identifier for the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete as the clientRequestId parameter is not used. Please use GetDeploymentAsync(string name, RequestOptions options) instead.")]
        public virtual async Task<ClientResult> GetDeploymentAsync(string name, string clientRequestId, RequestOptions options)
        {
            return await GetDeploymentAsync(name, options).ConfigureAwait(false);
        }

        /// <summary> Get a deployed model. </summary>
        /// <param name="name"> Name of the deployment. </param>
        /// <param name="clientRequestId"> An opaque, globally-unique, client-generated string identifier for the request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete as the clientRequestId parameter is not used. Please use GetDeploymentAsync(string name, CancellationToken cancellationToken) instead.")]
        public virtual ClientResult<AIProjectDeployment> GetDeployment(string name, string clientRequestId, CancellationToken cancellationToken)
        {
            return GetDeployment(name, cancellationToken);
        }

        /// <summary> Get a deployed model. </summary>
        /// <param name="name"> Name of the deployment. </param>
        /// <param name="clientRequestId"> An opaque, globally-unique, client-generated string identifier for the request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete as the clientRequestId parameter is not used. Please use GetDeploymentAsync(string name, CancellationToken cancellationToken) instead.")]
        public virtual async Task<ClientResult<AIProjectDeployment>> GetDeploymentAsync(string name, string clientRequestId, CancellationToken cancellationToken)
        {
            return await GetDeploymentAsync(name, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// [Protocol Method] List all deployed models in the project
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="modelPublisher"> Model publisher to filter models by. </param>
        /// <param name="modelName"> Model name (the publisher specific name) to filter models by. </param>
        /// <param name="deploymentType"> Type of deployment to filter list by. </param>
        /// <param name="clientRequestId"> An opaque, globally-unique, client-generated string identifier for the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete as the clientRequestId parameter is not used. Please use GetDeployments(string modelPublisher, string modelName, string deploymentType, RequestOptions options) instead.")]
        public virtual CollectionResult GetDeployments(string modelPublisher, string modelName, string deploymentType, string clientRequestId, RequestOptions options)
        {
            return GetDeployments(modelPublisher, modelName, deploymentType, options);
        }

        /// <summary>
        /// [Protocol Method] List all deployed models in the project
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="modelPublisher"> Model publisher to filter models by. </param>
        /// <param name="modelName"> Model name (the publisher specific name) to filter models by. </param>
        /// <param name="deploymentType"> Type of deployment to filter list by. </param>
        /// <param name="clientRequestId"> An opaque, globally-unique, client-generated string identifier for the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete as the clientRequestId parameter is not used. Please use GetDeploymentsAsync(string modelPublisher, string modelName, string deploymentType, RequestOptions options) instead.")]
        public virtual AsyncCollectionResult GetDeploymentsAsync(string modelPublisher, string modelName, string deploymentType, string clientRequestId, RequestOptions options)
        {
            return GetDeploymentsAsync(modelPublisher, modelName, deploymentType, options);
        }

        /// <summary> List all deployed models in the project. </summary>
        /// <param name="modelPublisher"> Model publisher to filter models by. </param>
        /// <param name="modelName"> Model name (the publisher specific name) to filter models by. </param>
        /// <param name="deploymentType"> Type of deployment to filter list by. </param>
        /// <param name="clientRequestId"> An opaque, globally-unique, client-generated string identifier for the request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete as the clientRequestId parameter is not used. Please use GetDeploymentsAsync(string modelPublisher, string modelName, AIProjectDeploymentType? deploymentType, CancellationToken cancellationToken) instead.")]
        public virtual CollectionResult<AIProjectDeployment> GetDeployments(string modelPublisher, string modelName, AIProjectDeploymentType? deploymentType, string clientRequestId, CancellationToken cancellationToken)
        {
            return GetDeployments(modelPublisher, modelName, deploymentType, cancellationToken);
        }

        /// <summary> List all deployed models in the project. </summary>
        /// <param name="modelPublisher"> Model publisher to filter models by. </param>
        /// <param name="modelName"> Model name (the publisher specific name) to filter models by. </param>
        /// <param name="deploymentType"> Type of deployment to filter list by. </param>
        /// <param name="clientRequestId"> An opaque, globally-unique, client-generated string identifier for the request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete as the clientRequestId parameter is not used. Please use GetDeploymentsAsync(string modelPublisher, string modelName, AIProjectDeploymentType? deploymentType, CancellationToken cancellationToken) instead.")]
        public virtual AsyncCollectionResult<AIProjectDeployment> GetDeploymentsAsync(string modelPublisher, string modelName, AIProjectDeploymentType? deploymentType, string clientRequestId, CancellationToken cancellationToken)
        {
            return GetDeploymentsAsync(modelPublisher, modelName, deploymentType, cancellationToken);
        }
    }
}
