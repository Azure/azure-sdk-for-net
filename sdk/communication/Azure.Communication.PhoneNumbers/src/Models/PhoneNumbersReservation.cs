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
        /// <param name="id"></param>
        /// <param name="phoneNumbers"></param>
        public PhoneNumbersReservation(Guid id, IDictionary<string, AvailablePhoneNumber> phoneNumbers)
        {
            Id = id;
            PhoneNumbers = new ChangeTrackingDictionary<string, AvailablePhoneNumber>(phoneNumbers ?? new Dictionary<string, AvailablePhoneNumber>());
        }

        /// <summary>
        /// Initializes a new instance of <see cref="PhoneNumbersReservation"/>.
        /// </summary>
        /// <remarks>
        /// The PhoneNumbers dictionary will be initialized to an empty dictionary.
        /// </remarks>
        internal PhoneNumbersReservation()
        {
            // Initializing it to an empty dictionary ensures that the dictionary is never null when serializing to JSON.
            PhoneNumbers = new ChangeTrackingDictionary<string, AvailablePhoneNumber>((IDictionary<string, AvailablePhoneNumber>)new Dictionary<string, AvailablePhoneNumber>());;
        }

        /// <summary> The id of the reservation. </summary>
        [CodeGenMember("Id")]
        public Guid Id { get; }
    }
}
