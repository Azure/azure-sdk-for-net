// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci.Models
{
    public readonly partial struct DiskType
    {
        /// <summary> HDD. </summary>
        [CodeGenMember("HDD")]
        public static DiskType Hdd { get; } = new DiskType("HDD");

        /// <summary> SSD. </summary>
        [CodeGenMember("SSD")]
        public static DiskType Ssd { get; } = new DiskType("SSD");
    }
}
