// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.SipRouting
{
    [CodeGenClient("Trunk")]
    public partial class SipTrunk : IUtf8JsonSerializable
    {
        /// <summary> Initializes a new instance of SipTrunk. </summary>
        /// <param name="sipSignalingPort"> Gets or sets SIP signaling port for the gateway. </param>
        public SipTrunk(int? sipSignalingPort)
        {
            SipSignalingPort = sipSignalingPort;
        }

        /// <summary> Gets or sets SIP signaling port of the trunk. </summary>
        public int? SipSignalingPort { get; }
    }
}
