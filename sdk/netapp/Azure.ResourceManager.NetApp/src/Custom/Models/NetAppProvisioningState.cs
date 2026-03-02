// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

namespace Azure.ResourceManager.NetApp.Models
{
    public enum NetAppProvisioningState
    {
        Accepted = 0,
        Creating = 1,
        Patching = 2,
        Deleting = 3,
        Moving = 4,
        Failed = 5,
        Succeeded = 6,
        Canceled = 7,
        Provisioning = 8,
        Updating = 9,
    }
}
