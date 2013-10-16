﻿//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//


using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Management;
using Microsoft.WindowsAzure.Management.Models;
using Microsoft.WindowsAzure.Management.VirtualNetworks;
using Microsoft.WindowsAzure.Management.VirtualNetworks.Models;

namespace Microsoft.WindowsAzure.Testing
{
    [TestClass]
    public class NetworkingTests : NetworkTestBase
    {
        private const string TestNetworkConfiguration =
@"<?xml version=""1.0"" encoding=""utf-8""?>
<NetworkConfiguration xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""http://schemas.microsoft.com/ServiceHosting/2011/07/NetworkConfiguration"">
  <VirtualNetworkConfiguration>
    <Dns>
      <DnsServers>
        <DnsServer name=""open"" IPAddress=""208.67.222.222"" />
      </DnsServers>
    </Dns>
    <LocalNetworkSites>
      <LocalNetworkSite name=""LocalNet1"">
        <AddressSpace>
          <AddressPrefix>157.59.34.0/28</AddressPrefix>
        </AddressSpace>
        <VPNGatewayAddress>157.59.34.62</VPNGatewayAddress>
      </LocalNetworkSite>
    </LocalNetworkSites>
    <VirtualNetworkSites>
      <VirtualNetworkSite name=""NewVNet1"" AffinityGroup=""WestUsAffinityGroup"">
        <AddressSpace>
          <AddressPrefix>10.0.0.0/8</AddressPrefix>
        </AddressSpace>
        <Subnets>
          <Subnet name=""Subnet1"">
            <AddressPrefix>10.0.0.0/11</AddressPrefix>
          </Subnet>
          <Subnet name=""Subnet2"">
            <AddressPrefix>10.32.0.0/11</AddressPrefix>
          </Subnet>
          <Subnet name=""GatewaySubnet"">
            <AddressPrefix>10.64.0.0/29</AddressPrefix>
          </Subnet>
        </Subnets>
        <DnsServersRef>
          <DnsServerRef name=""open"" />
        </DnsServersRef>
        <Gateway>
          <ConnectionsToLocalNetwork>
            <LocalNetworkSiteRef name=""LocalNet1"" />
          </ConnectionsToLocalNetwork>
        </Gateway>
      </VirtualNetworkSite>
      <VirtualNetworkSite name=""NewVNet2"" AffinityGroup=""WestUsAffinityGroup"">
        <AddressSpace>
          <AddressPrefix>172.16.0.0/20</AddressPrefix>
        </AddressSpace>
        <Subnets>
          <Subnet name=""Subnet-1"">
            <AddressPrefix>172.16.0.0/23</AddressPrefix>
          </Subnet>
          <Subnet name=""GatewaySubnet"">
            <AddressPrefix>172.16.2.0/29</AddressPrefix>
          </Subnet>
        </Subnets>
        <DnsServersRef>
          <DnsServerRef name=""open"" />
        </DnsServersRef>
        <Gateway>
          <ConnectionsToLocalNetwork>
            <LocalNetworkSiteRef name=""LocalNet1"" />
          </ConnectionsToLocalNetwork>
        </Gateway>
      </VirtualNetworkSite>
      <VirtualNetworkSite name=""NewVNet3"" AffinityGroup=""WestUsAffinityGroup"">
        <AddressSpace>
          <AddressPrefix>192.168.0.0/20</AddressPrefix>
        </AddressSpace>
        <Subnets>
          <Subnet name=""Subnet-1"">
            <AddressPrefix>192.168.0.0/23</AddressPrefix>
          </Subnet>
          <Subnet name=""GatewaySubnet"">
            <AddressPrefix>192.168.2.0/29</AddressPrefix>
          </Subnet>
        </Subnets>
        <DnsServersRef>
          <DnsServerRef name=""open"" />
        </DnsServersRef>
        <Gateway>
          <ConnectionsToLocalNetwork>
            <LocalNetworkSiteRef name=""LocalNet1"" />
          </ConnectionsToLocalNetwork>
        </Gateway>
      </VirtualNetworkSite>
    </VirtualNetworkSites>
  </VirtualNetworkConfiguration>
</NetworkConfiguration>";

        private const string TestAffinityGroupName = "WestUsAffinityGroup";

        [TestMethod]
        public void Networking_Configuration()
        {

            using (var management = GetManagementClient())
            using (var networking = GetNetworkingClient())
            {
                try
                {
                    management.AffinityGroups.Create(
                        new AffinityGroupCreateParameters()
                        {
                            Name = TestAffinityGroupName,
                            Description = TestAffinityGroupName,
                            Label = TestAffinityGroupName,
                            Location = LocationNames.WestUS
                        });

                    networking.Networks.SetConfiguration(
                        new NetworkSetConfigurationParameters()
                        {
                            Configuration = TestNetworkConfiguration
                        });

                    var config = networking.Networks.GetConfiguration();
                    Assert.IsNotNull(config.Configuration);
                }
                finally
                {
                    management.AffinityGroups.Delete(TestAffinityGroupName);
                }
            }
        }
    }
}
