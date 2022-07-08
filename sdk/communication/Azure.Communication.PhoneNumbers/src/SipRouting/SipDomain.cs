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
        /// <param name="domain"></param>
        /// <param name="domainType"></param>
        public SipDomain(string domain, string domainType)
        {
            DomainUri = domain;
            Type = domainType;
        }

        /// <summary>
        /// Initializes a new instance of SipDomain.
        /// </summary>
        /// <param name="domainType"></param>
        public SipDomain(DomainType domainType)
        {
            Type = domainType;
        }

        /// <summary>
        /// Type of Domain
        /// </summary>
#pragma warning disable CA1056 // URI-like properties should not be strings
        public string DomainUri { get; set; }
#pragma warning restore CA1056 // URI-like properties should not be strings
    }
}
