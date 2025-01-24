// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Core;
using Azure.AI.Language.Conversations.Authoring.Models;
using System.Threading.Tasks;
using System;
using Azure.Core.Pipeline;

namespace Azure.AI.Language.Conversations.Authoring
{
    [CodeGenSuppress("GetDeploymentAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetDeployment", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetDeploymentDeleteFromResourcesStatusAsync", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetDeploymentDeleteFromResourcesStatus", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetDeploymentStatusAsync", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetDeploymentStatus", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSwapDeploymentsStatusAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSwapDeploymentsStatus", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetDeploymentsAsync", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetDeployments", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("SwapDeploymentsAsync", typeof(WaitUntil), typeof(string), typeof(SwapDeploymentsDetails), typeof(CancellationToken))]
    [CodeGenSuppress("SwapDeployments", typeof(WaitUntil), typeof(string), typeof(SwapDeploymentsDetails), typeof(CancellationToken))]
    [CodeGenSuppress("DeployProjectAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(CreateDeploymentDetails), typeof(CancellationToken))]
    [CodeGenSuppress("DeployProject", typeof(WaitUntil), typeof(string), typeof(string), typeof(CreateDeploymentDetails), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteDeploymentFromResourcesAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(DeleteDeploymentDetails), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteDeploymentFromResources", typeof(WaitUntil), typeof(string), typeof(string), typeof(DeleteDeploymentDetails), typeof(CancellationToken))]
    public partial class ConversationAuthoringDeployments
    {
        private readonly string _projectName;

        /// <summary> Initializes a new instance of ConversationAuthoringDeployments. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="keyCredential"> The key credential to copy. </param>
        /// <param name="tokenCredential"> The token credential to copy. </param>
        /// <param name="endpoint"> Supported Cognitive Services endpoint e.g., https://&lt;resource-name&gt;.api.cognitiveservices.azure.com. </param>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <param name="projectName"> The new project name. </param>
        internal ConversationAuthoringDeployments(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, AzureKeyCredential keyCredential, TokenCredential tokenCredential, Uri endpoint, string apiVersion, string projectName)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _keyCredential = keyCredential;
            _tokenCredential = tokenCredential;
            _endpoint = endpoint;
            _apiVersion = apiVersion;
            _projectName = projectName;
        }

        /// <summary> Gets the details of a deployment. </summary>
        /// <param name="deploymentName"> Represents deployment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ProjectDeployment>> GetDeploymentAsync(string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetDeploymentAsync(_projectName, deploymentName, context).ConfigureAwait(false);
            return Response.FromValue(ProjectDeployment.FromResponse(response), response);
        }

        /// <summary> Gets the details of a deployment. </summary>
        /// <param name="deploymentName"> Represents deployment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ProjectDeployment> GetDeployment(string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetDeployment(_projectName, deploymentName, context);
            return Response.FromValue(ProjectDeployment.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing delete deployment from specific resources job. </summary>
        /// <param name="deploymentName"> Represents deployment name. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DeploymentDeleteFromResourcesJobState>> GetDeploymentDeleteFromResourcesStatusAsync(
            string deploymentName, string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetDeploymentDeleteFromResourcesStatusAsync(_projectName, deploymentName, jobId, context).ConfigureAwait(false);
            return Response.FromValue(DeploymentDeleteFromResourcesJobState.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing delete deployment from specific resources job. </summary>
        /// <param name="deploymentName"> Represents deployment name. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DeploymentDeleteFromResourcesJobState> GetDeploymentDeleteFromResourcesStatus(
            string deploymentName, string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetDeploymentDeleteFromResourcesStatus(_projectName, deploymentName, jobId, context);
            return Response.FromValue(DeploymentDeleteFromResourcesJobState.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing deployment job. </summary>
        /// <param name="deploymentName"> Represents deployment name. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DeploymentJobState>> GetDeploymentStatusAsync(
            string deploymentName, string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetDeploymentStatusAsync(_projectName, deploymentName, jobId, context).ConfigureAwait(false);
            return Response.FromValue(DeploymentJobState.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing deployment job. </summary>
        /// <param name="deploymentName"> Represents deployment name. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DeploymentJobState> GetDeploymentStatus(
            string deploymentName, string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetDeploymentStatus(_projectName, deploymentName, jobId, context);
            return Response.FromValue(DeploymentJobState.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing swap deployment job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SwapDeploymentsJobState>> GetSwapDeploymentsStatusAsync(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetSwapDeploymentsStatusAsync(_projectName, jobId, context).ConfigureAwait(false);
            return Response.FromValue(SwapDeploymentsJobState.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing swap deployment job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SwapDeploymentsJobState> GetSwapDeploymentsStatus(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetSwapDeploymentsStatus(_projectName, jobId, context);
            return Response.FromValue(SwapDeploymentsJobState.FromResponse(response), response);
        }

        /// <summary> Lists the deployments belonging to a project. </summary>
        /// <param name="maxCount"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<ProjectDeployment> GetDeploymentsAsync(
            int? maxCount = null, 
            int? skip = null, 
            int? maxpagesize = null, 
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));

            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetDeploymentsRequest(_projectName, maxCount, skip, pageSizeHint, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetDeploymentsNextPageRequest(nextLink, _projectName, maxCount, skip, pageSizeHint, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => ProjectDeployment.DeserializeProjectDeployment(e), ClientDiagnostics, _pipeline, "ConversationAuthoringDeployments.GetDeployments", "value", "nextLink", maxpagesize, context);
        }

        /// <summary> Lists the deployments belonging to a project. </summary>
        /// <param name="maxCount"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<ProjectDeployment> GetDeployments(
            int? maxCount = null, 
            int? skip = null, 
            int? maxpagesize = null, 
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));

            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetDeploymentsRequest(_projectName, maxCount, skip, pageSizeHint, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetDeploymentsNextPageRequest(nextLink, _projectName, maxCount, skip, pageSizeHint, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => ProjectDeployment.DeserializeProjectDeployment(e), ClientDiagnostics, _pipeline, "ConversationAuthoringDeployments.GetDeployments", "value", "nextLink", maxpagesize, context);
        }

        /// <summary> Swaps two existing deployments with each other. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="body"> The job object to swap two deployments. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Operation> SwapDeploymentsAsync(
            WaitUntil waitUntil, 
            SwapDeploymentsDetails body, 
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return await SwapDeploymentsAsync(waitUntil, _projectName, content, context).ConfigureAwait(false);
        }

        /// <summary> Swaps two existing deployments with each other. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="body"> The job object to swap two deployments. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Operation SwapDeployments(
            WaitUntil waitUntil, 
            SwapDeploymentsDetails body, 
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return SwapDeployments(waitUntil, _projectName, content, context);
        }

        /// <summary> Creates a new deployment or replaces an existing one. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="deploymentName"> The name of the specific deployment of the project to use. </param>
        /// <param name="body"> The new deployment info. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Operation> DeployProjectAsync(
            WaitUntil waitUntil, 
            string deploymentName, 
            CreateDeploymentDetails body, 
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return await DeployProjectAsync(waitUntil, _projectName, deploymentName, content, context).ConfigureAwait(false);
        }

        /// <summary> Creates a new deployment or replaces an existing one. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="deploymentName"> The name of the specific deployment of the project to use. </param>
        /// <param name="body"> The new deployment info. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Operation DeployProject(
            WaitUntil waitUntil, 
            string deploymentName, 
            CreateDeploymentDetails body, 
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return DeployProject(waitUntil, _projectName, deploymentName, content, context);
        }

        /// <summary> Deletes a project deployment from the specified assigned resources. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="deploymentName"> The name of the specific deployment of the project to use. </param>
        /// <param name="body"> The options for deleting the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Operation> DeleteDeploymentFromResourcesAsync(
            WaitUntil waitUntil, 
            string deploymentName, 
            DeleteDeploymentDetails body, 
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return await DeleteDeploymentFromResourcesAsync(waitUntil, _projectName, deploymentName, content, context).ConfigureAwait(false);
        }

        /// <summary> Deletes a project deployment from the specified assigned resources. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="deploymentName"> The name of the specific deployment of the project to use. </param>
        /// <param name="body"> The options for deleting the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Operation DeleteDeploymentFromResources(
            WaitUntil waitUntil, 
            string deploymentName, 
            DeleteDeploymentDetails body, 
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return DeleteDeploymentFromResources(waitUntil, _projectName, deploymentName, content, context);
        }

        /// <summary> Deletes a project deployment. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="deploymentName"> The name of the specific deployment of the project to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Operation> DeleteDeploymentAsync(
            WaitUntil waitUntil, 
            string deploymentName, 
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));

            RequestContext context = FromCancellationToken(cancellationToken);
            return await DeleteDeploymentAsync(waitUntil, _projectName, deploymentName, context).ConfigureAwait(false);
        }

        /// <summary> Deletes a project deployment. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="deploymentName"> The name of the specific deployment of the project to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Operation DeleteDeployment(
            WaitUntil waitUntil, 
            string deploymentName, 
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));

            RequestContext context = FromCancellationToken(cancellationToken);
            return DeleteDeployment(waitUntil, _projectName, deploymentName, context);
        }
    }
}
