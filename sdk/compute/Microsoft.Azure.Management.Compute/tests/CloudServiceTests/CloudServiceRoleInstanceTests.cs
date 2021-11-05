// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Compute.Tests
{
    public class CloudServiceRoleInstanceTests : CloudServiceTestsBase
    {
        [Fact]
        [Trait("Name", "Test_CloudServiceRoleInstanceOperations")]
        public void Test_CloudServiceRoleInstanceOperations()
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
                        { "HelloWorldTest1", new RoleConfiguration { InstanceCount = 2, RoleInstanceSize = supportedRoleInstanceSizes[0] } }
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

                    string roleInstanceName = getResponse.Properties.RoleProfile.Roles[0].Name + "_IN_0";
                    //Get the roleInstance
                    var roleInstance = m_CrpClient.CloudServiceRoleInstances.Get(roleInstanceName, rgName, csName);
                    verifyRoleInstance(roleInstanceName, supportedRoleInstanceSizes[0], roleInstance);

                    //Get the roleInstance InstanceView
                    var roleInstanceInstanceView = m_CrpClient.CloudServiceRoleInstances.GetInstanceView(roleInstanceName, rgName, csName);
                    verifyRoleInstanceInstanceView(roleInstanceInstanceView);

                    //Restart the roleInstance and verify response
                    m_CrpClient.CloudServiceRoleInstances.Restart(roleInstanceName, rgName, csName);
                    roleInstance = m_CrpClient.CloudServiceRoleInstances.Get(roleInstanceName, rgName, csName);
                    verifyRoleInstance(roleInstanceName, supportedRoleInstanceSizes[0], roleInstance);

                    //Reimage the roleInstance and verify response
                    m_CrpClient.CloudServiceRoleInstances.Reimage(roleInstanceName, rgName, csName);
                    roleInstance = m_CrpClient.CloudServiceRoleInstances.Get(roleInstanceName, rgName, csName);
                    verifyRoleInstance(roleInstanceName, supportedRoleInstanceSizes[0], roleInstance);

                    //Rebuild the roleInstance and verify response
                    m_CrpClient.CloudServiceRoleInstances.Rebuild(roleInstanceName, rgName, csName);
                    roleInstance = m_CrpClient.CloudServiceRoleInstances.Get(roleInstanceName, rgName, csName);
                    verifyRoleInstance(roleInstanceName, supportedRoleInstanceSizes[0], roleInstance);

                     //Delete the RoleInstance 
                    m_CrpClient.CloudServiceRoleInstances.Delete(roleInstanceName, rgName, csName);
                    IPage<RoleInstance> roleInstanceList = m_CrpClient.CloudServiceRoleInstances.List(rgName, csName);
                    Assert.True(roleInstanceList.Count() == 1, "Returned CloudService does not have 1 RoleInstance. Postcondition failed.");
                    
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
    }
}
