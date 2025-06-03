// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Communication.PhoneNumbers
{
    [CodeGenModel("PhoneNumbersReservation")]
    public partial class PhoneNumbersReservation
    {
        /// <summary>
        /// Initializes a new instance of <see cref="PhoneNumbersReservation"/>.
        /// </summary>
        /// <remarks>
        /// The PhoneNumbers dictionary will be initialized to an empty dictionary.
        /// </remarks>
        internal PhoneNumbersReservation()
        {
            // This needs to be initialized to an empty dictionary to ensure that the dictionary is never null when serializing to JSON.
            IDictionary<string, AvailablePhoneNumber> dict = new Dictionary<string, AvailablePhoneNumber>();
            PhoneNumbers = new ChangeTrackingDictionary<string, AvailablePhoneNumber>(dict);
        }

        // Removing nullability for these parameters.
        // They are originally nullable because they are not required in service requests.
        // However, they are never null when returned by the service.

        /// <summary> The id of the reservation. </summary>
        public Guid Id { get; }
        /// <summary> The time at which the reservation will expire. If a reservation is not purchased before this time, all of the reserved phone numbers will be released and made available for others to purchase. </summary>
        public DateTimeOffset ExpiresAt { get; }
        /// <summary> Represents the status of the reservation. Possible values include: 'active', 'submitted', 'completed', 'expired'. </summary>
        public ReservationStatus Status { get; }
    }
}
