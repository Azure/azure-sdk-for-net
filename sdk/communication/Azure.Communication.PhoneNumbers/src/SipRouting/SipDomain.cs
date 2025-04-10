// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.PhoneNumbers.SipRouting
{
    /// <summary> SIP domain related properties. </summary>
    [CodeGenClient("Domain")]
    public partial class SipDomain
    {
        /// <summary> Initializes a new instance of SipDomain. </summary>
        /// <param name="fqdn">Name of the trunk.</param>
        /// <param name="enabled"> Enabled flag. </param>
        public SipDomain(string fqdn, bool enabled)
        {
            Fqdn = fqdn;
            Enabled = enabled;
        }

        /// <summary> Name of the trunk. </summary>
        public string Fqdn { get; internal set; }
    }
}
