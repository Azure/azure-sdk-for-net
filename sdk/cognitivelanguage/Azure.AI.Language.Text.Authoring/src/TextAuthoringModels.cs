// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Core;
using Azure.AI.Language.Text.Authoring.Models;
using System.Threading.Tasks;
using System;
using Azure.Core.Pipeline;
using Autorest.CSharp.Core;

namespace Azure.AI.Language.Text.Authoring
{
    [CodeGenSuppress("GetTrainedModelAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetTrainedModel", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetEvaluationStatusAsync", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetEvaluationStatus", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetModelAnalyzeTextAuthoringEvaluationSummaryAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetModelAnalyzeTextAuthoringEvaluationSummary", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetLoadSnapshotStatusAsync", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetLoadSnapshotStatus", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetModelEvaluationResultsAsync", typeof(string), typeof(string), typeof(StringIndexType), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetModelEvaluationResults", typeof(string), typeof(string), typeof(StringIndexType), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("EvaluateModelAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(AnalyzeTextAuthoringEvaluationDetails), typeof(CancellationToken))]
    [CodeGenSuppress("EvaluateModel", typeof(WaitUntil), typeof(string), typeof(string), typeof(AnalyzeTextAuthoringEvaluationDetails), typeof(CancellationToken))]
    [CodeGenSuppress("GetExportedModelAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetExportedModel", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetExportedModelJobStatusAsync", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetExportedModelJobStatus", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("CreateOrUpdateExportedModelAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(AnalyzeTextAuthoringExportedModelDetails), typeof(CancellationToken))]
    [CodeGenSuppress("CreateOrUpdateExportedModel", typeof(WaitUntil), typeof(string), typeof(string), typeof(AnalyzeTextAuthoringExportedModelDetails), typeof(CancellationToken))]

    //[CodeGenSuppress("GetExportedModelsAsync", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    //[CodeGenSuppress("GetExportedModels", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    //[CodeGenSuppress("GetTrainedModelsAsync", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    //[CodeGenSuppress("GetTrainedModels", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    public partial class TextAuthoringModels
    {
        private readonly string _projectName;

        /// <summary> Initializes a new instance of TextAuthoringModels. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="keyCredential"> The key credential to copy. </param>
        /// <param name="tokenCredential"> The token credential to copy. </param>
        /// <param name="endpoint"> Supported Cognitive Services endpoint e.g., https://&lt;resource-name&gt;.api.cognitiveservices.azure.com. </param>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <param name="projectName"> The new project name. </param>
        internal TextAuthoringModels(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, AzureKeyCredential keyCredential, TokenCredential tokenCredential, Uri endpoint, string apiVersion, string projectName)
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
        public virtual async Task<Response<AnalyzeTextAuthoringProjectTrainedModel>> GetTrainedModelAsync(
            string trainedModelLabel,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetTrainedModelAsync(_projectName, trainedModelLabel, context).ConfigureAwait(false);
            return Response.FromValue(AnalyzeTextAuthoringProjectTrainedModel.FromResponse(response), response);
        }

        /// <summary> Gets the details of a trained model. </summary>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<AnalyzeTextAuthoringProjectTrainedModel> GetTrainedModel(
            string trainedModelLabel,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetTrainedModel(_projectName, trainedModelLabel, context);
            return Response.FromValue(AnalyzeTextAuthoringProjectTrainedModel.FromResponse(response), response);
        }

        /// <summary> Gets the status for an evaluation job. </summary>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<AnalyzeTextAuthoringEvaluationOperationState>> GetEvaluationStatusAsync(
            string trainedModelLabel,
            string jobId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetEvaluationStatusAsync(_projectName, trainedModelLabel, jobId, context).ConfigureAwait(false);
            return Response.FromValue(AnalyzeTextAuthoringEvaluationOperationState.FromResponse(response), response);
        }

        /// <summary> Gets the status for an evaluation job. </summary>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<AnalyzeTextAuthoringEvaluationOperationState> GetEvaluationStatus(
            string trainedModelLabel,
            string jobId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetEvaluationStatus(_projectName, trainedModelLabel, jobId, context);
            return Response.FromValue(AnalyzeTextAuthoringEvaluationOperationState.FromResponse(response), response);
        }

        /// <summary> Gets the evaluation summary of a trained model. </summary>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<AnalyzeTextAuthoringEvaluationSummary>> GetModelEvaluationSummaryAsync(
            string trainedModelLabel,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetModelEvaluationSummaryAsync(_projectName, trainedModelLabel, context).ConfigureAwait(false);
            return Response.FromValue(AnalyzeTextAuthoringEvaluationSummary.FromResponse(response), response);
        }

