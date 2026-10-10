// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the NetworkSecurityPerimeterLinkReferenceData type. </summary>
    public partial class NetworkSecurityPerimeterLinkReferenceData
    {
        /// <summary> Gets or sets the Status compatibility property. </summary>
        public System.Nullable<Azure.ResourceManager.Network.Models.NetworkSecurityPerimeterLinkStatus> Status
        {
            get => Properties is null ? default : Properties.Status;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }
}
