// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Compute.Batch
{
    /// <summary>
    /// Upon success a Node will be started
    /// </summary>
    public class StartNodeOperation : Operation<BatchNode>
    {
        /// <summary>
        /// The client used to check for completion.
        /// </summary>
        private readonly BatchClient _client;

        /// <summary>
        /// Whether the operation has completed.
        /// </summary>
        private bool _hasCompleted;

        /// <summary>
        /// Gets the success of the operation.
        /// </summary>
        private BatchNode _value;
        private Response _rawResponse;
        private string _nodeId;
        private string _poolId;
        private bool _hasValue;

        /// <summary>
        /// Initializes a new <see cref="StartNodeOperation"/> instance
        /// </summary>
        /// <param name="client">
        /// The client used to check for completion.
        /// </param>
        /// <param name="nodeId">The ID of the node.</param>
        /// <param name="poolId">The ID of the pool</param>
        /// <param name="initialResponse">
        /// Either the response from initiating the operation or getting the
        /// status if we're creating an operation from an existing ID.
        /// </param>
        internal StartNodeOperation(
            BatchClient client,
            string poolId,
            string nodeId,
            Response initialResponse)
        {
            Id = nodeId + ";" + poolId;
            _poolId = poolId;
            _nodeId = nodeId;
            _rawResponse = initialResponse;
            _client = client;
        }

        /// <summary>
        /// Initializes a new <see cref="StartNodeOperation"/> instance
        /// </summary>
        /// <param name="client">
        /// The client used to check for completion.
        /// </param>
        /// <param name="id">The ID of this operation.</param>
        public StartNodeOperation(
            BatchClient client,
            string id)
        {
            if (String.IsNullOrEmpty(id))
                throw new ArgumentNullException("id is not formated correctly");
            string[] idSplit = id.Split(';');
            _nodeId = idSplit[0];
            _poolId = idSplit[1];
            Id = id;
            _rawResponse = null;
            _client = client;
        }

        /// <summary>
        /// Initializes a new <see cref="StartNodeOperation"/> instance for
        /// mocking.
        /// </summary>
        protected StartNodeOperation()
        {
        }

        /// <summary>
        /// Get the sucess state of the deletion operation
        /// </summary>
        public override BatchNode Value => OperationHelpers.GetValue(ref _value);

        /// <summary>
        /// Gets a value indicating whether the operation completed and
        /// successfully produced a value.  The <see cref="Operation{Bool}.Value"/>
        /// property is the success of the operation.
        /// </summary>
        public override bool HasValue => _hasValue;

        /// <inheritdoc />
        public override string Id { get; }

        /// <summary>
        /// Gets a value indicating whether the operation has completed.
        /// </summary>
        public override bool HasCompleted => _hasCompleted;

        /// <inheritdoc />
        public override Response GetRawResponse() => _rawResponse;

        /// <summary>
        /// Check for the latest status of the delete operation.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>The <see cref="Response"/> with the status update.</returns>
        public override Response UpdateStatus(CancellationToken cancellationToken = default) =>
            UpdateStatusAsync(false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Check for the latest status of the delete operation.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>The <see cref="Response"/> with the status update.</returns>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) =>
            await UpdateStatusAsync(true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Check for the latest status of the copy operation.
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

            // Get the latest status
            Response<BatchNode> response = async
                    ? await _client.GetNodeAsync(_poolId, _nodeId, cancellationToken: cancellationToken).ConfigureAwait(false)
                    : _client.GetNode(_poolId, _nodeId, cancellationToken: cancellationToken);

            if (response != null)
            {
                _rawResponse = response.GetRawResponse();

                // we wait till we reach are no longer in the action state
                if (response.Value.State != BatchNodeState.Starting)
                {
                    _hasValue = true;
                    _value = response.Value;
                    _hasCompleted = true;
                }
            }

            return _rawResponse;
        }
    }
}
