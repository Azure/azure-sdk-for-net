// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.AppService;

public partial class SiteNetworkConfig
{
    private partial BicepValue<string> GetNameDefaultValue() =>
        "virtualNetwork";
}
