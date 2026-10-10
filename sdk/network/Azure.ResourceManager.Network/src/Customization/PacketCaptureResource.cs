// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the PacketCaptureResource type. </summary>
    public partial class PacketCaptureResource
    {
        internal PacketCaptureResource(ArmClient client, string id) : this(client, new ResourceIdentifier(id))
        {
        }
    }
}
