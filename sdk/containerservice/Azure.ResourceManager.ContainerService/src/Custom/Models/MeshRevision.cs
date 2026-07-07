// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService.Models
{
    public partial class MeshRevision
    {
        /// <summary> Initializes a new instance of <see cref="MeshRevision"/>. </summary>
        public MeshRevision()
        {
            Upgrades = new ChangeTrackingList<string>();
            CompatibleWith = new ChangeTrackingList<CompatibleVersions>();
        }

        /// <summary> The revision of the mesh release. </summary>
        [WirePath("revision")]
        public string Revision { get; set; }
    }
}
