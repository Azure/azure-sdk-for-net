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
    /// Upon success a Job will be terminated
    /// </summary>
    public class TerminateJobOperation : Operation<bool>
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
        private DateTimeOffset _creationTime;
        private Response _rawResponse;
        private string _jobId;

        /// <summary>
        /// Initializes a new <see cref="TerminateJobOperation"/> instance
        /// </summary>
        /// <param name="client">
        /// The client used to check for completion.
        /// </param>
        /// <param name="terminationId">The ID of this operation.</param>
        /// <param name="creationTime">The time the job was created.</param>
        /// <param name="initialResponse">
        /// Either the response from initiating the operation or getting the
        /// status if we're creating an operation from an existing ID.
        /// </param>
        internal TerminateJobOperation(
            BatchClient client,
            string terminationId,
            Response initialResponse,
            DateTimeOffset? creationTime = null)
        {
            if (creationTime == null)
            {
                _creationTime = DateTimeOffset.UtcNow;
            }
            else
            {
                _creationTime = (DateTimeOffset)creationTime;
            }

            Id = terminationId + ";" + _creationTime.ToString();
            _jobId = terminationId;
            _value = false;
            _rawResponse = initialResponse;
            _client = client;
        }

        /// <summary>
        /// Initializes a new <see cref="TerminateJobOperation"/> instance
        /// </summary>
        /// <param name="client">
        /// The client used to check for completion.
        /// </param>
        /// <param name="id">The ID of this operation.</param>
        public TerminateJobOperation(
            BatchClient client,
            string id)
        {
            if (String.IsNullOrEmpty(id))
                throw new ArgumentNullException("id is not formated correctly");
            string[] idSplit = id.Split(';');
            _jobId = idSplit[0];
            _creationTime = DateTimeOffset.Parse(idSplit[1]);
            Id = id;
            _value = false;
            _rawResponse = null;
            _client = client;
        }

        /// <summary>
        /// Initializes a new <see cref="TerminateJobOperation"/> instance for
        /// mocking.
        /// </summary>
        protected TerminateJobOperation()
        {
        }

        /// <summary>
        /// Get the sucess state of the termination operation
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
        /// Check for the latest status of the terminate operation.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>The <see cref="Response"/> with the status update.</returns>
        public override Response UpdateStatus(CancellationToken cancellationToken = default) =>
            UpdateStatusAsync(false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Check for the latest status of the terminate operation.
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
            Response<BatchJob> response = null;
            try
            {
                response = async
                    ? await _client.GetJobAsync(_jobId, cancellationToken: cancellationToken).ConfigureAwait(false)
                    : _client.GetJob(_jobId, cancellationToken: cancellationToken);
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

            if (response != null)
            {
                _rawResponse = response.GetRawResponse();

                // need to handle the case where we get back the response from a new object.
                if (response.Value.CreationTime > _creationTime)
                {
                    _value = true;
                    _hasCompleted = true;
                }

                if ( response.Value.State != BatchJobState.Terminating)
                {
                   _value = true;
                   _hasCompleted = true;
                }
            }
            return _rawResponse;
        }
    }
}
