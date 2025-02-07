// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.AI.Language.Conversations.Authoring.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Language.Conversations.Authoring
{
    [CodeGenSuppress("GetProjectsAsync", typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetProjects", typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetSupportedLanguagesAsync", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetSupportedLanguages", typeof(AnalyzeConversationAuthoringProjectKind), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetProjectAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetProject", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("CreateProjectAsync", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("CreateProject", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("GetExportStatusAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetExportStatus", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetImportStatusAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetImportStatus", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("AuthorizeProjectCopyAsync", typeof(string), typeof(AnalyzeConversationAuthoringProjectKind), typeof(string), typeof(bool?), typeof(CancellationToken))]
    [CodeGenSuppress("AuthorizeProjectCopy", typeof(string), typeof(AnalyzeConversationAuthoringProjectKind), typeof(string), typeof(bool?), typeof(CancellationToken))]
    [CodeGenSuppress("GetCopyProjectStatusAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetCopyProjectStatus", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteProjectAsync", typeof(WaitUntil), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("DeleteProject", typeof(WaitUntil), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("ExportAsync", typeof(WaitUntil), typeof(string), typeof(StringIndexType), typeof(AnalyzeConversationAuthoringExportedProjectFormat), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("Export", typeof(WaitUntil), typeof(string), typeof(StringIndexType), typeof(AnalyzeConversationAuthoringExportedProjectFormat), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("ImportAsync", typeof(WaitUntil), typeof(string), typeof(ExportedProject), typeof(AnalyzeConversationAuthoringExportedProjectFormat), typeof(CancellationToken))]
    [CodeGenSuppress("Import", typeof(WaitUntil), typeof(string), typeof(ExportedProject), typeof(AnalyzeConversationAuthoringExportedProjectFormat), typeof(CancellationToken))]
    [CodeGenSuppress("CopyProjectAsync", typeof(WaitUntil), typeof(string), typeof(CopyProjectDetails), typeof(CancellationToken))]
    [CodeGenSuppress("CopyProject", typeof(WaitUntil), typeof(string), typeof(CopyProjectDetails), typeof(CancellationToken))]
    public partial class ConversationAuthoringProjects
    {
        private readonly string _projectName;

        /// <summary> Initializes a new instance of ConversationAuthoringProjects. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="keyCredential"> The key credential to copy. </param>
        /// <param name="tokenCredential"> The token credential to copy. </param>
        /// <param name="endpoint"> Supported Cognitive Services endpoint e.g., https://&lt;resource-name&gt;.api.cognitiveservices.azure.com. </param>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <param name="projectName"> The name of the project. </param>
        internal ConversationAuthoringProjects(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, AzureKeyCredential keyCredential, TokenCredential tokenCredential, Uri endpoint, string apiVersion, string projectName)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
    
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _keyCredential = keyCredential;
            _tokenCredential = tokenCredential;
            _endpoint = endpoint;
            _apiVersion = apiVersion;
            _projectName = projectName; // Added as a member variable
        }

        /// <summary> Gets the details of a project. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='GetProjectAsync(CancellationToken)']/*" />
        public virtual async Task<Response<ProjectMetadata>> GetProjectAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetProjectAsync(_projectName, context).ConfigureAwait(false); // Using the member variable
            return Response.FromValue(ProjectMetadata.FromResponse(response), response);
        }

        /// <summary> Gets the details of a project. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='GetProject(CancellationToken)']/*" />
        public virtual Response<ProjectMetadata> GetProject(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetProject(_projectName, context); // Using the member variable
            return Response.FromValue(ProjectMetadata.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Creates a new project or updates an existing one.
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> CreateProjectAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringProjects.CreateProject");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateProjectRequest(_projectName, content, context); // Using member variable
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Creates a new project or updates an existing one.
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response CreateProject(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringProjects.CreateProject");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateProjectRequest(_projectName, content, context); // Using member variable
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the status of an export job. Once job completes, returns the project metadata, and assets. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='GetExportStatusAsync(CancellationToken)']/*" />
        public virtual async Task<Response<ExportProjectOperationState>> GetExportStatusAsync(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetExportStatusAsync(_projectName, jobId, context).ConfigureAwait(false);
            return Response.FromValue(ExportProjectOperationState.FromResponse(response), response);
        }

        /// <summary> Gets the status of an export job. Once job completes, returns the project metadata, and assets. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='GetExportStatus(CancellationToken)']/*" />
        public virtual Response<ExportProjectOperationState> GetExportStatus(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetExportStatus(_projectName, jobId, context);
            return Response.FromValue(ExportProjectOperationState.FromResponse(response), response);
        }

        /// <summary> Gets the status for an import. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='GetImportStatusAsync(CancellationToken)']/*" />
        public virtual async Task<Response<ImportProjectOperationState>> GetImportStatusAsync(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetImportStatusAsync(_projectName, jobId, context).ConfigureAwait(false);
            return Response.FromValue(ImportProjectOperationState.FromResponse(response), response);
        }

        /// <summary> Gets the status for an import. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='GetImportStatus(CancellationToken)']/*" />
        public virtual Response<ImportProjectOperationState> GetImportStatus(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetImportStatus(_projectName, jobId, context);
            return Response.FromValue(ImportProjectOperationState.FromResponse(response), response);
        }

        /// <summary> Generates a copy project operation authorization to the current target Azure resource. </summary>
        /// <param name="projectKind"> Represents the project kind. </param>
        /// <param name="storageInputContainerName"> The name of the storage container. </param>
        /// <param name="allowOverwrite"> Whether to allow an existing project to be overwritten using the resulting copy authorization. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='AuthorizeProjectCopyAsync(CancellationToken)']/*" />
        public virtual async Task<Response<CopyProjectDetails>> AuthorizeProjectCopyAsync(AnalyzeConversationAuthoringProjectKind projectKind, string storageInputContainerName = null, bool? allowOverwrite = null, CancellationToken cancellationToken = default)
        {
            CopyProjectAuthorizationRequest copyProjectAuthorizationRequest = new CopyProjectAuthorizationRequest(projectKind, storageInputContainerName, allowOverwrite, null);
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await AuthorizeProjectCopyAsync(_projectName, copyProjectAuthorizationRequest.ToRequestContent(), context).ConfigureAwait(false);
            return Response.FromValue(CopyProjectDetails.FromResponse(response), response);
        }

        /// <summary> Generates a copy project operation authorization to the current target Azure resource. </summary>
        /// <param name="projectKind"> Represents the project kind. </param>
        /// <param name="storageInputContainerName"> The name of the storage container. </param>
        /// <param name="allowOverwrite"> Whether to allow an existing project to be overwritten using the resulting copy authorization. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='AuthorizeProjectCopy(CancellationToken)']/*" />
        public virtual Response<CopyProjectDetails> AuthorizeProjectCopy(AnalyzeConversationAuthoringProjectKind projectKind, string storageInputContainerName = null, bool? allowOverwrite = null, CancellationToken cancellationToken = default)
        {
            CopyProjectAuthorizationRequest copyProjectAuthorizationRequest = new CopyProjectAuthorizationRequest(projectKind, storageInputContainerName, allowOverwrite, null);
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = AuthorizeProjectCopy(_projectName, copyProjectAuthorizationRequest.ToRequestContent(), context);
            return Response.FromValue(CopyProjectDetails.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing copy project job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='GetCopyProjectStatusAsync(CancellationToken)']/*" />
        public virtual async Task<Response<CopyProjectOperationState>> GetCopyProjectStatusAsync(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetCopyProjectStatusAsync(_projectName, jobId, context).ConfigureAwait(false);
            return Response.FromValue(CopyProjectOperationState.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing copy project job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='GetCopyProjectStatus(CancellationToken)']/*" />
        public virtual Response<CopyProjectOperationState> GetCopyProjectStatus(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetCopyProjectStatus(_projectName, jobId, context);
            return Response.FromValue(CopyProjectOperationState.FromResponse(response), response);
        }

        /// <summary> [Protocol Method] Deletes a project. </summary>
        /// <param name="waitUntil"> Determines if the method should wait until the operation completes or just starts. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='DeleteProjectAsync(WaitUntil,RequestContext)']/*" />
        public virtual async Task<Operation> DeleteProjectAsync(WaitUntil waitUntil, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringProjects.DeleteProject");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteProjectRequest(_projectName, context);
                return await ProtocolOperationHelpers.ProcessMessageWithoutResponseValueAsync(
                    _pipeline,
                    message,
                    ClientDiagnostics,
                    "ConversationAuthoringProjects.DeleteProject",
                    OperationFinalStateVia.OperationLocation,
                    context,
                    waitUntil
                ).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> [Protocol Method] Deletes a project. </summary>
        /// <param name="waitUntil"> Determines if the method should wait until the operation completes or just starts. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='DeleteProject(WaitUntil,RequestContext)']/*" />
        public virtual Operation DeleteProject(WaitUntil waitUntil, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringProjects.DeleteProject");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteProjectRequest(_projectName, context);
                return ProtocolOperationHelpers.ProcessMessageWithoutResponseValue(
                    _pipeline,
                    message,
                    ClientDiagnostics,
                    "ConversationAuthoringProjects.DeleteProject",
                    OperationFinalStateVia.OperationLocation,
                    context,
                    waitUntil
                );
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Triggers a job to export a project's data. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="stringIndexType"> Specifies the method used to interpret string offsets. </param>
        /// <param name="exportedProjectFormat"> The format of the exported project file to use. </param>
        /// <param name="assetKind"> Kind of asset to export. </param>
        /// <param name="trainedModelLabel"> Trained model label to export. If null, exports the current working copy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Operation> ExportAsync(WaitUntil waitUntil, StringIndexType stringIndexType, AnalyzeConversationAuthoringExportedProjectFormat? exportedProjectFormat = null, string assetKind = null, string trainedModelLabel = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            return await ExportAsync(waitUntil, _projectName, stringIndexType.ToString(), exportedProjectFormat?.ToString(), assetKind, trainedModelLabel, context).ConfigureAwait(false);
        }

        /// <summary> Triggers a job to export a project's data. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="stringIndexType"> Specifies the method used to interpret string offsets. </param>
        /// <param name="exportedProjectFormat"> The format of the exported project file to use. </param>
        /// <param name="assetKind"> Kind of asset to export. </param>
        /// <param name="trainedModelLabel"> Trained model label to export. If null, exports the current working copy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Operation Export(WaitUntil waitUntil, StringIndexType stringIndexType, AnalyzeConversationAuthoringExportedProjectFormat? exportedProjectFormat = null, string assetKind = null, string trainedModelLabel = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            return Export(waitUntil, _projectName, stringIndexType.ToString(), exportedProjectFormat?.ToString(), assetKind, trainedModelLabel, context);
        }

        /// <summary> Triggers a job to import a project. If a project with the same name already exists, the data of that project is replaced. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="exportedProject"> The project data to import. </param>
        /// <param name="exportedProjectFormat"> The format of the exported project file to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Operation> ImportAsync(WaitUntil waitUntil, ExportedProject exportedProject, AnalyzeConversationAuthoringExportedProjectFormat? exportedProjectFormat = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(exportedProject, nameof(exportedProject));

            using RequestContent content = exportedProject.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return await ImportAsync(waitUntil, _projectName, content, exportedProjectFormat?.ToString(), context).ConfigureAwait(false);
        }

        /// <summary> Triggers a job to import a project. If a project with the same name already exists, the data of that project is replaced. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="exportedProject"> The project data to import. </param>
        /// <param name="exportedProjectFormat"> The format of the exported project file to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Operation Import(WaitUntil waitUntil, ExportedProject exportedProject, AnalyzeConversationAuthoringExportedProjectFormat? exportedProjectFormat = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(exportedProject, nameof(exportedProject));

            using RequestContent content = exportedProject.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return Import(waitUntil, _projectName, content, exportedProjectFormat?.ToString(), context);
        }

        /// <summary> Copies an existing project to another Azure resource. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="details"> The copy project info. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Operation> CopyProjectAsync(WaitUntil waitUntil, CopyProjectDetails details, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(details, nameof(details));

            using RequestContent content = details.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return await CopyProjectAsync(waitUntil, _projectName, content, context).ConfigureAwait(false);
        }

        /// <summary> Copies an existing project to another Azure resource. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="details"> The copy project info. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Operation CopyProject(WaitUntil waitUntil, CopyProjectDetails details, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(details, nameof(details));

            using RequestContent content = details.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return CopyProject(waitUntil, _projectName, content, context);
        }
    }
}
