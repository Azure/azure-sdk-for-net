// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Compute.Tests
{
    public class CloudServiceOperationTests : CloudServiceTestsBase
    {
        [Fact]
        [Trait("Name", "Test_Create_PowerOff_Start_CloudServiceOperation")]
        public void Test_Create_PowerOff_Start_CloudServiceOperation()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                // Create resource group
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var csName = TestUtilities.GenerateName("cs");
                string cloudServiceName = "HelloWorldTest_WebRole";
                string publicIPAddressName = TestUtilities.GenerateName("cspip");
                string vnetName = TestUtilities.GenerateName("csvnet");
                string subnetName = TestUtilities.GenerateName("subnet");
                string dnsName = TestUtilities.GenerateName("dns");
                string lbName = TestUtilities.GenerateName("lb");
                string lbfeName = TestUtilities.GenerateName("lbfe");


                try
                {
                    CreateVirtualNetwork(rgName, vnetName, subnetName);
                    PublicIPAddress publicIPAddress = CreatePublicIP(publicIPAddressName, rgName, dnsName);

                    // Define Configurations
                    List<string> supportedRoleInstanceSizes = GetSupportedRoleInstanceSizes();
                    Dictionary<string, RoleConfiguration> roleNameToPropertiesMapping = new Dictionary<string, RoleConfiguration>
                    {
                        { "HelloWorldTest1", new RoleConfiguration { InstanceCount = 1, RoleInstanceSize = supportedRoleInstanceSizes[0] } }
                    };

                    CloudService cloudService = GenerateCloudServiceWithNetworkProfile(
                        resourceGroupName: rgName,
                        serviceName: cloudServiceName,
                        cspkgSasUri: CreateCspkgSasUrl(rgName, WebRoleSasUri),
                        roleNameToPropertiesMapping: roleNameToPropertiesMapping,
                                publicIPAddressName: publicIPAddressName,
                                vnetName: vnetName,
                                subnetName: subnetName,
                                lbName: lbName,
                                lbFrontendName: lbfeName);

                    CloudService getResponse = CreateCloudService_NoAsyncTracking(
                    rgName,
                    csName,
                    cloudService);

                    //PowerOFf the cloudService and verify response
                    m_CrpClient.CloudServices.PowerOff(rgName, csName);
                    getResponse = m_CrpClient.CloudServices.Get(rgName, csName);
                    ValidateCloudService(cloudService, getResponse, rgName, csName);

                    //Start the cloudService and verify response
                    m_CrpClient.CloudServices.Start(rgName, csName);
                    getResponse = m_CrpClient.CloudServices.Get(rgName, csName);
                    ValidateCloudService(cloudService, getResponse, rgName, csName);

                    //Restart the cloudService 
                    m_CrpClient.CloudServices.Restart(rgName, csName, new List<string> { "*" });
                    getResponse = m_CrpClient.CloudServices.Get(rgName, csName);
                    ValidateCloudService(cloudService, getResponse, rgName, csName);

                    //Reimage the cloudService 
                    m_CrpClient.CloudServices.Reimage(rgName, csName, new List<string> { "*" });
                    getResponse = m_CrpClient.CloudServices.Get(rgName, csName);
                    ValidateCloudService(cloudService, getResponse, rgName, csName);

                    //Rebuild the cloudService 
                    m_CrpClient.CloudServices.Rebuild(rgName, csName, new List<string> { "*" });
                    getResponse = m_CrpClient.CloudServices.Get(rgName, csName);
                    ValidateCloudService(cloudService, getResponse, rgName, csName);

                    // Delete the cloud Service
                    m_CrpClient.CloudServices.Delete(rgName, csName);
                }
                finally
                {
                    // Fire and forget. No need to wait for RG deletion completion
                    try
                    {
                        m_ResourcesClient.ResourceGroups.BeginDelete(rgName);
                    }
                    catch (Exception e)
                    {
                        // Swallow this exception so that the original exception is thrown
                        Console.WriteLine(e);
                    }
                }
            }
        }

        [Fact]
        [Trait("Name", "Test_ListCloudServicesOperation")]
        public void Test_ListCloudServicesOperation()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                // Create resource group
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var rgName2 = TestUtilities.GenerateName(TestPrefix);
                var csName1 = TestUtilities.GenerateName("cs");
                var csName2 = TestUtilities.GenerateName("cs");
                var csName3 = TestUtilities.GenerateName("cs");
                string cloudServiceName = "HelloWorldTest_WebRole";
                string publicIPAddressName = TestUtilities.GenerateName("cspip");
                string vnetName = TestUtilities.GenerateName("csvnet");
                string subnetName = TestUtilities.GenerateName("subnet");
                string dnsName = TestUtilities.GenerateName("dns");
                string lbName = TestUtilities.GenerateName("lb");
                string lbfeName = TestUtilities.GenerateName("lbfe");
                string publicIPAddressName2 = TestUtilities.GenerateName("cspip");
                string vnetName2 = TestUtilities.GenerateName("csvnet");
                string subnetName2 = TestUtilities.GenerateName("subnet");
                string dnsName2 = TestUtilities.GenerateName("dns");
                string lbName2 = TestUtilities.GenerateName("lb");
                string lbfeName2 = TestUtilities.GenerateName("lbfe");
                string publicIPAddressName3 = TestUtilities.GenerateName("cspip");
                string vnetName3 = TestUtilities.GenerateName("csvnet");
                string subnetName3 = TestUtilities.GenerateName("subnet");
                string dnsName3 = TestUtilities.GenerateName("dns");
                string lbName3 = TestUtilities.GenerateName("lb");
                string lbfeName3 = TestUtilities.GenerateName("lbfe");


                try
                {
                    // Define Configurations
                    List<string> supportedRoleInstanceSizes = GetSupportedRoleInstanceSizes();
                    Dictionary<string, RoleConfiguration> roleNameToPropertiesMapping = new Dictionary<string, RoleConfiguration>
            {
                { "HelloWorldTest1", new RoleConfiguration { InstanceCount = 1, RoleInstanceSize = supportedRoleInstanceSizes[0] } }
            };

                    string cspkgSasUri = CreateCspkgSasUrl(rgName, WebRoleSasUri);
                    // Create CS 1
                    CreateVirtualNetwork(rgName, vnetName, subnetName);
                    CreatePublicIP(publicIPAddressName, rgName, dnsName);
                    CloudService cloudService1 = GenerateCloudServiceWithNetworkProfile(
                        resourceGroupName: rgName,
                        serviceName: cloudServiceName,
                        cspkgSasUri: cspkgSasUri,
                        roleNameToPropertiesMapping: roleNameToPropertiesMapping,
                                publicIPAddressName: publicIPAddressName,
                                vnetName: vnetName,
                                subnetName: subnetName,
                                lbName: lbName,
                                lbFrontendName: lbfeName);
                    CloudService getResponse1 = CreateCloudService_NoAsyncTracking(
                    rgName,
                    csName1,
                    cloudService1);

                    // Create CS 2
                    CreateVirtualNetwork(rgName, vnetName2, subnetName2);
                    CreatePublicIP(publicIPAddressName2, rgName, dnsName2);
                    CloudService cloudService2 = GenerateCloudServiceWithNetworkProfile(
                        resourceGroupName: rgName,
                        serviceName: cloudServiceName,
                        cspkgSasUri: cspkgSasUri,
                        roleNameToPropertiesMapping: roleNameToPropertiesMapping,
                                publicIPAddressName: publicIPAddressName2,
                                vnetName: vnetName2,
                                subnetName: subnetName2,
                                lbName: lbName2,
                                lbFrontendName: lbfeName2);
                    CloudService getResponse2 = CreateCloudService_NoAsyncTracking(
                    rgName,
                    csName2,
                    cloudService2);

                    // List By ResourceGroup
                    IPage<CloudService> cloudServiceListInRG = m_CrpClient.CloudServices.List(rgName);
                    Assert.True(cloudServiceListInRG.Count() == 2, "Returned CloudService list does not have two CloudServices");
                    Assert.Null(cloudServiceListInRG.NextPageLink);
                    foreach (CloudService cs in cloudServiceListInRG)
                    {
                        Assert.True(cs.Name == csName1 || cs.Name == csName2);
                        ValidateCloudService(cs.Name == csName1 ? cloudService1 : cloudService2, cs, rgName, cs.Name);
                    }

                    // Create resources in RG 2
                    CreateVirtualNetwork(rgName2, vnetName3, subnetName3);
                    CreatePublicIP(publicIPAddressName3, rgName2, dnsName3);

                    // Create CS 3
                    CloudService cloudService3 = GenerateCloudServiceWithNetworkProfile(
                        resourceGroupName: rgName2,
                        serviceName: cloudServiceName,
                        cspkgSasUri: cspkgSasUri,
                        roleNameToPropertiesMapping: roleNameToPropertiesMapping,
                                publicIPAddressName: publicIPAddressName3,
                                vnetName: vnetName3,
                                subnetName: subnetName3,
                                lbName: lbName3,
                                lbFrontendName: lbfeName3);

                    CloudService getResponse3 = CreateCloudService_NoAsyncTracking(
                    rgName2,
                    csName3,
                    cloudService3);

                    // List By Subscription
                    IPage<CloudService> cloudServiceListInSub = m_CrpClient.CloudServices.ListAll();
                    //Assert.NotNull(cloudServiceListInSub.NextPageLink);
                    int count = 0;
                    while (count < 3)
                    {
                        foreach (CloudService cs in cloudServiceListInSub)
                        {
                            if (cs.Name == csName1 || cs.Name == csName2 || cs.Name == csName3)
                            {
                                ValidateCloudService(cs.Name == csName1 ? cloudService1 : cs.Name == csName2 ? cloudService2 : cloudService3, cs,
                                    cs.Name == csName1 || cs.Name == csName2 ? rgName : rgName2, cs.Name);
                                count++;
                            }
                        }
                        if (cloudServiceListInSub.NextPageLink != null)
                        {
                            cloudServiceListInSub = m_CrpClient.CloudServices.ListAllNext(cloudServiceListInSub.NextPageLink);
                        }
                        else
                        {
                            break;
                        }
                    }

                    // Assert that all 3 CS has been returned
                    Assert.True(count == 3);

                }
                finally
                {
                    // Fire and forget. No need to wait for RG deletion completion
                    try
                    {
                        m_ResourcesClient.ResourceGroups.BeginDelete(rgName);
                        m_ResourcesClient.ResourceGroups.BeginDelete(rgName2);
                    }
                    catch (Exception e)
                    {
                        // Swallow this exception so that the original exception is thrown
                        Console.WriteLine(e);
                    }
                }
            }
        }

    }
}
