// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Network.Tests;

public class BasicNetworkTests(bool async) : ProvisioningTestBase(async)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.network/vnet-two-subnets/main.bicep")]
    public async Task VNetTwoSubnets()
    {
        await using Trycep test = CreateBicepTest();
        await test.Define(
            ctx =>
            {
                #region Snippet:VNetTwoSubnets
                Infrastructure infra = new();
                ProvisioningParameter vnetName = new("vnetName", typeof(string))
                {
                    Description = "VNet name",
                    Value = "VNet1"
                };
                infra.Add(vnetName);
                ProvisioningParameter vnetAddressPrefix = new("vnetAddressPrefix", typeof(string))
                {
                    Description = "Address prefix",
                    Value = "10.0.0.0/16"
                };
                infra.Add(vnetAddressPrefix);
                ProvisioningParameter subnet1Prefix = new("subnet1Prefix", typeof(string))
                {
                    Description = "Subnet 1 Prefix",
                    Value = "10.0.0.0/24"
                };
                infra.Add(subnet1Prefix);
                ProvisioningParameter subnet1Name = new("subnet1Name", typeof(string))
                {
                    Description = "Subnet 1 Name",
                    Value = "Subnet1"
                };
                infra.Add(subnet1Name);
                ProvisioningParameter subnet2Prefix = new("subnet2Prefix", typeof(string))
                {
                    Description = "Subnet 2 Prefix",
                    Value = "10.0.1.0/24"
                };
                infra.Add(subnet2Prefix);
                ProvisioningParameter subnet2Name = new("subnet2Name", typeof(string))
                {
                    Description = "Subnet 2 Name",
                    Value = "Subnet2"
                };
                infra.Add(subnet2Name);
                VirtualNetwork vnet = new("vnet", "2021-08-01")
                {
                    Name = vnetName,
                    AddressSpace = new VirtualNetworkAddressSpace()
                    {
                        AddressPrefixes =
                        [
                            vnetAddressPrefix
                        ]
                    },
                    Subnets =
                    [
                        new Subnet()
                        {
                            Name = subnet1Name,
                            AddressPrefix = subnet1Prefix
                        },
                        new Subnet()
                        {
                            Name = subnet2Name,
                            AddressPrefix = subnet2Prefix
                        }
                    ]
                };
                infra.Add(vnet);
                #endregion
                return infra;
            })
        .Compare(
            """
            @description('VNet name')
            param vnetName string = 'VNet1'

            @description('Address prefix')
            param vnetAddressPrefix string = '10.0.0.0/16'

            @description('Subnet 1 Prefix')
            param subnet1Prefix string = '10.0.0.0/24'

            @description('Subnet 1 Name')
            param subnet1Name string = 'Subnet1'

            @description('Subnet 2 Prefix')
            param subnet2Prefix string = '10.0.1.0/24'

            @description('Subnet 2 Name')
            param subnet2Name string = 'Subnet2'

            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource vnet 'Microsoft.Network/virtualNetworks@2021-08-01' = {
              name: vnetName
              properties: {
                addressSpace: {
                  addressPrefixes: [
                    vnetAddressPrefix
                  ]
                }
                subnets: [
                  {
                    name: subnet1Name
                    properties: {
                      addressPrefix: subnet1Prefix
                    }
                  }
                  {
                    name: subnet2Name
                    properties: {
                      addressPrefix: subnet2Prefix
                    }
                  }
                ]
              }
              location: location
            }
            """)
        .Lint()
        .ValidateAsync();
    }
}
