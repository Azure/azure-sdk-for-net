// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.Communication.Email
{
    [CodeGenModel("EmailAddress")]
    public partial struct EmailAddress
    {
        /// <summary> Initializes a new instance of EmailAddress. </summary>
        /// <param name="address"> Email address of the receipient</param>
        /// <param name="displayName">The display name of the recepient</param>
        /// <exception cref="ArgumentNullException"> <paramref name="address"/> is null. </exception>
        public EmailAddress(string address, string displayName)
            : this(address)
        {
            DisplayName = displayName;
        }

        /// <summary> Initializes a new instance of EmailAddress. </summary>
        /// <param name="address"> Email address of the receipient</param>
        /// <exception cref="ArgumentNullException"> <paramref name="address"/> is null. </exception>
        public EmailAddress(string address)
        {
            Argument.AssertNotNullOrWhiteSpace(address, nameof(address));
            Address = address;
            DisplayName = string.Empty;
        }
    }
}
