// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.EventGrid.Models
{
    public partial class EventGridInboundIPRule
    {
        /// <summary> IP Address in CIDR notation e.g., 10.0.0.0/8. </summary>
        [WirePath("ipMask")]
        public string IPMask
        {
            get => IpMask;
            set => IpMask = value;
        }
    }
}
