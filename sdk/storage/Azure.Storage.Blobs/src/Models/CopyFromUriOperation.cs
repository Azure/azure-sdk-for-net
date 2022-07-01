// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// An <see cref="Operation{Int64}"/> for tracking the status of a
    /// <see cref="BlobBaseClient.StartCopyFromUriAsync(Uri, System.Collections.Generic.IDictionary{String, String}, AccessTier?, BlobRequestConditions, BlobRequestConditions, RehydratePriority?, CancellationToken)"/>
    /// request.  Its <see cref="Operation{Int64}.Value"/> upon successful
    /// completion will be the number of bytes copied.
    /// </summary>
    public class CopyFromUriOperation : Operation<long>
    {
        /// <summary>
        /// The client used to check for completion.
        /// </summary>
        private readonly BlobBaseClient _client;

        /// <summary>
        /// The CancellationToken to use for all status checking.
        /// </summary>
        private readonly CancellationToken _cancellationToken;

        /// <summary>
        /// Whether the operation has completed.
        /// </summary>
        private bool _hasCompleted;

        /// <summary>
        /// Gets the number of bytes copied by the operation.
        /// </summary>
        private long? _value;

        private Response _rawResponse;

        /// <summary>
        /// Gets a value indicating whether the operation has completed.
        /// </summary>
        public override bool HasCompleted => _hasCompleted;

        /// <summary>
        /// Gets a value indicating whether the operation completed and
        /// successfully produced a value.  The <see cref="Operation{Int64}.Value"/>
        /// property is the number of bytes copied by the operation.
        /// </summary>
        public override bool HasValue => _value.HasValue;

        /// <inheritdoc />
        public override string Id { get; }

        /// <summary>
        /// Gets the number of bytes copied by the operation.
        /// </summary>
        public override long Value => OperationHelpers.GetValue(ref _value);

        /// <inheritdoc />
        public override Response GetRawResponse() => _rawResponse;

        /// <inheritdoc />
        public override ValueTask<Response<long>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<long>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

        /// <summary>
        /// Initializes a new <see cref="CopyFromUriOperation"/> instance for
        /// mocking.
        /// </summary>
        protected CopyFromUriOperation()
        {
        }

        /// <summary>
        /// Initializes a new <see cref="CopyFromUriOperation"/> instance
        /// </summary>
        /// <param name="client">
        /// The client used to check for completion.
        /// </param>
        /// <param name="id">The ID of this operation.</param>
        public CopyFromUriOperation(string id, BlobBaseClient client):
            this(client, id, null, CancellationToken.None)
        {
        }

        /// <summary>
        /// Initializes a new <see cref="CopyFromUriOperation"/> instance
        /// </summary>
        /// <param name="client">
        /// The client used to check for completion.
        /// </param>
        /// <param name="copyId">The ID of this operation.</param>
        /// <param name="initialResponse">
        /// Either the response from initiating the operation or getting the
        /// status if we're creating an operation from an existing ID.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        internal CopyFromUriOperation(
            BlobBaseClient client,
            string copyId,
            Response initialResponse,
            CancellationToken cancellationToken)
        {
            Id = copyId;
            _value = null;
            _rawResponse = initialResponse;
            _client = client;
            _cancellationToken = cancellationToken;
        }

        /// <summary>
        /// Check for the latest status of the copy operation.
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
        /// Check for the latest status of the copy operation.
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

            // Use our original CancellationToken if the user didn't provide one
            if (cancellationToken == default)
            {
                cancellationToken = _cancellationToken;
            }

            // Get the latest status
            Response<BlobProperties> update = async
                ? await _client.GetPropertiesAsync(cancellationToken: cancellationToken).ConfigureAwait(false)
                : _client.GetProperties(cancellationToken: cancellationToken);

            // Check if the operation is no longer running
            if (Id != update.Value.CopyId ||
                update.Value.CopyStatus != CopyStatus.Pending)
            {
                _hasCompleted = true;
            }

            // Check if the operation succeeded
            if (Id == update.Value.CopyId &&
                update.Value.CopyStatus == CopyStatus.Success)
            {
                _value = update.Value.ContentLength;
            }
            // Check if the operation aborted or failed
            if (Id == update.Value.CopyId &&
                (update.Value.CopyStatus == CopyStatus.Aborted ||
                update.Value.CopyStatus == CopyStatus.Failed))
            {
                _value = 0;
            }

            // Save this update as the latest raw response indicating the state
            // of the copy operation
            Response response = update.GetRawResponse();
            _rawResponse = response;
            return response;
        }
    }
}
