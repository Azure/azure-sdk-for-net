// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.PhoneNumbers.Models
{
    /// <summary>
    /// The request to update a reservation.
    /// </summary>
    public class CreateOrUpdateReservationOptions
    {
        /// <summary>
        /// The ID of an existing reservation.
        /// </summary>
        public Guid? Id { get; set; }

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
