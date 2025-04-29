﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Compute.Batch
{
    /// <summary>
    /// Upon success a Certificate will be deleted
    /// </summary>
    public class DeleteCertificateOperation : Operation<bool>
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
        private bool? _value;
        private Response _rawResponse;
        private string _thumbprintAlgorithm;
        private string _thumbprint;

        /// <summary>
        /// Initializes a new <see cref="DeleteCertificateOperation"/> instance
        /// </summary>
        /// <param name="client">
        /// The client used to check for completion.
        /// </param>
        /// <param name="thumbprintAlgorithm">thumbprint Algortihm of certificate</param>
        /// <param name="thumbprint">thumbprint of certificate</param>
        /// <param name="initialResponse">
        /// Either the response from initiating the operation or getting the
        /// status if we're creating an operation from an existing ID.
        /// </param>
        internal DeleteCertificateOperation(
            BatchClient client,
            string thumbprintAlgorithm,
            string thumbprint,
            Response initialResponse)
        {
            _thumbprint = thumbprint;
            _thumbprintAlgorithm = thumbprintAlgorithm;
            Id = _thumbprint + ";" + _thumbprintAlgorithm;
            _value = false;
            _rawResponse = initialResponse;
            _client = client;
        }

        /// <summary>
        /// Initializes a new <see cref="DeleteCertificateOperation"/> instance
        /// </summary>
        /// <param name="client">
        /// The client used to check for completion.
        /// </param>
        /// <param name="id">The ID of this operation.</param>
        public DeleteCertificateOperation(
            BatchClient client,
            string id)
        {
            if (String.IsNullOrEmpty(id))
                throw new ArgumentNullException("id is not formated correctly");
            string[] idSplit = id.Split(';');
            _thumbprint = idSplit[0];
            _thumbprintAlgorithm = idSplit[1];
            Id = id;
            _value = false;
            _rawResponse = null;
            _client = client;
        }

        /// <summary>
        /// Initializes a new <see cref="DeleteCertificateOperation"/> instance for
        /// mocking.
        /// </summary>
        protected DeleteCertificateOperation()
        {
        }

        /// <summary>
        /// Get the sucess state of the deletion operation
        /// </summary>
        public override bool Value => OperationHelpers.GetValue(ref _value);

        /// <summary>
        /// Gets a value indicating whether the operation completed and
        /// successfully produced a value.  The <see cref="Operation{Bool}.Value"/>
        /// property is the success of the operation.
        /// </summary>
        public override bool HasValue => _value.HasValue;

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
            Response<BatchCertificate> deleteResponse = null;
            try
            {
                deleteResponse = async
                    ? await _client.GetCertificateAsync(_thumbprintAlgorithm,_thumbprint, cancellationToken: cancellationToken).ConfigureAwait(false)
                    : _client.GetCertificate(_thumbprintAlgorithm, _thumbprint, cancellationToken: cancellationToken);
            }
            catch (Azure.RequestFailedException e)
            {
                if (e.Status == 404)
                {
                    _value = true;
                    _hasCompleted = true;
                    _rawResponse = e.GetRawResponse();
                }
            }

            if (deleteResponse != null)
            {
                _rawResponse = deleteResponse.GetRawResponse();
            }
            return _rawResponse;
        }
    }
}
