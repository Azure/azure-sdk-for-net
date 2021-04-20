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
    public partial class KnowledgebaseOperation : Operation
    {
        private readonly ClientDiagnostics _diagnostics;
        private readonly Uri _endpoint;
        private readonly HttpPipeline _pipeline;
        private readonly OperationsRestClient _operationsRestClient;

        private Response _response;

        /// <summary>
        /// Initializes a new instance of the <see cref="KnowledgebaseOperation"/> class.
        /// </summary>
        /// <param name="client">A <see cref="QuestionAnsweringServiceClient"/> to connect to an endpoint.</param>
        /// <param name="id">The operation identifier saved from a previously started operation.</param>
        /// <exception cref="ArgumentException"><paramref name="id"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="client"/> or <paramref name="id"/> is null.</exception>
        public KnowledgebaseOperation(QuestionAnsweringServiceClient client, string id) :
            this(client?.Diagnostics, client?.Pipeline, client?.Endpoint, id)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNullOrEmpty(id, nameof(id));
        }

        internal KnowledgebaseOperation(ClientDiagnostics diagnostics, HttpPipeline pipeline, Uri endpoint, string id)
        {
            Id = id;

            _diagnostics = diagnostics;
            _pipeline = pipeline;
            _endpoint = endpoint;

            _operationsRestClient = new OperationsRestClient(_diagnostics, _pipeline, _endpoint);
        }

        /// <summary>
        /// Protected constructor to allow mocking.
        /// </summary>
        protected KnowledgebaseOperation()
        {
        }

        /// <summary>
        /// Gets the operation identifier.
        /// </summary>
        [CodeGenMember("OperationId")]
        public override string Id { get; }

        /// <summary>
        /// Gets the time the operation was started.
        /// </summary>
        [CodeGenMember("CreatedTimestamp")]
        public DateTimeOffset? CreatedOn { get; }

        /// <summary>
        /// Gets the time the operation was last updated.
        /// </summary>
        [CodeGenMember("LastActionTimestamp")]
        public DateTimeOffset? UpdatedOn { get; }

        /// <summary>
        /// Gets the state of the operation.
        /// </summary>
        internal OperationStateType? OperationState { get; }

        /// <summary>
        /// Gets the final resource location after the operation has completed.
        /// </summary>
        internal string ResourceLocation { get; }

        /// <summary>
        /// Gets the identifier of the user that started the operation.
        /// </summary>
        internal string UserId { get; }

        /// <summary>
        /// Gets the error response if the operation failed.
        /// </summary>
        internal ErrorResponse ErrorResponse { get; }

        /// <inheritdoc/>
        public override bool HasCompleted => OperationState.HasValue && (OperationState == OperationStateType.Failed || OperationState == OperationStateType.Succeeded);

        /// <inheritdoc/>
        public override Response GetRawResponse() => _response;

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override ValueTask<Response> WaitForCompletionResponseAsync(CancellationToken cancellationToken = default) =>
            // TODO: Determine if the seemingly custom RetryAfter (defined with no dash) header should be used.
            this.DefaultWaitForCompletionResponseAsync(cancellationToken);

        /// <inheritdoc/>
        public override ValueTask<Response> WaitForCompletionResponseAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) =>
            // TODO: Determine if the seemingly custom RetryAfter (defined with no dash) header should be used.
            this.DefaultWaitForCompletionResponseAsync(pollingInterval, cancellationToken);
    }
}
