// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat wrapper for the GA IsRestoring setter. Other VolumeProperties
// members are flattened by TypeSpec.

#nullable disable

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppVolumeGroupVolume
    {
        /// <summary> Restoring. </summary>
        public bool? IsRestoring
        {
            get => Properties is null ? default : Properties.IsRestoring;
            set { /* setter kept for backward compat; value is read-only from service */ }
        }
    }
}
