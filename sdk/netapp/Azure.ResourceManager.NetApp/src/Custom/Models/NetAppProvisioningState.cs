// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

namespace Azure.ResourceManager.NetApp.Models
{
    public readonly partial struct NetAppProvisioningState
    {
        public static NetAppProvisioningState Canceled { get; } = new NetAppProvisioningState("Canceled");
        public static NetAppProvisioningState Provisioning { get; } = new NetAppProvisioningState("Provisioning");
    }
}
