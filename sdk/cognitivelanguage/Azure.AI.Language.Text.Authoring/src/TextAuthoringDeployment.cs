// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Core;
using System.Threading.Tasks;
using System;
using Azure.Core.Pipeline;
using Autorest.CSharp.Core;

namespace Azure.AI.Language.Text.Authoring
{
    [CodeGenSuppress("GetDeploymentDeleteFromResourcesStatusAsync", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetDeploymentDeleteFromResourcesStatus", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetDeploymentStatusAsync", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetDeploymentStatus", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSwapDeploymentsStatusAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSwapDeploymentsStatus", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("SwapDeploymentsAsync", typeof(WaitUntil), typeof(string), typeof(TextAuthoringSwapDeploymentsDetails), typeof(CancellationToken))]
    [CodeGenSuppress("SwapDeployments", typeof(WaitUntil), typeof(string), typeof(TextAuthoringSwapDeploymentsDetails), typeof(CancellationToken))]
    [CodeGenSuppress("DeployProjectAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(TextAuthoringCreateDeploymentDetails), typeof(CancellationToken))]
    [CodeGenSuppress("DeployProject", typeof(WaitUntil), typeof(string), typeof(string), typeof(TextAuthoringCreateDeploymentDetails), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteDeploymentFromResourcesAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(TextAuthoringDeleteDeploymentDetails), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteDeploymentFromResources", typeof(WaitUntil), typeof(string), typeof(string), typeof(TextAuthoringDeleteDeploymentDetails), typeof(CancellationToken))]
    [CodeGenSuppress("GetAssignDeploymentResourcesStatusAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetAssignDeploymentResourcesStatus", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetUnassignDeploymentResourcesStatusAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetUnassignDeploymentResourcesStatus", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("AssignDeploymentResourcesAsync", typeof(WaitUntil), typeof(string), typeof(TextAuthoringAssignDeploymentResourcesDetails), typeof(CancellationToken))]
    [CodeGenSuppress("AssignDeploymentResources", typeof(WaitUntil), typeof(string), typeof(TextAuthoringAssignDeploymentResourcesDetails), typeof(CancellationToken))]
    [CodeGenSuppress("UnassignDeploymentResourcesAsync", typeof(WaitUntil), typeof(string), typeof(TextAuthoringUnassignDeploymentResourcesDetails), typeof(CancellationToken))]
    [CodeGenSuppress("UnassignDeploymentResources", typeof(WaitUntil), typeof(string), typeof(TextAuthoringUnassignDeploymentResourcesDetails), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteDeploymentAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("DeleteDeployment", typeof(WaitUntil), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetDeploymentAsync", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetDeployment", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetDeploymentDeleteFromResourcesStatusAsync", typeof(string), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetDeploymentDeleteFromResourcesStatus", typeof(string), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetDeploymentStatusAsync", typeof(string), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetDeploymentStatus", typeof(string), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetSwapDeploymentsStatusAsync", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetSwapDeploymentsStatus", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetAssignDeploymentResourcesStatusAsync", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetAssignDeploymentResourcesStatus", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetUnassignDeploymentResourcesStatusAsync", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetUnassignDeploymentResourcesStatus", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("DeleteDeploymentFromResourcesAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("DeleteDeploymentFromResources", typeof(WaitUntil), typeof(string), typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("SwapDeploymentsAsync", typeof(WaitUntil), typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("SwapDeployments", typeof(WaitUntil), typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("AssignDeploymentResourcesAsync", typeof(WaitUntil), typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("AssignDeploymentResources", typeof(WaitUntil), typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("UnassignDeploymentResourcesAsync", typeof(WaitUntil), typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("UnassignDeploymentResources", typeof(WaitUntil), typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("DeployProjectAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("DeployProject", typeof(WaitUntil), typeof(string), typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("GetDeploymentAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetDeployment", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("CancelTrainingJobAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("CancelTrainingJob", typeof(WaitUntil), typeof(string), typeof(string), typeof(RequestContext))]

    //[CodeGenSuppress("GetDeploymentsAsync", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    //[CodeGenSuppress("GetDeployments", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    //[CodeGenSuppress("GetDeploymentAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    //[CodeGenSuppress("GetDeployment", typeof(string), typeof(string), typeof(CancellationToken))]
    //[CodeGenSuppress("GetAssignedResourceDeploymentsAsync", typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    //[CodeGenSuppress("GetAssignedResourceDeployments", typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    //[CodeGenSuppress("GetDeploymentResourcesAsync", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    //[CodeGenSuppress("GetDeploymentResources", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    public partial class TextAuthoringDeployment
    {
        private readonly string _projectName;

        private readonly string _deploymentName;

        /// <summary> Initializes a new instance of TextAuthoringDeployment. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="keyCredential"> The key credential to copy. </param>
        /// <param name="tokenCredential"> The token credential to copy. </param>
        /// <param name="endpoint"> Supported Cognitive Services endpoint e.g., https://&lt;resource-name&gt;.api.cognitiveservices.azure.com. </param>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <param name="projectName"> The new project name. </param>
        /// <param name="deploymentName"> Represents deployment name. </param>
        internal TextAuthoringDeployment(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, AzureKeyCredential keyCredential, TokenCredential tokenCredential, Uri endpoint, string apiVersion, string projectName, string deploymentName)
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
        public virtual async Task<Response<TextAuthoringProjectDeployment>> GetDeploymentAsync(CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_deploymentName, nameof(_deploymentName));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetDeploymentAsync(context).ConfigureAwait(false);
            return Response.FromValue(TextAuthoringProjectDeployment.FromResponse(response), response);
        }

        /// <summary> Gets the details of a deployment. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TextAuthoringProjectDeployment> GetDeployment(CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_deploymentName, nameof(_deploymentName));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetDeployment(context);
            return Response.FromValue(TextAuthoringProjectDeployment.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing delete deployment from specific resources job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<TextAuthoringDeploymentDeleteFromResourcesState>> GetDeploymentDeleteFromResourcesStatusAsync(
            string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_deploymentName, nameof(_deploymentName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetDeploymentDeleteFromResourcesStatusAsync(jobId, context).ConfigureAwait(false);
            return Response.FromValue(TextAuthoringDeploymentDeleteFromResourcesState.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing delete deployment from specific resources job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TextAuthoringDeploymentDeleteFromResourcesState> GetDeploymentDeleteFromResourcesStatus(
            string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_deploymentName, nameof(_deploymentName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetDeploymentDeleteFromResourcesStatus(jobId, context);
            return Response.FromValue(TextAuthoringDeploymentDeleteFromResourcesState.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing deployment job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<TextAuthoringDeploymentState>> GetDeploymentStatusAsync(
            string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_deploymentName, nameof(_deploymentName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetDeploymentStatusAsync(jobId, context).ConfigureAwait(false);
            return Response.FromValue(TextAuthoringDeploymentState.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing deployment job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TextAuthoringDeploymentState> GetDeploymentStatus(
            string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_deploymentName, nameof(_deploymentName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetDeploymentStatus(jobId, context);
            return Response.FromValue(TextAuthoringDeploymentState.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing swap deployment job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<TextAuthoringSwapDeploymentsState>> GetSwapDeploymentsStatusAsync(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetSwapDeploymentsStatusAsync(jobId, context).ConfigureAwait(false);
            return Response.FromValue(TextAuthoringSwapDeploymentsState.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing swap deployment job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TextAuthoringSwapDeploymentsState> GetSwapDeploymentsStatus(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetSwapDeploymentsStatus(jobId, context);
            return Response.FromValue(TextAuthoringSwapDeploymentsState.FromResponse(response), response);
        }

        /// <summary> Swaps two existing deployments with each other. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="details"> The job object to swap two deployments. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Operation> SwapDeploymentsAsync(
            WaitUntil waitUntil,
            TextAuthoringSwapDeploymentsDetails details,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(details, nameof(details));

            using RequestContent content = details.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return await SwapDeploymentsAsync(waitUntil, content, context).ConfigureAwait(false);
        }

        /// <summary> Swaps two existing deployments with each other. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="details"> The job object to swap two deployments. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Operation SwapDeployments(
            WaitUntil waitUntil,
            TextAuthoringSwapDeploymentsDetails details,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(details, nameof(details));

            using RequestContent content = details.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return SwapDeployments(waitUntil, content, context);
        }

        /// <summary> Creates a new deployment or replaces an existing one. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="details"> The new deployment info. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Operation> DeployProjectAsync(
            WaitUntil waitUntil,
            TextAuthoringCreateDeploymentDetails details,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_deploymentName, nameof(_deploymentName));
            Argument.AssertNotNull(details, nameof(details));

            using RequestContent content = details.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return await DeployProjectAsync(waitUntil, content, context).ConfigureAwait(false);
        }

        /// <summary> Creates a new deployment or replaces an existing one. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="details"> The new deployment info. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Operation DeployProject(
            WaitUntil waitUntil,
            TextAuthoringCreateDeploymentDetails details,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_deploymentName, nameof(_deploymentName));
            Argument.AssertNotNull(details, nameof(details));

            using RequestContent content = details.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return DeployProject(waitUntil, content, context);
        }

        /// <summary> Deletes a project deployment from the specified assigned resources. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="details"> The options for deleting the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Operation> DeleteDeploymentFromResourcesAsync(
            WaitUntil waitUntil,
            TextAuthoringDeleteDeploymentDetails details,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_deploymentName, nameof(_deploymentName));
            Argument.AssertNotNull(details, nameof(details));

            using RequestContent content = details.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return await DeleteDeploymentFromResourcesAsync(waitUntil, content, context).ConfigureAwait(false);
        }

        /// <summary> Deletes a project deployment from the specified assigned resources. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="details"> The options for deleting the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Operation DeleteDeploymentFromResources(
            WaitUntil waitUntil,
            TextAuthoringDeleteDeploymentDetails details,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_deploymentName, nameof(_deploymentName));
            Argument.AssertNotNull(details, nameof(details));

            using RequestContent content = details.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return DeleteDeploymentFromResources(waitUntil, content, context);
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
            return await DeleteDeploymentAsync(waitUntil, context).ConfigureAwait(false);
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
            return DeleteDeployment(waitUntil, context);
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
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> GetDeploymentAsync(RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_deploymentName, nameof(_deploymentName));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringDeployment.GetDeployment");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDeploymentRequest(_projectName, _deploymentName, context);
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
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response GetDeployment(RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_deploymentName, nameof(_deploymentName));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringDeployment.GetDeployment");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDeploymentRequest(_projectName, _deploymentName, context);
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
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> GetDeploymentDeleteFromResourcesStatusAsync(string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_deploymentName, nameof(_deploymentName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringDeployment.GetDeploymentDeleteFromResourcesStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDeploymentDeleteFromResourcesStatusRequest(_projectName, _deploymentName, jobId, context);
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
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response GetDeploymentDeleteFromResourcesStatus(string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_deploymentName, nameof(_deploymentName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringDeployment.GetDeploymentDeleteFromResourcesStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDeploymentDeleteFromResourcesStatusRequest(_projectName, _deploymentName, jobId, context);
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
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> GetDeploymentStatusAsync(string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_deploymentName, nameof(_deploymentName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringDeployment.GetDeploymentStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDeploymentStatusRequest(_projectName, _deploymentName, jobId, context);
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
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response GetDeploymentStatus(string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_deploymentName, nameof(_deploymentName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringDeployment.GetDeploymentStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDeploymentStatusRequest(_projectName, _deploymentName, jobId, context);
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
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> GetSwapDeploymentsStatusAsync(string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringDeployment.GetSwapDeploymentsStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetSwapDeploymentsStatusRequest(_projectName, jobId, context);
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
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response GetSwapDeploymentsStatus(string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringDeployment.GetSwapDeploymentsStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetSwapDeploymentsStatusRequest(_projectName, jobId, context);
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
        /// Please try the simpler <see cref="SwapDeploymentsAsync(WaitUntil,TextAuthoringSwapDeploymentsDetails,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual async Task<Operation> SwapDeploymentsAsync(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringDeployment.SwapDeployments");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSwapDeploymentsRequest(_projectName, content, context);
                return await ProtocolOperationHelpers.ProcessMessageWithoutResponseValueAsync(_pipeline, message, ClientDiagnostics, "TextAuthoringDeployment.SwapDeployments", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
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
        /// Please try the simpler <see cref="SwapDeployments(WaitUntil,TextAuthoringSwapDeploymentsDetails,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual Operation SwapDeployments(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringDeployment.SwapDeployments");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSwapDeploymentsRequest(_projectName, content, context);
                return ProtocolOperationHelpers.ProcessMessageWithoutResponseValue(_pipeline, message, ClientDiagnostics, "TextAuthoringDeployment.SwapDeployments", OperationFinalStateVia.OperationLocation, context, waitUntil);
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
        /// Please try the simpler <see cref="DeployProjectAsync(WaitUntil,TextAuthoringCreateDeploymentDetails,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual async Task<Operation> DeployProjectAsync(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_deploymentName, nameof(_deploymentName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringDeployment.DeployProject");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeployProjectRequest(_projectName, _deploymentName, content, context);
                return await ProtocolOperationHelpers.ProcessMessageWithoutResponseValueAsync(_pipeline, message, ClientDiagnostics, "TextAuthoringDeployment.DeployProject", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
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
        /// Please try the simpler <see cref="DeployProject(WaitUntil,TextAuthoringCreateDeploymentDetails,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual Operation DeployProject(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_deploymentName, nameof(_deploymentName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringDeployment.DeployProject");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeployProjectRequest(_projectName, _deploymentName, content, context);
                return ProtocolOperationHelpers.ProcessMessageWithoutResponseValue(_pipeline, message, ClientDiagnostics, "TextAuthoringDeployment.DeployProject", OperationFinalStateVia.OperationLocation, context, waitUntil);
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
        /// Please try the simpler <see cref="DeleteDeploymentFromResourcesAsync(WaitUntil, TextAuthoringDeleteDeploymentDetails,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual async Task<Operation> DeleteDeploymentFromResourcesAsync(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_deploymentName, nameof(_deploymentName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringDeployment.DeleteDeploymentFromResources");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteDeploymentFromResourcesRequest(_projectName, _deploymentName, content, context);
                return await ProtocolOperationHelpers.ProcessMessageWithoutResponseValueAsync(_pipeline, message, ClientDiagnostics, "TextAuthoringDeployment.DeleteDeploymentFromResources", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
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
        /// Please try the simpler <see cref="DeleteDeploymentFromResources(WaitUntil,TextAuthoringDeleteDeploymentDetails,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual Operation DeleteDeploymentFromResources(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_deploymentName, nameof(_deploymentName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringDeployment.DeleteDeploymentFromResources");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteDeploymentFromResourcesRequest(_projectName, _deploymentName, content, context);
                return ProtocolOperationHelpers.ProcessMessageWithoutResponseValue(_pipeline, message, ClientDiagnostics, "TextAuthoringDeployment.DeleteDeploymentFromResources", OperationFinalStateVia.OperationLocation, context, waitUntil);
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
        public virtual async Task<Response<TextAuthoringAssignDeploymentResourcesState>> GetAssignDeploymentResourcesStatusAsync(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetAssignDeploymentResourcesStatusAsync(jobId, context).ConfigureAwait(false);
            return Response.FromValue(TextAuthoringAssignDeploymentResourcesState.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing assign deployment resources job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<TextAuthoringAssignDeploymentResourcesState> GetAssignDeploymentResourcesStatus(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetAssignDeploymentResourcesStatus(jobId, context);
            return Response.FromValue(TextAuthoringAssignDeploymentResourcesState.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing unassign deployment resources job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<TextAuthoringUnassignDeploymentResourcesState>> GetUnassignDeploymentResourcesStatusAsync(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetUnassignDeploymentResourcesStatusAsync(jobId, context).ConfigureAwait(false);
            return Response.FromValue(TextAuthoringUnassignDeploymentResourcesState.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing unassign deployment resources job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<TextAuthoringUnassignDeploymentResourcesState> GetUnassignDeploymentResourcesStatus(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetUnassignDeploymentResourcesStatus(jobId, context);
            return Response.FromValue(TextAuthoringUnassignDeploymentResourcesState.FromResponse(response), response);
        }

        /// <summary> Assign new Azure resources to a project to allow deploying new deployments to them. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="details"> The new project resources info. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Operation> AssignDeploymentResourcesAsync(
            WaitUntil waitUntil,
            TextAuthoringAssignDeploymentResourcesDetails details,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(details, nameof(details));

            using RequestContent content = details.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return await AssignDeploymentResourcesAsync(waitUntil, content, context).ConfigureAwait(false);
        }

        /// <summary> Assign new Azure resources to a project to allow deploying new deployments to them. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="details"> The new project resources info. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Operation AssignDeploymentResources(
            WaitUntil waitUntil,
            TextAuthoringAssignDeploymentResourcesDetails details,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(details, nameof(details));

            using RequestContent content = details.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return AssignDeploymentResources(waitUntil, content, context);
        }

        /// <summary> Unassign resources from a project. This disallows deploying new deployments to these resources, and deletes existing deployments assigned to them. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="details"> The info for the deployment resources to be deleted. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Operation> UnassignDeploymentResourcesAsync(
            WaitUntil waitUntil,
            TextAuthoringUnassignDeploymentResourcesDetails details,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(details, nameof(details));

            using RequestContent content = details.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return await UnassignDeploymentResourcesAsync(waitUntil, content, context).ConfigureAwait(false);
        }

        /// <summary> Unassign resources from a project. This disallows deploying new deployments to these resources, and deletes existing deployments assigned to them. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="details"> The info for the deployment resources to be deleted. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Operation UnassignDeploymentResources(
            WaitUntil waitUntil,
            TextAuthoringUnassignDeploymentResourcesDetails details,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(details, nameof(details));

            using RequestContent content = details.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return UnassignDeploymentResources(waitUntil, content, context);
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
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> GetAssignDeploymentResourcesStatusAsync(string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringDeploymentResources.GetAssignDeploymentResourcesStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetAssignDeploymentResourcesStatusRequest(_projectName, jobId, context);
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
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response GetAssignDeploymentResourcesStatus(string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringDeploymentResources.GetAssignDeploymentResourcesStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetAssignDeploymentResourcesStatusRequest(_projectName, jobId, context);
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
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> GetUnassignDeploymentResourcesStatusAsync(string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringDeploymentResources.GetUnassignDeploymentResourcesStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetUnassignDeploymentResourcesStatusRequest(_projectName, jobId, context);
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
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response GetUnassignDeploymentResourcesStatus(string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringDeploymentResources.GetUnassignDeploymentResourcesStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetUnassignDeploymentResourcesStatusRequest(_projectName, jobId, context);
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
        /// Please try the simpler <see cref="AssignDeploymentResourcesAsync(WaitUntil,TextAuthoringAssignDeploymentResourcesDetails,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual async Task<Operation> AssignDeploymentResourcesAsync(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringDeploymentResources.AssignDeploymentResources");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAssignDeploymentResourcesRequest(_projectName, content, context);
                return await ProtocolOperationHelpers.ProcessMessageWithoutResponseValueAsync(_pipeline, message, ClientDiagnostics, "TextAuthoringDeploymentResources.AssignDeploymentResources", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
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
        /// Please try the simpler <see cref="AssignDeploymentResources(WaitUntil,TextAuthoringAssignDeploymentResourcesDetails,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual Operation AssignDeploymentResources(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringDeploymentResources.AssignDeploymentResources");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAssignDeploymentResourcesRequest(_projectName, content, context);
                return ProtocolOperationHelpers.ProcessMessageWithoutResponseValue(_pipeline, message, ClientDiagnostics, "TextAuthoringDeploymentResources.AssignDeploymentResources", OperationFinalStateVia.OperationLocation, context, waitUntil);
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
        /// Please try the simpler <see cref="UnassignDeploymentResourcesAsync(WaitUntil,TextAuthoringUnassignDeploymentResourcesDetails,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual async Task<Operation> UnassignDeploymentResourcesAsync(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringDeploymentResources.UnassignDeploymentResources");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUnassignDeploymentResourcesRequest(_projectName, content, context);
                return await ProtocolOperationHelpers.ProcessMessageWithoutResponseValueAsync(_pipeline, message, ClientDiagnostics, "TextAuthoringDeploymentResources.UnassignDeploymentResources", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
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
        /// Please try the simpler <see cref="UnassignDeploymentResources(WaitUntil,TextAuthoringUnassignDeploymentResourcesDetails,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual Operation UnassignDeploymentResources(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringDeploymentResources.UnassignDeploymentResources");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUnassignDeploymentResourcesRequest(_projectName, content, context);
                return ProtocolOperationHelpers.ProcessMessageWithoutResponseValue(_pipeline, message, ClientDiagnostics, "TextAuthoringDeploymentResources.UnassignDeploymentResources", OperationFinalStateVia.OperationLocation, context, waitUntil);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Deletes a project deployment.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual async Task<Operation> DeleteDeploymentAsync(WaitUntil waitUntil, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_deploymentName, nameof(_deploymentName));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringDeployment.DeleteDeployment");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteDeploymentRequest(_projectName, _deploymentName, context);
                return await ProtocolOperationHelpers.ProcessMessageWithoutResponseValueAsync(_pipeline, message, ClientDiagnostics, "TextAuthoringDeployment.DeleteDeployment", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Deletes a project deployment.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual Operation DeleteDeployment(WaitUntil waitUntil, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_deploymentName, nameof(_deploymentName));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringDeployment.DeleteDeployment");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteDeploymentRequest(_projectName, _deploymentName, context);
                return ProtocolOperationHelpers.ProcessMessageWithoutResponseValue(_pipeline, message, ClientDiagnostics, "TextAuthoringDeployment.DeleteDeployment", OperationFinalStateVia.OperationLocation, context, waitUntil);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
