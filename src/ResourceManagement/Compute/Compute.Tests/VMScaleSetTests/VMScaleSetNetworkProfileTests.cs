// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using Xunit;

namespace Compute.Tests
{
    public class VMScaleSetNetworkProfileTests : VMScaleSetTestsBase
    {
        /// <summary>
        /// Associates a VMScaleSet to an Application gateway
        /// </summary>
        [Fact]
        public void TestVMScaleSetWithApplciationGateway()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                // Create resource group
                string rgName = TestUtilities.GenerateName(TestPrefix) + 1;
                var vmssName = TestUtilities.GenerateName("vmss");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachineScaleSet inputVMScaleSet;

                bool passed = false;
                try
                {
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);
                    var vnetResponse = CreateVNETWithSubnets(rgName, 2);
                    var gatewaySubnet = vnetResponse.Subnets[0];
                    var vmssSubnet = vnetResponse.Subnets[1];
                    ApplicationGateway appgw = CreateApplicationGateway(rgName, gatewaySubnet);
                    Microsoft.Azure.Management.Compute.Models.SubResource backendAddressPool = new Microsoft.Azure.Management.Compute.Models.SubResource()
                    {
                        Id = appgw.BackendAddressPools[0].Id
                    };

                    VirtualMachineScaleSet vmScaleSet = CreateVMScaleSet_NoAsyncTracking(
                        rgName: rgName,
                        vmssName: vmssName,
                        storageAccount: storageAccountOutput,
                        imageRef: imageRef,
                        inputVMScaleSet: out inputVMScaleSet,
                        vmScaleSetCustomizer:
                            (virtualMachineScaleSet) =>
                                virtualMachineScaleSet.VirtualMachineProfile.NetworkProfile
                                    .NetworkInterfaceConfigurations[0].IpConfigurations[0]
                                    .ApplicationGatewayBackendAddressPools.Add(backendAddressPool),
                        createWithPublicIpAddress: false,
                        subnet: vmssSubnet);

                    var getGwResponse = m_NrpClient.ApplicationGateways.Get(rgName, appgw.Name);
                    Assert.True(2 == getGwResponse.BackendAddressPools[0].BackendIPConfigurations.Count);
                    passed = true;
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.DeleteIfExists(rgName);
                }

                Assert.True(passed);
            }
        }
    }
}