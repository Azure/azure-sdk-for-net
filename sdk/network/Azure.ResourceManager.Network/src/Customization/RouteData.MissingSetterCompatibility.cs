// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the RouteData type. </summary>
    public partial class RouteData
    {
        /// <summary> Gets or sets the HasBgpOverride compatibility property. </summary>
        public System.Nullable<System.Boolean> HasBgpOverride
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }
}
