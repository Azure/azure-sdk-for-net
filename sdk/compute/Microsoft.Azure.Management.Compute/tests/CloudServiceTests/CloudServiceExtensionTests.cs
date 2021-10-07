// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
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
    public class CloudServiceExtensionTests : CloudServiceTestsBase
    {
        [Fact]
        [Trait("Name", "MultiRole_CreateUpdateGetAndDeleteWithExtension_WorkerAndWebRole")]
        public void MultiRole_CreateUpdateGetAndDeleteWithExtension_WorkerAndWebRole()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                // Create resource group
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var csName = TestUtilities.GenerateName("cs");
                string cloudServiceName = "TestCloudServiceMultiRole";
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


                    ///
                    /// Create: Create a multi-role CloudService with 2 WorkerRoles, 1 WebRole, and RDP Extension.
                    ///

                    string rdpExtensionPublicConfig = "<PublicConfig>" +
                                                        "<UserName>adminRdpTest</UserName>" +
                                                        "<Expiration>2021-10-27T23:59:59</Expiration>" +
                                                     "</PublicConfig>";
                    string rdpExtensionPrivateConfig = "<PrivateConfig>" +
                                                          "<Password>VsmrdpTest!</Password>" +
                                                       "</PrivateConfig>";

                    Extension rdpExtension = CreateExtension("RDPExtension", "Microsoft.Windows.Azure.Extensions", "RDP", "1.2.1", autoUpgrade: true,
                                                                                                      publicConfig: rdpExtensionPublicConfig,
                                                                                                      privateConfig: rdpExtensionPrivateConfig);
                    // Define Configurations
                    List<string> supportedRoleInstanceSizes = GetSupportedRoleInstanceSizes();
                    Dictionary<string, RoleConfiguration> roleNameToPropertiesMapping = new Dictionary<string, RoleConfiguration>
            {
                { "WorkerRole1", new RoleConfiguration { InstanceCount = 1, RoleInstanceSize = supportedRoleInstanceSizes[0] } },
                { "WorkerRole2", new RoleConfiguration { InstanceCount = 1, RoleInstanceSize = supportedRoleInstanceSizes[1] } },
                { "WebRole1", new RoleConfiguration { InstanceCount = 2, RoleInstanceSize = supportedRoleInstanceSizes[3] } }
            };

                    // Generate the request
                    CloudService cloudService = GenerateCloudServiceWithNetworkProfile(
                        resourceGroupName: rgName,
                        serviceName: cloudServiceName,
                        cspkgSasUri: CreateCspkgSasUrl(rgName, MultiRole2Worker1WebRolesPackageSasUri),
                        roleNameToPropertiesMapping: roleNameToPropertiesMapping,
                        publicIPAddressName: publicIPAddressName,
                        vnetName: vnetName,
                        subnetName: subnetName,
                        lbName: lbName,
                        lbFrontendName: lbfeName);

                    cloudService.Properties.ExtensionProfile = new CloudServiceExtensionProfile()
                    {
                        Extensions = new List<Extension>()
                    };
                    cloudService.Properties.ExtensionProfile.Extensions.Add(rdpExtension);

                    CloudService getResponse = CreateCloudService_NoAsyncTracking(
                            rgName,
                            csName,
                            cloudService);

                    // Validate the response for multirole
                    ValidateGetAndListResponseForMultiRole(rgName, csName, cloudService, roleNameToPropertiesMapping);

                    ///
                    /// Update[1]: Delete RDP Extension, and Add Monitor Extension.
                    ///

                    Extension monitorExtension = CreateExtension("MonitoringExtension", "Microsoft.Azure.Security", "Monitoring", "3.1.0.0");
                    cloudService.Properties.ExtensionProfile = new CloudServiceExtensionProfile()
                    {
                        Extensions = new List<Extension>()
                    };
                    cloudService.Properties.ExtensionProfile.Extensions.Add(monitorExtension);

                    getResponse = CreateCloudService_NoAsyncTracking(
                            rgName,
                            csName,
                            cloudService);

                    // Send the request
                    ValidateGetAndListResponseForMultiRole(rgName, csName, cloudService, roleNameToPropertiesMapping);

                    ///
                    /// Update[2]: Delete Monitor Extension
                    ///

                    cloudService.Properties.ExtensionProfile = null;
                    getResponse = CreateCloudService_NoAsyncTracking(
                            rgName,
                            csName,
                            cloudService);

                    // Send the request
                    ValidateGetAndListResponseForMultiRole(rgName, csName, cloudService, roleNameToPropertiesMapping);

                    ///
                    /// Delete the CloudService
                    ///

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
        [Trait("Name", "MultiRole_CreateUpdateGetAndDeleteWithExtension_WorkerAndWebRole_MultiRoleExtension")]
        public void MultiRole_CreateUpdateGetAndDeleteWithExtension_WorkerAndWebRole_MultiRoleExtension()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                // Create resource group
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var csName = TestUtilities.GenerateName("cs");
                string cloudServiceName = "TestCloudServiceMultiRole";
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


                    ///
                    /// Create: Create a multi-role CloudService with 2 WorkerRoles, 1 WebRole, and RDP Extension.
                    ///

                    string rdpExtensionPublicConfig = "<PublicConfig>" +
                                                        "<UserName>adminRdpTest</UserName>" +
                                                        "<Expiration>2021-10-27T23:59:59</Expiration>" +
                                                     "</PublicConfig>";
                    string rdpExtensionPrivateConfig = "<PrivateConfig>" +
                                                          "<Password>VsmrdpTest!</Password>" +
                                                       "</PrivateConfig>";

                    Extension rdpExtension = CreateExtension("RDPExtension", "Microsoft.Windows.Azure.Extensions", "RDP", "1.2.1", autoUpgrade: true,
                                                                                                      publicConfig: rdpExtensionPublicConfig,
                                                                                                      privateConfig: rdpExtensionPrivateConfig);
                    // Define Configurations
                    List<string> supportedRoleInstanceSizes = GetSupportedRoleInstanceSizes();
                    Dictionary<string, RoleConfiguration> roleNameToPropertiesMapping = new Dictionary<string, RoleConfiguration>
            {
                { "WorkerRole1", new RoleConfiguration { InstanceCount = 1, RoleInstanceSize = supportedRoleInstanceSizes[0] } },
                { "WorkerRole2", new RoleConfiguration { InstanceCount = 1, RoleInstanceSize = supportedRoleInstanceSizes[1] } },
                { "WebRole1", new RoleConfiguration { InstanceCount = 2, RoleInstanceSize = supportedRoleInstanceSizes[3] } }
            };

                    // Generate the request
                    CloudService cloudService = GenerateCloudServiceWithNetworkProfile(
                        resourceGroupName: rgName,
                        serviceName: cloudServiceName,
                        cspkgSasUri: CreateCspkgSasUrl(rgName, MultiRole2Worker1WebRolesPackageSasUri),
                        roleNameToPropertiesMapping: roleNameToPropertiesMapping,
                        publicIPAddressName: publicIPAddressName,
                        vnetName: vnetName,
                        subnetName: subnetName,
                        lbName: lbName,
                        lbFrontendName: lbfeName);

                    cloudService.Properties.ExtensionProfile = new CloudServiceExtensionProfile()
                    {
                        Extensions = new List<Extension>()
                    };
                    cloudService.Properties.ExtensionProfile.Extensions.Add(rdpExtension);

                    CloudService getResponse = CreateCloudService_NoAsyncTracking(
                            rgName,
                            csName,
                            cloudService);

                    // Send the request
                    ValidateGetAndListResponseForMultiRole(rgName, csName, cloudService, roleNameToPropertiesMapping);

                    // Validate the RDP file response
                    VerifyRDPResponse("WorkerRole1_IN_0", rgName, csName);
                    VerifyRDPResponse("WorkerRole2_IN_0", rgName, csName);
                    VerifyRDPResponse("WebRole1_IN_0", rgName, csName);
                    VerifyRDPResponse("WebRole1_IN_1", rgName, csName);
                    ///
                    /// Update[1]: and Add Monitor Extension in WorkerRole1.
                    ///


                    Extension monitorExtension = CreateExtension("MonitoringExtension", "Microsoft.Azure.Security", "Monitoring", "3.1.0.0");
                    monitorExtension.Properties.RolesAppliedTo = new List<string>() { "WorkerRole1" };
                    cloudService.Properties.ExtensionProfile.Extensions.Add(monitorExtension);

                    getResponse = CreateCloudService_NoAsyncTracking(
                                    rgName,
                                    csName,
                                    cloudService);

                    // Send the request
                    ValidateGetAndListResponseForMultiRole(rgName, csName, cloudService, roleNameToPropertiesMapping);
                    ///
                    /// Update[2]: Delete RDPExtension from WorkerRole1,WebRole1
                    ///

                    cloudService.Properties.ExtensionProfile.Extensions.Remove(rdpExtension);
                    rdpExtension.Properties.RolesAppliedTo = new List<string>() { "WorkerRole2" };
                    cloudService.Properties.ExtensionProfile.Extensions.Add(rdpExtension);

                    getResponse = CreateCloudService_NoAsyncTracking(
                                    rgName,
                                    csName,
                                    cloudService);

                    ValidateCloudService(cloudService, getResponse, rgName, csName);
                    // Send the request
                    ValidateGetAndListResponseForMultiRole(rgName, csName, cloudService, roleNameToPropertiesMapping);
                    VerifyRDPResponse("WorkerRole2_IN_0", rgName, csName);
                    ///
                    /// Update[3]: Add MonitorExtension to all roles,
                    /// 
                    cloudService.Properties.ExtensionProfile.Extensions.Remove(monitorExtension);
                    monitorExtension.Properties.RolesAppliedTo = new List<string>() { "*" };
                    cloudService.Properties.ExtensionProfile.Extensions.Add(monitorExtension);

                    getResponse = CreateCloudService_NoAsyncTracking(
                                    rgName,
                                    csName,
                                    cloudService);

                    ValidateCloudService(cloudService, getResponse, rgName, csName);
                    // Send the request
                    ValidateGetAndListResponseForMultiRole(rgName, csName, cloudService, roleNameToPropertiesMapping);

                    ///
                    /// Update[4]: Delete MonitorExtension from all roles
                    ///

                    cloudService.Properties.ExtensionProfile.Extensions.Remove(monitorExtension);


                    getResponse = CreateCloudService_NoAsyncTracking(
                                    rgName,
                                    csName,
                                    cloudService);

                    ValidateCloudService(cloudService, getResponse, rgName, csName);
                    // Send the request
                    ValidateGetAndListResponseForMultiRole(rgName, csName, cloudService, roleNameToPropertiesMapping);
                    ///
                    /// Delete the CloudService
                    ///

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

        private void ValidateGetAndListResponseForMultiRole(string rgName, string csName, CloudService modelCloudService, Dictionary<string, RoleConfiguration> roleNameToPropertiesMapping, bool verifyRolesAppliedTo = false)
        {
            Assert.NotNull(modelCloudService);
            Assert.NotNull(roleNameToPropertiesMapping);

            var returnedCloudService = m_CrpClient.CloudServices.Get(rgName, csName);
            Assert.Equal(returnedCloudService.Properties.ProvisioningState, ProvisioningState.Succeeded);
            ValidateCloudServiceRoleProfile(returnedCloudService.Properties.RoleProfile, modelCloudService.Properties.RoleProfile);

            if (modelCloudService.Properties.ExtensionProfile != null && modelCloudService.Properties.ExtensionProfile.Extensions.Count > 0)
            {
                VerifyExtensionsAreSame(
                    modelCloudService.Properties.ExtensionProfile.Extensions,
                    returnedCloudService.Properties.ExtensionProfile.Extensions,
                    verifyRolesAppliedTo: verifyRolesAppliedTo); // also verify rolesAppliedTo if required
            }

            // Now verify by calling instances API to assert we have two instances
            IPage<RoleInstance> cloudServiceRoleInstances = m_CrpClient.CloudServiceRoleInstances.List(rgName, csName);

            Dictionary<string, string> expectedRoleInstanceNameMappedWithSkuName = new Dictionary<string, string>();
            foreach (string roleName in roleNameToPropertiesMapping.Keys)
            {
                int roleInstanceCount = (int)roleNameToPropertiesMapping[roleName].InstanceCount;
                for (int i = 0; i < roleInstanceCount; i++)
                {
                    expectedRoleInstanceNameMappedWithSkuName.Add($"{roleName}_IN_{i}", roleNameToPropertiesMapping[roleName].RoleInstanceSize);
                }
            }

            VerifyCloudServiceRoleInstanceResponseMatchesExpected(cloudServiceRoleInstances, expectedRoleInstanceNameMappedWithSkuName);
        }

        private void VerifyCloudServiceRoleInstanceResponseMatchesExpected(IPage<RoleInstance> roleInstanceList, Dictionary<string, string> expectedRoleInstanceNameMappedWithSkuName)
        {
            Assert.NotNull(roleInstanceList);
            Assert.True(expectedRoleInstanceNameMappedWithSkuName.Count == roleInstanceList.Count(), "CloudService RoleInstances count should match");

            foreach (RoleInstance roleInstance in roleInstanceList)
            {
                Assert.True(expectedRoleInstanceNameMappedWithSkuName.ContainsKey(roleInstance.Name), "Returned RoleInstance Name should be present in Expected RoleInstance Names");
                Assert.True(expectedRoleInstanceNameMappedWithSkuName[roleInstance.Name] == roleInstance.Sku.Name, "RoleInstance Sku should match expected sku");
                expectedRoleInstanceNameMappedWithSkuName.Remove(roleInstance.Name);
            }
        }

        private void VerifyRDPResponse(string roleInstanceName, string rgName, string cloudServiceName)
        {
            //Call GetRemoteDesktopFile for RoleInstance: {roleInstanceName} of CloudService: {cloudServiceName}"
            Stream rdpResponse = m_CrpClient.CloudServiceRoleInstances.GetRemoteDesktopFile(roleInstanceName, rgName, cloudServiceName);
            Assert.True(rdpResponse.Length > 0, "ContentLength should be > 0.");
        }
    }
}
