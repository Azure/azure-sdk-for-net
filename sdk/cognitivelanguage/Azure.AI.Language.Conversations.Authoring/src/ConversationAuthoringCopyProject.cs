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
        /// <include file="Generated/Docs/ConversationAuthoringCopyProject.xml" path="doc/members/member[@name='CopyProjectAuthorizationAsync(string,AnalyzeConversationAuthoringProjectKind,string,bool?,CancellationToken)']/*" />
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
        /// <include file="Generated/Docs/ConversationAuthoringCopyProject.xml" path="doc/members/member[@name='CopyProjectAuthorization(string,AnalyzeConversationAuthoringProjectKind,string,bool?,CancellationToken)']/*" />
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
        /// <include file="Generated/Docs/ConversationAuthoringCopyProject.xml" path="doc/members/member[@name='GetCopyProjectStatusAsync(string,string,CancellationToken)']/*" />
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
        /// <include file="Generated/Docs/ConversationAuthoringCopyProject.xml" path="doc/members/member[@name='GetCopyProjectStatus(string,string,CancellationToken)']/*" />
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
        /// <include file="Generated/Docs/ConversationAuthoringCopyProject.xml" path="doc/members/member[@name='CopyProjectAsync(WaitUntil,string,CopyProjectDetails,CancellationToken)']/*" />
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
        /// <include file="Generated/Docs/ConversationAuthoringCopyProject.xml" path="doc/members/member[@name='CopyProject(WaitUntil,string,CopyProjectDetails,CancellationToken)']/*" />
        public virtual Operation CopyProject(WaitUntil waitUntil, CopyProjectDetails body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return CopyProject(waitUntil, _projectName, content, context);
        }

        /// <summary>
        /// [Protocol Method] Gets the status of an existing copy project job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetCopyProjectStatusAsync(string,CancellationToken)"/> convenience overload with strongly typed models first.
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
        /// <include file="Generated/Docs/ConversationAuthoringCopyProject.xml" path="doc/members/member[@name='GetCopyProjectStatusAsync(string,string,RequestContext)']/*" />
        public virtual async Task<Response> GetCopyProjectStatusAsync(string projectName, string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringCopyProject.GetCopyProjectStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetCopyProjectStatusRequest(projectName, jobId, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the status of an existing copy project job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetCopyProjectStatus(string,CancellationToken)"/> convenience overload with strongly typed models first.
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
        /// <include file="Generated/Docs/ConversationAuthoringCopyProject.xml" path="doc/members/member[@name='GetCopyProjectStatus(string,string,RequestContext)']/*" />
        public virtual Response GetCopyProjectStatus(string projectName, string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringCopyProject.GetCopyProjectStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetCopyProjectStatusRequest(projectName, jobId, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Copies an existing project to another Azure resource.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CopyProjectAsync(WaitUntil,CopyProjectDetails,CancellationToken)"/> convenience overload with strongly typed models first.
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
        /// <include file="Generated/Docs/ConversationAuthoringCopyProject.xml" path="doc/members/member[@name='CopyProjectAsync(WaitUntil,string,RequestContent,RequestContext)']/*" />
        public virtual async Task<Operation> CopyProjectAsync(WaitUntil waitUntil, string projectName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringCopyProject.CopyProject");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCopyProjectRequest(projectName, content, context);
                return await ProtocolOperationHelpers.ProcessMessageWithoutResponseValueAsync(_pipeline, message, ClientDiagnostics, "ConversationAuthoringCopyProject.CopyProject", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Copies an existing project to another Azure resource.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CopyProject(WaitUntil,CopyProjectDetails,CancellationToken)"/> convenience overload with strongly typed models first.
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
        /// <include file="Generated/Docs/ConversationAuthoringCopyProject.xml" path="doc/members/member[@name='CopyProject(WaitUntil,string,RequestContent,RequestContext)']/*" />
        public virtual Operation CopyProject(WaitUntil waitUntil, string projectName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringCopyProject.CopyProject");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCopyProjectRequest(projectName, content, context);
                return ProtocolOperationHelpers.ProcessMessageWithoutResponseValue(_pipeline, message, ClientDiagnostics, "ConversationAuthoringCopyProject.CopyProject", OperationFinalStateVia.OperationLocation, context, waitUntil);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Generates a copy project operation authorization to the current target Azure resource.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CopyProjectAuthorizationAsync(AnalyzeConversationAuthoringProjectKind,string,bool?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The new project name. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/ConversationAuthoringCopyProject.xml" path="doc/members/member[@name='CopyProjectAuthorizationAsync(string,RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> CopyProjectAuthorizationAsync(string projectName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringCopyProject.CopyProjectAuthorization");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCopyProjectAuthorizationRequest(projectName, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Generates a copy project operation authorization to the current target Azure resource.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CopyProjectAuthorization(AnalyzeConversationAuthoringProjectKind,string,bool?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The new project name. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/ConversationAuthoringCopyProject.xml" path="doc/members/member[@name='CopyProjectAuthorization(string,RequestContent,RequestContext)']/*" />
        public virtual Response CopyProjectAuthorization(string projectName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringCopyProject.CopyProjectAuthorization");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCopyProjectAuthorizationRequest(projectName, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
