// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Provisioning.Network;

internal partial class IPConfigurationPropertiesFormat
{
    // The enclosing IP configuration has only output usages, but 1.1.0 allowed these
    // assignments. Use the registered fields so replacements keep their Bicep binding.
    internal void SetSubnet(SubnetResource value)
    {
        Initialize();
        AssignOrReplace(ref _subnet, value);
    }

    internal void SetPublicIPAddress(PublicIPAddress value)
    {
        Initialize();
        AssignOrReplace(ref _publicIPAddress, value);
    }
}
