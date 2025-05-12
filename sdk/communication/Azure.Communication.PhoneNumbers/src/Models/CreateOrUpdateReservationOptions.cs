// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.PhoneNumbers
{
    /// <summary>
    /// The request to create or update a reservation.
    /// </summary>
    public class CreateOrUpdateReservationOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateOrUpdateReservationOptions"/> class.
        /// </summary>
        /// <param name="reservationId"></param>
        public CreateOrUpdateReservationOptions(Guid reservationId)
        {
            ReservationId = reservationId;
        }

        /// <summary>
        /// The ID of the reservation. If a reservation with the given ID does not exist, a new reservation will be created.
        /// </summary>
        public Guid ReservationId { get; }

        /// <summary>
        /// The list of phone numbers to add to the reservation.
        /// </summary>
        public IEnumerable<AvailablePhoneNumber> PhoneNumbersToAdd { get; set; }

        /// <summary>
        /// The list of phone number IDs to remove from the reservation.
        /// </summary>
        public IEnumerable<string> PhoneNumbersToRemove { get; set; }
    }
}
