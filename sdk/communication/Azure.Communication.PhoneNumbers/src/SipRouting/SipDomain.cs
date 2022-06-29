// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Communication.PhoneNumbers.SipRouting
{
    /// <summary> SIP domain related properties. </summary>
    [CodeGenClient("Domain")]
    public partial class SipDomain
    {
        /// <summary>
        /// Initializes a new instance of SipDomain.
        /// </summary>
        /// <param name="domainType"></param>
        public SipDomain(string domainType)
        {
            DomainType = domainType;
        }

        /// <summary>
        /// Type of Domain
        /// </summary>
        public string DomainType { get; set; }
    }
}
