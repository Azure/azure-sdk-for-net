// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the PeerExpressRouteCircuitConnectionData type. </summary>
    public partial class PeerExpressRouteCircuitConnectionData
    {
        /// <summary> Gets or sets the AddressPrefix compatibility property. </summary>
        public System.String AddressPrefix
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        /// <summary> Gets or sets the AuthResourceGuid compatibility property. </summary>
        public System.Nullable<System.Guid> AuthResourceGuid
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        /// <summary> Gets or sets the ConnectionName compatibility property. </summary>
        public System.String ConnectionName
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        /// <summary> Gets or sets the ExpressRouteCircuitPeeringId compatibility property. </summary>
        public Azure.Core.ResourceIdentifier ExpressRouteCircuitPeeringId
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        /// <summary> Gets or sets the PeerExpressRouteCircuitPeeringId compatibility property. </summary>
        public Azure.Core.ResourceIdentifier PeerExpressRouteCircuitPeeringId
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }
}
