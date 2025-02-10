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
    //[CodeGenSuppress("GetProjectsAsync", typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    //[CodeGenSuppress("GetProjects", typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    //[CodeGenSuppress("GetSupportedLanguagesAsync", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    //[CodeGenSuppress("GetSupportedLanguages", typeof(AnalyzeConversationAuthoringProjectKind), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetProjectAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetProject", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetProjectAsync", typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetProject", typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("CreateProjectAsync", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("CreateProject", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("GetExportStatusAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetExportStatus", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetExportStatusAsync", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetExportStatus", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetImportStatusAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetImportStatus", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetImportStatusAsync", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetImportStatus", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("AuthorizeProjectCopyAsync", typeof(string), typeof(AnalyzeConversationAuthoringProjectKind), typeof(string), typeof(bool?), typeof(CancellationToken))]
    [CodeGenSuppress("AuthorizeProjectCopy", typeof(string), typeof(AnalyzeConversationAuthoringProjectKind), typeof(string), typeof(bool?), typeof(CancellationToken))]
    [CodeGenSuppress("AuthorizeProjectCopyAsync", typeof(string), typeof(AnalyzeConversationAuthoringProjectKind), typeof(string), typeof(bool?), typeof(RequestContext))]
    [CodeGenSuppress("AuthorizeProjectCopy", typeof(string), typeof(AnalyzeConversationAuthoringProjectKind), typeof(string), typeof(bool?), typeof(RequestContext))]
    [CodeGenSuppress("GetCopyProjectStatusAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetCopyProjectStatus", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetCopyProjectStatusAsync", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetCopyProjectStatus", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("DeleteProjectAsync", typeof(WaitUntil), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("DeleteProject", typeof(WaitUntil), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("ExportAsync", typeof(WaitUntil), typeof(string), typeof(StringIndexType), typeof(AnalyzeConversationAuthoringExportedProjectFormat), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("Export", typeof(WaitUntil), typeof(string), typeof(StringIndexType), typeof(AnalyzeConversationAuthoringExportedProjectFormat), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("ImportAsync", typeof(WaitUntil), typeof(string), typeof(ExportedProject), typeof(AnalyzeConversationAuthoringExportedProjectFormat), typeof(CancellationToken))]
    [CodeGenSuppress("Import", typeof(WaitUntil), typeof(string), typeof(ExportedProject), typeof(AnalyzeConversationAuthoringExportedProjectFormat), typeof(CancellationToken))]
    [CodeGenSuppress("CopyProjectAsync", typeof(WaitUntil), typeof(string), typeof(CopyProjectDetails), typeof(CancellationToken))]
    [CodeGenSuppress("CopyProject", typeof(WaitUntil), typeof(string), typeof(CopyProjectDetails), typeof(CancellationToken))]
    [CodeGenSuppress("CopyProjectAsync", typeof(WaitUntil), typeof(string), typeof(CopyProjectDetails), typeof(RequestContext))]
    [CodeGenSuppress("CopyProject", typeof(WaitUntil), typeof(string), typeof(CopyProjectDetails), typeof(RequestContext))]
    [CodeGenSuppress("GetTrainingStatusAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetTrainingStatus", typeof(string), typeof(string), typeof(CancellationToken))]
    //[CodeGenSuppress("GetTrainingJobsAsync", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    //[CodeGenSuppress("GetTrainingJobs", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("TrainAsync", typeof(WaitUntil), typeof(string), typeof(TrainingJobDetails), typeof(CancellationToken))]
    [CodeGenSuppress("Train", typeof(WaitUntil), typeof(string), typeof(TrainingJobDetails), typeof(CancellationToken))]
    [CodeGenSuppress("CancelTrainingJobAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("CancelTrainingJob", typeof(WaitUntil), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetTrainingConfigVersionsAsync", typeof(AnalyzeConversationAuthoringProjectKind), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetTrainingConfigVersions", typeof(AnalyzeConversationAuthoringProjectKind), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
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
        /// <include file="Generated/Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='GetProjectAsync(CancellationToken)']/*" />
        public virtual async Task<Response<ProjectMetadata>> GetProjectAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetProjectAsync(_projectName, context).ConfigureAwait(false); // Using the member variable
            return Response.FromValue(ProjectMetadata.FromResponse(response), response);
        }

        /// <summary> Gets the details of a project. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Generated/Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='GetProject(CancellationToken)']/*" />
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
        /// <include file="Generated/Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='GetExportStatusAsync(CancellationToken)']/*" />
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
        /// <include file="Generated/Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='GetExportStatus(CancellationToken)']/*" />
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
        /// <include file="Generated/Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='GetImportStatusAsync(CancellationToken)']/*" />
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
        /// <include file="Generated/Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='GetImportStatus(CancellationToken)']/*" />
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
        /// <include file="Generated/Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='AuthorizeProjectCopyAsync(CancellationToken)']/*" />
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
        /// <include file="Generated/Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='AuthorizeProjectCopy(CancellationToken)']/*" />
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
        /// <include file="Generated/Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='GetCopyProjectStatusAsync(CancellationToken)']/*" />
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
        /// <include file="Generated/Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='GetCopyProjectStatus(CancellationToken)']/*" />
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
        /// <include file="Generated/Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='DeleteProjectAsync(WaitUntil,RequestContext)']/*" />
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
        /// <include file="Generated/Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='DeleteProject(WaitUntil,RequestContext)']/*" />
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

        /// <summary> Gets the status for a training job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<TrainingOperationState>> GetTrainingStatusAsync(
            string jobId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetTrainingStatusAsync(_projectName, jobId, context).ConfigureAwait(false);
            return Response.FromValue(TrainingOperationState.FromResponse(response), response);
        }

        /// <summary> Gets the status for a training job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TrainingOperationState> GetTrainingStatus(
            string jobId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetTrainingStatus(_projectName, jobId, context);
            return Response.FromValue(TrainingOperationState.FromResponse(response), response);
        }

        /// <summary> Triggers a training job for a project. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="details"> The training input parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Operation<TrainingJobResult>> TrainAsync(
            WaitUntil waitUntil,
            TrainingJobDetails details,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(details, nameof(details));

            using RequestContent content = details.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> response = await TrainAsync(waitUntil, _projectName, content, context).ConfigureAwait(false);
            return ProtocolOperationHelpers.Convert(response, FetchTrainingJobResultFromTrainingOperationState, ClientDiagnostics, "ConversationAuthoringTraining.Train");
        }

        /// <summary> Triggers a training job for a project. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="body"> The training input parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Operation<TrainingJobResult> Train(
            WaitUntil waitUntil,
            TrainingJobDetails body,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> response = Train(waitUntil, _projectName, content, context);
            return ProtocolOperationHelpers.Convert(response, FetchTrainingJobResultFromTrainingOperationState, ClientDiagnostics, "ConversationAuthoringTraining.Train");
        }

        /// <summary> Triggers a cancellation for a running training job. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Operation<TrainingJobResult>> CancelTrainingJobAsync(
            WaitUntil waitUntil,
            string jobId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> response = await CancelTrainingJobAsync(waitUntil, _projectName, jobId, context).ConfigureAwait(false);
            return ProtocolOperationHelpers.Convert(response, FetchTrainingJobResultFromTrainingOperationState, ClientDiagnostics, "ConversationAuthoringTraining.CancelTrainingJob");
        }

        /// <summary> Triggers a cancellation for a running training job. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Operation<TrainingJobResult> CancelTrainingJob(
            WaitUntil waitUntil,
            string jobId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> response = CancelTrainingJob(waitUntil, _projectName, jobId, context);
            return ProtocolOperationHelpers.Convert(response, FetchTrainingJobResultFromTrainingOperationState, ClientDiagnostics, "ConversationAuthoringTraining.CancelTrainingJob");
        }

        /// <summary>
        /// [Protocol Method] Gets the status for a training job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetTrainingStatusAsync(string,CancellationToken)"/> convenience overload with strongly typed models first.
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
        /// <include file="Generated/Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='GetTrainingStatusAsync(string,string,RequestContext)']/*" />
        public virtual async Task<Response> GetTrainingStatusAsync(string projectName, string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringTraining.GetTrainingStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetTrainingStatusRequest(projectName, jobId, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the status for a training job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetTrainingStatus(string,CancellationToken)"/> convenience overload with strongly typed models first.
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
        /// <include file="Generated/Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='GetTrainingStatus(string,string,RequestContext)']/*" />
        public virtual Response GetTrainingStatus(string projectName, string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringTraining.GetTrainingStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetTrainingStatusRequest(projectName, jobId, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary>
        /// [Protocol Method] Triggers a training job for a project.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="TrainAsync(WaitUntil,TrainingJobDetails,CancellationToken)"/> convenience overload with strongly typed models first.
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
        /// <include file="Generated/Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='TrainAsync(WaitUntil,string,RequestContent,RequestContext)']/*" />
        public virtual async Task<Operation<BinaryData>> TrainAsync(WaitUntil waitUntil, string projectName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringTraining.Train");
            scope.Start();
            try
            {
                using HttpMessage message = CreateTrainRequest(projectName, content, context);
                return await ProtocolOperationHelpers.ProcessMessageAsync(_pipeline, message, ClientDiagnostics, "ConversationAuthoringTraining.Train", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Triggers a training job for a project.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Train(WaitUntil,TrainingJobDetails,CancellationToken)"/> convenience overload with strongly typed models first.
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
        /// <include file="Generated/Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='Train(WaitUntil,string,RequestContent,RequestContext)']/*" />
        public virtual Operation<BinaryData> Train(WaitUntil waitUntil, string projectName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringTraining.Train");
            scope.Start();
            try
            {
                using HttpMessage message = CreateTrainRequest(projectName, content, context);
                return ProtocolOperationHelpers.ProcessMessage(_pipeline, message, ClientDiagnostics, "ConversationAuthoringTraining.Train", OperationFinalStateVia.OperationLocation, context, waitUntil);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Triggers a cancellation for a running training job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CancelTrainingJobAsync(WaitUntil,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="projectName"> The name of the project to use. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> or <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Generated/Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='CancelTrainingJobAsync(WaitUntil,string,string,RequestContext)']/*" />
        public virtual async Task<Operation<BinaryData>> CancelTrainingJobAsync(WaitUntil waitUntil, string projectName, string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringTraining.CancelTrainingJob");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCancelTrainingJobRequest(projectName, jobId, context);
                return await ProtocolOperationHelpers.ProcessMessageAsync(_pipeline, message, ClientDiagnostics, "ConversationAuthoringTraining.CancelTrainingJob", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Triggers a cancellation for a running training job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CancelTrainingJob(WaitUntil,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="projectName"> The name of the project to use. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> or <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Generated/Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='CancelTrainingJob(WaitUntil,string,string,RequestContext)']/*" />
        public virtual Operation<BinaryData> CancelTrainingJob(WaitUntil waitUntil, string projectName, string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringTraining.CancelTrainingJob");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCancelTrainingJobRequest(projectName, jobId, context);
                return ProtocolOperationHelpers.ProcessMessage(_pipeline, message, ClientDiagnostics, "ConversationAuthoringTraining.CancelTrainingJob", OperationFinalStateVia.OperationLocation, context, waitUntil);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the details of a project.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetProjectAsync(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The new project name. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='GetProjectAsync(string,RequestContext)']/*" />
        public virtual async Task<Response> GetProjectAsync(string projectName, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringProjects.GetProject");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetProjectRequest(projectName, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the details of a project.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetProject(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The new project name. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='GetProject(string,RequestContext)']/*" />
        public virtual Response GetProject(string projectName, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringProjects.GetProject");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetProjectRequest(projectName, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the status of an export job. Once job completes, returns the project metadata, and assets.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetExportStatusAsync(string,CancellationToken)"/> convenience overload with strongly typed models first.
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
        /// <include file="Generated/Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='GetExportStatusAsync(string,string,RequestContext)']/*" />
        public virtual async Task<Response> GetExportStatusAsync(string projectName, string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringProjects.GetExportStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetExportStatusRequest(projectName, jobId, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the status of an export job. Once job completes, returns the project metadata, and assets.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetExportStatus(string,CancellationToken)"/> convenience overload with strongly typed models first.
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
        /// <include file="Generated/Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='GetExportStatus(string,string,RequestContext)']/*" />
        public virtual Response GetExportStatus(string projectName, string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringProjects.GetExportStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetExportStatusRequest(projectName, jobId, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the status for an import.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetImportStatusAsync(string,CancellationToken)"/> convenience overload with strongly typed models first.
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
        /// <include file="Generated/Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='GetImportStatusAsync(string,string,RequestContext)']/*" />
        public virtual async Task<Response> GetImportStatusAsync(string projectName, string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringProjects.GetImportStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetImportStatusRequest(projectName, jobId, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the status for an import.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetImportStatus(string,CancellationToken)"/> convenience overload with strongly typed models first.
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
        /// <include file="Generated/Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='GetImportStatus(string,string,RequestContext)']/*" />
        public virtual Response GetImportStatus(string projectName, string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringProjects.GetImportStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetImportStatusRequest(projectName, jobId, context);
                return _pipeline.ProcessMessage(message, context);
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
        /// Please try the simpler <see cref="AuthorizeProjectCopyAsync(AnalyzeConversationAuthoringProjectKind,string,bool?,CancellationToken)"/> convenience overload with strongly typed models first.
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
        /// <include file="Generated/Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='AuthorizeProjectCopyAsync(string,RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> AuthorizeProjectCopyAsync(string projectName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringProjects.AuthorizeProjectCopy");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAuthorizeProjectCopyRequest(projectName, content, context);
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
        /// Please try the simpler <see cref="AuthorizeProjectCopy(AnalyzeConversationAuthoringProjectKind,string,bool?,CancellationToken)"/> convenience overload with strongly typed models first.
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
        /// <include file="Generated/Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='AuthorizeProjectCopy(string,RequestContent,RequestContext)']/*" />
        public virtual Response AuthorizeProjectCopy(string projectName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringProjects.AuthorizeProjectCopy");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAuthorizeProjectCopyRequest(projectName, content, context);
                return _pipeline.ProcessMessage(message, context);
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
        /// <include file="Generated/Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='GetCopyProjectStatusAsync(string,string,RequestContext)']/*" />
        public virtual async Task<Response> GetCopyProjectStatusAsync(string projectName, string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringProjects.GetCopyProjectStatus");
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
        /// <include file="Generated/Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='GetCopyProjectStatus(string,string,RequestContext)']/*" />
        public virtual Response GetCopyProjectStatus(string projectName, string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringProjects.GetCopyProjectStatus");
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
        /// <include file="Generated/Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='CopyProjectAsync(WaitUntil,string,RequestContent,RequestContext)']/*" />
        public virtual async Task<Operation> CopyProjectAsync(WaitUntil waitUntil, string projectName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringProjects.CopyProject");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCopyProjectRequest(projectName, content, context);
                return await ProtocolOperationHelpers.ProcessMessageWithoutResponseValueAsync(_pipeline, message, ClientDiagnostics, "ConversationAuthoringProjects.CopyProject", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
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
        /// <include file="Generated/Docs/ConversationAuthoringProjects.xml" path="doc/members/member[@name='CopyProject(WaitUntil,string,RequestContent,RequestContext)']/*" />
        public virtual Operation CopyProject(WaitUntil waitUntil, string projectName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringProjects.CopyProject");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCopyProjectRequest(projectName, content, context);
                return ProtocolOperationHelpers.ProcessMessageWithoutResponseValue(_pipeline, message, ClientDiagnostics, "ConversationAuthoringProjects.CopyProject", OperationFinalStateVia.OperationLocation, context, waitUntil);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
