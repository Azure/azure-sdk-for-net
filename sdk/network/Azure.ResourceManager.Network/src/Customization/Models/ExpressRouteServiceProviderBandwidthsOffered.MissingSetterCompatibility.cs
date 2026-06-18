// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ExpressRouteServiceProviderBandwidthsOffered type. </summary>
    public partial class ExpressRouteServiceProviderBandwidthsOffered
    {
        /// <summary> Gets or sets the OfferName compatibility property. </summary>
        public System.String OfferName
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        /// <summary> Gets or sets the ValueInMbps compatibility property. </summary>
        public System.Nullable<System.Int32> ValueInMbps
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }
}
