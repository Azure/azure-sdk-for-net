// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Administration.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Administration
{
    /// <summary>
    /// Represent a long-running phone number search operation.
    /// </summary>
    public class PhoneNumberSearchOperation : Operation<PhoneNumberSearch>
    {
        private readonly PhoneNumberAdministrationClient _client;
        private readonly CancellationToken _cancellationToken;
        private bool _hasCompleted;
        private PhoneNumberSearch? _value;
        private Response _rawResponse;
        private readonly IReadOnlyList<SearchStatus> _terminateStatuses = new SearchStatus []
        {
            SearchStatus.Reserved,
            SearchStatus.Expired,
            SearchStatus.Success,
            SearchStatus.Cancelled,
            SearchStatus.Error
        };

        /// <summary>
        /// Initializes a new <see cref="PhoneNumberSearchOperation"/> instance
        /// </summary>
        /// <param name="client">The client used to check for completion.</param>
        /// <param name="phoneNumberSearchId">The search ID of this operation.</param>
        /// <param name="initialResponse">The original server response on start operation request.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        internal PhoneNumberSearchOperation(
            PhoneNumberAdministrationClient client,
            string phoneNumberSearchId,
            Response initialResponse,
            CancellationToken cancellationToken = default)
        {
            Id = phoneNumberSearchId;
            _value = null;
            _rawResponse = initialResponse;
            _client = client;
            _cancellationToken = cancellationToken;
        }

        /// <summary>
        /// Initializes a new <see cref="PhoneNumberSearchOperation"/> instance
        /// </summary>
        /// <param name="client">The client used to check for completion.</param>
        /// <param name="phoneNumberSearchId">The search ID of this operation.</param>
        /// <param name="initialResponse">The original server response on start operation request.</param>
        /// <param name="terminateStatuses">The list of <see cref="SearchStatus"/> that indicate the end of operation.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        internal PhoneNumberSearchOperation(
            PhoneNumberAdministrationClient client,
            string phoneNumberSearchId,
            Response initialResponse,
            IReadOnlyList<SearchStatus> terminateStatuses,
            CancellationToken cancellationToken = default) :
            this(client, phoneNumberSearchId, initialResponse, cancellationToken)
        {
            _terminateStatuses = terminateStatuses;
        }

        /// <inheritdocs />
        public override string Id { get; }

        /// <inheritdocs />
        public override PhoneNumberSearch Value => OperationHelpers.GetValue(ref _value);

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

            Response<PhoneNumberSearch> update = async
                ? await _client.GetSearchByIdAsync(searchId: Id, cancellationToken: cancellationToken).ConfigureAwait(false)
                : _client.GetSearchById(searchId: Id, cancellationToken: cancellationToken);

            _value = update.Value;

            if (IsOperationFinished(update))
            {
                _hasCompleted = true;
            }

            _rawResponse = update.GetRawResponse();
            return _rawResponse;
        }

        private bool IsOperationFinished(Response<PhoneNumberSearch> response)
        {
            if (!response.Value.Status.HasValue)
                return false;

            return _terminateStatuses.Contains(response.Value.Status.Value);
        }

        /// <inheritdocs />
        public override ValueTask<Response<PhoneNumberSearch>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(cancellationToken);

        /// <inheritdocs />
        public override ValueTask<Response<PhoneNumberSearch>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}
