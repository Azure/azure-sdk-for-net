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
    [CodeGenSuppress("CopyProjectAuthorizationAsync", typeof(string), typeof(AnalyzeConversationAuthoringProjectKind), typeof(string), typeof(bool?), typeof(CancellationToken))]
    [CodeGenSuppress("CopyProjectAuthorization", typeof(string), typeof(AnalyzeConversationAuthoringProjectKind), typeof(string), typeof(bool?), typeof(CancellationToken))]
    [CodeGenSuppress("GetCopyProjectStatusAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetCopyProjectStatus", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("CopyProjectAsync", typeof(WaitUntil), typeof(string), typeof(CopyProjectDetails), typeof(CancellationToken))]
    [CodeGenSuppress("CopyProject", typeof(WaitUntil), typeof(string), typeof(CopyProjectDetails), typeof(CancellationToken))]
    public partial class ConversationAuthoringCopyProject
    {
        private readonly string _projectName;

        /// <summary> Initializes a new instance of ConversationAuthoringCopyProject. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="keyCredential"> The key credential to copy. </param>
        /// <param name="tokenCredential"> The token credential to copy. </param>
        /// <param name="endpoint"> Supported Cognitive Services endpoint e.g., https://&lt;resource-name&gt;.api.cognitiveservices.azure.com. </param>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <param name="projectName"> The new project name. </param>
        internal ConversationAuthoringCopyProject(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, AzureKeyCredential keyCredential, TokenCredential tokenCredential, Uri endpoint, string apiVersion, string projectName)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _keyCredential = keyCredential;
            _tokenCredential = tokenCredential;
            _endpoint = endpoint;
            _apiVersion = apiVersion;
            _projectName = projectName;
        }

        /// <summary> Generates a copy project operation authorization to the current target Azure resource. </summary>
        /// <param name="projectKind"> Represents the project kind. </param>
        /// <param name="storageInputContainerName"> The name of the storage container. </param>
        /// <param name="allowOverwrite"> Whether to allow an existing project to be overwritten using the resulting copy authorization. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConversationAuthoringCopyProject.xml" path="doc/members/member[@name='CopyProjectAuthorizationAsync(string,AnalyzeConversationAuthoringProjectKind,string,bool?,CancellationToken)']/*" />
        public virtual async Task<Response<CopyProjectDetails>> CopyProjectAuthorizationAsync(AnalyzeConversationAuthoringProjectKind projectKind, string storageInputContainerName = null, bool? allowOverwrite = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));

            CopyProjectAuthorizationRequest copyProjectAuthorizationRequest = new CopyProjectAuthorizationRequest(projectKind, storageInputContainerName, allowOverwrite, null);
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await CopyProjectAuthorizationAsync(_projectName, copyProjectAuthorizationRequest.ToRequestContent(), context).ConfigureAwait(false);
            return Response.FromValue(CopyProjectDetails.FromResponse(response), response);
        }

        /// <summary> Generates a copy project operation authorization to the current target Azure resource. </summary>
        /// <param name="projectKind"> Represents the project kind. </param>
        /// <param name="storageInputContainerName"> The name of the storage container. </param>
        /// <param name="allowOverwrite"> Whether to allow an existing project to be overwritten using the resulting copy authorization. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConversationAuthoringCopyProject.xml" path="doc/members/member[@name='CopyProjectAuthorization(string,AnalyzeConversationAuthoringProjectKind,string,bool?,CancellationToken)']/*" />
        public virtual Response<CopyProjectDetails> CopyProjectAuthorization(AnalyzeConversationAuthoringProjectKind projectKind, string storageInputContainerName = null, bool? allowOverwrite = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));

            CopyProjectAuthorizationRequest copyProjectAuthorizationRequest = new CopyProjectAuthorizationRequest(projectKind, storageInputContainerName, allowOverwrite, null);
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = CopyProjectAuthorization(_projectName, copyProjectAuthorizationRequest.ToRequestContent(), context);
            return Response.FromValue(CopyProjectDetails.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing copy project job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConversationAuthoringCopyProject.xml" path="doc/members/member[@name='GetCopyProjectStatusAsync(string,string,CancellationToken)']/*" />
        public virtual async Task<Response<CopyProjectJobState>> GetCopyProjectStatusAsync(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetCopyProjectStatusAsync(_projectName, jobId, context).ConfigureAwait(false);
            return Response.FromValue(CopyProjectJobState.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing copy project job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConversationAuthoringCopyProject.xml" path="doc/members/member[@name='GetCopyProjectStatus(string,string,CancellationToken)']/*" />
        public virtual Response<CopyProjectJobState> GetCopyProjectStatus(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetCopyProjectStatus(_projectName, jobId, context);
            return Response.FromValue(CopyProjectJobState.FromResponse(response), response);
        }

        /// <summary> Copies an existing project to another Azure resource. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="body"> The copy project info. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConversationAuthoringCopyProject.xml" path="doc/members/member[@name='CopyProjectAsync(WaitUntil,string,CopyProjectDetails,CancellationToken)']/*" />
        public virtual async Task<Operation> CopyProjectAsync(WaitUntil waitUntil, CopyProjectDetails body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return await CopyProjectAsync(waitUntil, _projectName, content, context).ConfigureAwait(false);
        }

        /// <summary> Copies an existing project to another Azure resource. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="body"> The copy project info. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConversationAuthoringCopyProject.xml" path="doc/members/member[@name='CopyProject(WaitUntil,string,CopyProjectDetails,CancellationToken)']/*" />
        public virtual Operation CopyProject(WaitUntil waitUntil, CopyProjectDetails body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return CopyProject(waitUntil, _projectName, content, context);
        }
    }
}
