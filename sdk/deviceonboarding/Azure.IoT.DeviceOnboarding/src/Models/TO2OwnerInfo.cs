// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// Class used to store TO1dPayload and its signature for TO2.ProveOVHdr
    /// </summary>
    public class TO2OwnerInfo
    {
        /// <summary>
        /// Gets or Sets the TO1dPayload received at the end of TO1
        /// </summary>
        public TO1dPayload To1dPayload { get; set; }

        /// <summary>
        /// Gets or Sets the TO1d Cose_Sign1 Message received at the end of TO1
        /// </summary>
        public byte[] TO1dCoseSign1MessageEncoded { get; set; }
    }
}
