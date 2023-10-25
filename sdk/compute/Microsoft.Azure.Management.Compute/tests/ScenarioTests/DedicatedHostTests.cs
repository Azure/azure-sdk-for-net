// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using Xunit;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;

namespace Compute.Tests
{
    public class DedicatedHostTests : VMTestBase
    {
        [Fact]
        public void TestDedicatedHostOperations()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus2");
                EnsureClientsInitialized(context);

                string baseRGName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string rgName = baseRGName + "DH";
                string dhgName = "DHG-1";
                string dhgWithUltraSSDName = "DHG-UltraSSD-1";
                string dhName = "DH-1";

                try
                {
                    // Create a dedicated host group, then get the dedicated host group and validate that they match
                    DedicatedHostGroup createdDHG = CreateDedicatedHostGroup(rgName, dhgName);
                    DedicatedHostGroup returnedDHG = m_CrpClient.DedicatedHostGroups.Get(rgName, dhgName);
                    ValidateDedicatedHostGroup(createdDHG, returnedDHG);

                    // Update existing dedicated host group 
                    DedicatedHostGroupUpdate updateDHGInput = new DedicatedHostGroupUpdate()
                    {
                        Tags = new Dictionary<string, string>() { { "testKey", "testValue" } }
                    };
                    createdDHG.Tags = updateDHGInput.Tags;
                    updateDHGInput.PlatformFaultDomainCount = returnedDHG.PlatformFaultDomainCount; // There is a bug in PATCH.  PlatformFaultDomainCount is a required property now.
                    returnedDHG =  m_CrpClient.DedicatedHostGroups.Update(rgName, dhgName, updateDHGInput);
                    ValidateDedicatedHostGroup(createdDHG, returnedDHG);

                    //List DedicatedHostGroups by subscription and by resourceGroup
                    var listDHGsResponse = m_CrpClient.DedicatedHostGroups.ListByResourceGroup(rgName);
                    Assert.Single(listDHGsResponse);
                    ValidateDedicatedHostGroup(createdDHG, listDHGsResponse.First());
                    listDHGsResponse = m_CrpClient.DedicatedHostGroups.ListBySubscription();

                    //There might be multiple dedicated host groups in the subscription, we only care about the one that we created.
                    returnedDHG = listDHGsResponse.First(dhg => dhg.Id == createdDHG.Id);
                    Assert.NotNull(returnedDHG);
                    ValidateDedicatedHostGroup(createdDHG, returnedDHG);

                    //Create DedicatedHost within the DedicatedHostGroup and validate
                    var createdDH = CreateDedicatedHost(rgName, dhgName, dhName, "ESv3-Type1");
                    var returnedDH = m_CrpClient.DedicatedHosts.Get(rgName, dhgName, dhName);
                    ValidateDedicatedHost(createdDH, returnedDH);
                    
                    //List DedicatedHosts
                    var listDHsResponse = m_CrpClient.DedicatedHosts.ListByHostGroup(rgName, dhgName);
                    Assert.Single(listDHsResponse);
                    ValidateDedicatedHost(createdDH, listDHsResponse.First());

                    //Delete DedicatedHosts and DedicatedHostGroups
                    m_CrpClient.DedicatedHosts.Delete(rgName, dhgName, dhName);
                    m_CrpClient.DedicatedHostGroups.Delete(rgName, dhgName);

                    // Create a dedicated host group with ultraSSDCapabilty set to true, then get the dedicated host group and validate that they match
                    createdDHG = CreateDedicatedHostGroup(rgName, dhgWithUltraSSDName, ultraSSDCapability: true);
                    returnedDHG = m_CrpClient.DedicatedHostGroups.Get(rgName, dhgWithUltraSSDName);
                    ValidateDedicatedHostGroup(createdDHG, returnedDHG);
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
                }
            }
        }

        [Fact]
        public void TestNonZonalDedicatedHostGroupInstanceViewAndAutomaticPlacement()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "westus");
                EnsureClientsInitialized(context);

                string baseRGName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string rgName = baseRGName + "DH";
                string dhgName = "DHG-1";
                string dhName = "DH-1";

                try
                {
                    // Create a dedicated host group, then get the dedicated host group and validate that they match
                    DedicatedHostGroup createdDHG = CreateDedicatedHostGroup(rgName, dhgName, availabilityZone: null);
                    DedicatedHostGroup returnedDHG = m_CrpClient.DedicatedHostGroups.Get(rgName, dhgName);
                    ValidateDedicatedHostGroup(createdDHG, returnedDHG);

                    //Create DedicatedHost within the DedicatedHostGroup and validate
                    var createdDH = CreateDedicatedHost(rgName, dhgName, dhName, "ESv3-Type1");
                    var returnedDH = m_CrpClient.DedicatedHosts.Get(rgName, dhgName, dhName);
                    ValidateDedicatedHost(createdDH, returnedDH);

                    // Validate dedicated host group instance view
                    DedicatedHostGroup returnedDHGWithInstanceView = m_CrpClient.DedicatedHostGroups.Get(rgName, dhgName, InstanceViewTypes.InstanceView);
                    ValidateDedicatedHostGroupInstanceView(returnedDHGWithInstanceView, createdDH);

                    //Delete DedicatedHosts and DedicatedHostGroups
                    m_CrpClient.DedicatedHosts.Delete(rgName, dhgName, dhName);
                    m_CrpClient.DedicatedHostGroups.Delete(rgName, dhgName);

                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
                }
            }
        }

        [Fact]
        public void TestDedicatedHostRestart()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus2");
                EnsureClientsInitialized(context);

                string baseRGName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string rgName = baseRGName + "DH";
                string dhgName = "DHG-1";
                string dhName = "DH-1";

                try
                {
                    // Create a dedicated host group, then get the dedicated host group and validate that they match
                    DedicatedHostGroup createdDHG = CreateDedicatedHostGroup(rgName, dhgName, availabilityZone: null);
                    DedicatedHostGroup returnedDHG = m_CrpClient.DedicatedHostGroups.Get(rgName, dhgName);
                    ValidateDedicatedHostGroup(createdDHG, returnedDHG);

                    //Create DedicatedHost within the DedicatedHostGroup and validate
                    var createdDH = CreateDedicatedHost(rgName, dhgName, dhName, "ESv3-Type1");
                    var returnedDH = m_CrpClient.DedicatedHosts.Get(rgName, dhgName, dhName);
                    ValidateDedicatedHost(createdDH, returnedDH);

                    // Validate dedicated host group instance view
                    DedicatedHostGroup returnedDHGWithInstanceView = m_CrpClient.DedicatedHostGroups.Get(rgName, dhgName, InstanceViewTypes.InstanceView);
                    ValidateDedicatedHostGroupInstanceView(returnedDHGWithInstanceView, createdDH);

                    // Restart the DedicatedHost
                    //m_CrpClient.DedicatedHosts.Restart(rgName, dhgName, dhName);

                    // Delete DedicatedHost and DedicatedHostGroup
                    m_CrpClient.DedicatedHosts.Delete(rgName, dhgName, dhName);
                    m_CrpClient.DedicatedHostGroups.Delete(rgName, dhgName);
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
                }
            }
        }

        [Fact]
        public void TestDedicatedHostResize()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "southeastasia");
                EnsureClientsInitialized(context);

                string baseRGName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string rgName = baseRGName + "DH";
                string dhgName = "DHG-1";
                string dhName = "DH-1";

                try
                {
                    // Create a dedicated host group, then get the dedicated host group and validate that they match
                    DedicatedHostGroup createdDHG = CreateDedicatedHostGroup(rgName, dhgName, availabilityZone: null);
                    DedicatedHostGroup returnedDHG = m_CrpClient.DedicatedHostGroups.Get(rgName, dhgName);
                    ValidateDedicatedHostGroup(createdDHG, returnedDHG);

                    //Create DedicatedHost within the DedicatedHostGroup and validate
                    var createdDH = CreateDedicatedHost(rgName, dhgName, dhName, "ESv3-Type1");
                    var returnedDH = m_CrpClient.DedicatedHosts.Get(rgName, dhgName, dhName);
                    ValidateDedicatedHost(createdDH, returnedDH);

                    // ListAvailableDedicatedHost sizes that DedicatedHost can be updated to
                    var returnedAvailableSizes = m_CrpClient.DedicatedHosts.ListAvailableSizes(rgName, dhgName, dhName).ToList();
                    ValidateDedicatedHostSizeListResponse(returnedAvailableSizes);

                    //Resize the DedicatedHost
                    createdDH.Sku.Name = returnedAvailableSizes[0];
                    var updatedDH = m_CrpClient.DedicatedHosts.Update(rgName, dhgName, dhName,
                        new DedicatedHostUpdate()
                        {
                            Sku = new Sku() { Name = createdDH.Sku.Name }
                        });
                    // Delete DedicatedHost and DedicatedHostGroup
                    m_CrpClient.DedicatedHosts.Delete(rgName, dhgName, dhName);
                    m_CrpClient.DedicatedHostGroups.Delete(rgName, dhgName);
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
                }
            }
        }

        private void ValidateDedicatedHostGroup(DedicatedHostGroup expectedDHG, DedicatedHostGroup actualDHG)
        {
            if (expectedDHG == null)
            {
                Assert.Null(actualDHG);
            }
            else
            {
                Assert.NotNull(actualDHG);
                if (expectedDHG.Hosts == null)
                {
                    Assert.Null(actualDHG.Hosts);
                }
                else
                {
                    Assert.NotNull(actualDHG);
                    Assert.True(actualDHG.Hosts.SequenceEqual(expectedDHG.Hosts));
                }
                Assert.Equal(expectedDHG.Location, actualDHG.Location);
                Assert.Equal(expectedDHG.Name, actualDHG.Name);
                Assert.Equal(expectedDHG.SupportAutomaticPlacement, actualDHG.SupportAutomaticPlacement);

                if(expectedDHG.AdditionalCapabilities != null)
                {
                    Assert.NotNull(actualDHG.AdditionalCapabilities);
                    Assert.Equal(expectedDHG.AdditionalCapabilities.UltraSSDEnabled, actualDHG.AdditionalCapabilities.UltraSSDEnabled);
                }
            }
        }

        private void ValidateDedicatedHostGroupInstanceView(DedicatedHostGroup actualDHGWithInstanceView, params DedicatedHost[] expectedDedicatedHostsInInstanceView)
        {
            Assert.NotNull(actualDHGWithInstanceView);
            Assert.Equal(expectedDedicatedHostsInInstanceView.Count(), actualDHGWithInstanceView.InstanceView.Hosts.Count);
            foreach (DedicatedHost dedicatedHost in expectedDedicatedHostsInInstanceView)
            {
                Assert.True(actualDHGWithInstanceView.InstanceView.Hosts.FirstOrDefault(host => host.Name.Equals(dedicatedHost.Name)) != null);
            }
        }

        private void ValidateDedicatedHost(DedicatedHost expectedDH, DedicatedHost actualDH)
        {
            if (expectedDH == null)
            {
                Assert.Null(actualDH);
            }
            else
            {
                Assert.NotNull(actualDH);
                if (expectedDH.VirtualMachines == null)
                {
                    Assert.Null(actualDH.VirtualMachines);
                }
                else
                {
                    Assert.NotNull(actualDH);
                    Assert.True(actualDH.VirtualMachines.SequenceEqual(expectedDH.VirtualMachines));
                }
                Assert.Equal(expectedDH.Location, actualDH.Location);
                Assert.Equal(expectedDH.Name, actualDH.Name);
                Assert.Equal(expectedDH.HostId, actualDH.HostId);
            }
        }

        private static void ValidateDedicatedHostSizeListResponse(List<string> dhSizeListResponse)
        {
            var expectedDHSizePropertiesList = new List<string>() {"ESv3-Type2", "ESv3-Type3", "ESv3-Type4" };

            Assert.NotNull(dhSizeListResponse);
            Assert.True(dhSizeListResponse.Count() >= 0, "ListDHSizes should return more than 0 DH sizes");
            Assert.Equal(expectedDHSizePropertiesList.Count(), dhSizeListResponse.Count());
            foreach (var expectedDHSize in expectedDHSizePropertiesList)
            {
                Assert.True(dhSizeListResponse.Contains(expectedDHSize), $"{expectedDHSize} size does not exist in dhSizeListResponse");
            }

        }
    }
}
