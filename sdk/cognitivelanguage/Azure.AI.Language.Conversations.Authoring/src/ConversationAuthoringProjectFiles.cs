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
    [CodeGenSuppress("ExportAsync", typeof(WaitUntil), typeof(string), typeof(StringIndexType), typeof(AnalyzeConversationAuthoringExportedProjectFormat?), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("Export", typeof(WaitUntil), typeof(string), typeof(StringIndexType), typeof(AnalyzeConversationAuthoringExportedProjectFormat?), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetExportStatusAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetExportStatus", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetImportStatusAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetImportStatus", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("ImportAsync", typeof(WaitUntil), typeof(string), typeof(ExportedProject), typeof(AnalyzeConversationAuthoringExportedProjectFormat?), typeof(CancellationToken))]
    [CodeGenSuppress("Import", typeof(WaitUntil), typeof(string), typeof(ExportedProject), typeof(AnalyzeConversationAuthoringExportedProjectFormat?), typeof(CancellationToken))]
    public partial class ConversationAuthoringProjectFiles
    {
        private readonly string _projectName;

        /// <summary> Initializes a new instance of ConversationAuthoringProjectFiles. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="keyCredential"> The key credential to copy. </param>
        /// <param name="tokenCredential"> The token credential to copy. </param>
        /// <param name="endpoint"> Supported Cognitive Services endpoint e.g., https://&lt;resource-name&gt;.api.cognitiveservices.azure.com. </param>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <param name="projectName"> The new project name. </param>
        internal ConversationAuthoringProjectFiles(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, AzureKeyCredential keyCredential, TokenCredential tokenCredential, Uri endpoint, string apiVersion, string projectName)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _keyCredential = keyCredential;
            _tokenCredential = tokenCredential;
            _endpoint = endpoint;
            _apiVersion = apiVersion;
            _projectName = projectName;
        }

        /// <summary> Triggers a job to export a project's data. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="exportedProjectFormat"> The format of the exported project file to use. </param>
        /// <param name="assetKind"> Kind of asset to export. </param>
        /// <param name="trainedModelLabel"> Trained model label to export. If the trainedModelLabel is null, the default behavior is to export the current working copy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Operation> ExportAsync(
            WaitUntil waitUntil,
            AnalyzeConversationAuthoringExportedProjectFormat? exportedProjectFormat = null,
            string assetKind = null,
            string trainedModelLabel = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));

            RequestContext context = FromCancellationToken(cancellationToken);
            return await ExportAsync(waitUntil, _projectName, "Utf16CodeUnit", exportedProjectFormat?.ToString(), assetKind, trainedModelLabel, context).ConfigureAwait(false);
        }

        /// <summary> Triggers a job to export a project's data. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="exportedProjectFormat"> The format of the exported project file to use. </param>
        /// <param name="assetKind"> Kind of asset to export. </param>
        /// <param name="trainedModelLabel"> Trained model label to export. If the trainedModelLabel is null, the default behavior is to export the current working copy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Operation Export(
            WaitUntil waitUntil,
            AnalyzeConversationAuthoringExportedProjectFormat? exportedProjectFormat = null,
            string assetKind = null,
            string trainedModelLabel = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));

            RequestContext context = FromCancellationToken(cancellationToken);
            return Export(waitUntil, _projectName, "Utf16CodeUnit", exportedProjectFormat?.ToString(), assetKind, trainedModelLabel, context);
        }

        /// <summary> Gets the status of an export job. Once the job completes, returns the project metadata and assets. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ExportProjectJobState>> GetExportStatusAsync(
            string jobId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetExportStatusAsync(_projectName, jobId, context).ConfigureAwait(false);
            return Response.FromValue(ExportProjectJobState.FromResponse(response), response);
        }

        /// <summary> Gets the status of an export job. Once the job completes, returns the project metadata and assets. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ExportProjectJobState> GetExportStatus(
            string jobId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetExportStatus(_projectName, jobId, context);
            return Response.FromValue(ExportProjectJobState.FromResponse(response), response);
        }

        /// <summary> Gets the status for an import job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ImportProjectJobState>> GetImportStatusAsync(
            string jobId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetImportStatusAsync(_projectName, jobId, context).ConfigureAwait(false);
            return Response.FromValue(ImportProjectJobState.FromResponse(response), response);
        }

        /// <summary> Gets the status for an import job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ImportProjectJobState> GetImportStatus(
            string jobId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetImportStatus(_projectName, jobId, context);
            return Response.FromValue(ImportProjectJobState.FromResponse(response), response);
        }

        /// <summary> Triggers a job to import a project. If a project with the same name already exists, the data of that project is replaced. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="body"> The project data to import. </param>
        /// <param name="exportedProjectFormat"> The format of the exported project file to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Operation> ImportAsync(
            WaitUntil waitUntil,
            ExportedProject body,
            AnalyzeConversationAuthoringExportedProjectFormat? exportedProjectFormat = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return await ImportAsync(waitUntil, _projectName, content, exportedProjectFormat?.ToString(), context).ConfigureAwait(false);
        }

        /// <summary> Triggers a job to import a project. If a project with the same name already exists, the data of that project is replaced. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="body"> The project data to import. </param>
        /// <param name="exportedProjectFormat"> The format of the exported project file to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Operation Import(
            WaitUntil waitUntil,
            ExportedProject body,
            AnalyzeConversationAuthoringExportedProjectFormat? exportedProjectFormat = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return Import(waitUntil, _projectName, content, exportedProjectFormat?.ToString(), context);
        }
    }
}
