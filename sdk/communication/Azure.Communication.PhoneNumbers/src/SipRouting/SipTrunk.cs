// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.PhoneNumbers.SipRouting
{
    /// <summary> Gets or sets SIP signaling port of the trunk. </summary>
    [CodeGenClient("Trunk")]
    public partial class SipTrunk
    {
        /// <summary> Initializes a new instance of SipTrunk. </summary>
        /// <param name="name">Name of the trunk</param>
        /// <param name="sipSignalingPort"> Gets or sets SIP signaling port for the gateway. </param>
        public SipTrunk(string name, int? sipSignalingPort)
        {
            Fqdn = name;
            SipSignalingPort = sipSignalingPort;
        }

        private SipTrunk(int? sipSignalingPort)
        {
            SipSignalingPort = sipSignalingPort;
        }

        /// <summary> Gets or sets SIP signaling port of the trunk. </summary>
        public int? SipSignalingPort { get; }

        /// <summary> Name of the trunk. </summary>
        public string Fqdn { get; internal set; }
    }
}
