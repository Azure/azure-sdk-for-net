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

        /// <summary> The id of the reservation. </summary>
        public Guid Id { get; set; }
    }
}
