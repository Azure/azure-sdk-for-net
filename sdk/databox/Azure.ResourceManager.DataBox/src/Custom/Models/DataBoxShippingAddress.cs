// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.DataBox.Models
{
    /// <summary> Shipping address where customer wishes to receive the device. </summary>
    public partial class DataBoxShippingAddress
    {
        /// <summary> Initializes a new instance of <see cref="DataBoxShippingAddress"/>. </summary>
        /// <param name="streetAddress1"> Street Address line 1. </param>
        /// <param name="country"> Name of the Country. </param>
        /// <param name="postalCode"> Postal code. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="streetAddress1"/>, <paramref name="country"/> or <paramref name="postalCode"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DataBoxShippingAddress(string streetAddress1, string country, string postalCode)
        {
            Argument.AssertNotNull(streetAddress1, nameof(streetAddress1));
            Argument.AssertNotNull(country, nameof(country));
            Argument.AssertNotNull(postalCode, nameof(postalCode));

            StreetAddress1 = streetAddress1;
            Country = country;
            PostalCode = postalCode;
        }
    }
}
