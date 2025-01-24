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
    [CodeGenSuppress("GetTrainedModelAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetTrainedModel", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetEvaluationStatusAsync", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetEvaluationStatus", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetModelEvaluationSummaryAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetModelEvaluationSummary", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetLoadSnapshotStatusAsync", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetLoadSnapshotStatus", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetTrainedModelsAsync", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetTrainedModels", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetModelEvaluationResultsAsync", typeof(string), typeof(string), typeof(StringIndexType), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetModelEvaluationResults", typeof(string), typeof(string), typeof(StringIndexType), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("EvaluateModelAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(EvaluationDetails), typeof(CancellationToken))]
    [CodeGenSuppress("EvaluateModel", typeof(WaitUntil), typeof(string), typeof(string), typeof(EvaluationDetails), typeof(CancellationToken))]
    public partial class ConversationAuthoringModels
    {
        private readonly string _projectName;

        /// <summary> Initializes a new instance of ConversationAuthoringModels. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="keyCredential"> The key credential to copy. </param>
        /// <param name="tokenCredential"> The token credential to copy. </param>
        /// <param name="endpoint"> Supported Cognitive Services endpoint e.g., https://&lt;resource-name&gt;.api.cognitiveservices.azure.com. </param>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <param name="projectName"> The new project name. </param>
        internal ConversationAuthoringModels(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, AzureKeyCredential keyCredential, TokenCredential tokenCredential, Uri endpoint, string apiVersion, string projectName)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _keyCredential = keyCredential;
            _tokenCredential = tokenCredential;
            _endpoint = endpoint;
            _apiVersion = apiVersion;
            _projectName = projectName;
        }

        /// <summary> Gets the details of a trained model. </summary>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ProjectTrainedModel>> GetTrainedModelAsync(
            string trainedModelLabel,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetTrainedModelAsync(_projectName, trainedModelLabel, context).ConfigureAwait(false);
            return Response.FromValue(ProjectTrainedModel.FromResponse(response), response);
        }

        /// <summary> Gets the details of a trained model. </summary>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ProjectTrainedModel> GetTrainedModel(
            string trainedModelLabel,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetTrainedModel(_projectName, trainedModelLabel, context);
            return Response.FromValue(ProjectTrainedModel.FromResponse(response), response);
        }

        /// <summary> Gets the status for an evaluation job. </summary>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<EvaluationJobState>> GetEvaluationStatusAsync(
            string trainedModelLabel,
            string jobId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetEvaluationStatusAsync(_projectName, trainedModelLabel, jobId, context).ConfigureAwait(false);
            return Response.FromValue(EvaluationJobState.FromResponse(response), response);
        }

        /// <summary> Gets the status for an evaluation job. </summary>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<EvaluationJobState> GetEvaluationStatus(
            string trainedModelLabel,
            string jobId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetEvaluationStatus(_projectName, trainedModelLabel, jobId, context);
            return Response.FromValue(EvaluationJobState.FromResponse(response), response);
        }

        /// <summary> Gets the evaluation summary of a trained model. </summary>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<EvaluationSummary>> GetModelEvaluationSummaryAsync(
            string trainedModelLabel,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetModelEvaluationSummaryAsync(_projectName, trainedModelLabel, context).ConfigureAwait(false);
            return Response.FromValue(EvaluationSummary.FromResponse(response), response);
        }

        /// <summary> Gets the evaluation summary of a trained model. </summary>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<EvaluationSummary> GetModelEvaluationSummary(
            string trainedModelLabel,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetModelEvaluationSummary(_projectName, trainedModelLabel, context);
            return Response.FromValue(EvaluationSummary.FromResponse(response), response);
        }

        /// <summary> Gets the status for loading a snapshot. </summary>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<LoadSnapshotJobState>> GetLoadSnapshotStatusAsync(
            string trainedModelLabel,
            string jobId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetLoadSnapshotStatusAsync(_projectName, trainedModelLabel, jobId, context).ConfigureAwait(false);
            return Response.FromValue(LoadSnapshotJobState.FromResponse(response), response);
        }

        /// <summary> Gets the status for loading a snapshot. </summary>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<LoadSnapshotJobState> GetLoadSnapshotStatus(
            string trainedModelLabel,
            string jobId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetLoadSnapshotStatus(_projectName, trainedModelLabel, jobId, context);
            return Response.FromValue(LoadSnapshotJobState.FromResponse(response), response);
        }

        /// <summary> Lists the trained models belonging to a project. </summary>
        /// <param name="maxCount"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<ProjectTrainedModel> GetTrainedModelsAsync(
            int? maxCount = null,
            int? skip = null,
            int? maxpagesize = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));

            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetTrainedModelsRequest(_projectName, maxCount, skip, pageSizeHint, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetTrainedModelsNextPageRequest(nextLink, _projectName, maxCount, skip, pageSizeHint, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => ProjectTrainedModel.DeserializeProjectTrainedModel(e), ClientDiagnostics, _pipeline, "ConversationAuthoringModels.GetTrainedModels", "value", "nextLink", maxpagesize, context);
        }

        /// <summary> Lists the trained models belonging to a project. </summary>
        /// <param name="maxCount"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<ProjectTrainedModel> GetTrainedModels(
            int? maxCount = null,
            int? skip = null,
            int? maxpagesize = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));

            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetTrainedModelsRequest(_projectName, maxCount, skip, pageSizeHint, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetTrainedModelsNextPageRequest(nextLink, _projectName, maxCount, skip, pageSizeHint, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => ProjectTrainedModel.DeserializeProjectTrainedModel(e), ClientDiagnostics, _pipeline, "ConversationAuthoringModels.GetTrainedModels", "value", "nextLink", maxpagesize, context);
        }

        /// <summary> Gets the detailed results of the evaluation for a trained model. </summary>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="stringIndexType"> Specifies the method used to interpret string offsets. </param>
        /// <param name="maxCount"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<UtteranceEvaluationResult> GetModelEvaluationResultsAsync(
            string trainedModelLabel,
            StringIndexType stringIndexType,
            int? maxCount = null,
            int? skip = null,
            int? maxpagesize = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));

            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetModelEvaluationResultsRequest(_projectName, trainedModelLabel, stringIndexType.ToString(), maxCount, skip, pageSizeHint, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetModelEvaluationResultsNextPageRequest(nextLink, _projectName, trainedModelLabel, stringIndexType.ToString(), maxCount, skip, pageSizeHint, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => UtteranceEvaluationResult.DeserializeUtteranceEvaluationResult(e), ClientDiagnostics, _pipeline, "ConversationAuthoringModels.GetModelEvaluationResults", "value", "nextLink", maxpagesize, context);
        }

        /// <summary> Gets the detailed results of the evaluation for a trained model. </summary>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="stringIndexType"> Specifies the method used to interpret string offsets. </param>
        /// <param name="maxCount"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<UtteranceEvaluationResult> GetModelEvaluationResults(
            string trainedModelLabel,
            StringIndexType stringIndexType,
            int? maxCount = null,
            int? skip = null,
            int? maxpagesize = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));

            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetModelEvaluationResultsRequest(_projectName, trainedModelLabel, stringIndexType.ToString(), maxCount, skip, pageSizeHint, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetModelEvaluationResultsNextPageRequest(nextLink, _projectName, trainedModelLabel, stringIndexType.ToString(), maxCount, skip, pageSizeHint, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => UtteranceEvaluationResult.DeserializeUtteranceEvaluationResult(e), ClientDiagnostics, _pipeline, "ConversationAuthoringModels.GetModelEvaluationResults", "value", "nextLink", maxpagesize, context);
        }

        /// <summary> Triggers evaluation operation on a trained model. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="body"> The training input parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Operation<EvaluationJobResult>> EvaluateModelAsync(
            WaitUntil waitUntil,
            string trainedModelLabel,
            EvaluationDetails body,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> response = await EvaluateModelAsync(waitUntil, _projectName, trainedModelLabel, content, context).ConfigureAwait(false);
            return ProtocolOperationHelpers.Convert(response, FetchEvaluationJobResultFromEvaluationJobState, ClientDiagnostics, "ConversationAuthoringModels.EvaluateModel");
        }

        /// <summary> Triggers evaluation operation on a trained model. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="body"> The training input parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Operation<EvaluationJobResult> EvaluateModel(
            WaitUntil waitUntil,
            string trainedModelLabel,
            EvaluationDetails body,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> response = EvaluateModel(waitUntil, _projectName, trainedModelLabel, content, context);
            return ProtocolOperationHelpers.Convert(response, FetchEvaluationJobResultFromEvaluationJobState, ClientDiagnostics, "ConversationAuthoringModels.EvaluateModel");
        }

        /// <summary> Deletes a trained model. </summary>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> DeleteTrainedModelAsync(
            string trainedModelLabel,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));

            RequestContext context = FromCancellationToken(cancellationToken);
            return await DeleteTrainedModelAsync(_projectName, trainedModelLabel, context).ConfigureAwait(false);
        }

        /// <summary> Deletes a trained model. </summary>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response DeleteTrainedModel(
            string trainedModelLabel,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));

            RequestContext context = FromCancellationToken(cancellationToken);
            return DeleteTrainedModel(_projectName, trainedModelLabel, context);
        }

        /// <summary> Loads a snapshot of a trained model. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A long-running operation to manage the snapshot load process. </returns>
        public virtual async Task<Operation> LoadSnapshotAsync(
            WaitUntil waitUntil,
            string trainedModelLabel,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));

            RequestContext context = FromCancellationToken(cancellationToken);
            return await LoadSnapshotAsync(waitUntil, _projectName, trainedModelLabel, context).ConfigureAwait(false);
        }

        /// <summary> Loads a snapshot of a trained model. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A long-running operation to manage the snapshot load process. </returns>
        public virtual Operation LoadSnapshot(
            WaitUntil waitUntil,
            string trainedModelLabel,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));

            RequestContext context = FromCancellationToken(cancellationToken);
            return LoadSnapshot(waitUntil, _projectName, trainedModelLabel, context);
        }
    }
}
