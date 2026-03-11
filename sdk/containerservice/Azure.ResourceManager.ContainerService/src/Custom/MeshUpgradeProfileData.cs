// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.ContainerService.Models;
using Azure.ResourceManager.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService
{
    public partial class MeshUpgradeProfileData : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="MeshUpgradeProfileData"/>. </summary>
        public MeshUpgradeProfileData()
        {
        }

        /// <summary> Mesh upgrade profile properties for a major.minor release. </summary>
        [WirePath("properties")]
        public MeshUpgradeProfileProperties Properties { get; set; }        // Make the Properties settable for backwward compatibility.
    }
}
