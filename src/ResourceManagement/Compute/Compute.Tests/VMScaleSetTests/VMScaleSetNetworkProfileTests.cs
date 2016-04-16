//
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