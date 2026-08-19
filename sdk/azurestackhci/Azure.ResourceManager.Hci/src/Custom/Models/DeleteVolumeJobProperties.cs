// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci.Models
{
    public partial class DeleteVolumeJobProperties
    {
        /// <summary> Indicates whether deletion is confirmed. </summary>
        [CodeGenMember("ConfirmDeletion")]
        public bool? IsConfirmDeletion { get; set; }
    }
}
