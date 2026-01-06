// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Network;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.PrivateDns.Tests;

public class BasicPrivateDnsTests
{
    internal static Trycep CreatePrivateDnsZoneBasic()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:PrivateDnsZoneBasic
                Infrastructure infra = new();
                ProvisioningParameter privateDnsZoneName = new(nameof(privateDnsZoneName), typeof(string))
                    {
                        Description = "Private DNS zone name"
                    };
                infra.Add(privateDnsZoneName);
                ProvisioningParameter vmRegistration = new(nameof(vmRegistration), typeof(bool))
                    {
                        Description = "Enable automatic VM DNS registration in the zone",
                        Value = true
                    };
                infra.Add(vmRegistration);
                ProvisioningParameter vnetName = new(nameof(vnetName), typeof(string))
                    {
                        Description = "VNet name",
                        Value = "VNet"
                    };
                infra.Add(vnetName);
                ProvisioningParameter vnetAddressPrefix = new(nameof(vnetAddressPrefix), typeof(string))
                    {
                        Description = "VNet Address prefix",
                        Value = "10.0.0.0/16"
                    };
                infra.Add(vnetAddressPrefix);
                ProvisioningParameter subnetPrefix = new(nameof(subnetPrefix), typeof(string))
                    {
                        Description = "Subnet Prefix",
                        Value = "10.0.0.0/24"
                    };
                infra.Add(subnetPrefix);
                ProvisioningParameter subnetName = new(nameof(subnetName), typeof(string))
                    {
                        Description = "Subnet Name",
                        Value = "App"
                    };
                infra.Add(subnetName);
                VirtualNetwork vnet =
                    new(nameof(vnet), VirtualNetwork.ResourceVersions.V2021_03_01)
                    {
                        Name = vnetName,
                        AddressSpace = new()
                        {
                            AddressPrefixes = { vnetAddressPrefix }
                        },
                        Subnets =
                        {
                            new SubnetResource("subnet")
                            {
                                Name = subnetName,
                                AddressPrefix = subnetPrefix
                            }
                        }
                    };
                infra.Add(vnet);
                PrivateDnsZone privateDnsZone =
                    new(nameof(privateDnsZone), PrivateDnsZone.ResourceVersions.V2020_06_01)
                    {
                        Name = privateDnsZoneName,
                        Location = new AzureLocation("global")
                    };
                infra.Add(privateDnsZone);
                VirtualNetworkLink privateDnsZoneLink =
                    new(nameof(privateDnsZoneLink), VirtualNetworkLink.ResourceVersions.V2020_06_01)
                    {
                        Parent = privateDnsZone,
                        Name = BicepFunction.Interpolate($"{vnet.Name.ToBicepExpression()}-link"),
                        Location = new AzureLocation("global"),
                        RegistrationEnabled = vmRegistration,
                        VirtualNetworkId = vnet.Id
                    };
                infra.Add(privateDnsZoneLink);
                #endregion
                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.network/private-dns-zone/main.bicep")]
    public async Task PrivateDnsZoneBasic()
    {
        await using Trycep test = CreatePrivateDnsZoneBasic();
        test.Compare(
            """
            @description('Private DNS zone name')
            param privateDnsZoneName string

            @description('Enable automatic VM DNS registration in the zone')
            param vmRegistration bool = true

            @description('VNet name')
            param vnetName string = 'VNet'

            @description('VNet Address prefix')
            param vnetAddressPrefix string = '10.0.0.0/16'

            @description('Subnet Prefix')
            param subnetPrefix string = '10.0.0.0/24'

            @description('Subnet Name')
            param subnetName string = 'App'

            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource vnet 'Microsoft.Network/virtualNetworks@2021-03-01' = {
              name: vnetName
              properties: {
                addressSpace: {
                  addressPrefixes: [
                    vnetAddressPrefix
                  ]
                }
                subnets: [
                  {
                    name: subnetName
                    properties: {
                      addressPrefix: subnetPrefix
                    }
                  }
                ]
              }
              location: location
            }

            resource privateDnsZone 'Microsoft.Network/privateDnsZones@2020-06-01' = {
              name: privateDnsZoneName
              location: 'global'
            }

            resource privateDnsZoneLink 'Microsoft.Network/privateDnsZones/virtualNetworkLinks@2020-06-01' = {
              name: '${vnet.name}-link'
              location: 'global'
              properties: {
                registrationEnabled: vmRegistration
                virtualNetwork: {
                  id: vnet.id
                }
              }
              parent: privateDnsZone
            }
            """);
    }
}
