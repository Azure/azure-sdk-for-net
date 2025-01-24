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
    [CodeGenSuppress("GetTrainingStatusAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetTrainingStatus", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetTrainingJobsAsync", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetTrainingJobs", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("TrainAsync", typeof(WaitUntil), typeof(string), typeof(TrainingJobDetails), typeof(CancellationToken))]
    [CodeGenSuppress("Train", typeof(WaitUntil), typeof(string), typeof(TrainingJobDetails), typeof(CancellationToken))]
    [CodeGenSuppress("CancelTrainingJobAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("CancelTrainingJob", typeof(WaitUntil), typeof(string), typeof(string), typeof(CancellationToken))]
    public partial class ConversationAuthoringTraining
    {
        private readonly string _projectName;

        /// <summary> Initializes a new instance of ConversationAuthoringTraining. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="keyCredential"> The key credential to copy. </param>
        /// <param name="tokenCredential"> The token credential to copy. </param>
        /// <param name="endpoint"> Supported Cognitive Services endpoint e.g., https://&lt;resource-name&gt;.api.cognitiveservices.azure.com. </param>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <param name="projectName"> The new project name. </param>
        internal ConversationAuthoringTraining(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, AzureKeyCredential keyCredential, TokenCredential tokenCredential, Uri endpoint, string apiVersion, string projectName)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _keyCredential = keyCredential;
            _tokenCredential = tokenCredential;
            _endpoint = endpoint;
            _apiVersion = apiVersion;
            _projectName = projectName;
        }

        /// <summary> Gets the status for a training job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<TrainingJobState>> GetTrainingStatusAsync(
            string jobId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetTrainingStatusAsync(_projectName, jobId, context).ConfigureAwait(false);
            return Response.FromValue(TrainingJobState.FromResponse(response), response);
        }

        /// <summary> Gets the status for a training job. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TrainingJobState> GetTrainingStatus(
            string jobId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetTrainingStatus(_projectName, jobId, context);
            return Response.FromValue(TrainingJobState.FromResponse(response), response);
        }

        /// <summary> Lists the non-expired training jobs created for a project. </summary>
        /// <param name="maxCount"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<TrainingJobState> GetTrainingJobsAsync(
            int? maxCount = null,
            int? skip = null,
            int? maxpagesize = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));

            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetTrainingJobsRequest(_projectName, maxCount, skip, pageSizeHint, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetTrainingJobsNextPageRequest(nextLink, _projectName, maxCount, skip, pageSizeHint, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => TrainingJobState.DeserializeTrainingJobState(e), ClientDiagnostics, _pipeline, "ConversationAuthoringTraining.GetTrainingJobs", "value", "nextLink", maxpagesize, context);
        }

        /// <summary> Lists the non-expired training jobs created for a project. </summary>
        /// <param name="maxCount"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<TrainingJobState> GetTrainingJobs(
            int? maxCount = null,
            int? skip = null,
            int? maxpagesize = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));

            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetTrainingJobsRequest(_projectName, maxCount, skip, pageSizeHint, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetTrainingJobsNextPageRequest(nextLink, _projectName, maxCount, skip, pageSizeHint, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => TrainingJobState.DeserializeTrainingJobState(e), ClientDiagnostics, _pipeline, "ConversationAuthoringTraining.GetTrainingJobs", "value", "nextLink", maxpagesize, context);
        }

        /// <summary> Triggers a training job for a project. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="body"> The training input parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Operation<TrainingJobResult>> TrainAsync(
            WaitUntil waitUntil,
            TrainingJobDetails body,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> response = await TrainAsync(waitUntil, _projectName, content, context).ConfigureAwait(false);
            return ProtocolOperationHelpers.Convert(response, FetchTrainingJobResultFromTrainingJobState, ClientDiagnostics, "ConversationAuthoringTraining.Train");
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
            return ProtocolOperationHelpers.Convert(response, FetchTrainingJobResultFromTrainingJobState, ClientDiagnostics, "ConversationAuthoringTraining.Train");
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
            return ProtocolOperationHelpers.Convert(response, FetchTrainingJobResultFromTrainingJobState, ClientDiagnostics, "ConversationAuthoringTraining.CancelTrainingJob");
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
            return ProtocolOperationHelpers.Convert(response, FetchTrainingJobResultFromTrainingJobState, ClientDiagnostics, "ConversationAuthoringTraining.CancelTrainingJob");
        }
    }
}
