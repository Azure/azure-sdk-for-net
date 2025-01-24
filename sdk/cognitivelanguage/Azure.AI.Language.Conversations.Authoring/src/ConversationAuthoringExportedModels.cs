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
    [CodeGenSuppress("GetExportedModelAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetExportedModel", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetExportedModelJobStatusAsync", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetExportedModelJobStatus", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetExportedModelsAsync", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetExportedModels", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("CreateOrUpdateExportedModelAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(ExportedModelDetails), typeof(CancellationToken))]
    [CodeGenSuppress("CreateOrUpdateExportedModel", typeof(WaitUntil), typeof(string), typeof(string), typeof(ExportedModelDetails), typeof(CancellationToken))]
    public partial class ConversationAuthoringExportedModels
    {
        private readonly string _projectName;

        /// <summary> Initializes a new instance of ConversationAuthoringExportedModels. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="keyCredential"> The key credential to copy. </param>
        /// <param name="tokenCredential"> The token credential to copy. </param>
        /// <param name="endpoint"> Supported Cognitive Services endpoint e.g., https://&lt;resource-name&gt;.api.cognitiveservices.azure.com. </param>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <param name="projectName"> The new project name. </param>
        internal ConversationAuthoringExportedModels(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, AzureKeyCredential keyCredential, TokenCredential tokenCredential, Uri endpoint, string apiVersion, string projectName)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _keyCredential = keyCredential;
            _tokenCredential = tokenCredential;
            _endpoint = endpoint;
            _apiVersion = apiVersion;
            _projectName = projectName;
        }

        /// <summary> Gets the details of an exported model. </summary>
        /// <param name="exportedModelName"> The exported model name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ExportedTrainedModel>> GetExportedModelAsync(
            string exportedModelName, 
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(exportedModelName, nameof(exportedModelName));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetExportedModelAsync(_projectName, exportedModelName, context).ConfigureAwait(false);
            return Response.FromValue(ExportedTrainedModel.FromResponse(response), response);
        }

        /// <summary> Gets the details of an exported model. </summary>
        /// <param name="exportedModelName"> The exported model name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ExportedTrainedModel> GetExportedModel(
            string exportedModelName, 
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(exportedModelName, nameof(exportedModelName));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetExportedModel(_projectName, exportedModelName, context);
            return Response.FromValue(ExportedTrainedModel.FromResponse(response), response);
        }

        /// <summary> Gets the status for an existing job to create or update an exported model. </summary>
        /// <param name="exportedModelName"> The exported model name. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ExportedModelJobState>> GetExportedModelJobStatusAsync(
            string exportedModelName, 
            string jobId, 
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(exportedModelName, nameof(exportedModelName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetExportedModelJobStatusAsync(_projectName, exportedModelName, jobId, context).ConfigureAwait(false);
            return Response.FromValue(ExportedModelJobState.FromResponse(response), response);
        }

        /// <summary> Gets the status for an existing job to create or update an exported model. </summary>
        /// <param name="exportedModelName"> The exported model name. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ExportedModelJobState> GetExportedModelJobStatus(
            string exportedModelName, 
            string jobId, 
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(exportedModelName, nameof(exportedModelName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetExportedModelJobStatus(_projectName, exportedModelName, jobId, context);
            return Response.FromValue(ExportedModelJobState.FromResponse(response), response);
        }

        /// <summary> Lists the exported models belonging to a project. </summary>
        /// <param name="maxCount"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<ExportedTrainedModel> GetExportedModelsAsync(
            int? maxCount = null, 
            int? skip = null, 
            int? maxpagesize = null, 
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));

            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetExportedModelsRequest(_projectName, maxCount, skip, pageSizeHint, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetExportedModelsNextPageRequest(nextLink, _projectName, maxCount, skip, pageSizeHint, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => ExportedTrainedModel.DeserializeExportedTrainedModel(e), ClientDiagnostics, _pipeline, "ConversationAuthoringExportedModels.GetExportedModels", "value", "nextLink", maxpagesize, context);
        }

        /// <summary> Lists the exported models belonging to a project. </summary>
        /// <param name="maxCount"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<ExportedTrainedModel> GetExportedModels(
            int? maxCount = null, 
            int? skip = null, 
            int? maxpagesize = null, 
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));

            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetExportedModelsRequest(_projectName, maxCount, skip, pageSizeHint, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetExportedModelsNextPageRequest(nextLink, _projectName, maxCount, skip, pageSizeHint, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => ExportedTrainedModel.DeserializeExportedTrainedModel(e), ClientDiagnostics, _pipeline, "ConversationAuthoringExportedModels.GetExportedModels", "value", "nextLink", maxpagesize, context);
        }

        /// <summary> Creates a new exported model or replaces an existing one. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="exportedModelName"> The exported model name. </param>
        /// <param name="body"> The exported model info. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exportedModelName"/> or <paramref name="body"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="exportedModelName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Operation> CreateOrUpdateExportedModelAsync(
            WaitUntil waitUntil,
            string exportedModelName,
            ExportedModelDetails body,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(exportedModelName, nameof(exportedModelName));
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return await CreateOrUpdateExportedModelAsync(waitUntil, _projectName, exportedModelName, content, context).ConfigureAwait(false);
        }

        /// <summary> Creates a new exported model or replaces an existing one. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="exportedModelName"> The exported model name. </param>
        /// <param name="body"> The exported model info. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exportedModelName"/> or <paramref name="body"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="exportedModelName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Operation CreateOrUpdateExportedModel(
            WaitUntil waitUntil,
            string exportedModelName,
            ExportedModelDetails body,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(exportedModelName, nameof(exportedModelName));
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return CreateOrUpdateExportedModel(waitUntil, _projectName, exportedModelName, content, context);
        }

        /// <summary> Deletes an exported model. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="exportedModelName"> The name of the exported model to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exportedModelName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="exportedModelName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Operation> DeleteExportedModelAsync(
            WaitUntil waitUntil,
            string exportedModelName,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(exportedModelName, nameof(exportedModelName));

            RequestContext context = FromCancellationToken(cancellationToken);
            return await DeleteExportedModelAsync(waitUntil, _projectName, exportedModelName, context).ConfigureAwait(false);
        }

        /// <summary> Deletes an exported model. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="exportedModelName"> The name of the exported model to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exportedModelName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="exportedModelName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Operation DeleteExportedModel(
            WaitUntil waitUntil,
            string exportedModelName,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(exportedModelName, nameof(exportedModelName));

            RequestContext context = FromCancellationToken(cancellationToken);
            return DeleteExportedModel(waitUntil, _projectName, exportedModelName, context);
        }
    }
}
