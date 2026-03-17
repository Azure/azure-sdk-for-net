// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.NetworkCloud
{
    // CodeGenSuppress for ManagerExtendedLocation: old API returned NetworkCloud.Models.ExtendedLocation;
    // regenerated code returns Resources.Models.ExtendedLocation. This preserves the old return type.
    [CodeGenSuppress("ManagerExtendedLocation")]
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
                if (baseLoc is Models.ExtendedLocation ncLoc) return ncLoc;
                return new Models.ExtendedLocation(baseLoc.Name, baseLoc.ExtendedLocationType?.ToString());
            }
        }
    }
}
