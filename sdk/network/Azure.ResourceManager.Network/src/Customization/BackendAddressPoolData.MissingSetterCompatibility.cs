// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the BackendAddressPoolData type. </summary>
    public partial class BackendAddressPoolData
    {
        /// <summary> Gets or sets the Location compatibility property. </summary>
        public System.Nullable<Azure.Core.AzureLocation> Location
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }
}
