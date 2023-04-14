// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Communication.PhoneNumbers
{
    /// <summary>
    /// Describes a phone number operator.  Operators can be carriers, such as Verizon, etc. or they can be
    /// service providers like ACS which provide phone service utilizing underlying infrastructure operated by an external party.
    /// </summary>
    public partial class PhoneNumberOperator
    {
        /// <summary>
        /// Creates a new Operator.
        /// </summary>
        public PhoneNumberOperator() { }

        /// <summary>
        /// Name of the phone operator, e.g. Verizon.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Mobile network code, a unique code associated with a phone number, often tied to a SIM card.
        /// </summary>
        public string MobileNetworkCode { get; set; }
        /// <summary>
        /// Mobile country code, a code that identifies the country of origin for a mobile number, e.g. 310 for US.
        /// </summary>
        public string MobileCountryCode { get; set; }
    }
}
