// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Azure.ResourceManager.EdgeOrder.Models
{
    // Manually add to maintain its backward compatibility
    public partial class EdgeOrderAddressContactDetails
    {
        /// <summary> Initializes a new instance of <see cref="EdgeOrderAddressContactDetails"/>. </summary>
        /// <param name="contactName"> Contact name of the person. </param>
        /// <param name="phone"> Phone number of the contact person. </param>
        /// <param name="emailList"> List of Email-ids to be notified about job progress. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="contactName"/>, <paramref name="phone"/> or <paramref name="emailList"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public EdgeOrderAddressContactDetails(string contactName, string phone, IEnumerable<string> emailList) : this()
        {
            ContactName = contactName;
            Phone = phone;
            EmailList = emailList.ToList();
        }
    }
}
