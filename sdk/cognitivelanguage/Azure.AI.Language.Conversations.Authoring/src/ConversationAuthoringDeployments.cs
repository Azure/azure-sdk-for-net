// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Core;
using Azure.AI.Language.Conversations.Authoring.Models;
using System.Threading.Tasks;
using System;
using Azure.Core.Pipeline;
using Autorest.CSharp.Core;

namespace Azure.AI.Language.Conversations.Authoring
{
    //[CodeGenSuppress("GetDeploymentAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    //[CodeGenSuppress("GetDeployment", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetDeploymentDeleteFromResourcesStatusAsync", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetDeploymentDeleteFromResourcesStatus", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetDeploymentStatusAsync", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetDeploymentStatus", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    //[CodeGenSuppress("GetDeploymentsAsync", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    //[CodeGenSuppress("GetDeployments", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetSwapDeploymentsStatusAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSwapDeploymentsStatus", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("SwapDeploymentsAsync", typeof(WaitUntil), typeof(string), typeof(SwapDeploymentsDetails), typeof(CancellationToken))]
    [CodeGenSuppress("SwapDeployments", typeof(WaitUntil), typeof(string), typeof(SwapDeploymentsDetails), typeof(CancellationToken))]
    [CodeGenSuppress("DeployProjectAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(CreateDeploymentDetails), typeof(CancellationToken))]
    [CodeGenSuppress("DeployProject", typeof(WaitUntil), typeof(string), typeof(string), typeof(CreateDeploymentDetails), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteDeploymentFromResourcesAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(DeleteDeploymentDetails), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteDeploymentFromResources", typeof(WaitUntil), typeof(string), typeof(string), typeof(DeleteDeploymentDetails), typeof(CancellationToken))]
    [CodeGenSuppress("GetAssignDeploymentResourcesStatusAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetAssignDeploymentResourcesStatus", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetUnassignDeploymentResourcesStatusAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetUnassignDeploymentResourcesStatus", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("AssignDeploymentResourcesAsync", typeof(WaitUntil), typeof(string), typeof(AssignDeploymentResourcesDetails), typeof(CancellationToken))]
    [CodeGenSuppress("AssignDeploymentResources", typeof(WaitUntil), typeof(string), typeof(AssignDeploymentResourcesDetails), typeof(CancellationToken))]
    [CodeGenSuppress("UnassignDeploymentResourcesAsync", typeof(WaitUntil), typeof(string), typeof(UnassignDeploymentResourcesDetails), typeof(CancellationToken))]
    [CodeGenSuppress("UnassignDeploymentResources", typeof(WaitUntil), typeof(string), typeof(UnassignDeploymentResourcesDetails), typeof(CancellationToken))]
    //[CodeGenSuppress("GetAssignedResourceDeploymentsAsync", typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    //[CodeGenSuppress("GetAssignedResourceDeployments", typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    //[CodeGenSuppress("GetDeploymentResourcesAsync", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    //[CodeGenSuppress("GetDeploymentResources", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    public partial class ConversationAuthoringDeployments
    {
        private readonly string _projectName;

        private readonly string _deploymentName;

        /// <summary> Initializes a new instance of ConversationAuthoringDeployments. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="keyCredential"> The key credential to copy. </param>
        /// <param name="tokenCredential"> The token credential to copy. </param>
        /// <param name="endpoint"> Supported Cognitive Services endpoint e.g., https://&lt;resource-name&gt;.api.cognitiveservices.azure.com. </param>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <param name="projectName"> The new project name. </param>
        /// <param name="deploymentName"> Represents deployment name. </param>
        internal ConversationAuthoringDeployments(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, AzureKeyCredential keyCredential, TokenCredential tokenCredential, Uri endpoint, string apiVersion, string projectName, string deploymentName)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _keyCredential = keyCredential;
            _tokenCredential = tokenCredential;
            _endpoint = endpoint;
            _apiVersion = apiVersion;
            _projectName = projectName;
            _deploymentName = deploymentName;
        }

        /// <summary> Gets the details of a deployment. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ProjectDeployment>> GetDeploymentAsync(CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_deploymentName, nameof(_deploymentName));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetDeploymentAsync(_projectName, _deploymentName, context).ConfigureAwait(false);
            return Response.FromValue(ProjectDeployment.FromResponse(response), response);
        }

        /// <summary> Gets the details of a deployment. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ProjectDeployment> GetDeployment(CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_deploymentName, nameof(_deploymentName));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetDeployment(_projectName, _deploymentName, context);
            return Response.FromValue(ProjectDeployment.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing delete deployment from specific resources job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DeploymentDeleteFromResourcesOperationState>> GetDeploymentDeleteFromResourcesStatusAsync(
            string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_deploymentName, nameof(_deploymentName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetDeploymentDeleteFromResourcesStatusAsync(_projectName, _deploymentName, jobId, context).ConfigureAwait(false);
            return Response.FromValue(DeploymentDeleteFromResourcesOperationState.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing delete deployment from specific resources job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DeploymentDeleteFromResourcesOperationState> GetDeploymentDeleteFromResourcesStatus(
            string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_deploymentName, nameof(_deploymentName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetDeploymentDeleteFromResourcesStatus(_projectName, _deploymentName, jobId, context);
            return Response.FromValue(DeploymentDeleteFromResourcesOperationState.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing deployment job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DeploymentOperationState>> GetDeploymentStatusAsync(
            string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_deploymentName, nameof(_deploymentName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetDeploymentStatusAsync(_projectName, _deploymentName, jobId, context).ConfigureAwait(false);
            return Response.FromValue(DeploymentOperationState.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing deployment job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DeploymentOperationState> GetDeploymentStatus(
            string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_deploymentName, nameof(_deploymentName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetDeploymentStatus(_projectName, _deploymentName, jobId, context);
            return Response.FromValue(DeploymentOperationState.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing swap deployment job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SwapDeploymentsOperationState>> GetSwapDeploymentsStatusAsync(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetSwapDeploymentsStatusAsync(_projectName, jobId, context).ConfigureAwait(false);
            return Response.FromValue(SwapDeploymentsOperationState.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing swap deployment job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SwapDeploymentsOperationState> GetSwapDeploymentsStatus(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetSwapDeploymentsStatus(_projectName, jobId, context);
            return Response.FromValue(SwapDeploymentsOperationState.FromResponse(response), response);
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
        /// <param name="body"> The new deployment info. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Operation> DeployProjectAsync(
            WaitUntil waitUntil,
            CreateDeploymentDetails body,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_deploymentName, nameof(_deploymentName));
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return await DeployProjectAsync(waitUntil, _projectName, _deploymentName, content, context).ConfigureAwait(false);
        }

        /// <summary> Creates a new deployment or replaces an existing one. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="body"> The new deployment info. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Operation DeployProject(
            WaitUntil waitUntil,
            CreateDeploymentDetails body,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_deploymentName, nameof(_deploymentName));
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return DeployProject(waitUntil, _projectName, _deploymentName, content, context);
        }

        /// <summary> Deletes a project deployment from the specified assigned resources. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="body"> The options for deleting the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Operation> DeleteDeploymentFromResourcesAsync(
            WaitUntil waitUntil,
            DeleteDeploymentDetails body,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_deploymentName, nameof(_deploymentName));
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return await DeleteDeploymentFromResourcesAsync(waitUntil, _projectName, _deploymentName, content, context).ConfigureAwait(false);
        }

        /// <summary> Deletes a project deployment from the specified assigned resources. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="body"> The options for deleting the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Operation DeleteDeploymentFromResources(
            WaitUntil waitUntil,
            DeleteDeploymentDetails body,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_deploymentName, nameof(_deploymentName));
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return DeleteDeploymentFromResources(waitUntil, _projectName, _deploymentName, content, context);
        }

        /// <summary> Deletes a project deployment. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Operation> DeleteDeploymentAsync(
            WaitUntil waitUntil,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_deploymentName, nameof(_deploymentName));

            RequestContext context = FromCancellationToken(cancellationToken);
            return await DeleteDeploymentAsync(waitUntil, _projectName, _deploymentName, context).ConfigureAwait(false);
        }

        /// <summary> Deletes a project deployment. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Operation DeleteDeployment(
            WaitUntil waitUntil,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_deploymentName, nameof(_deploymentName));

            RequestContext context = FromCancellationToken(cancellationToken);
            return DeleteDeployment(waitUntil, _projectName, _deploymentName, context);
        }

        /// <summary>
        /// [Protocol Method] Gets the details of a deployment.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetDeploymentAsync(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The new project name. </param>
        /// <param name="deploymentName"> Represents deployment name. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> or <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/ConversationAuthoringDeployments.xml" path="doc/members/member[@name='GetDeploymentAsync(string,string,RequestContext)']/*" />
        public virtual async Task<Response> GetDeploymentAsync(string projectName, string deploymentName, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringDeployments.GetDeployment");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDeploymentRequest(projectName, deploymentName, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the details of a deployment.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetDeployment(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The new project name. </param>
        /// <param name="deploymentName"> Represents deployment name. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> or <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/ConversationAuthoringDeployments.xml" path="doc/members/member[@name='GetDeployment(string,string,RequestContext)']/*" />
        public virtual Response GetDeployment(string projectName, string deploymentName, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringDeployments.GetDeployment");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDeploymentRequest(projectName, deploymentName, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the status of an existing delete deployment from specific resources job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetDeploymentDeleteFromResourcesStatusAsync(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The new project name. </param>
        /// <param name="deploymentName"> Represents deployment name. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/>, <paramref name="deploymentName"/> or <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/>, <paramref name="deploymentName"/> or <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/ConversationAuthoringDeployments.xml" path="doc/members/member[@name='GetDeploymentDeleteFromResourcesStatusAsync(string,string,string,RequestContext)']/*" />
        public virtual async Task<Response> GetDeploymentDeleteFromResourcesStatusAsync(string projectName, string deploymentName, string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringDeployments.GetDeploymentDeleteFromResourcesStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDeploymentDeleteFromResourcesStatusRequest(projectName, deploymentName, jobId, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the status of an existing delete deployment from specific resources job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetDeploymentDeleteFromResourcesStatus(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The new project name. </param>
        /// <param name="deploymentName"> Represents deployment name. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/>, <paramref name="deploymentName"/> or <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/>, <paramref name="deploymentName"/> or <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/ConversationAuthoringDeployments.xml" path="doc/members/member[@name='GetDeploymentDeleteFromResourcesStatus(string,string,string,RequestContext)']/*" />
        public virtual Response GetDeploymentDeleteFromResourcesStatus(string projectName, string deploymentName, string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringDeployments.GetDeploymentDeleteFromResourcesStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDeploymentDeleteFromResourcesStatusRequest(projectName, deploymentName, jobId, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the status of an existing deployment job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetDeploymentStatusAsync(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The new project name. </param>
        /// <param name="deploymentName"> Represents deployment name. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/>, <paramref name="deploymentName"/> or <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/>, <paramref name="deploymentName"/> or <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/ConversationAuthoringDeployments.xml" path="doc/members/member[@name='GetDeploymentStatusAsync(string,string,string,RequestContext)']/*" />
        public virtual async Task<Response> GetDeploymentStatusAsync(string projectName, string deploymentName, string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringDeployments.GetDeploymentStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDeploymentStatusRequest(projectName, deploymentName, jobId, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the status of an existing deployment job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetDeploymentStatus(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The new project name. </param>
        /// <param name="deploymentName"> Represents deployment name. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/>, <paramref name="deploymentName"/> or <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/>, <paramref name="deploymentName"/> or <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/ConversationAuthoringDeployments.xml" path="doc/members/member[@name='GetDeploymentStatus(string,string,string,RequestContext)']/*" />
        public virtual Response GetDeploymentStatus(string projectName, string deploymentName, string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringDeployments.GetDeploymentStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDeploymentStatusRequest(projectName, deploymentName, jobId, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the status of an existing swap deployment job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetSwapDeploymentsStatusAsync(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The new project name. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> or <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/ConversationAuthoringDeployments.xml" path="doc/members/member[@name='GetSwapDeploymentsStatusAsync(string,string,RequestContext)']/*" />
        public virtual async Task<Response> GetSwapDeploymentsStatusAsync(string projectName, string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringDeployments.GetSwapDeploymentsStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetSwapDeploymentsStatusRequest(projectName, jobId, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the status of an existing swap deployment job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetSwapDeploymentsStatus(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The new project name. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> or <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/ConversationAuthoringDeployments.xml" path="doc/members/member[@name='GetSwapDeploymentsStatus(string,string,RequestContext)']/*" />
        public virtual Response GetSwapDeploymentsStatus(string projectName, string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringDeployments.GetSwapDeploymentsStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetSwapDeploymentsStatusRequest(projectName, jobId, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Swaps two existing deployments with each other.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SwapDeploymentsAsync(WaitUntil,SwapDeploymentsDetails,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="projectName"> The name of the project to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Generated/Docs/ConversationAuthoringDeployments.xml" path="doc/members/member[@name='SwapDeploymentsAsync(WaitUntil,string,RequestContent,RequestContext)']/*" />
        public virtual async Task<Operation> SwapDeploymentsAsync(WaitUntil waitUntil, string projectName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringDeployments.SwapDeployments");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSwapDeploymentsRequest(projectName, content, context);
                return await ProtocolOperationHelpers.ProcessMessageWithoutResponseValueAsync(_pipeline, message, ClientDiagnostics, "ConversationAuthoringDeployments.SwapDeployments", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Swaps two existing deployments with each other.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SwapDeployments(WaitUntil,SwapDeploymentsDetails,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="projectName"> The name of the project to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Generated/Docs/ConversationAuthoringDeployments.xml" path="doc/members/member[@name='SwapDeployments(WaitUntil,string,RequestContent,RequestContext)']/*" />
        public virtual Operation SwapDeployments(WaitUntil waitUntil, string projectName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringDeployments.SwapDeployments");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSwapDeploymentsRequest(projectName, content, context);
                return ProtocolOperationHelpers.ProcessMessageWithoutResponseValue(_pipeline, message, ClientDiagnostics, "ConversationAuthoringDeployments.SwapDeployments", OperationFinalStateVia.OperationLocation, context, waitUntil);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Creates a new deployment or replaces an existing one.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="DeployProjectAsync(WaitUntil,CreateDeploymentDetails,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="projectName"> The name of the project to use. </param>
        /// <param name="deploymentName"> The name of the specific deployment of the project to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/>, <paramref name="deploymentName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> or <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Generated/Docs/ConversationAuthoringDeployments.xml" path="doc/members/member[@name='DeployProjectAsync(WaitUntil,string,string,RequestContent,RequestContext)']/*" />
        public virtual async Task<Operation> DeployProjectAsync(WaitUntil waitUntil, string projectName, string deploymentName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringDeployments.DeployProject");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeployProjectRequest(projectName, deploymentName, content, context);
                return await ProtocolOperationHelpers.ProcessMessageWithoutResponseValueAsync(_pipeline, message, ClientDiagnostics, "ConversationAuthoringDeployments.DeployProject", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Creates a new deployment or replaces an existing one.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="DeployProject(WaitUntil,CreateDeploymentDetails,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="projectName"> The name of the project to use. </param>
        /// <param name="deploymentName"> The name of the specific deployment of the project to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/>, <paramref name="deploymentName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> or <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Generated/Docs/ConversationAuthoringDeployments.xml" path="doc/members/member[@name='DeployProject(WaitUntil,string,string,RequestContent,RequestContext)']/*" />
        public virtual Operation DeployProject(WaitUntil waitUntil, string projectName, string deploymentName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringDeployments.DeployProject");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeployProjectRequest(projectName, deploymentName, content, context);
                return ProtocolOperationHelpers.ProcessMessageWithoutResponseValue(_pipeline, message, ClientDiagnostics, "ConversationAuthoringDeployments.DeployProject", OperationFinalStateVia.OperationLocation, context, waitUntil);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Deletes a project deployment from the specified assigned resources.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="DeleteDeploymentFromResourcesAsync(WaitUntil, DeleteDeploymentDetails,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="projectName"> The name of the project to use. </param>
        /// <param name="deploymentName"> The name of the specific deployment of the project to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/>, <paramref name="deploymentName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> or <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Generated/Docs/ConversationAuthoringDeployments.xml" path="doc/members/member[@name='DeleteDeploymentFromResourcesAsync(WaitUntil,string,string,RequestContent,RequestContext)']/*" />
        public virtual async Task<Operation> DeleteDeploymentFromResourcesAsync(WaitUntil waitUntil, string projectName, string deploymentName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringDeployments.DeleteDeploymentFromResources");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteDeploymentFromResourcesRequest(projectName, deploymentName, content, context);
                return await ProtocolOperationHelpers.ProcessMessageWithoutResponseValueAsync(_pipeline, message, ClientDiagnostics, "ConversationAuthoringDeployments.DeleteDeploymentFromResources", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Deletes a project deployment from the specified assigned resources.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="DeleteDeploymentFromResources(WaitUntil,DeleteDeploymentDetails,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="projectName"> The name of the project to use. </param>
        /// <param name="deploymentName"> The name of the specific deployment of the project to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/>, <paramref name="deploymentName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> or <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Generated/Docs/ConversationAuthoringDeployments.xml" path="doc/members/member[@name='DeleteDeploymentFromResources(WaitUntil,string,string,RequestContent,RequestContext)']/*" />
        public virtual Operation DeleteDeploymentFromResources(WaitUntil waitUntil, string projectName, string deploymentName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringDeployments.DeleteDeploymentFromResources");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteDeploymentFromResourcesRequest(projectName, deploymentName, content, context);
                return ProtocolOperationHelpers.ProcessMessageWithoutResponseValue(_pipeline, message, ClientDiagnostics, "ConversationAuthoringDeployments.DeleteDeploymentFromResources", OperationFinalStateVia.OperationLocation, context, waitUntil);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the status of an existing assign deployment resources job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Generated/Docs/ConversationAuthoringDeployments.xml" path="doc/members/member[@name='GetAssignDeploymentResourcesStatusAsync(string,string,CancellationToken)']/*" />
        public virtual async Task<Response<DeploymentResourcesOperationState>> GetAssignDeploymentResourcesStatusAsync(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetAssignDeploymentResourcesStatusAsync(_projectName, jobId, context).ConfigureAwait(false);
            return Response.FromValue(DeploymentResourcesOperationState.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing assign deployment resources job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<DeploymentResourcesOperationState> GetAssignDeploymentResourcesStatus(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetAssignDeploymentResourcesStatus(_projectName, jobId, context);
            return Response.FromValue(DeploymentResourcesOperationState.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing unassign deployment resources job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<DeploymentResourcesOperationState>> GetUnassignDeploymentResourcesStatusAsync(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetUnassignDeploymentResourcesStatusAsync(_projectName, jobId, context).ConfigureAwait(false);
            return Response.FromValue(DeploymentResourcesOperationState.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing unassign deployment resources job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<DeploymentResourcesOperationState> GetUnassignDeploymentResourcesStatus(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetUnassignDeploymentResourcesStatus(_projectName, jobId, context);
            return Response.FromValue(DeploymentResourcesOperationState.FromResponse(response), response);
        }

        /// <summary> Assign new Azure resources to a project to allow deploying new deployments to them. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="body"> The new project resources info. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Operation> AssignDeploymentResourcesAsync(
            WaitUntil waitUntil,
            AssignDeploymentResourcesDetails body,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return await AssignDeploymentResourcesAsync(waitUntil, _projectName, content, context).ConfigureAwait(false);
        }

        /// <summary> Assign new Azure resources to a project to allow deploying new deployments to them. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="body"> The new project resources info. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Operation AssignDeploymentResources(
            WaitUntil waitUntil,
            AssignDeploymentResourcesDetails body,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return AssignDeploymentResources(waitUntil, _projectName, content, context);
        }

        /// <summary> Unassign resources from a project. This disallows deploying new deployments to these resources, and deletes existing deployments assigned to them. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="body"> The info for the deployment resources to be deleted. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Operation> UnassignDeploymentResourcesAsync(
            WaitUntil waitUntil,
            UnassignDeploymentResourcesDetails body,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return await UnassignDeploymentResourcesAsync(waitUntil, _projectName, content, context).ConfigureAwait(false);
        }

        /// <summary> Unassign resources from a project. This disallows deploying new deployments to these resources, and deletes existing deployments assigned to them. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="body"> The info for the deployment resources to be deleted. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Operation UnassignDeploymentResources(
            WaitUntil waitUntil,
            UnassignDeploymentResourcesDetails body,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return UnassignDeploymentResources(waitUntil, _projectName, content, context);
        }

        /// <summary>
        /// [Protocol Method] Gets the status of an existing assign deployment resources job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetAssignDeploymentResourcesStatusAsync(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The new project name. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> or <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/ConversationAuthoringDeployments.xml" path="doc/members/member[@name='GetAssignDeploymentResourcesStatusAsync(string,string,RequestContext)']/*" />
        public virtual async Task<Response> GetAssignDeploymentResourcesStatusAsync(string projectName, string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringDeploymentResources.GetAssignDeploymentResourcesStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetAssignDeploymentResourcesStatusRequest(projectName, jobId, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the status of an existing assign deployment resources job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetAssignDeploymentResourcesStatus(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The new project name. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> or <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/ConversationAuthoringDeployments.xml" path="doc/members/member[@name='GetAssignDeploymentResourcesStatus(string,string,RequestContext)']/*" />
        public virtual Response GetAssignDeploymentResourcesStatus(string projectName, string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringDeploymentResources.GetAssignDeploymentResourcesStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetAssignDeploymentResourcesStatusRequest(projectName, jobId, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the status of an existing unassign deployment resources job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetUnassignDeploymentResourcesStatusAsync(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The name of the project to use. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> or <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/ConversationAuthoringDeployments.xml" path="doc/members/member[@name='GetUnassignDeploymentResourcesStatusAsync(string,string,RequestContext)']/*" />
        public virtual async Task<Response> GetUnassignDeploymentResourcesStatusAsync(string projectName, string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringDeploymentResources.GetUnassignDeploymentResourcesStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetUnassignDeploymentResourcesStatusRequest(projectName, jobId, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the status of an existing unassign deployment resources job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetUnassignDeploymentResourcesStatus(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The name of the project to use. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> or <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/ConversationAuthoringDeployments.xml" path="doc/members/member[@name='GetUnassignDeploymentResourcesStatus(string,string,RequestContext)']/*" />
        public virtual Response GetUnassignDeploymentResourcesStatus(string projectName, string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringDeploymentResources.GetUnassignDeploymentResourcesStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetUnassignDeploymentResourcesStatusRequest(projectName, jobId, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Assign new Azure resources to a project to allow deploying new deployments to them. This API is available only via AAD authentication and not supported via subscription key authentication. For more details about AAD authentication, check here: https://learn.microsoft.com/en-us/azure/cognitive-services/authentication?tabs=powershell#authenticate-with-azure-active-directory
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="AssignDeploymentResourcesAsync(WaitUntil,AssignDeploymentResourcesDetails,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="projectName"> The name of the project to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Generated/Docs/ConversationAuthoringDeployments.xml" path="doc/members/member[@name='AssignDeploymentResourcesAsync(WaitUntil,string,RequestContent,RequestContext)']/*" />
        public virtual async Task<Operation> AssignDeploymentResourcesAsync(WaitUntil waitUntil, string projectName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringDeploymentResources.AssignDeploymentResources");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAssignDeploymentResourcesRequest(projectName, content, context);
                return await ProtocolOperationHelpers.ProcessMessageWithoutResponseValueAsync(_pipeline, message, ClientDiagnostics, "ConversationAuthoringDeploymentResources.AssignDeploymentResources", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Assign new Azure resources to a project to allow deploying new deployments to them. This API is available only via AAD authentication and not supported via subscription key authentication. For more details about AAD authentication, check here: https://learn.microsoft.com/en-us/azure/cognitive-services/authentication?tabs=powershell#authenticate-with-azure-active-directory
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="AssignDeploymentResources(WaitUntil,AssignDeploymentResourcesDetails,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="projectName"> The name of the project to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Generated/Docs/ConversationAuthoringDeployments.xml" path="doc/members/member[@name='AssignDeploymentResources(WaitUntil,string,RequestContent,RequestContext)']/*" />
        public virtual Operation AssignDeploymentResources(WaitUntil waitUntil, string projectName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringDeploymentResources.AssignDeploymentResources");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAssignDeploymentResourcesRequest(projectName, content, context);
                return ProtocolOperationHelpers.ProcessMessageWithoutResponseValue(_pipeline, message, ClientDiagnostics, "ConversationAuthoringDeploymentResources.AssignDeploymentResources", OperationFinalStateVia.OperationLocation, context, waitUntil);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Unassign resources from a project. This disallows deploying new deployments to these resources, and deletes existing deployments assigned to them.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="UnassignDeploymentResourcesAsync(WaitUntil,UnassignDeploymentResourcesDetails,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="projectName"> The name of the project to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Generated/Docs/ConversationAuthoringDeployments.xml" path="doc/members/member[@name='UnassignDeploymentResourcesAsync(WaitUntil,string,RequestContent,RequestContext)']/*" />
        public virtual async Task<Operation> UnassignDeploymentResourcesAsync(WaitUntil waitUntil, string projectName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringDeploymentResources.UnassignDeploymentResources");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUnassignDeploymentResourcesRequest(projectName, content, context);
                return await ProtocolOperationHelpers.ProcessMessageWithoutResponseValueAsync(_pipeline, message, ClientDiagnostics, "ConversationAuthoringDeploymentResources.UnassignDeploymentResources", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Unassign resources from a project. This disallows deploying new deployments to these resources, and deletes existing deployments assigned to them.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="UnassignDeploymentResources(WaitUntil,UnassignDeploymentResourcesDetails,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="projectName"> The name of the project to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Generated/Docs/ConversationAuthoringDeployments.xml" path="doc/members/member[@name='UnassignDeploymentResources(WaitUntil,string,RequestContent,RequestContext)']/*" />
        public virtual Operation UnassignDeploymentResources(WaitUntil waitUntil, string projectName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringDeploymentResources.UnassignDeploymentResources");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUnassignDeploymentResourcesRequest(projectName, content, context);
                return ProtocolOperationHelpers.ProcessMessageWithoutResponseValue(_pipeline, message, ClientDiagnostics, "ConversationAuthoringDeploymentResources.UnassignDeploymentResources", OperationFinalStateVia.OperationLocation, context, waitUntil);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
