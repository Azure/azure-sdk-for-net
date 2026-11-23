// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.Network.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    public partial class VirtualHubData
    {
        /// <summary> List of all routes. </summary>
        [CodeGenMember("RouteRoutes")]
        [WirePath("properties.routeTable.routes")]
        public IList<VirtualHubRoute> Routes
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new VirtualHubProperties();
                }
                return Properties.RouteRoutes;
            }
        }
    }
}
