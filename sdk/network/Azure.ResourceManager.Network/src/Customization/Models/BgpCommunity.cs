// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the BgpCommunity type. </summary>
    public partial class BgpCommunity
    {
        /// <summary> Gets or sets the CommunityName compatibility property. </summary>
        public string CommunityName { get; set; }

        /// <summary> Gets or sets the CommunityValue compatibility property. </summary>
        public string CommunityValue { get; set; }

        /// <summary> Gets or sets the IsAuthorizedToUse compatibility property. </summary>
        public bool? IsAuthorizedToUse { get; set; }

        /// <summary> Gets or sets the ServiceGroup compatibility property. </summary>
        public string ServiceGroup { get; set; }

        /// <summary> Gets or sets the ServiceSupportedRegion compatibility property. </summary>
        public string ServiceSupportedRegion { get; set; }
    }
}
