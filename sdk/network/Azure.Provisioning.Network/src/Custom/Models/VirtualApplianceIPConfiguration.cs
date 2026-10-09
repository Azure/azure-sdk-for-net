// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Network;

public partial class VirtualApplianceIPConfiguration
{
    // Match management's IsPrimary name: safe flatten does not recognize BicepValue<bool> as Boolean.
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/60921.
    /// <summary> Whether or not this is primary IP configuration of the NIC. </summary>
    [CodeGenMember("VirtualApplianceIPIsPrimary")]
    public BicepValue<bool> IsPrimary
    {
        get => Properties is null ? default : Properties.IsPrimary;
        set
        {
            if (Properties is null)
            {
                Properties = new VirtualApplianceIPConfigurationProperties();
            }
            Properties.IsPrimary = value;
        }
    }
}
