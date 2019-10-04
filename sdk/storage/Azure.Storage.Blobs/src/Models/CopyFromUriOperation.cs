// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Specialized;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// An <see cref="Operation{Int64}"/> for tracking the status of a
    /// <see cref="BlobBaseClient.StartCopyFromUriAsync(Uri, System.Collections.Generic.IDictionary{String, String}, AccessTier?, BlobAccessConditions?, BlobAccessConditions?, RehydratePriority?, CancellationToken)"/>
    /// request.  Its <see cref="Operation{Int64}.Value"/> upon succesful
    /// completion will be the number of bytes copied.
    /// </summary>
    internal class CopyFromUriOperation : Operation<long>
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
        /// Gets a value indicating whether the operation has completed.
        /// </summary>
        public override bool HasCompleted => _hasCompleted;

        /// <summary>
        /// Whether the operation completed succesfully.
        /// </summary>
        private bool _hasValue;

        /// <summary>
        /// Gets a value indicating whether the operation completed and
        /// succesfully produced a value.  The <see cref="Operation{Int64}.Value"/>
        /// property is the number of bytes copied by the operation.
        /// </summary>
        public override bool HasValue => _hasValue;

        /// <summary>
        /// Initializes a new <see cref="CopyFromUriOperation"/> instance for
        /// mocking.
        /// </summary>
        public CopyFromUriOperation(
            string copyId,
            bool hasCompleted,
            long? value = default,
            Response rawResponse = default)
            : base(copyId)
        {
            _hasCompleted = hasCompleted;
            if (value != null)
            {
                _hasValue = true;
                Value = value.Value;
            }
            else
            {
                _hasValue = false;
            }
            if (rawResponse != null)
            {
                SetRawResponse(rawResponse);
            }
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
        public CopyFromUriOperation(
            BlobBaseClient client,
            string copyId,
            Response initialResponse,
            CancellationToken cancellationToken)
            : base(copyId)
        {
            _client = client;
            _cancellationToken = cancellationToken;
            SetRawResponse(initialResponse);
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
        public async override ValueTask<Response> UpdateStatusAsync(
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
            { return GetRawResponse(); }

            // Use our original CancellationToken if the user didn't provide one
            if (cancellationToken == default)
            {
                cancellationToken = _cancellationToken;
            }

            // Get the latest status
            Task<Response<BlobProperties>> task = _client.GetPropertiesAsync(cancellationToken: cancellationToken);
            Response<BlobProperties> update = async ?
                await task.ConfigureAwait(false) :
                task.EnsureCompleted();

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
                Value = update.Value.ContentLength;
                _hasValue = true;
            }

            // Save this update as the latest raw response indicating the state
            // of the copy operation
            Response response = update.GetRawResponse();
            SetRawResponse(response);
            return response;
        }
    }

    /// <summary>
    /// BlobsModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class BlobsModelFactory
    {
        /// <summary>
        /// Creates a new Operation{long} instance for mocking long running
        /// Copy From URI operations.
        /// </summary>
        public static Operation<long> CopyFromUriOperation(
            string copyId,
            bool hasCompleted,
            long? value = default,
            Response rawResponse = default) =>
            new CopyFromUriOperation(copyId, hasCompleted, value, rawResponse);
    }
}
