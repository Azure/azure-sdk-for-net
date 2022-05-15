// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Language.Conversations.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Language.Conversations
{
    /// <summary> operation class for analyzing multiple actions using long running operation. </summary>
    public class AnalyzeConversationOperation: Operation<AnalyzeConversationJobState>, IOperation<AnalyzeConversationJobState>
    {
        private static readonly TimeSpan s_defaultPollingInterval = TimeSpan.FromSeconds(2);

        /// <summary>Provides communication with the Text Analytics Azure Cognitive Service through its REST API.</summary>
        private readonly ConversationAnalysisRestClient _serviceClient;

        private readonly OperationInternal<AnalyzeConversationJobState> _operationInternal;

        /// <summary>Provides tools for exception creation in case of failure.</summary>
        private readonly ClientDiagnostics _diagnostics;

        /// <inheritdoc/>
        private readonly bool? _showStats;

        /// <inheritdoc/>
        private readonly Guid _jobId;

        /// <inheritdoc/>
        public override string Id { get; }

        /// <inheritdoc/>
        public override bool HasValue => _operationInternal.HasValue;

        /// <inheritdoc/>
        public override bool HasCompleted => _operationInternal.HasCompleted;

        /// <inheritdoc/>
        public override Response GetRawResponse() => _operationInternal.RawResponse;

        /// <inheritdoc/>
        public override AnalyzeConversationJobState Value => _operationInternal.Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyzeConversationOperation"/> class.
        /// </summary>
        public AnalyzeConversationOperation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyzeConversationOperation"/> class.
        /// </summary>
        /// <param name="serviceClient">The client for communicating with the Form Recognizer Azure Cognitive Service through its REST API.</param>
        /// <param name="diagnostics">The client diagnostics for exception creation in case of failure.</param>
        /// <param name="operationLocation">The address of the long-running operation. It can be obtained from the response headers upon starting the operation.</param>
        /// <param name="showStats"></param>
        internal AnalyzeConversationOperation(ConversationAnalysisRestClient serviceClient, ClientDiagnostics diagnostics, string operationLocation, bool? showStats = default)
        {
            _serviceClient = serviceClient;
            _diagnostics = diagnostics;
            _showStats = showStats;
            _operationInternal = new OperationInternal<AnalyzeConversationJobState>(_diagnostics, this, rawResponse: null);

            _jobId = getJobId(operationLocation);
        }

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            if (!HasCompleted)
            {
                return _operationInternal.UpdateStatus(cancellationToken);
            }

            return GetRawResponse();
        }

        /// <inheritdoc/>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            if (!HasCompleted)
            {
                return await _operationInternal.UpdateStatusAsync(cancellationToken).ConfigureAwait(false);
            }

            return GetRawResponse();
        }

        /// <inheritdoc />
        public override ValueTask<Response<AnalyzeConversationJobState>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(s_defaultPollingInterval, cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<AnalyzeConversationJobState>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

        /// <inheritdoc />
        public override Response<AnalyzeConversationJobState> WaitForCompletion(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletion(s_defaultPollingInterval, cancellationToken);

        async ValueTask<OperationState<AnalyzeConversationJobState>> IOperation<AnalyzeConversationJobState>.UpdateStateAsync(bool async, CancellationToken cancellationToken)
        {
            Response<AnalyzeConversationJobState> response = async
                ? await _serviceClient.JobStatusAsync(_jobId, _showStats, cancellationToken).ConfigureAwait(false)
                : _serviceClient.JobStatus(_jobId, _showStats, cancellationToken);

            Response rawResponse = response.GetRawResponse();

            switch (response.Value.Status)
            {
                case JobState.Succeeded:
                    AnalyzeConversationJobState value = response.Value;
                    return OperationState<AnalyzeConversationJobState>.Success(rawResponse, value);

                case JobState.Running:
                case JobState.NotStarted:
                    return OperationState<AnalyzeConversationJobState>.Pending(rawResponse);

                default:
                    RequestFailedException ex = async
                        ? await _diagnostics.CreateRequestFailedExceptionAsync(rawResponse).ConfigureAwait(false)
                        : _diagnostics.CreateRequestFailedException(rawResponse);

                    return OperationState<AnalyzeConversationJobState>.Failure(rawResponse, ex);
            }
        }

        private static Guid getJobId(string operationLocationHeader)
        {
            string last = operationLocationHeader.Split('/').ToList().Last();
            string jobId = last.Split('?').ToList().First();
            return Guid.Parse(jobId);
        }
    }
}