        /// <summary> Gets the evaluation summary of a trained model. </summary>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<AnalyzeTextAuthoringEvaluationSummary> GetModelAnalyzeTextAuthoringEvaluationSummary(
            string trainedModelLabel,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetModelEvaluationSummary(_projectName, trainedModelLabel, context);
            return Response.FromValue(AnalyzeTextAuthoringEvaluationSummary.FromResponse(response), response);
        }

        /// <summary> Gets the status for loading a snapshot. </summary>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<AnalyzeTextAuthoringLoadSnapshotOperationState>> GetLoadSnapshotStatusAsync(
            string trainedModelLabel,
            string jobId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetLoadSnapshotStatusAsync(_projectName, trainedModelLabel, jobId, context).ConfigureAwait(false);
            return Response.FromValue(AnalyzeTextAuthoringLoadSnapshotOperationState.FromResponse(response), response);
        }

        /// <summary> Gets the status for loading a snapshot. </summary>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<AnalyzeTextAuthoringLoadSnapshotOperationState> GetLoadSnapshotStatus(
            string trainedModelLabel,
            string jobId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetLoadSnapshotStatus(_projectName, trainedModelLabel, jobId, context);
            return Response.FromValue(AnalyzeTextAuthoringLoadSnapshotOperationState.FromResponse(response), response);
        }

        /// <summary> Gets the detailed results of the evaluation for a trained model. </summary>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="stringIndexType"> Specifies the method used to interpret string offsets. </param>
        /// <param name="maxCount"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<AnalyzeTextAuthoringDocumentEvaluationResult> GetModelEvaluationResultsAsync(
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
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => AnalyzeTextAuthoringDocumentEvaluationResult.DeserializeAnalyzeTextAuthoringDocumentEvaluationResult(e), ClientDiagnostics, _pipeline, "TextAuthoringModels.GetModelEvaluationResults", "value", "nextLink", maxpagesize, context);
        }

        /// <summary> Gets the detailed results of the evaluation for a trained model. </summary>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="stringIndexType"> Specifies the method used to interpret string offsets. </param>
        /// <param name="maxCount"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<AnalyzeTextAuthoringDocumentEvaluationResult> GetModelEvaluationResults(
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
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => AnalyzeTextAuthoringDocumentEvaluationResult.DeserializeAnalyzeTextAuthoringDocumentEvaluationResult(e), ClientDiagnostics, _pipeline, "TextAuthoringModels.GetModelEvaluationResults", "value", "nextLink", maxpagesize, context);
        }

        /// <summary> Triggers evaluation operation on a trained model. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="details"> The training input parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Operation<AnalyzeTextAuthoringEvaluationJobResult>> EvaluateModelAsync(
            WaitUntil waitUntil,
            string trainedModelLabel,
            AnalyzeTextAuthoringEvaluationDetails details,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));
            Argument.AssertNotNull(details, nameof(details));

            using RequestContent content = details.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> response = await EvaluateModelAsync(waitUntil, _projectName, trainedModelLabel, content, context).ConfigureAwait(false);
            return ProtocolOperationHelpers.Convert(response, FetchAnalyzeTextAuthoringEvaluationJobResultFromAnalyzeTextAuthoringEvaluationOperationState, ClientDiagnostics, "TextAuthoringModels.EvaluateModel");
        }

        /// <summary> Triggers evaluation operation on a trained model. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="details"> The training input parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Operation<AnalyzeTextAuthoringEvaluationJobResult> EvaluateModel(
            WaitUntil waitUntil,
            string trainedModelLabel,
            AnalyzeTextAuthoringEvaluationDetails details,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));
            Argument.AssertNotNull(details, nameof(details));

            using RequestContent content = details.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> response = EvaluateModel(waitUntil, _projectName, trainedModelLabel, content, context);
            return ProtocolOperationHelpers.Convert(response, FetchAnalyzeTextAuthoringEvaluationJobResultFromAnalyzeTextAuthoringEvaluationOperationState, ClientDiagnostics, "TextAuthoringModels.EvaluateModel");
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
        /// Please try the simpler <see cref="GetTrainedModelAsync(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The new project name. </param>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="trainedModelLabel"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> or <paramref name="trainedModelLabel"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/TextAuthoringModels.xml" path="doc/members/member[@name='GetTrainedModelAsync(string,string,RequestContext)']/*" />
        public virtual async Task<Response> GetTrainedModelAsync(string projectName, string trainedModelLabel, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringModels.GetTrainedModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetTrainedModelRequest(projectName, trainedModelLabel, context);
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
        /// Please try the simpler <see cref="GetTrainedModel(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The new project name. </param>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="trainedModelLabel"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> or <paramref name="trainedModelLabel"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/TextAuthoringModels.xml" path="doc/members/member[@name='GetTrainedModel(string,string,RequestContext)']/*" />
        public virtual Response GetTrainedModel(string projectName, string trainedModelLabel, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringModels.GetTrainedModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetTrainedModelRequest(projectName, trainedModelLabel, context);
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
        /// Please try the simpler <see cref="GetEvaluationStatusAsync(string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The new project name. </param>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/>, <paramref name="trainedModelLabel"/> or <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/>, <paramref name="trainedModelLabel"/> or <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/TextAuthoringModels.xml" path="doc/members/member[@name='GetEvaluationStatusAsync(string,string,string,RequestContext)']/*" />
        public virtual async Task<Response> GetEvaluationStatusAsync(string projectName, string trainedModelLabel, string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringModels.GetEvaluationStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetEvaluationStatusRequest(projectName, trainedModelLabel, jobId, context);
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
        /// Please try the simpler <see cref="GetEvaluationStatus(string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The new project name. </param>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/>, <paramref name="trainedModelLabel"/> or <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/>, <paramref name="trainedModelLabel"/> or <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/TextAuthoringModels.xml" path="doc/members/member[@name='GetEvaluationStatus(string,string,string,RequestContext)']/*" />
        public virtual Response GetEvaluationStatus(string projectName, string trainedModelLabel, string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringModels.GetEvaluationStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetEvaluationStatusRequest(projectName, trainedModelLabel, jobId, context);
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
        /// Please try the simpler <see cref="GetModelEvaluationSummaryAsync(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The name of the project to use. </param>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="trainedModelLabel"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> or <paramref name="trainedModelLabel"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/TextAuthoringModels.xml" path="doc/members/member[@name='GetModelAnalyzeTextAuthoringEvaluationSummaryAsync(string,string,RequestContext)']/*" />
        public virtual async Task<Response> GetModelEvaluationSummaryAsync(string projectName, string trainedModelLabel, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringModels.GetModelAnalyzeTextAuthoringEvaluationSummary");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetModelEvaluationSummaryRequest(projectName, trainedModelLabel, context);
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
        /// Please try the simpler <see cref="GetModelAnalyzeTextAuthoringEvaluationSummary(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The name of the project to use. </param>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="trainedModelLabel"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> or <paramref name="trainedModelLabel"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/TextAuthoringModels.xml" path="doc/members/member[@name='GetModelAnalyzeTextAuthoringEvaluationSummary(string,string,RequestContext)']/*" />
        public virtual Response GetModelEvaluationSummary(string projectName, string trainedModelLabel, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringModels.GetModelAnalyzeTextAuthoringEvaluationSummary");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetModelEvaluationSummaryRequest(projectName, trainedModelLabel, context);
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
        /// Please try the simpler <see cref="GetLoadSnapshotStatusAsync(string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The new project name. </param>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/>, <paramref name="trainedModelLabel"/> or <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/>, <paramref name="trainedModelLabel"/> or <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/TextAuthoringModels.xml" path="doc/members/member[@name='GetLoadSnapshotStatusAsync(string,string,string,RequestContext)']/*" />
        public virtual async Task<Response> GetLoadSnapshotStatusAsync(string projectName, string trainedModelLabel, string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringModels.GetLoadSnapshotStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetLoadSnapshotStatusRequest(projectName, trainedModelLabel, jobId, context);
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
        /// Please try the simpler <see cref="GetLoadSnapshotStatus(string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The new project name. </param>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/>, <paramref name="trainedModelLabel"/> or <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/>, <paramref name="trainedModelLabel"/> or <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/TextAuthoringModels.xml" path="doc/members/member[@name='GetLoadSnapshotStatus(string,string,string,RequestContext)']/*" />
        public virtual Response GetLoadSnapshotStatus(string projectName, string trainedModelLabel, string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringModels.GetLoadSnapshotStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetLoadSnapshotStatusRequest(projectName, trainedModelLabel, jobId, context);
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
        /// Please try the simpler <see cref="GetModelEvaluationResultsAsync(string,StringIndexType,int?,int?,int?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The new project name. </param>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="stringIndexType"> Specifies the method used to interpret string offsets. For additional information see https://aka.ms/text-analytics-offsets. Allowed values: "Utf16CodeUnit" | "Utf8CodeUnit" | "Utf32CodeUnit". </param>
        /// <param name="maxCount"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/>, <paramref name="trainedModelLabel"/> or <paramref name="stringIndexType"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> or <paramref name="trainedModelLabel"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Generated/Docs/TextAuthoringModels.xml" path="doc/members/member[@name='GetModelEvaluationResultsAsync(string,string,string,int?,int?,int?,RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetModelEvaluationResultsAsync(string projectName, string trainedModelLabel, string stringIndexType, int? maxCount = null, int? skip = null, int? maxpagesize = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));
            Argument.AssertNotNull(stringIndexType, nameof(stringIndexType));

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetModelEvaluationResultsRequest(projectName, trainedModelLabel, stringIndexType, maxCount, skip, pageSizeHint, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetModelEvaluationResultsNextPageRequest(nextLink, projectName, trainedModelLabel, stringIndexType, maxCount, skip, pageSizeHint, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "TextAuthoringModels.GetModelEvaluationResults", "value", "nextLink", maxpagesize, context);
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
        /// Please try the simpler <see cref="GetModelEvaluationResults(string,StringIndexType,int?,int?,int?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The new project name. </param>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="stringIndexType"> Specifies the method used to interpret string offsets. For additional information see https://aka.ms/text-analytics-offsets. Allowed values: "Utf16CodeUnit" | "Utf8CodeUnit" | "Utf32CodeUnit". </param>
        /// <param name="maxCount"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/>, <paramref name="trainedModelLabel"/> or <paramref name="stringIndexType"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> or <paramref name="trainedModelLabel"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Generated/Docs/TextAuthoringModels.xml" path="doc/members/member[@name='GetModelEvaluationResults(string,string,string,int?,int?,int?,RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetModelEvaluationResults(string projectName, string trainedModelLabel, string stringIndexType, int? maxCount = null, int? skip = null, int? maxpagesize = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));
            Argument.AssertNotNull(stringIndexType, nameof(stringIndexType));

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetModelEvaluationResultsRequest(projectName, trainedModelLabel, stringIndexType, maxCount, skip, pageSizeHint, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetModelEvaluationResultsNextPageRequest(nextLink, projectName, trainedModelLabel, stringIndexType, maxCount, skip, pageSizeHint, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "TextAuthoringModels.GetModelEvaluationResults", "value", "nextLink", maxpagesize, context);
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
        /// Please try the simpler <see cref="EvaluateModelAsync(WaitUntil,string,AnalyzeTextAuthoringEvaluationDetails,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="projectName"> The name of the project to use. </param>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/>, <paramref name="trainedModelLabel"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> or <paramref name="trainedModelLabel"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Generated/Docs/TextAuthoringModels.xml" path="doc/members/member[@name='EvaluateModelAsync(WaitUntil,string,string,RequestContent,RequestContext)']/*" />
        public virtual async Task<Operation<BinaryData>> EvaluateModelAsync(WaitUntil waitUntil, string projectName, string trainedModelLabel, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringModels.EvaluateModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateEvaluateModelRequest(projectName, trainedModelLabel, content, context);
                return await ProtocolOperationHelpers.ProcessMessageAsync(_pipeline, message, ClientDiagnostics, "TextAuthoringModels.EvaluateModel", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
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
        /// Please try the simpler <see cref="EvaluateModel(WaitUntil,string,AnalyzeTextAuthoringEvaluationDetails,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="projectName"> The name of the project to use. </param>
        /// <param name="trainedModelLabel"> The trained model label. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/>, <paramref name="trainedModelLabel"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> or <paramref name="trainedModelLabel"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Generated/Docs/TextAuthoringModels.xml" path="doc/members/member[@name='EvaluateModel(WaitUntil,string,string,RequestContent,RequestContext)']/*" />
        public virtual Operation<BinaryData> EvaluateModel(WaitUntil waitUntil, string projectName, string trainedModelLabel, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringModels.EvaluateModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateEvaluateModelRequest(projectName, trainedModelLabel, content, context);
                return ProtocolOperationHelpers.ProcessMessage(_pipeline, message, ClientDiagnostics, "TextAuthoringModels.EvaluateModel", OperationFinalStateVia.OperationLocation, context, waitUntil);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the details of an exported model. </summary>
        /// <param name="exportedModelName"> The exported model name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<AnalyzeTextAuthoringExportedTrainedModel>> GetExportedModelAsync(
            string exportedModelName,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(exportedModelName, nameof(exportedModelName));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetExportedModelAsync(_projectName, exportedModelName, context).ConfigureAwait(false);
            return Response.FromValue(AnalyzeTextAuthoringExportedTrainedModel.FromResponse(response), response);
        }

        /// <summary> Gets the details of an exported model. </summary>
        /// <param name="exportedModelName"> The exported model name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<AnalyzeTextAuthoringExportedTrainedModel> GetExportedModel(
            string exportedModelName,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(exportedModelName, nameof(exportedModelName));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetExportedModel(_projectName, exportedModelName, context);
            return Response.FromValue(AnalyzeTextAuthoringExportedTrainedModel.FromResponse(response), response);
        }

        /// <summary> Gets the status for an existing job to create or update an exported model. </summary>
        /// <param name="exportedModelName"> The exported model name. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<AnalyzeTextAuthoringExportedModelOperationState>> GetExportedModelJobStatusAsync(
            string exportedModelName,
            string jobId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(exportedModelName, nameof(exportedModelName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetExportedModelJobStatusAsync(_projectName, exportedModelName, jobId, context).ConfigureAwait(false);
            return Response.FromValue(AnalyzeTextAuthoringExportedModelOperationState.FromResponse(response), response);
        }

        /// <summary> Gets the status for an existing job to create or update an exported model. </summary>
        /// <param name="exportedModelName"> The exported model name. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<AnalyzeTextAuthoringExportedModelOperationState> GetExportedModelJobStatus(
            string exportedModelName,
            string jobId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(exportedModelName, nameof(exportedModelName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetExportedModelJobStatus(_projectName, exportedModelName, jobId, context);
            return Response.FromValue(AnalyzeTextAuthoringExportedModelOperationState.FromResponse(response), response);
        }

        /// <summary> Creates a new exported model or replaces an existing one. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="exportedModelName"> The exported model name. </param>
        /// <param name="details"> The exported model info. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exportedModelName"/> or <paramref name="details"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="exportedModelName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Operation> CreateOrUpdateExportedModelAsync(
            WaitUntil waitUntil,
            string exportedModelName,
            AnalyzeTextAuthoringExportedModelDetails details,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(exportedModelName, nameof(exportedModelName));
            Argument.AssertNotNull(details, nameof(details));

            using RequestContent content = details.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            return await CreateOrUpdateExportedModelAsync(waitUntil, _projectName, exportedModelName, content, context).ConfigureAwait(false);
        }

        /// <summary> Creates a new exported model or replaces an existing one. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="exportedModelName"> The exported model name. </param>
        /// <param name="details"> The exported model info. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exportedModelName"/> or <paramref name="details"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="exportedModelName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Operation CreateOrUpdateExportedModel(
            WaitUntil waitUntil,
            string exportedModelName,
            AnalyzeTextAuthoringExportedModelDetails details,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(exportedModelName, nameof(exportedModelName));
            Argument.AssertNotNull(details, nameof(details));

            using RequestContent content = details.ToRequestContent();
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

        /// <summary>
        /// [Protocol Method] Gets the details of an exported model.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetExportedModelAsync(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The new project name. </param>
        /// <param name="exportedModelName"> The exported model name. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="exportedModelName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> or <paramref name="exportedModelName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/TextAuthoringModels.xml" path="doc/members/member[@name='GetExportedModelAsync(string,string,RequestContext)']/*" />
        public virtual async Task<Response> GetExportedModelAsync(string projectName, string exportedModelName, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(exportedModelName, nameof(exportedModelName));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringModels.GetExportedModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetExportedModelRequest(projectName, exportedModelName, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the details of an exported model.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetExportedModel(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The new project name. </param>
        /// <param name="exportedModelName"> The exported model name. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="exportedModelName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> or <paramref name="exportedModelName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/TextAuthoringModels.xml" path="doc/members/member[@name='GetExportedModel(string,string,RequestContext)']/*" />
        public virtual Response GetExportedModel(string projectName, string exportedModelName, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(exportedModelName, nameof(exportedModelName));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringModels.GetExportedModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetExportedModelRequest(projectName, exportedModelName, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the status for an existing job to create or update an exported model.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetExportedModelJobStatusAsync(string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The new project name. </param>
        /// <param name="exportedModelName"> The exported model name. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/>, <paramref name="exportedModelName"/> or <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/>, <paramref name="exportedModelName"/> or <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/TextAuthoringModels.xml" path="doc/members/member[@name='GetExportedModelJobStatusAsync(string,string,string,RequestContext)']/*" />
        public virtual async Task<Response> GetExportedModelJobStatusAsync(string projectName, string exportedModelName, string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(exportedModelName, nameof(exportedModelName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringModels.GetExportedModelJobStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetExportedModelJobStatusRequest(projectName, exportedModelName, jobId, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the status for an existing job to create or update an exported model.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetExportedModelJobStatus(string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The new project name. </param>
        /// <param name="exportedModelName"> The exported model name. </param>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/>, <paramref name="exportedModelName"/> or <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/>, <paramref name="exportedModelName"/> or <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/TextAuthoringModels.xml" path="doc/members/member[@name='GetExportedModelJobStatus(string,string,string,RequestContext)']/*" />
        public virtual Response GetExportedModelJobStatus(string projectName, string exportedModelName, string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(exportedModelName, nameof(exportedModelName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringModels.GetExportedModelJobStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetExportedModelJobStatusRequest(projectName, exportedModelName, jobId, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Creates a new exported model or replaces an existing one.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CreateOrUpdateExportedModelAsync(WaitUntil,string,AnalyzeTextAuthoringExportedModelDetails,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="projectName"> The name of the project to use. </param>
        /// <param name="exportedModelName"> The exported model name. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/>, <paramref name="exportedModelName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> or <paramref name="exportedModelName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Generated/Docs/TextAuthoringModels.xml" path="doc/members/member[@name='CreateOrUpdateExportedModelAsync(WaitUntil,string,string,RequestContent,RequestContext)']/*" />
        public virtual async Task<Operation> CreateOrUpdateExportedModelAsync(WaitUntil waitUntil, string projectName, string exportedModelName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(exportedModelName, nameof(exportedModelName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringModels.CreateOrUpdateExportedModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateOrUpdateExportedModelRequest(projectName, exportedModelName, content, context);
                return await ProtocolOperationHelpers.ProcessMessageWithoutResponseValueAsync(_pipeline, message, ClientDiagnostics, "TextAuthoringModels.CreateOrUpdateExportedModel", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Creates a new exported model or replaces an existing one.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CreateOrUpdateExportedModel(WaitUntil,string,AnalyzeTextAuthoringExportedModelDetails,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="projectName"> The name of the project to use. </param>
        /// <param name="exportedModelName"> The exported model name. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/>, <paramref name="exportedModelName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> or <paramref name="exportedModelName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Generated/Docs/TextAuthoringModels.xml" path="doc/members/member[@name='CreateOrUpdateExportedModel(WaitUntil,string,string,RequestContent,RequestContext)']/*" />
        public virtual Operation CreateOrUpdateExportedModel(WaitUntil waitUntil, string projectName, string exportedModelName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(exportedModelName, nameof(exportedModelName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("TextAuthoringModels.CreateOrUpdateExportedModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateOrUpdateExportedModelRequest(projectName, exportedModelName, content, context);
                return ProtocolOperationHelpers.ProcessMessageWithoutResponseValue(_pipeline, message, ClientDiagnostics, "TextAuthoringModels.CreateOrUpdateExportedModel", OperationFinalStateVia.OperationLocation, context, waitUntil);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
