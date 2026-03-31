// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.NetworkCloud
{
    public partial class NetworkCloudClusterManagerData
    {
        /// <summary> The extended location (custom location) that represents the cluster manager's control plane location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Models.ExtendedLocation ManagerExtendedLocation
        {
            get
            {
                var baseLoc = Properties?.ManagerExtendedLocation;
                if (baseLoc == null) return null;
                return new Models.ExtendedLocation(baseLoc.Name, baseLoc.ExtendedLocationType?.ToString());
            }
        }
    }
}
