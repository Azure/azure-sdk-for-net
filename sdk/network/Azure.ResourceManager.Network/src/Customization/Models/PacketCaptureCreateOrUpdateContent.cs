// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    public partial class PacketCaptureCreateOrUpdateContent
    {
        // Work around flattened input setters being omitted: https://github.com/Azure/azure-sdk-for-net/issues/64198
        [CodeGenMember("Properties")]
        internal PacketCaptureParameters Properties { get; set; }
    }
}
