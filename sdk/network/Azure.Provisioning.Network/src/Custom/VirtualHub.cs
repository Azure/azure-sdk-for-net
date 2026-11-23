// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Network;

public partial class VirtualHub
{
    /// <summary> Gets or sets the routes. </summary>
    [CodeGenMember("RouteRoutes")]
    public BicepList<VirtualHubRoute> Routes
    {
        get => Properties is null ? default : Properties.RouteRoutes;
        set
        {
            if (Properties is null)
            {
                Properties = new VirtualHubProperties();
            }
            Properties.RouteRoutes = value;
        }
    }
}
