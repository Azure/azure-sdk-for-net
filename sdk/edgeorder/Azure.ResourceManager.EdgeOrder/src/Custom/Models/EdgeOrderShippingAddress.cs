// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.EdgeOrder.Models
{
    // Manually add to maintain its backward compatibility
    public partial class EdgeOrderShippingAddress
    {
        /// <summary> Initializes a new instance of <see cref="EdgeOrderShippingAddress"/>. </summary>
        /// <param name="streetAddress1"> Street Address line 1. </param>
        /// <param name="country"> Name of the Country. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="streetAddress1"/> or <paramref name="country"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public EdgeOrderShippingAddress(string streetAddress1, string country) : this(country)
        {
            StreetAddress1 = streetAddress1;
        }
    }
}
