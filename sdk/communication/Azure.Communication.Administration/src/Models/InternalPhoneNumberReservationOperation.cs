// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Administration.Models
{
    internal class InternalPhoneNumberReservationOperation
    {
        private readonly object _lockObject = new object();
        private readonly PhoneNumberAdministrationClient _client;
        private readonly CancellationToken _cancellationToken;
        private bool _hasCompleted;
        private PhoneNumberReservation? _value;
        private Response _rawResponse;
        private Response _finalRawResponse;
        private readonly IReadOnlyList<ReservationStatus> _terminateStatuses = new ReservationStatus[]
        {
            ReservationStatus.Reserved,
            ReservationStatus.Expired,
            ReservationStatus.Cancelled,
            ReservationStatus.Error
        };

        /// <summary>
        /// Initializes a new <see cref="PhoneNumberReservationOperation"/> instance
        /// </summary>
        /// <param name="client">The client used to check for completion.</param>
        /// <param name="id">The reservation operation ID.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        internal InternalPhoneNumberReservationOperation(
            PhoneNumberAdministrationClient client,
            string id,
            CancellationToken cancellationToken = default)
        {
            Id = id;
            _rawResponse = null!;
            _finalRawResponse = null!;
            _client = client;
            _cancellationToken = cancellationToken;
        }

        /// <summary>
        /// Initializes a new <see cref="PhoneNumberReservationOperation"/> instance
        /// </summary>
        /// <param name="client">The client used to check for completion.</param>
        /// <param name="id">The reservation operation ID.</param>
        /// <param name="initialResponse">The original server response on start operation request.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        internal InternalPhoneNumberReservationOperation(
            PhoneNumberAdministrationClient client,
            string id,
            Response initialResponse,
            CancellationToken cancellationToken = default)
        {
            Id = id;
            _value = null;
            _rawResponse = initialResponse;
            _finalRawResponse = null!;
            _client = client;
            _cancellationToken = cancellationToken;
        }

        /// <summary>
        /// Initializes a new <see cref="PhoneNumberReservationOperation"/> instance
        /// </summary>
        /// <param name="client">The client used to check for completion.</param>
        /// <param name="phoneNumberReservationId">The reservation ID of this operation.</param>
        /// <param name="initialResponse">The original server response on start operation request.</param>
        /// <param name="terminateStatuses">The list of <see cref="ReservationStatus"/> that indicate the end of operation.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        internal InternalPhoneNumberReservationOperation(
            PhoneNumberAdministrationClient client,
            string phoneNumberReservationId,
            Response initialResponse,
            IReadOnlyList<ReservationStatus> terminateStatuses,
            CancellationToken cancellationToken = default) :
            this(client, phoneNumberReservationId, initialResponse, cancellationToken)
        {
            _terminateStatuses = terminateStatuses;
        }

        /// <inheritdocs />
        internal string Id { get; }

        /// <inheritdocs />
        internal PhoneNumberReservation Value => OperationHelpers.GetValue(ref _value);

        /// <inheritdocs />
        internal bool HasCompleted => _hasCompleted;

        /// <inheritdocs />
        internal bool HasValue => (_rawResponse != null || _finalRawResponse != null) && _value != null;

        /// <inheritdocs />
        internal Response GetRawResponse() => HasCompleted ? _finalRawResponse : _rawResponse;

        /// <summary>
        /// Check for the latest status of the operation.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>The <see cref="Response"/> with the status update.</returns>
        internal Response UpdateStatus(CancellationToken cancellationToken = default)
            => UpdateStatusAsync(false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Check for the latest status of the operation.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>The <see cref="Response"/> with the status update.</returns>
        internal async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
            => await UpdateStatusAsync(true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Check for the latest status of the operation.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <param name="async" />
        /// <returns>The <see cref="Response"/> with the status update.</returns>
        private async ValueTask<Response> UpdateStatusAsync(bool async, CancellationToken cancellationToken)
        {
            if (HasCompleted)
            {
                return GetRawResponse();
            }

            if (cancellationToken == default)
            {
                cancellationToken = _cancellationToken;
            }

            Response<PhoneNumberReservation> update = async
                ? await _client.GetReservationByIdAsync(reservationId: Id, cancellationToken: cancellationToken).ConfigureAwait(false)
                : _client.GetReservationById(reservationId: Id, cancellationToken: cancellationToken);

            var response = update.GetRawResponse();
            _rawResponse = response;

            if (IsOperationFinished(update))
            {
                lock (_lockObject)
                {
                    _finalRawResponse = response;
                    _value = update.Value;
                    _hasCompleted = true;
                }
            }

            return _rawResponse;
        }

        private bool IsOperationFinished(Response<PhoneNumberReservation> response)
        {
            if (!response.Value.Status.HasValue)
                return false;

            return _terminateStatuses.Contains(response.Value.Status.Value);
        }
    }
}
