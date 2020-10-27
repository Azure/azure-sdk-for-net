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
    /// <summary>
    /// Represents a long-running phone number reservation operation.
    /// </summary>
    public class PhoneNumberReservationOperation : Operation<PhoneNumberReservation>
    {
        private InternalPhoneNumberReservationOperation _reservationOperation;

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
            var terminateStatuses = new ReservationStatus[]
            {
                ReservationStatus.Reserved,
                ReservationStatus.Expired,
                ReservationStatus.Cancelled,
                ReservationStatus.Error
            };
            _reservationOperation = new InternalPhoneNumberReservationOperation(client, id, initialResponse, terminateStatuses, cancellationToken);
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

        /// <summary>
        /// Check for the latest status of the operation.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>The <see cref="Response"/> with the status update.</returns>
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
            => _reservationOperation.UpdateStatus(cancellationToken);

        /// <summary>
        /// Check for the latest status of the operation.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>The <see cref="Response"/> with the status update.</returns>
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
            => _reservationOperation.UpdateStatusAsync(cancellationToken);


        /// <inheritdocs />
        public override ValueTask<Response<PhoneNumberReservation>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
            => this.DefaultWaitForCompletionAsync(cancellationToken);

        /// <inheritdocs />
        public override ValueTask<Response<PhoneNumberReservation>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
            => this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}
