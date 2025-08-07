// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Language.Text.Authoring
{
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
    [CodeGenSuppress("AuthorizeProjectCopyAsync", typeof(string), typeof(TextAuthoringProjectKind), typeof(string), typeof(bool?), typeof(CancellationToken))]
    [CodeGenSuppress("AuthorizeProjectCopy", typeof(string), typeof(TextAuthoringProjectKind), typeof(string), typeof(bool?), typeof(CancellationToken))]
    [CodeGenSuppress("AuthorizeProjectCopyAsync", typeof(string), typeof(TextAuthoringProjectKind), typeof(string), typeof(bool?), typeof(RequestContext))]
    [CodeGenSuppress("AuthorizeProjectCopy", typeof(string), typeof(TextAuthoringProjectKind), typeof(string), typeof(bool?), typeof(RequestContext))]
    [CodeGenSuppress("GetCopyProjectStatusAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetCopyProjectStatus", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetCopyProjectStatusAsync", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetCopyProjectStatus", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("DeleteProjectAsync", typeof(WaitUntil), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("DeleteProject", typeof(WaitUntil), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("ExportAsync", typeof(WaitUntil), typeof(string), typeof(StringIndexType), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("Export", typeof(WaitUntil), typeof(string), typeof(StringIndexType), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("ImportAsync", typeof(WaitUntil), typeof(string), typeof(TextAuthoringExportedProject), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("Import", typeof(WaitUntil), typeof(string), typeof(TextAuthoringExportedProject), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("CopyProjectAsync", typeof(WaitUntil), typeof(string), typeof(TextAuthoringCopyProjectDetails), typeof(CancellationToken))]
    [CodeGenSuppress("CopyProject", typeof(WaitUntil), typeof(string), typeof(TextAuthoringCopyProjectDetails), typeof(CancellationToken))]
    [CodeGenSuppress("CopyProjectAsync", typeof(WaitUntil), typeof(string), typeof(TextAuthoringCopyProjectDetails), typeof(RequestContext))]
    [CodeGenSuppress("CopyProject", typeof(WaitUntil), typeof(string), typeof(TextAuthoringCopyProjectDetails), typeof(RequestContext))]
    [CodeGenSuppress("GetTrainingStatusAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetTrainingStatus", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("TrainAsync", typeof(WaitUntil), typeof(string), typeof(TextAuthoringTrainingJobDetails), typeof(CancellationToken))]
    [CodeGenSuppress("Train", typeof(WaitUntil), typeof(string), typeof(TextAuthoringTrainingJobDetails), typeof(CancellationToken))]
    [CodeGenSuppress("CancelTrainingJobAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("CancelTrainingJob", typeof(WaitUntil), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetTrainingConfigVersionsAsync", typeof(TextAuthoringProjectKind), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetTrainingConfigVersions", typeof(TextAuthoringProjectKind), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("AuthorizeProjectCopyAsync", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("AuthorizeProjectCopy", typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("GetTrainingStatusAsync", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetTrainingStatus", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("CopyProjectAsync", typeof(WaitUntil), typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("CopyProject", typeof(WaitUntil), typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("ExportAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("Export", typeof(WaitUntil), typeof(string), typeof(string), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("ImportAsync", typeof(WaitUntil), typeof(string), typeof(RequestContent), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("Import", typeof(WaitUntil), typeof(string), typeof(RequestContent), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("TrainAsync", typeof(WaitUntil), typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("Train", typeof(WaitUntil), typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("CancelTrainingJobAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("CancelTrainingJob", typeof(WaitUntil), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("AssignDeploymentResourcesAsync", typeof(WaitUntil), typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("AssignDeploymentResources", typeof(WaitUntil), typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("UnassignDeploymentResourcesAsync", typeof(WaitUntil), typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("UnassignDeploymentResources", typeof(WaitUntil), typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("AssignDeploymentResourcesAsync", typeof(WaitUntil), typeof(string), typeof(TextAuthoringAssignDeploymentResourcesDetails), typeof(CancellationToken))]
    [CodeGenSuppress("AssignDeploymentResources", typeof(WaitUntil), typeof(string), typeof(TextAuthoringAssignDeploymentResourcesDetails), typeof(CancellationToken))]
    [CodeGenSuppress("UnassignDeploymentResourcesAsync", typeof(WaitUntil), typeof(string), typeof(TextAuthoringUnassignDeploymentResourcesDetails), typeof(CancellationToken))]
    [CodeGenSuppress("UnassignDeploymentResources", typeof(WaitUntil), typeof(string), typeof(TextAuthoringUnassignDeploymentResourcesDetails), typeof(CancellationToken))]
    [CodeGenSuppress("GetAssignDeploymentResourcesStatusAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetAssignDeploymentResourcesStatus", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetUnassignDeploymentResourcesStatusAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetUnassignDeploymentResourcesStatus", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetAssignDeploymentResourcesStatusAsync", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetAssignDeploymentResourcesStatus", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetUnassignDeploymentResourcesStatusAsync", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetUnassignDeploymentResourcesStatus", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetSwapDeploymentsStatusAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSwapDeploymentsStatus", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSwapDeploymentsStatusAsync", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetSwapDeploymentsStatus", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("SwapDeploymentsAsync", typeof(WaitUntil), typeof(string), typeof(TextAuthoringSwapDeploymentsDetails), typeof(CancellationToken))]
    [CodeGenSuppress("SwapDeployments", typeof(WaitUntil), typeof(string), typeof(TextAuthoringSwapDeploymentsDetails), typeof(CancellationToken))]
    [CodeGenSuppress("SwapDeploymentsAsync", typeof(WaitUntil), typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("SwapDeployments", typeof(WaitUntil), typeof(string), typeof(RequestContent), typeof(RequestContext))]
    //[CodeGenSuppress("GetProjectsAsync", typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    //[CodeGenSuppress("GetProjects", typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    //[CodeGenSuppress("GetSupportedLanguagesAsync", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    //[CodeGenSuppress("GetSupportedLanguages", typeof(TextAuthoringProjectKind), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    //[CodeGenSuppress("GetTrainingJobsAsync", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    //[CodeGenSuppress("GetTrainingJobs", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    public partial class TextAuthoringProject
    {
        private readonly string _projectName;

        /// <summary> Initializes a new instance of TextAuthoringProject. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="keyCredential"> The key credential to copy. </param>
        /// <param name="tokenCredential"> The token credential to copy. </param>
        /// <param name="endpoint"> Supported Cognitive Services endpoint e.g., https://&lt;resource-name&gt;.api.cognitiveservices.azure.com. </param>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <param name="projectName"> The name of the project. </param>
        internal TextAuthoringProject(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, AzureKeyCredential keyCredential, TokenCredential tokenCredential, Uri endpoint, string apiVersion, string projectName)
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
        public virtual async Task<Response<TextAuthoringProjectMetadata>> GetProjectAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetProjectAsync(context).ConfigureAwait(false); // Using the member variable
            return Response.FromValue(TextAuthoringProjectMetadata.FromResponse(response), response);
        }

        /// <summary> Gets the details of a project. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TextAuthoringProjectMetadata> GetProject(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetProject(context); // Using the member variable
            return Response.FromValue(TextAuthoringProjectMetadata.FromResponse(response), response);
        }

        /// <summary> Creates a new deployment or replaces an existing one. </summary>
        /// <param name="details"> The new deployment info. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> CreateProjectAsync(
            TextAuthoringCreateProjectDetails details,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(details, nameof(details));

            details.ProjectName = _projectName;
            using RequestContent content = details.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return await CreateProjectAsync(content, context).ConfigureAwait(false);
        }

        /// <summary> Creates a new deployment or replaces an existing one. </summary>
        /// <param name="details"> The new deployment info. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response CreateProject(
            TextAuthoringCreateProjectDetails details,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(details, nameof(details));

            details.ProjectName = _projectName;
            using RequestContent content = details.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return CreateProject(content, context);
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

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringProject.CreateProject");
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

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringProject.CreateProject");
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
        public virtual async Task<Response<TextAuthoringExportProjectState>> GetExportStatusAsync(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetExportStatusAsync(jobId, context).ConfigureAwait(false);
            return Response.FromValue(TextAuthoringExportProjectState.FromResponse(response), response);
        }

        /// <summary> Gets the status of an export job. Once job completes, returns the project metadata, and assets. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<TextAuthoringExportProjectState> GetExportStatus(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetExportStatus(jobId, context);
            return Response.FromValue(TextAuthoringExportProjectState.FromResponse(response), response);
        }

        /// <summary> Gets the status for an import. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<TextAuthoringImportProjectState>> GetImportStatusAsync(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetImportStatusAsync(jobId, context).ConfigureAwait(false);
            return Response.FromValue(TextAuthoringImportProjectState.FromResponse(response), response);
        }

        /// <summary> Gets the status for an import. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<TextAuthoringImportProjectState> GetImportStatus(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetImportStatus(jobId, context);
            return Response.FromValue(TextAuthoringImportProjectState.FromResponse(response), response);
        }

        /// <summary> Generates a copy project operation authorization to the current target Azure resource. </summary>
        /// <param name="projectKind"> Represents the project kind. </param>
        /// <param name="storageInputContainerName"> The name of the storage container. </param>
        /// <param name="allowOverwrite"> Whether to allow an existing project to be overwritten using the resulting copy authorization. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<TextAuthoringCopyProjectDetails>> AuthorizeProjectCopyAsync(TextAuthoringProjectKind projectKind, string storageInputContainerName = null, bool? allowOverwrite = null, CancellationToken cancellationToken = default)
        {
            CopyProjectAuthorizationRequest copyProjectAuthorizationRequest = new CopyProjectAuthorizationRequest(projectKind, storageInputContainerName, allowOverwrite, null);
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await AuthorizeProjectCopyAsync(copyProjectAuthorizationRequest.ToRequestContent(), context).ConfigureAwait(false);
            return Response.FromValue(TextAuthoringCopyProjectDetails.FromResponse(response), response);
        }

        /// <summary> Generates a copy project operation authorization to the current target Azure resource. </summary>
        /// <param name="projectKind"> Represents the project kind. </param>
        /// <param name="storageInputContainerName"> The name of the storage container. </param>
        /// <param name="allowOverwrite"> Whether to allow an existing project to be overwritten using the resulting copy authorization. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TextAuthoringCopyProjectDetails> AuthorizeProjectCopy(TextAuthoringProjectKind projectKind, string storageInputContainerName = null, bool? allowOverwrite = null, CancellationToken cancellationToken = default)
        {
            CopyProjectAuthorizationRequest copyProjectAuthorizationRequest = new CopyProjectAuthorizationRequest(projectKind, storageInputContainerName, allowOverwrite, null);
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = AuthorizeProjectCopy(copyProjectAuthorizationRequest.ToRequestContent(), context);
            return Response.FromValue(TextAuthoringCopyProjectDetails.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing copy project job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<TextAuthoringCopyProjectState>> GetCopyProjectStatusAsync(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetCopyProjectStatusAsync(jobId, context).ConfigureAwait(false);
            return Response.FromValue(TextAuthoringCopyProjectState.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing copy project job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<TextAuthoringCopyProjectState> GetCopyProjectStatus(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetCopyProjectStatus(jobId, context);
            return Response.FromValue(TextAuthoringCopyProjectState.FromResponse(response), response);
        }

        /// <summary> [Protocol Method] Deletes a project. </summary>
        /// <param name="waitUntil"> Determines if the method should wait until the operation completes or just starts. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual async Task<Operation> DeleteProjectAsync(WaitUntil waitUntil, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("TextAuthoringProject.DeleteProject");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteProjectRequest(_projectName, context);
                return await ProtocolOperationHelpers.ProcessMessageWithoutResponseValueAsync(
                    _pipeline,
                    message,
                    ClientDiagnostics,
                    "TextAuthoringProject.DeleteProject",
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
        public virtual Operation DeleteProject(WaitUntil waitUntil, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("TextAuthoringProject.DeleteProject");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteProjectRequest(_projectName, context);
                return ProtocolOperationHelpers.ProcessMessageWithoutResponseValue(
                    _pipeline,
                    message,
                    ClientDiagnostics,
                    "TextAuthoringProject.DeleteProject",
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
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="stringIndexType"> Specifies the method used to interpret string offsets. For additional information see https://aka.ms/text-analytics-offsets. </param>
        /// <param name="assetKind"> Kind of asset to export. </param>
        /// <param name="trainedModelLabel"> Trained model label to export. If the trainedModelLabel is null, the default behavior is to export the current working copy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Operation> ExportAsync(WaitUntil waitUntil, StringIndexType stringIndexType, string assetKind = null, string trainedModelLabel = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));

            RequestContext context = FromCancellationToken(cancellationToken);
            return await ExportAsync(waitUntil, stringIndexType.ToString(), assetKind, trainedModelLabel, context).ConfigureAwait(false);
        }

        /// <summary>
        /// [Protocol Method] Triggers a job to export a project's data.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ExportAsync(WaitUntil,StringIndexType,string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="stringIndexType"> Specifies the method used to interpret string offsets. For additional information see https://aka.ms/text-analytics-offsets. Allowed values: "Utf16CodeUnit". </param>
        /// <param name="assetKind"> Kind of asset to export. </param>
        /// <param name="trainedModelLabel"> Trained model label to export. If the trainedModelLabel is null, the default behavior is to export the current working copy. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual async Task<Operation> ExportAsync(WaitUntil waitUntil, string stringIndexType, string assetKind = null, string trainedModelLabel = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(stringIndexType, nameof(stringIndexType));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringProject.Export");
            scope.Start();
            try
            {
                using HttpMessage message = CreateExportRequest(_projectName, stringIndexType, assetKind, trainedModelLabel, context);
                return await ProtocolOperationHelpers.ProcessMessageWithoutResponseValueAsync(_pipeline, message, ClientDiagnostics, "TextAuthoringProject.Export", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Triggers a job to export a project's data.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Export(WaitUntil,StringIndexType,string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="stringIndexType"> Specifies the method used to interpret string offsets. For additional information see https://aka.ms/text-analytics-offsets. Allowed values: "Utf16CodeUnit". </param>
        /// <param name="assetKind"> Kind of asset to export. </param>
        /// <param name="trainedModelLabel"> Trained model label to export. If the trainedModelLabel is null, the default behavior is to export the current working copy. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual Operation Export(WaitUntil waitUntil, string stringIndexType, string assetKind = null, string trainedModelLabel = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(stringIndexType, nameof(stringIndexType));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringProject.Export");
            scope.Start();
            try
            {
                using HttpMessage message = CreateExportRequest(_projectName, stringIndexType, assetKind, trainedModelLabel, context);
                return ProtocolOperationHelpers.ProcessMessageWithoutResponseValue(_pipeline, message, ClientDiagnostics, "TextAuthoringProject.Export", OperationFinalStateVia.OperationLocation, context, waitUntil);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Triggers a job to export a project's data. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="stringIndexType"> Specifies the method used to interpret string offsets. For additional information see https://aka.ms/text-analytics-offsets. </param>
        /// <param name="assetKind"> Kind of asset to export. </param>
        /// <param name="trainedModelLabel"> Trained model label to export. If the trainedModelLabel is null, the default behavior is to export the current working copy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Operation Export(WaitUntil waitUntil, StringIndexType stringIndexType, string assetKind = null, string trainedModelLabel = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));

            RequestContext context = FromCancellationToken(cancellationToken);
            return Export(waitUntil, stringIndexType.ToString(), assetKind, trainedModelLabel, context);
        }

        /// <summary> Triggers a job to import a project. If a project with the same name already exists, the data of that project is replaced. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="body"> The project data to import. </param>
        /// <param name="format"> The format of the project to import. The currently supported formats are json and aml formats. If not provided, the default is set to json. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Operation> ImportAsync(WaitUntil waitUntil, TextAuthoringExportedProject body, string format = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return await ImportAsync(waitUntil, content, format, context).ConfigureAwait(false);
        }

        /// <summary> Triggers a job to import a project. If a project with the same name already exists, the data of that project is replaced. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="body"> The project data to import. </param>
        /// <param name="format"> The format of the project to import. The currently supported formats are json and aml formats. If not provided, the default is set to json. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Operation Import(WaitUntil waitUntil, TextAuthoringExportedProject body, string format = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return Import(waitUntil, content, format, context);
        }

        /// <summary>
        /// Triggers a job to import a project using raw JSON string input.
        /// This is an alternative to the structured import method, and is useful when importing directly from exported project files.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="projectJson">
        /// A raw JSON string representing the entire project to import.
        /// This string should match the format of an exported Text Authoring project.
        /// </param>
        /// <param name="format"> The format of the project to import. The currently supported formats are json and aml formats. If not provided, the default is set to json. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Operation> ImportAsync(WaitUntil waitUntil, string projectJson, string format = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(projectJson, nameof(projectJson));

            using RequestContent content = RequestContent.Create(Encoding.UTF8.GetBytes(projectJson));
            RequestContext context = FromCancellationToken(cancellationToken);
            return await ImportAsync(waitUntil, content, format, context).ConfigureAwait(false);
        }

        /// <summary>
        /// Triggers a job to import a project using raw JSON string input.
        /// This is an alternative to the structured import method, and is useful when importing directly from exported project files.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="projectJson">
        /// A raw JSON string representing the entire project to import.
        /// This string should match the format of an exported Text Authoring project.
        /// </param>
        /// <param name="format"> The format of the project to import. The currently supported formats are json and aml formats. If not provided, the default is set to json. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Operation Import(WaitUntil waitUntil, string projectJson, string format = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(projectJson, nameof(projectJson));

            using RequestContent content = RequestContentHelper.FromObject(projectJson);
            RequestContext context = FromCancellationToken(cancellationToken);
            return Import(waitUntil, content, format, context);
        }

        /// <summary>
        /// [Protocol Method] Triggers a job to import a project. If a project with the same name already exists, the data of that project is replaced.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ImportAsync(WaitUntil,TextAuthoringExportedProject,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="format"> The format of the project to import. The currently supported formats are json and aml formats. If not provided, the default is set to json. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual async Task<Operation> ImportAsync(WaitUntil waitUntil, RequestContent content, string format = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringProject.Import");
            scope.Start();
            try
            {
                using HttpMessage message = CreateImportRequest(_projectName, content, format, context);
                return await ProtocolOperationHelpers.ProcessMessageWithoutResponseValueAsync(_pipeline, message, ClientDiagnostics, "TextAuthoringProject.Import", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Triggers a job to import a project. If a project with the same name already exists, the data of that project is replaced.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Import(WaitUntil,TextAuthoringExportedProject,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="format"> The format of the project to import. The currently supported formats are json and aml formats. If not provided, the default is set to json. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual Operation Import(WaitUntil waitUntil, RequestContent content, string format = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringProject.Import");
            scope.Start();
            try
            {
                using HttpMessage message = CreateImportRequest(_projectName, content, format, context);
                return ProtocolOperationHelpers.ProcessMessageWithoutResponseValue(_pipeline, message, ClientDiagnostics, "TextAuthoringProject.Import", OperationFinalStateVia.OperationLocation, context, waitUntil);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Copies an existing project to another Azure resource. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="details"> The copy project info. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Operation> CopyProjectAsync(WaitUntil waitUntil, TextAuthoringCopyProjectDetails details, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(details, nameof(details));

            using RequestContent content = details.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return await CopyProjectAsync(waitUntil, content, context).ConfigureAwait(false);
        }

        /// <summary> Copies an existing project to another Azure resource. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="details"> The copy project info. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Operation CopyProject(WaitUntil waitUntil, TextAuthoringCopyProjectDetails details, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(details, nameof(details));

            using RequestContent content = details.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return CopyProject(waitUntil, content, context);
        }

        /// <summary> Gets the status for a training job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<TextAuthoringTrainingState>> GetTrainingStatusAsync(
            string jobId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetTrainingStatusAsync(jobId, context).ConfigureAwait(false);
            return Response.FromValue(TextAuthoringTrainingState.FromResponse(response), response);
        }

        /// <summary> Gets the status for a training job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TextAuthoringTrainingState> GetTrainingStatus(
            string jobId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetTrainingStatus(jobId, context);
            return Response.FromValue(TextAuthoringTrainingState.FromResponse(response), response);
        }

        /// <summary> Triggers a training job for a project. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="details"> The training input parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Operation<TextAuthoringTrainingJobResult>> TrainAsync(
            WaitUntil waitUntil,
            TextAuthoringTrainingJobDetails details,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(details, nameof(details));

            using RequestContent content = details.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> response = await TrainAsync(waitUntil, content, context).ConfigureAwait(false);
            return ProtocolOperationHelpers.Convert(response, FetchTextAuthoringTrainingJobResultFromTextAuthoringTrainingState, ClientDiagnostics, "TextAuthoringTraining.Train");
        }

        /// <summary> Triggers a training job for a project. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="details"> The training input parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Operation<TextAuthoringTrainingJobResult> Train(
            WaitUntil waitUntil,
            TextAuthoringTrainingJobDetails details,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(details, nameof(details));

            using RequestContent content = details.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> response = Train(waitUntil, content, context);
            return ProtocolOperationHelpers.Convert(response, FetchTextAuthoringTrainingJobResultFromTextAuthoringTrainingState, ClientDiagnostics, "TextAuthoringTraining.Train");
        }

        /// <summary> Triggers a cancellation for a running training job. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Operation<TextAuthoringTrainingJobResult>> CancelTrainingJobAsync(
            WaitUntil waitUntil,
            string jobId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> response = await CancelTrainingJobAsync(waitUntil, jobId, context).ConfigureAwait(false);
            return ProtocolOperationHelpers.Convert(response, FetchTextAuthoringTrainingJobResultFromTextAuthoringTrainingState, ClientDiagnostics, "TextAuthoringTraining.CancelTrainingJob");
        }

        /// <summary> Triggers a cancellation for a running training job. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Operation<TextAuthoringTrainingJobResult> CancelTrainingJob(
            WaitUntil waitUntil,
            string jobId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> response = CancelTrainingJob(waitUntil, jobId, context);
            return ProtocolOperationHelpers.Convert(response, FetchTextAuthoringTrainingJobResultFromTextAuthoringTrainingState, ClientDiagnostics, "TextAuthoringTraining.CancelTrainingJob");
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
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> GetTrainingStatusAsync(string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringTraining.GetTrainingStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetTrainingStatusRequest(_projectName, jobId, context);
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
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response GetTrainingStatus(string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringTraining.GetTrainingStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetTrainingStatusRequest(_projectName, jobId, context);
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
        /// Please try the simpler <see cref="TrainAsync(WaitUntil,TextAuthoringTrainingJobDetails,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual async Task<Operation<BinaryData>> TrainAsync(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringTraining.Train");
            scope.Start();
            try
            {
                using HttpMessage message = CreateTrainRequest(_projectName, content, context);
                return await ProtocolOperationHelpers.ProcessMessageAsync(_pipeline, message, ClientDiagnostics, "TextAuthoringTraining.Train", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
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
        /// Please try the simpler <see cref="Train(WaitUntil,TextAuthoringTrainingJobDetails,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual Operation<BinaryData> Train(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringTraining.Train");
            scope.Start();
            try
            {
                using HttpMessage message = CreateTrainRequest(_projectName, content, context);
                return ProtocolOperationHelpers.ProcessMessage(_pipeline, message, ClientDiagnostics, "TextAuthoringTraining.Train", OperationFinalStateVia.OperationLocation, context, waitUntil);
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
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual async Task<Operation<BinaryData>> CancelTrainingJobAsync(WaitUntil waitUntil, string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringTraining.CancelTrainingJob");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCancelTrainingJobRequest(_projectName, jobId, context);
                return await ProtocolOperationHelpers.ProcessMessageAsync(_pipeline, message, ClientDiagnostics, "TextAuthoringTraining.CancelTrainingJob", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
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
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual Operation<BinaryData> CancelTrainingJob(WaitUntil waitUntil, string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringTraining.CancelTrainingJob");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCancelTrainingJobRequest(_projectName, jobId, context);
                return ProtocolOperationHelpers.ProcessMessage(_pipeline, message, ClientDiagnostics, "TextAuthoringTraining.CancelTrainingJob", OperationFinalStateVia.OperationLocation, context, waitUntil);
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
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> GetProjectAsync(RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringProject.GetProject");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetProjectRequest(_projectName, context);
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
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response GetProject(RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringProject.GetProject");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetProjectRequest(_projectName, context);
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
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> GetExportStatusAsync(string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringProject.GetExportStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetExportStatusRequest(_projectName, jobId, context);
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
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response GetExportStatus(string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringProject.GetExportStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetExportStatusRequest(_projectName, jobId, context);
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
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> GetImportStatusAsync(string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringProject.GetImportStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetImportStatusRequest(_projectName, jobId, context);
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
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response GetImportStatus(string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringProject.GetImportStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetImportStatusRequest(_projectName, jobId, context);
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
        /// Please try the simpler <see cref="AuthorizeProjectCopyAsync(TextAuthoringProjectKind,string,bool?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> AuthorizeProjectCopyAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringProject.AuthorizeProjectCopy");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAuthorizeProjectCopyRequest(_projectName, content, context);
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
        /// Please try the simpler <see cref="AuthorizeProjectCopy(TextAuthoringProjectKind,string,bool?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response AuthorizeProjectCopy(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringProject.AuthorizeProjectCopy");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAuthorizeProjectCopyRequest(_projectName, content, context);
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
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> GetCopyProjectStatusAsync(string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringProject.GetCopyProjectStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetCopyProjectStatusRequest(_projectName, jobId, context);
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
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response GetCopyProjectStatus(string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringProject.GetCopyProjectStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetCopyProjectStatusRequest(_projectName, jobId, context);
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
        /// Please try the simpler <see cref="CopyProjectAsync(WaitUntil,TextAuthoringCopyProjectDetails,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual async Task<Operation> CopyProjectAsync(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringProject.CopyProject");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCopyProjectRequest(_projectName, content, context);
                return await ProtocolOperationHelpers.ProcessMessageWithoutResponseValueAsync(_pipeline, message, ClientDiagnostics, "TextAuthoringProject.CopyProject", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
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
        /// Please try the simpler <see cref="CopyProject(WaitUntil,TextAuthoringCopyProjectDetails,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual Operation CopyProject(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringProject.CopyProject");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCopyProjectRequest(_projectName, content, context);
                return ProtocolOperationHelpers.ProcessMessageWithoutResponseValue(_pipeline, message, ClientDiagnostics, "TextAuthoringProject.CopyProject", OperationFinalStateVia.OperationLocation, context, waitUntil);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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

        /// <summary> Gets the status of an existing assign deployment resources job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<TextAuthoringDeploymentResourcesState>> GetAssignDeploymentResourcesStatusAsync(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetAssignDeploymentResourcesStatusAsync(jobId, context).ConfigureAwait(false);
            return Response.FromValue(TextAuthoringDeploymentResourcesState.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing assign deployment resources job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<TextAuthoringDeploymentResourcesState> GetAssignDeploymentResourcesStatus(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetAssignDeploymentResourcesStatus(jobId, context);
            return Response.FromValue(TextAuthoringDeploymentResourcesState.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing unassign deployment resources job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<TextAuthoringDeploymentResourcesState>> GetUnassignDeploymentResourcesStatusAsync(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetUnassignDeploymentResourcesStatusAsync(jobId, context).ConfigureAwait(false);
            return Response.FromValue(TextAuthoringDeploymentResourcesState.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing unassign deployment resources job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<TextAuthoringDeploymentResourcesState> GetUnassignDeploymentResourcesStatus(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetUnassignDeploymentResourcesStatus(jobId, context);
            return Response.FromValue(TextAuthoringDeploymentResourcesState.FromResponse(response), response);
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
    }
}
