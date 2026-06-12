// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

namespace Azure.ResourceManager.Network.Models
{
    public partial class BgpCommunity
    {
        public string CommunityName { get; set; }

        public string CommunityValue { get; set; }

        public bool? IsAuthorizedToUse { get; set; }

        public string ServiceGroup { get; set; }

        public string ServiceSupportedRegion { get; set; }
    }
}
