// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Personalizer
{
    /// <summary>
    /// An <see cref="Operation{PersonalizerEvaluation}"/> for tracking the status of a
    /// <see cref="PersonalizerAdministrationClient.CreatePersonalizerEvaluationAsync(PersonalizerEvaluationOptions, CancellationToken)"/>
    /// request.  Its <see cref="Operation{PersonalizerEvaluation}.Value"/> upon successful
    /// completion will be the completed personalizer evaluation.
    /// </summary>
    public class PersonalizerCreateEvaluationOperation : Operation<PersonalizerEvaluation>
    {
        /// <summary>
        /// The client used to check for completion.
        /// </summary>
        private readonly PersonalizerAdministrationClient _client;

        /// <summary>
        /// The CancellationToken to use for all status checking.
        /// </summary>
        private readonly CancellationToken _cancellationToken;

        /// <summary>
        /// Whether the operation has completed.
        /// </summary>
        private bool _hasCompleted;

        /// <summary>
        /// Gets the personalizer evaluation once it is completed.
        /// </summary>
        private PersonalizerEvaluation _value;

        private Response _rawResponse;

        /// <summary>
        /// Gets a value indicating whether the operation has completed.
        /// </summary>
        public override bool HasCompleted => _hasCompleted;

        /// <summary>
        /// Gets a value indicating whether the operation completed and
        /// successfully produced a value.  The <see cref="Operation{PersonalizerEvaluation}.Value"/>
        /// property completed evaluation.
        /// </summary>
        public override bool HasValue => _value != null;

        /// <inheritdoc />
        public override string Id { get; }

        /// <summary>
        /// Gets the personalizer evaluation.
        /// </summary>
        public override PersonalizerEvaluation Value => OperationHelpers.GetValue(ref _value);

        /// <inheritdoc />
        public override Response GetRawResponse() => _rawResponse;

        /// <inheritdoc />
        public override ValueTask<Response<PersonalizerEvaluation>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<PersonalizerEvaluation>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

        /// <summary>
        /// Initializes a new <see cref="PersonalizerCreateEvaluationOperation"/> instance for
        /// mocking.
        /// </summary>
        protected PersonalizerCreateEvaluationOperation()
        {
        }

        /// <summary>
        /// Initializes a new <see cref="PersonalizerCreateEvaluationOperation"/> instance.
        /// </summary>
        /// <param name="client">
        /// The client used to check for completion.
        /// </param>
        /// <param name="evaluationId">The ID of the evaluation.</param>
        public PersonalizerCreateEvaluationOperation(string evaluationId, PersonalizerAdministrationClient client) :
            this(client, evaluationId, null, CancellationToken.None)
        {
        }

        /// <summary>
        /// Initializes a new <see cref="PersonalizerCreateEvaluationOperation"/> instance.
        /// </summary>
        /// <param name="client">
        /// The client used to check for completion.
        /// </param>
        /// <param name="evaluationId">The ID of the evaluation.</param>
        /// <param name="initialResponse">
        /// Either the response from initiating the operation or getting the
        /// status if we're creating an operation from an existing ID.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        internal PersonalizerCreateEvaluationOperation(
            PersonalizerAdministrationClient client,
            string evaluationId,
            Response initialResponse,
            CancellationToken cancellationToken)
        {
            Id = evaluationId;
            _value = null;
            _rawResponse = initialResponse;
            _client = client;
            _cancellationToken = cancellationToken;
        }

        /// <summary>
        /// Check for the latest status of the personalizer evaluation.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>The <see cref="Response"/> with the status update.</returns>
        public override Response UpdateStatus(
            CancellationToken cancellationToken = default) =>
            UpdateStatusAsync(false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Check for the latest status of the personalizer evaluation.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>The <see cref="Response"/> with the status update.</returns>
        public override async ValueTask<Response> UpdateStatusAsync(
            CancellationToken cancellationToken = default) =>
            await UpdateStatusAsync(true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Check for the latest status of the personalizer evaluation.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <param name="async" />
        /// <returns>The <see cref="Response"/> with the status update.</returns>
        private async Task<Response> UpdateStatusAsync(bool async, CancellationToken cancellationToken)
        {
            // Short-circuit when already completed (which improves mocking
            // scenarios that won't have a client).
            if (HasCompleted)
            {
                return GetRawResponse();
            }

            // Use our original CancellationToken if the user didn't provide one
            if (cancellationToken == default)
            {
                cancellationToken = _cancellationToken;
            }

            // Get the latest status
            Response<PersonalizerEvaluation> evaluation = async
                ? await _client.GetPersonalizerEvaluationAsync(Id, cancellationToken: cancellationToken).ConfigureAwait(false)
                : _client.GetPersonalizerEvaluation(Id, cancellationToken: cancellationToken);

            // Check if the operation is no longer running
            if (evaluation.Value.Status != PersonalizerEvaluationJobStatus.Pending)
            {
                _hasCompleted = true;
                _value = evaluation.Value;
            }

            // Save this update as the latest raw response indicating the state
            // of the copy operation
            Response response = evaluation.GetRawResponse();
            _rawResponse = response;
            return response;
        }
    }
}
