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
    [CodeGenSuppress("GetAssignDeploymentResourcesStatusAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetAssignDeploymentResourcesStatus", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetUnassignDeploymentResourcesStatusAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetUnassignDeploymentResourcesStatus", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetDeploymentResourcesAsync", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetDeploymentResources", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("AssignDeploymentResourcesAsync", typeof(WaitUntil), typeof(string), typeof(AssignDeploymentResourcesDetails), typeof(CancellationToken))]
    [CodeGenSuppress("AssignDeploymentResources", typeof(WaitUntil), typeof(string), typeof(AssignDeploymentResourcesDetails), typeof(CancellationToken))]
    [CodeGenSuppress("UnassignDeploymentResourcesAsync", typeof(WaitUntil), typeof(string), typeof(UnassignDeploymentResourcesDetails), typeof(CancellationToken))]
    [CodeGenSuppress("UnassignDeploymentResources", typeof(WaitUntil), typeof(string), typeof(UnassignDeploymentResourcesDetails), typeof(CancellationToken))]
    public partial class ConversationAuthoringDeploymentResources
    {
        private readonly string _projectName;

        /// <summary> Initializes a new instance of ConversationAuthoringDeploymentResources. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="keyCredential"> The key credential to copy. </param>
        /// <param name="tokenCredential"> The token credential to copy. </param>
        /// <param name="endpoint"> Supported Cognitive Services endpoint e.g., https://&lt;resource-name&gt;.api.cognitiveservices.azure.com. </param>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <param name="projectName"> The new project name. </param>
        internal ConversationAuthoringDeploymentResources(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, AzureKeyCredential keyCredential, TokenCredential tokenCredential, Uri endpoint, string apiVersion, string projectName)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _keyCredential = keyCredential;
            _tokenCredential = tokenCredential;
            _endpoint = endpoint;
            _apiVersion = apiVersion;
            _projectName = projectName;
        }

        /// <summary> Gets the status of an existing assign deployment resources job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/ConversationAuthoringDeploymentResources.xml" path="doc/members/member[@name='GetAssignDeploymentResourcesStatusAsync(string,string,CancellationToken)']/*" />
        public virtual async Task<Response<DeploymentResourcesJobState>> GetAssignDeploymentResourcesStatusAsync(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetAssignDeploymentResourcesStatusAsync(_projectName, jobId, context).ConfigureAwait(false);
            return Response.FromValue(DeploymentResourcesJobState.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing assign deployment resources job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<DeploymentResourcesJobState> GetAssignDeploymentResourcesStatus(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetAssignDeploymentResourcesStatus(_projectName, jobId, context);
            return Response.FromValue(DeploymentResourcesJobState.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing unassign deployment resources job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<DeploymentResourcesJobState>> GetUnassignDeploymentResourcesStatusAsync(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetUnassignDeploymentResourcesStatusAsync(_projectName, jobId, context).ConfigureAwait(false);
            return Response.FromValue(DeploymentResourcesJobState.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing unassign deployment resources job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<DeploymentResourcesJobState> GetUnassignDeploymentResourcesStatus(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetUnassignDeploymentResourcesStatus(_projectName, jobId, context);
            return Response.FromValue(DeploymentResourcesJobState.FromResponse(response), response);
        }

        /// <summary> Lists the deployments resources assigned to the project. </summary>
        /// <param name="maxCount"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<AssignedDeploymentResource> GetDeploymentResourcesAsync(
            int? maxCount = null, 
            int? skip = null, 
            int? maxpagesize = null, 
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));

            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetDeploymentResourcesRequest(_projectName, maxCount, skip, pageSizeHint, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetDeploymentResourcesNextPageRequest(nextLink, _projectName, maxCount, skip, pageSizeHint, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => AssignedDeploymentResource.DeserializeAssignedDeploymentResource(e), ClientDiagnostics, _pipeline, "ConversationAuthoringDeploymentResources.GetDeploymentResources", "value", "nextLink", maxpagesize, context);
        }

        /// <summary> Lists the deployments resources assigned to the project. </summary>
        /// <param name="maxCount"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<AssignedDeploymentResource> GetDeploymentResources(
            int? maxCount = null, 
            int? skip = null, 
            int? maxpagesize = null, 
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));

            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetDeploymentResourcesRequest(_projectName, maxCount, skip, pageSizeHint, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetDeploymentResourcesNextPageRequest(nextLink, _projectName, maxCount, skip, pageSizeHint, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => AssignedDeploymentResource.DeserializeAssignedDeploymentResource(e), ClientDiagnostics, _pipeline, "ConversationAuthoringDeploymentResources.GetDeploymentResources", "value", "nextLink", maxpagesize, context);
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
    }
}
