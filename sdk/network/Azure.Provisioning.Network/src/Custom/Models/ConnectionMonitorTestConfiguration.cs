// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Network;

public partial class ConnectionMonitorTestConfiguration
{
    // Match management's DisableTraceRoute name: safe flatten does not recognize BicepValue<bool> as Boolean.
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/60921.
    /// <summary> Whether path evaluation with trace route should be disabled. </summary>
    [CodeGenMember("IcmpDisableTraceRoute")]
    public BicepValue<bool> DisableTraceRoute
    {
        get => IcmpConfiguration is null ? default : IcmpConfiguration.DisableTraceRoute;
        set
        {
            if (IcmpConfiguration is null)
            {
                IcmpConfiguration = new ConnectionMonitorIcmpConfiguration();
            }
            IcmpConfiguration.DisableTraceRoute = value;
        }
    }
}
