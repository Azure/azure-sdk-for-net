// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.EdgeOrder.Models;

namespace Azure.ResourceManager.EdgeOrder
{
    /// Manually add to maintain its backward compatibility
    public partial class EdgeOrderAddressData
    {
        /// <summary> Initializes a new instance of <see cref="EdgeOrderAddressData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="contactDetails"> Contact details for the address. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="contactDetails"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public EdgeOrderAddressData(AzureLocation location, EdgeOrderAddressContactDetails contactDetails) : base(location)
        {
            Argument.AssertNotNull(contactDetails, nameof(contactDetails));

            ContactDetails = contactDetails;
        }
    }
}
