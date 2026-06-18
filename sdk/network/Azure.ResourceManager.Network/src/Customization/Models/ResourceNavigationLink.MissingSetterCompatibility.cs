// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ResourceNavigationLink type. </summary>
    public partial class ResourceNavigationLink
    {
        /// <summary> Gets or sets the Link compatibility property. </summary>
        public Azure.Core.ResourceIdentifier Link
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        /// <summary> Gets or sets the LinkedResourceType compatibility property. </summary>
        public System.Nullable<Azure.Core.ResourceType> LinkedResourceType
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }
}
