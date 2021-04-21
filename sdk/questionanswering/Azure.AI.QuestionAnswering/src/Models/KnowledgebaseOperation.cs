// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.QuestionAnswering.Models
{
    /// <summary>
    /// A long-running operation for knowledgebase operations.
    /// </summary>
    public partial class KnowledgebaseOperation : Azure.Operation
    {
        private readonly ClientDiagnostics _diagnostics;
        private readonly Uri _endpoint;
        private readonly HttpPipeline _pipeline;
        private readonly OperationsRestClient _operationsRestClient;

        private bool _completed;
        private Response<Operation> _response;

        /// <summary>
        /// Initializes a new instance of the <see cref="KnowledgebaseOperation"/> class.
        /// </summary>
        /// <param name="client">A <see cref="QuestionAnsweringServiceClient"/> to connect to an endpoint.</param>
        /// <param name="id">The operation identifier saved from a previously started operation.</param>
        /// <exception cref="ArgumentException"><paramref name="id"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="client"/> or <paramref name="id"/> is null.</exception>
        public KnowledgebaseOperation(QuestionAnsweringServiceClient client, string id) :
            this(client?.Endpoint, id, client?.Diagnostics, client?.Pipeline)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNullOrEmpty(id, nameof(id));
        }

        internal KnowledgebaseOperation(QuestionAnsweringServiceClient client, Response<Operation> response) :
            this(client.Endpoint, response.Value.OperationId, client.Diagnostics, client.Pipeline)
        {
            _response = response;
            _completed = CheckCompleted(response);
        }

        /// <summary>
        /// Protected constructor to allow mocking.
        /// </summary>
        protected KnowledgebaseOperation()
        {
        }

        private KnowledgebaseOperation(Uri endpoint, string id, ClientDiagnostics diagnostics, HttpPipeline pipeline)
        {
            Id = id;

            _endpoint = endpoint;
            _diagnostics = diagnostics;
            _pipeline = pipeline;

            _operationsRestClient = new OperationsRestClient(_diagnostics, _pipeline, _endpoint);
        }

        /// <summary>
        /// Gets the operation identifier.
        /// </summary>
        public override string Id { get; }

        /// <summary>
        /// Gets the time the operation was started.
        /// </summary>
        public DateTimeOffset? CreatedOn => _response?.Value.CreatedTimestamp;

        /// <summary>
        /// Gets the time the operation was last updated.
        /// </summary>
        public DateTimeOffset? UpdatedOn => _response?.Value.LastActionTimestamp;

        /// <inheritdoc/>
        public override bool HasCompleted => _completed;

        /// <summary>
        /// Gets a <see cref="KnowledgebaseClient"/> for the completed <see cref="KnowledgebaseOperation"/>.
        /// </summary>
        /// <returns>A <see cref="KnowledgebaseClient"/> for the completed <see cref="KnowledgebaseOperation"/>.</returns>
        /// <exception cref="InvalidOperationException">This operation has not completed successfully.</exception>
        public virtual KnowledgebaseClient GetKnowledgebaseClient()
        {
            if (HasCompleted && KnowledgebaseIdentifier.TryParse(_endpoint, _response.Value?.ResourceLocation, out KnowledgebaseIdentifier id))
            {
                KnowledgebaseRestClient client = new KnowledgebaseRestClient(_diagnostics, _pipeline, id.Endpoint);
                return new KnowledgebaseClient(id.Endpoint, id.KnowledgebaseId, client);
            }

            throw new InvalidOperationException($"Operation {Id} has not completed successfully");
        }

        /// <inheritdoc/>
        public override Response GetRawResponse() => _response?.GetRawResponse();

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            if (!HasCompleted)
            {
                using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KnowledgebaseOperation)}.{nameof(UpdateStatusAsync)}");
                scope.Start();

                try
                {
                    ResponseWithHeaders<Operation, GetDetailsHeaders> response = _operationsRestClient.GetDetails(Id, cancellationToken);

                    _response = Response.FromValue(response.Value, response.GetRawResponse());
                    _completed = CheckCompleted(_response);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }

            return GetRawResponse();
        }

        /// <inheritdoc/>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            if (!HasCompleted)
            {
                using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KnowledgebaseOperation)}.{nameof(UpdateStatusAsync)}");
                scope.Start();

                try
                {
                    ResponseWithHeaders<Operation, GetDetailsHeaders> response = await _operationsRestClient.GetDetailsAsync(Id, cancellationToken).ConfigureAwait(false);

                    _response = Response.FromValue(response.Value, response.GetRawResponse());
                    _completed = await CheckCompletedAsync(_response).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }

            return GetRawResponse();
        }

        /// <inheritdoc/>
        public override ValueTask<Response> WaitForCompletionResponseAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionResponseAsync(cancellationToken);

        /// <inheritdoc/>
        public override ValueTask<Response> WaitForCompletionResponseAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionResponseAsync(pollingInterval, cancellationToken);

        private bool CheckCompleted(Response<Operation> response)
        {
            if (response?.Value is not null)
            {
                if (response.Value.OperationState == OperationStateType.Succeeded)
                {
                    return true;
                }
                else if (response.Value.OperationState == OperationStateType.Failed)
                {
                    ErrorResponseError error = response.Value.ErrorResponse?.Error;
                    throw _diagnostics.CreateRequestFailedException(response.GetRawResponse(), error.Message, error.Code.ToString());
                }
            }

            return false;
        }

        private async ValueTask<bool> CheckCompletedAsync(Response<Operation> response)
        {
            if (response?.Value is not null)
            {
                if (response.Value.OperationState == OperationStateType.Succeeded)
                {
                    return true;
                }
                else if (response.Value.OperationState == OperationStateType.Failed)
                {
                    ErrorResponseError error = response.Value.ErrorResponse?.Error;
                    throw await _diagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse(), error.Message, error.Code.ToString()).ConfigureAwait(false);
                }
            }

            return false;
        }
    }
}
