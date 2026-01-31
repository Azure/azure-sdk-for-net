// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.EdgeOrder.Models
{
    // Manually add to maintain its backward compatibility
    public partial class EdgeOrderItemAddressProperties
    {
        /// <summary> Initializes a new instance of <see cref="EdgeOrderItemAddressProperties"/>. </summary>
        /// <param name="contactDetails"> Contact details for the address. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="contactDetails"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public EdgeOrderItemAddressProperties(EdgeOrderAddressContactDetails contactDetails) : this()
        {
            ContactDetails = contactDetails;
        }
    }
}
