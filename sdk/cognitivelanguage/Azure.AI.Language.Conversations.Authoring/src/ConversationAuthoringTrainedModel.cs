// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Core;
using System.Threading.Tasks;
using System;
using Azure.Core.Pipeline;
using Autorest.CSharp.Core;

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
    [CodeGenSuppress("GetModelEvaluationResultsAsync", typeof(string), typeof(string), typeof(StringIndexType), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetModelEvaluationResults", typeof(string), typeof(string), typeof(StringIndexType), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("EvaluateModelAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(ConversationAuthoringEvaluationDetails), typeof(CancellationToken))]
    [CodeGenSuppress("EvaluateModel", typeof(WaitUntil), typeof(string), typeof(string), typeof(ConversationAuthoringEvaluationDetails), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteTrainedModelAsync", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("DeleteTrainedModel", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("LoadSnapshotAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("LoadSnapshot", typeof(WaitUntil), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetTrainedModelAsync", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetTrainedModel", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetEvaluationStatusAsync", typeof(string), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetEvaluationStatus", typeof(string), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetModelEvaluationSummaryAsync", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetModelEvaluationSummary", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetLoadSnapshotStatusAsync", typeof(string), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetLoadSnapshotStatus", typeof(string), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetModelEvaluationResultsAsync", typeof(string), typeof(string), typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(RequestContext))]
    [CodeGenSuppress("GetModelEvaluationResults", typeof(string), typeof(string), typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(RequestContext))]
    [CodeGenSuppress("EvaluateModelAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("EvaluateModel", typeof(WaitUntil), typeof(string), typeof(string), typeof(RequestContent), typeof(RequestContext))]
    public partial class ConversationAuthoringTrainedModel
    {
        /// <summary>
        /// Stores the project name associated with the client.
        /// </summary>
        public readonly string _projectName;

        /// <summary>
        /// Stores the project name associated with the client.
        /// </summary>
        public readonly string _trainedModelLabel;

        /// <summary> Initializes a new instance of ConversationAuthoringTrainedModel. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="keyCredential"> The key credential to copy. </param>
        /// <param name="tokenCredential"> The token credential to copy. </param>
        /// <param name="endpoint"> Supported Cognitive Services endpoint e.g., https://&lt;resource-name&gt;.api.cognitiveservices.azure.com. </param>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <param name="projectName"> The new project name. </param>
        /// <param name="trainedModelLabel"> The new trained model label. </param>
        internal ConversationAuthoringTrainedModel(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, AzureKeyCredential keyCredential, TokenCredential tokenCredential, Uri endpoint, string apiVersion, string projectName, string trainedModelLabel)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _keyCredential = keyCredential;
            _tokenCredential = tokenCredential;
            _endpoint = endpoint;
            _apiVersion = apiVersion;
            _projectName = projectName;
            _trainedModelLabel = trainedModelLabel;
        }

        /// <summary> Gets the details of a trained model. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ConversationAuthoringProjectTrainedModel>> GetTrainedModelAsync(
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_trainedModelLabel, nameof(_trainedModelLabel));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetTrainedModelAsync(context).ConfigureAwait(false);
            return Response.FromValue(ConversationAuthoringProjectTrainedModel.FromResponse(response), response);
        }

        /// <summary> Gets the details of a trained model. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ConversationAuthoringProjectTrainedModel> GetTrainedModel(
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_trainedModelLabel, nameof(_trainedModelLabel));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetTrainedModel(context);
            return Response.FromValue(ConversationAuthoringProjectTrainedModel.FromResponse(response), response);
        }

        /// <summary> Gets the status for an evaluation job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ConversationAuthoringEvaluationState>> GetEvaluationStatusAsync(
            string jobId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_trainedModelLabel, nameof(_trainedModelLabel));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetEvaluationStatusAsync(jobId, context).ConfigureAwait(false);
            return Response.FromValue(ConversationAuthoringEvaluationState.FromResponse(response), response);
        }

        /// <summary> Gets the status for an evaluation job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ConversationAuthoringEvaluationState> GetEvaluationStatus(
            string jobId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_trainedModelLabel, nameof(_trainedModelLabel));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetEvaluationStatus(jobId, context);
            return Response.FromValue(ConversationAuthoringEvaluationState.FromResponse(response), response);
        }

        /// <summary> Gets the evaluation summary of a trained model. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ConversationAuthoringEvalSummary>> GetModelEvaluationSummaryAsync(
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_trainedModelLabel, nameof(_trainedModelLabel));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetModelEvaluationSummaryAsync(context).ConfigureAwait(false);
            return Response.FromValue(ConversationAuthoringEvalSummary.FromResponse(response), response);
        }

        /// <summary> Gets the evaluation summary of a trained model. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ConversationAuthoringEvalSummary> GetModelEvaluationSummary(
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_trainedModelLabel, nameof(_trainedModelLabel));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetModelEvaluationSummary(context);
            return Response.FromValue(ConversationAuthoringEvalSummary.FromResponse(response), response);
        }

        /// <summary> Gets the status for loading a snapshot. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ConversationAuthoringLoadSnapshotState>> GetLoadSnapshotStatusAsync(
            string jobId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_trainedModelLabel, nameof(_trainedModelLabel));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetLoadSnapshotStatusAsync(jobId, context).ConfigureAwait(false);
            return Response.FromValue(ConversationAuthoringLoadSnapshotState.FromResponse(response), response);
        }

        /// <summary> Gets the status for loading a snapshot. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ConversationAuthoringLoadSnapshotState> GetLoadSnapshotStatus(
            string jobId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_trainedModelLabel, nameof(_trainedModelLabel));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetLoadSnapshotStatus(jobId, context);
            return Response.FromValue(ConversationAuthoringLoadSnapshotState.FromResponse(response), response);
        }

        /// <summary> Gets the detailed results of the evaluation for a trained model. </summary>
        /// <param name="stringIndexType"> Specifies the method used to interpret string offsets. </param>
        /// <param name="maxCount"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<UtteranceEvaluationResult> GetModelEvaluationResultsAsync(
            StringIndexType stringIndexType,
            int? maxCount = null,
            int? skip = null,
            int? maxpagesize = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_trainedModelLabel, nameof(_trainedModelLabel));

            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetModelEvaluationResultsRequest(_projectName, _trainedModelLabel, stringIndexType.ToString(), maxCount, skip, pageSizeHint, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetModelEvaluationResultsNextPageRequest(nextLink, _projectName, _trainedModelLabel, stringIndexType.ToString(), maxCount, skip, pageSizeHint, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => UtteranceEvaluationResult.DeserializeUtteranceEvaluationResult(e), ClientDiagnostics, _pipeline, "ConversationAuthoringTrainedModel.GetModelEvaluationResults", "value", "nextLink", maxpagesize, context);
        }

        /// <summary> Gets the detailed results of the evaluation for a trained model. </summary>
        /// <param name="stringIndexType"> Specifies the method used to interpret string offsets. </param>
        /// <param name="maxCount"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<UtteranceEvaluationResult> GetModelEvaluationResults(
            StringIndexType stringIndexType,
            int? maxCount = null,
            int? skip = null,
            int? maxpagesize = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_trainedModelLabel, nameof(_trainedModelLabel));

            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetModelEvaluationResultsRequest(_projectName, _trainedModelLabel, stringIndexType.ToString(), maxCount, skip, pageSizeHint, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetModelEvaluationResultsNextPageRequest(nextLink, _projectName, _trainedModelLabel, stringIndexType.ToString(), maxCount, skip, pageSizeHint, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => UtteranceEvaluationResult.DeserializeUtteranceEvaluationResult(e), ClientDiagnostics, _pipeline, "ConversationAuthoringTrainedModel.GetModelEvaluationResults", "value", "nextLink", maxpagesize, context);
        }

        /// <summary> Triggers evaluation operation on a trained model. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="details"> The training input parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Operation<ConversationAuthoringEvaluationJobResult>> EvaluateModelAsync(
            WaitUntil waitUntil,
            ConversationAuthoringEvaluationDetails details,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_trainedModelLabel, nameof(_trainedModelLabel));
            Argument.AssertNotNull(details, nameof(details));

            using RequestContent content = details.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> response = await EvaluateModelAsync(waitUntil, content, context).ConfigureAwait(false);
            return ProtocolOperationHelpers.Convert(response, FetchConversationAuthoringEvaluationJobResultFromConversationAuthoringEvaluationState, ClientDiagnostics, "ConversationAuthoringTrainedModel.EvaluateModel");
        }

        /// <summary> Triggers evaluation operation on a trained model. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="details"> The training input parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Operation<ConversationAuthoringEvaluationJobResult> EvaluateModel(
            WaitUntil waitUntil,
            ConversationAuthoringEvaluationDetails details,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_trainedModelLabel, nameof(_trainedModelLabel));
            Argument.AssertNotNull(details, nameof(details));

            using RequestContent content = details.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> response = EvaluateModel(waitUntil, content, context);
            return ProtocolOperationHelpers.Convert(response, FetchConversationAuthoringEvaluationJobResultFromConversationAuthoringEvaluationState, ClientDiagnostics, "ConversationAuthoringTrainedModel.EvaluateModel");
        }

        /// <summary> Deletes a trained model. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> DeleteTrainedModelAsync(
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_trainedModelLabel, nameof(_trainedModelLabel));

            RequestContext context = FromCancellationToken(cancellationToken);
            return await DeleteTrainedModelAsync(context).ConfigureAwait(false);
        }

        /// <summary> Deletes a trained model. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response DeleteTrainedModel(
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_trainedModelLabel, nameof(_trainedModelLabel));

            RequestContext context = FromCancellationToken(cancellationToken);
            return DeleteTrainedModel(context);
        }

        /// <summary> Loads a snapshot of a trained model. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A long-running operation to manage the snapshot load process. </returns>
        public virtual async Task<Operation> LoadSnapshotAsync(
            WaitUntil waitUntil,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_trainedModelLabel, nameof(_trainedModelLabel));

            RequestContext context = FromCancellationToken(cancellationToken);
            return await LoadSnapshotAsync(waitUntil, context).ConfigureAwait(false);
        }

        /// <summary> Loads a snapshot of a trained model. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A long-running operation to manage the snapshot load process. </returns>
        public virtual Operation LoadSnapshot(
            WaitUntil waitUntil,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_trainedModelLabel, nameof(_trainedModelLabel));

            RequestContext context = FromCancellationToken(cancellationToken);
            return LoadSnapshot(waitUntil, context);
        }

        /// <summary>
        /// [Protocol Method] Gets the details of a trained model.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetTrainedModelAsync(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> GetTrainedModelAsync(RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_trainedModelLabel, nameof(_trainedModelLabel));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringTrainedModel.GetTrainedModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetTrainedModelRequest(_projectName, _trainedModelLabel, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the details of a trained model.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetTrainedModel(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response GetTrainedModel(RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_trainedModelLabel, nameof(_trainedModelLabel));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringTrainedModel.GetTrainedModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetTrainedModelRequest(_projectName, _trainedModelLabel, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the status for an evaluation job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetEvaluationStatusAsync(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> GetEvaluationStatusAsync(string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_trainedModelLabel, nameof(_trainedModelLabel));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringTrainedModel.GetEvaluationStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetEvaluationStatusRequest(_projectName, _trainedModelLabel, jobId, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the status for an evaluation job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetEvaluationStatus(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response GetEvaluationStatus(string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_trainedModelLabel, nameof(_trainedModelLabel));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringTrainedModel.GetEvaluationStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetEvaluationStatusRequest(_projectName, _trainedModelLabel, jobId, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the evaluation summary of a trained model. The summary includes high level performance measurements of the model e.g., F1, Precision, Recall, etc.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetModelEvaluationSummaryAsync(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> GetModelEvaluationSummaryAsync(RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_trainedModelLabel, nameof(_trainedModelLabel));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringTrainedModel.GetModelEvaluationSummary");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetModelEvaluationSummaryRequest(_projectName, _trainedModelLabel, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the evaluation summary of a trained model. The summary includes high level performance measurements of the model e.g., F1, Precision, Recall, etc.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetModelEvaluationSummary(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response GetModelEvaluationSummary(RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_trainedModelLabel, nameof(_trainedModelLabel));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringTrainedModel.GetModelEvaluationSummary");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetModelEvaluationSummaryRequest(_projectName, _trainedModelLabel, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the status for loading a snapshot.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetLoadSnapshotStatusAsync(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> GetLoadSnapshotStatusAsync(string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_trainedModelLabel, nameof(_trainedModelLabel));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringTrainedModel.GetLoadSnapshotStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetLoadSnapshotStatusRequest(_projectName, _trainedModelLabel, jobId, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the status for loading a snapshot.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetLoadSnapshotStatus(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response GetLoadSnapshotStatus(string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_trainedModelLabel, nameof(_trainedModelLabel));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringTrainedModel.GetLoadSnapshotStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetLoadSnapshotStatusRequest(_projectName, _trainedModelLabel, jobId, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the detailed results of the evaluation for a trained model. This includes the raw inference results for the data included in the evaluation process.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetModelEvaluationResultsAsync(StringIndexType,int?,int?,int?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="stringIndexType"> Specifies the method used to interpret string offsets. For additional information see https://aka.ms/text-analytics-offsets. Allowed values: "Utf16CodeUnit" | "Utf8CodeUnit" | "Utf32CodeUnit". </param>
        /// <param name="maxCount"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        public virtual AsyncPageable<BinaryData> GetModelEvaluationResultsAsync(string stringIndexType, int? maxCount = null, int? skip = null, int? maxpagesize = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_trainedModelLabel, nameof(_trainedModelLabel));
            Argument.AssertNotNull(stringIndexType, nameof(stringIndexType));

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetModelEvaluationResultsRequest(_projectName, _trainedModelLabel, stringIndexType, maxCount, skip, pageSizeHint, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetModelEvaluationResultsNextPageRequest(nextLink, _projectName, _trainedModelLabel, stringIndexType, maxCount, skip, pageSizeHint, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "ConversationAuthoringTrainedModel.GetModelEvaluationResults", "value", "nextLink", maxpagesize, context);
        }

        /// <summary>
        /// [Protocol Method] Gets the detailed results of the evaluation for a trained model. This includes the raw inference results for the data included in the evaluation process.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetModelEvaluationResults(StringIndexType,int?,int?,int?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="stringIndexType"> Specifies the method used to interpret string offsets. For additional information see https://aka.ms/text-analytics-offsets. Allowed values: "Utf16CodeUnit" | "Utf8CodeUnit" | "Utf32CodeUnit". </param>
        /// <param name="maxCount"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        public virtual Pageable<BinaryData> GetModelEvaluationResults(string stringIndexType, int? maxCount = null, int? skip = null, int? maxpagesize = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_trainedModelLabel, nameof(_trainedModelLabel));
            Argument.AssertNotNull(stringIndexType, nameof(stringIndexType));

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetModelEvaluationResultsRequest(_projectName, _trainedModelLabel, stringIndexType, maxCount, skip, pageSizeHint, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetModelEvaluationResultsNextPageRequest(nextLink, _projectName, _trainedModelLabel, stringIndexType, maxCount, skip, pageSizeHint, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "ConversationAuthoringTrainedModel.GetModelEvaluationResults", "value", "nextLink", maxpagesize, context);
        }

        /// <summary>
        /// [Protocol Method] Triggers evaluation operation on a trained model.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="EvaluateModelAsync(WaitUntil,ConversationAuthoringEvaluationDetails,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual async Task<Operation<BinaryData>> EvaluateModelAsync(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_trainedModelLabel, nameof(_trainedModelLabel));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringTrainedModel.EvaluateModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateEvaluateModelRequest(_projectName, _trainedModelLabel, content, context);
                return await ProtocolOperationHelpers.ProcessMessageAsync(_pipeline, message, ClientDiagnostics, "ConversationAuthoringTrainedModel.EvaluateModel", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Triggers evaluation operation on a trained model.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="EvaluateModel(WaitUntil,ConversationAuthoringEvaluationDetails,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual Operation<BinaryData> EvaluateModel(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_trainedModelLabel, nameof(_trainedModelLabel));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringTrainedModel.EvaluateModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateEvaluateModelRequest(_projectName, _trainedModelLabel, content, context);
                return ProtocolOperationHelpers.ProcessMessage(_pipeline, message, ClientDiagnostics, "ConversationAuthoringTrainedModel.EvaluateModel", OperationFinalStateVia.OperationLocation, context, waitUntil);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Deletes an existing trained model.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> DeleteTrainedModelAsync(RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_trainedModelLabel, nameof(_trainedModelLabel));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringTrainedModel.DeleteTrainedModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteTrainedModelRequest(_projectName, _trainedModelLabel, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Deletes an existing trained model.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response DeleteTrainedModel(RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_trainedModelLabel, nameof(_trainedModelLabel));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringTrainedModel.DeleteTrainedModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteTrainedModelRequest(_projectName, _trainedModelLabel, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Restores the snapshot of this trained model to be the current working directory of the project.
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
        public virtual async Task<Operation> LoadSnapshotAsync(WaitUntil waitUntil, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_trainedModelLabel, nameof(_trainedModelLabel));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringTrainedModel.LoadSnapshot");
            scope.Start();
            try
            {
                using HttpMessage message = CreateLoadSnapshotRequest(_projectName, _trainedModelLabel, context);
                return await ProtocolOperationHelpers.ProcessMessageWithoutResponseValueAsync(_pipeline, message, ClientDiagnostics, "ConversationAuthoringTrainedModel.LoadSnapshot", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Restores the snapshot of this trained model to be the current working directory of the project.
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
        public virtual Operation LoadSnapshot(WaitUntil waitUntil, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(_trainedModelLabel, nameof(_trainedModelLabel));

            using var scope = ClientDiagnostics.CreateScope("ConversationAuthoringTrainedModel.LoadSnapshot");
            scope.Start();
            try
            {
                using HttpMessage message = CreateLoadSnapshotRequest(_projectName, _trainedModelLabel, context);
                return ProtocolOperationHelpers.ProcessMessageWithoutResponseValue(_pipeline, message, ClientDiagnostics, "ConversationAuthoringTrainedModel.LoadSnapshot", OperationFinalStateVia.OperationLocation, context, waitUntil);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
