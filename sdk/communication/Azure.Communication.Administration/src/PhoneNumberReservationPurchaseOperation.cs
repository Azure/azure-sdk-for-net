// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Administration.Models;

namespace Azure.Communication.Administration
{
    /// <summary>
    /// Represents a long-running phone number reservation purchase operation.
    /// </summary>
    public class PhoneNumberReservationPurchaseOperation : Operation<PhoneNumberReservation>
    {
        private PhoneNumberReservationOperation _reservationOperation;

        /// <summary>
        /// Initializes a new <see cref="PhoneNumberReservationPurchaseOperation"/> instance.
        /// </summary>
        /// <param name="client">The client used to check for completion.</param>
        /// <param name="id">The reservation operation ID.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public PhoneNumberReservationPurchaseOperation(
            PhoneNumberAdministrationClient client,
            string id,
            CancellationToken cancellationToken = default)
            : this(client, id, null!, cancellationToken)
        {
        }

        /// <summary>
        /// Initializes a new <see cref="PhoneNumberReservationPurchaseOperation"/> instance
        /// </summary>
        /// <param name="client">The client used to check for completion.</param>
        /// <param name="id">The reservation operation ID.</param>
        /// <param name="initialResponse">The original server response on start operation request.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        internal PhoneNumberReservationPurchaseOperation(
            PhoneNumberAdministrationClient client,
            string id,
            Response initialResponse,
            CancellationToken cancellationToken = default)
        {
            var terminateStatuses = new ReservationStatus []
            {
                ReservationStatus.Success,
                ReservationStatus.Expired,
                ReservationStatus.Cancelled,
                ReservationStatus.Error
            };
            _reservationOperation = new PhoneNumberReservationOperation(client, id, initialResponse, terminateStatuses, cancellationToken);
        }

        /// <inheritdocs />
        public override string Id => _reservationOperation.Id;

        /// <inheritdocs />
        public override PhoneNumberReservation Value => _reservationOperation.Value;

        /// <inheritdocs />
        public override bool HasCompleted => _reservationOperation.HasCompleted;

        /// <inheritdocs />
        public override bool HasValue => _reservationOperation.HasValue;

        /// <inheritdocs />
        public override Response GetRawResponse() => _reservationOperation.GetRawResponse();

        /// <inheritdocs />
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
            => _reservationOperation.UpdateStatus(cancellationToken);

        /// <inheritdocs />
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
            => _reservationOperation.UpdateStatusAsync(cancellationToken);

        /// <inheritdocs />
        public override ValueTask<Response<PhoneNumberReservation>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
            => _reservationOperation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdocs />
        public override ValueTask<Response<PhoneNumberReservation>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
            => _reservationOperation.WaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}
