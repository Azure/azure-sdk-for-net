// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ComputeFleet.Models
{
    /// <summary> Fleet Update Model. </summary>
    public partial class ComputeFleetPatch
    {
        /// <summary> Updatable managed service identity. </summary>
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get; set; }
    }
}
