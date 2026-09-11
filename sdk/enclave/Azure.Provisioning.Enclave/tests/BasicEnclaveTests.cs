// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Enclave.Tests;

public class BasicEnclaveTests
{
    internal static Trycep CreateVirtualEnclaveTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:EnclaveBasic
                Infrastructure infra = new();

                VirtualEnclave enclave =
                    new(nameof(enclave), VirtualEnclave.ResourceVersions.V2026_03_01_PREVIEW)
                    {
                        Properties = new VirtualEnclaveProperties
                        {
                            CommunityResourceId = new ResourceIdentifier(
                                "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/example/providers/Microsoft.Mission/communities/example"),
                            EnclaveVirtualNetwork = new EnclaveVirtualNetwork
                            {
                                NetworkName = "enclave-vnet",
                                NetworkSize = "small",
                                CustomCidrRange = "10.0.0.0/16",
                                AllowSubnetCommunication = true,
                            },
                            IsBastionEnabled = false,
                        },
                    };
                infra.Add(enclave);
                #endregion

                return infra;
            });
    }

    [Test]
    public async Task CreateVirtualEnclave()
    {
        await using Trycep test = CreateVirtualEnclaveTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource enclave 'Microsoft.Mission/virtualEnclaves@2026-03-01-preview' = {
              name: take('enclave-${uniqueString(resourceGroup().id)}', 24)
              location: location
              properties: {
                bastionEnabled: false
                communityResourceId: '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/example/providers/Microsoft.Mission/communities/example'
                enclaveVirtualNetwork: {
                  allowSubnetCommunication: true
                  customCidrRange: '10.0.0.0/16'
                  networkName: 'enclave-vnet'
                  networkSize: 'small'
                }
              }
            }
            """);
    }
}
