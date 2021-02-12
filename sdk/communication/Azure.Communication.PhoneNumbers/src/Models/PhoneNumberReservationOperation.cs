﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.PhoneNumbers.Models
{
    /// <summary>
    /// Represents a long-running phone number reservation operation.
    /// </summary>
    public class PhoneNumberReservationOperation : Operation<PhoneNumberReservation>
    {
        private bool _hasCompleted;
        private readonly PhoneNumberAdministrationClient _client;
        private readonly CancellationToken _cancellationToken;
        private PhoneNumberReservation? _value;
        private Response _rawResponse;
        private readonly IReadOnlyList<ReservationStatus> _terminateStatuses;

        /// <summary>
        /// Initializes a new <see cref="PhoneNumberReservationOperation"/> instance
        /// </summary>
        /// <param name="client">The client used to check for completion.</param>
        /// <param name="id">The reservation operation ID.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public PhoneNumberReservationOperation(
            PhoneNumberAdministrationClient client,
            string id,
            CancellationToken cancellationToken = default)
            : this(client, id, null!, cancellationToken)
        {
        }

        /// <summary>
        /// Initializes a new <see cref="PhoneNumberReservationOperation"/> instance
        /// </summary>
        /// <param name="client">The client used to check for completion.</param>
        /// <param name="id">The reservation operation ID.</param>
        /// <param name="initialResponse">The original server response on start operation request.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        internal PhoneNumberReservationOperation(
            PhoneNumberAdministrationClient client,
            string id,
            Response initialResponse,
            CancellationToken cancellationToken = default)
        {
            _terminateStatuses = new[]
            {
                ReservationStatus.Reserved,
                ReservationStatus.Expired,
                ReservationStatus.Cancelled,
                ReservationStatus.Error
            };

            Id = id;
            _value = null;
            _rawResponse = initialResponse;
            _client = client;
            _cancellationToken = cancellationToken;
        }

        /// <inheritdocs />
        public override string Id { get; }

        /// <inheritdocs />
        public override PhoneNumberReservation Value
        {
            get
            {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                if (!HasCompleted)
                {
                    throw new InvalidOperationException("The operation has not completed yet.");
                }
                if (_value?.Status != ReservationStatus.Reserved)
                {
                    throw new RequestFailedException(GetErrorMessage(_value));
                }
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations

                return OperationHelpers.GetValue(ref _value);
            }
        }

        /// <inheritdocs />
        public override bool HasCompleted => _hasCompleted;

        /// <inheritdocs />
        public override bool HasValue => _value?.Status == ReservationStatus.Reserved;

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
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
            => UpdateStatusAsync(false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Check for the latest status of the operation.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>The <see cref="Response"/> with the status update.</returns>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
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
            using DiagnosticScope scope = _client.ClientDiagnostics.CreateScope($"{nameof(PhoneNumberReservationOperation)}.{nameof(UpdateStatus)}");
            scope.Start();

            try
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

                if (!HasCompleted)
                    _rawResponse = update.GetRawResponse();

                if (IsOperationCompleted(update))
                {
                    _value = update.Value;
                    _hasCompleted = true;
                }

                return GetRawResponse();
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private bool IsOperationCompleted(Response<PhoneNumberReservation> response)
        {
            if (response.Value?.Status == null)
                return false;

            return _terminateStatuses.Contains(response.Value.Status.Value);
        }

        /// <inheritdocs />
        public override ValueTask<Response<PhoneNumberReservation>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
            => this.DefaultWaitForCompletionAsync(cancellationToken);

        /// <inheritdocs />
        public override ValueTask<Response<PhoneNumberReservation>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
            => this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

        private static string GetErrorMessage(PhoneNumberReservation? reservation)
        {
            var reservationStatus = reservation?.Status;

            if (reservationStatus == ReservationStatus.Cancelled)
                return "Reservation is cancelled.";
            if (reservationStatus == ReservationStatus.Error)
                return "Reservation has failed.";
            if (reservationStatus == ReservationStatus.Expired)
                return "Reservation is expired.";

            throw new InvalidOperationException($"Unsupported status: {reservationStatus}");
        }
    }
}
