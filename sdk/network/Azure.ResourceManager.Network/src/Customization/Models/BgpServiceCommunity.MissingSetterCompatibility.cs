// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the BgpServiceCommunity type. </summary>
    public partial class BgpServiceCommunity
    {
        /// <summary> Gets or sets the ServiceName compatibility property. </summary>
        public System.String ServiceName
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }
}
