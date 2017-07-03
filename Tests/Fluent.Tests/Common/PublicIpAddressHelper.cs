// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.Network.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Tests.Common
{
    public static class PublicIPAddressHelper
    {
        public static void PrintPIP(IPublicIPAddress resource)
        {
            var info = new StringBuilder().Append("Public IP Address: ").Append(resource.Id)
                    .Append("\n\tName: ").Append(resource.Name)
                    .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(resource.Region)
                    .Append("\n\tTags: ").Append(resource.Tags)
                    .Append("\n\tIP Address: ").Append(resource.IPAddress)
                    .Append("\n\tLeaf domain label: ").Append(resource.LeafDomainLabel)
                    .Append("\n\tFQDN: ").Append(resource.Fqdn)
                    .Append("\n\tReverse FQDN: ").Append(resource.ReverseFqdn)
                    .Append("\n\tIdle timeout (minutes): ").Append(resource.IdleTimeoutInMinutes)
                    .Append("\n\tIP allocation method: ").Append(resource.IPAllocationMethod)
                    .Append("\n\tIP version: ").Append(resource.Version);

            // Show the associated load balancer if any
            info.Append("\n\tLoad balancer association: ");
            if (resource.HasAssignedLoadBalancer)
            {
                var frontend = resource.GetAssignedLoadBalancerFrontend();
                var lb = frontend.Parent;
                info.Append("\n\t\tLoad balancer ID: ").Append(lb.Id)
                    .Append("\n\t\tFrontend name: ").Append(frontend.Name);
            }
            else
            {
                info.Append("(None)");
            }

            // Show the associated NIC if any
            info.Append("\n\tNetwork interface association: ");
            if (resource.HasAssignedNetworkInterface)
            {
                var nicIP = resource.GetAssignedNetworkInterfaceIPConfiguration();
                var nic = nicIP.Parent;
                info.Append("\n\t\tNetwork interface ID: ").Append(nic.Id)
                    .Append("\n\t\tIP config name: ").Append(nicIP.Name);
            }
            else
            {
                info.Append("(None)");
            }

            TestHelper.WriteLine(info.ToString());
        }
    }
}
