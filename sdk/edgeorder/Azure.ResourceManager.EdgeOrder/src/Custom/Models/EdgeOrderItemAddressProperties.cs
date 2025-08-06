// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.EdgeOrder.Models
{
    public partial class EdgeOrderItemAddressProperties
    {
        /// <summary> Initializes a new instance of <see cref="EdgeOrderItemAddressProperties"/>. </summary>
        /// <param name="contactDetails"> Contact details for the address. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="contactDetails"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public EdgeOrderItemAddressProperties(EdgeOrderAddressContactDetails contactDetails)
        {
            Argument.AssertNotNull(contactDetails, nameof(contactDetails));

            ContactDetails = contactDetails;
        }
    }
}
