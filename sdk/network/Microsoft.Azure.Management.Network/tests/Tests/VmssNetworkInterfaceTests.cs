// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Net;
using System;
using System.Linq;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Test;
using Networks.Tests.Helpers;
using ResourceGroups.Tests;
using Xunit;
using Microsoft.Azure.Test.HttpRecorder;
using Network.Tests.Helpers;

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using System.Diagnostics;

namespace Networks.Tests
{
    public class VmssNetworkInterfaceTests
    {
        public VmssNetworkInterfaceTests()
        {
            HttpMockServer.RecordsDirectory = "SessionRecords";
        }

        static string GetNameById(string Id, string resourceType)
        {
            string name = Id.Substring(Id.IndexOf(resourceType + '/') + resourceType.Length + 1);
            if (name.IndexOf('/') != -1)
            {
                name = name.Substring(0, name.IndexOf('/'));
            }
            return name;
        }

        [Fact(Skip="Disable tests")]
        public void VmssNetworkInterfaceApiTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1, true);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Compute/virtualMachineScaleSets");
                string resourceGroupName = TestUtilities.GenerateName();
                string deploymentName = TestUtilities.GenerateName("vmss");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                DeploymentUpdate.CreateVmss(resourcesClient, resourceGroupName, deploymentName);

                string virtualMachineScaleSetName = "vmssip";
                var vmssListAllPageResult = networkManagementClient.PublicIPAddresses.ListVirtualMachineScaleSetPublicIPAddresses(resourceGroupName, virtualMachineScaleSetName);
                var vmssListAllResult = vmssListAllPageResult.ToList();
                var firstResult = vmssListAllResult.First();

                Assert.NotNull(vmssListAllResult);
                Assert.Equal("Succeeded", firstResult.ProvisioningState);
                Assert.NotNull(firstResult.ResourceGuid);

                var idItem = firstResult.Id;
                var vmIndex = GetNameById(idItem, "virtualMachines");
                var nicName = GetNameById(idItem, "networkInterfaces");
                var ipConfigName = GetNameById(idItem, "ipConfigurations");
                var ipName = GetNameById(idItem, "publicIPAddresses");

				// Verify that NICs contain reference to publicIp, nsg and dns settings
				var listNicPerVmss = networkManagementClient.NetworkInterfaces.ListVirtualMachineScaleSetNetworkInterfaces(resourceGroupName, virtualMachineScaleSetName).ToList();
				Assert.NotNull(listNicPerVmss);

				foreach (var nic in listNicPerVmss)
				{
					this.VerifyVmssNicProperties(nic);
				}

				// Verify nics on a vm level
				var listNicPerVm = networkManagementClient.NetworkInterfaces.ListVirtualMachineScaleSetVMNetworkInterfaces(resourceGroupName, virtualMachineScaleSetName, vmIndex).ToList();
				Assert.NotNull(listNicPerVm);
				Assert.Single(listNicPerVm);

				foreach (var nic in listNicPerVm)
				{
					this.VerifyVmssNicProperties(nic);
				}

				// Verify getting individual nic
				var getNic = networkManagementClient.NetworkInterfaces.GetVirtualMachineScaleSetNetworkInterface(resourceGroupName, virtualMachineScaleSetName, vmIndex, nicName);
				Assert.NotNull(getNic);
				this.VerifyVmssNicProperties(getNic);				

				resourcesClient.ResourceGroups.Delete(resourceGroupName);
            }
        }

		private void VerifyVmssNicProperties(NetworkInterface nic)
		{
			Assert.NotNull(nic.NetworkSecurityGroup);
			Assert.False(string.IsNullOrEmpty(nic.NetworkSecurityGroup.Id));
			Assert.NotNull(nic.DnsSettings);
			Assert.NotNull(nic.DnsSettings.DnsServers);
			Assert.Equal(1, nic.DnsSettings.DnsServers.Count);
			Assert.NotNull(nic.IpConfigurations[0].PublicIPAddress);
			Assert.False(string.IsNullOrEmpty(nic.IpConfigurations[0].PublicIPAddress.Id));
		}
    }
}
