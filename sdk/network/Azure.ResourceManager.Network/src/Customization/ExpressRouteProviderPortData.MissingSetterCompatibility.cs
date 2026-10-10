// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ExpressRouteProviderPortData type. </summary>
    public partial class ExpressRouteProviderPortData
    {
        /// <summary> Gets or sets the OverprovisionFactor compatibility property. </summary>
        public System.Nullable<System.Int32> OverprovisionFactor { get; set; }

        /// <summary> Gets or sets the PeeringLocation compatibility property. </summary>
        public System.String PeeringLocation { get; set; }

        /// <summary> Gets or sets the PortBandwidthInMbps compatibility property. </summary>
        public System.Nullable<System.Int32> PortBandwidthInMbps { get; set; }

        /// <summary> Gets or sets the RemainingBandwidthInMbps compatibility property. </summary>
        public System.Nullable<System.Int32> RemainingBandwidthInMbps { get; set; }

        /// <summary> Gets or sets the UsedBandwidthInMbps compatibility property. </summary>
        public System.Nullable<System.Int32> UsedBandwidthInMbps { get; set; }
    }
}
