// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Administration.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Administration
{
    /// <summary>
    /// Represents a long-running release phone number operation.
    /// </summary>
    public class ReleasePhoneNumberOperation : Operation<PhoneNumberRelease>
    {
        private readonly PhoneNumberAdministrationClient _client;
        private readonly CancellationToken _cancellationToken;
        private bool _hasCompleted;
        private PhoneNumberRelease? _value;
        private Response _rawResponse;

        /// <summary>
        /// Initializes a new <see cref="ReleasePhoneNumberOperation"/> instance
        /// </summary>
        /// <param name="client">The client used to check for completion.</param>
        /// <param name="releaseResponseId">The phone number release ID of this operation.</param>
        /// <param name="initialResponse">The original server response on start operation request.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        internal ReleasePhoneNumberOperation(
            PhoneNumberAdministrationClient client,
            string releaseResponseId,
            Response initialResponse,
            CancellationToken cancellationToken = default)
        {
            Id = releaseResponseId;
            _value = null;
            _rawResponse = initialResponse;
            _client = client;
            _cancellationToken = cancellationToken;
        }

        /// <inheritdocs />
        public override string Id { get; }

        /// <inheritdocs />
        public override PhoneNumberRelease Value => OperationHelpers.GetValue(ref _value);

        /// <inheritdocs />
        public override bool HasCompleted => _hasCompleted;

        /// <inheritdocs />
        public override bool HasValue => _value != null;

        /// <inheritdocs />
        public override Response GetRawResponse() => _rawResponse;

        /// <summary>
        /// Check for the latest status of the operation.
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
        /// Check for the latest status of the operation.
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
        /// Check for the latest status of the operation.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <param name="async" />
        /// <returns>The <see cref="Response"/> with the status update.</returns>
        private async Task<Response> UpdateStatusAsync(bool async, CancellationToken cancellationToken)
        {
            if (HasCompleted)
            {
                return GetRawResponse();
            }

            if (cancellationToken == default)
            {
                cancellationToken = _cancellationToken;
            }

            Response<PhoneNumberRelease> update = async
                ? await _client.GetReleaseByIdAsync(releaseId: Id, cancellationToken: cancellationToken).ConfigureAwait(false)
                : _client.GetReleaseById(releaseId: Id, cancellationToken: cancellationToken);

            _value = update.Value;

            var terminateStatuses = new ReleaseStatus[]
            {
                ReleaseStatus.Complete,
                ReleaseStatus.Failed,
                ReleaseStatus.Expired
            };

            if (update.Value.Status.HasValue)
            {
                if (terminateStatuses.Contains(update.Value.Status.Value))
                {
                    _hasCompleted = true;
                }
            }

            Response response = update.GetRawResponse();
            _rawResponse = response;
            return response;
        }

        /// <inheritdocs />
        public override ValueTask<Response<PhoneNumberRelease>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(cancellationToken);

        /// <inheritdocs />
        public override ValueTask<Response<PhoneNumberRelease>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}
