// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.EdgeOrder.Models
{
    public partial class EdgeOrderShippingAddress
    {
        /// <summary> Initializes a new instance of <see cref="EdgeOrderShippingAddress"/>. </summary>
        /// <param name="streetAddress1"> Street Address line 1. </param>
        /// <param name="country"> Name of the Country. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="streetAddress1"/> or <paramref name="country"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public EdgeOrderShippingAddress(string streetAddress1, string country)
        {
            Argument.AssertNotNull(streetAddress1, nameof(streetAddress1));
            Argument.AssertNotNull(country, nameof(country));

            StreetAddress1 = streetAddress1;
            Country = country;
        }
    }
}
