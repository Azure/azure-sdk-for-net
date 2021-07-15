// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.SipRouting.Models
{
    public partial class TrunkPatch
    {
        /// <summary> Initializes a new instance of TrunkConfig. </summary>
        /// <param name="sipSignalingPort"> Gets or sets SIP signaling port for the gateway. </param>
        public TrunkPatch(int sipSignalingPort)
            : this()
        {
            SipSignalingPort = sipSignalingPort;
        }
    }
}
