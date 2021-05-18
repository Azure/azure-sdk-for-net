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
    public class CloudServiceUpdateTests : CloudServiceTestsBase
    {
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Network Resources
        /// Create CloudService
        /// Update CloudService
        /// Delete CloudService
        /// Delete RG
        /// </summary>
        [Fact]
        [Trait("Name", "TestCloudServiceUpdateOperations")]
        public void TestCloudServiceUpdateOperations()
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
                    /// Create: Create a multi-role CloudService with 2 WorkerRoles and 1 WebRole
                    ///

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

                    CloudService getResponse = CreateCloudService_NoAsyncTracking(
                    rgName,
                    csName,
                    cloudService);

                    ///
                    /// Update[1]: Delete WorkerRole1, ScaleUp WorkerRole2 and ScaleIn WebRole1
                    ///

                    roleNameToPropertiesMapping = new Dictionary<string, RoleConfiguration>
            {
                /// Delete WorkerRole1
                /// { "WorkerRole1", new RoleConfiguration { InstanceCount = 1, RoleInstanceSize = supportedRoleInstanceSizes[0] } },
                /// Scale-Up WorkerRole2
                { "WorkerRole2", new RoleConfiguration { InstanceCount = 1, RoleInstanceSize = supportedRoleInstanceSizes[0] } },
                /// Scale-In WebRole1
                { "WebRole1", new RoleConfiguration { InstanceCount = 1, RoleInstanceSize = supportedRoleInstanceSizes[3] } }
            };

                    cloudService = GenerateCloudServiceWithNetworkProfile(
                        resourceGroupName: rgName,
                        serviceName: cloudServiceName,
                        cspkgSasUri: CreateCspkgSasUrl(rgName, MultiRole1Worker1WebRolesPackageSasUri),
                        roleNameToPropertiesMapping: roleNameToPropertiesMapping,
                        publicIPAddressName: publicIPAddressName,
                        vnetName: vnetName,
                        subnetName: subnetName,
                        lbName: lbName,
                        lbFrontendName: lbfeName);

                    CloudServiceExtensionProfile extensionProfile = new CloudServiceExtensionProfile()
                    {
                        Extensions = new List<Extension>() { CreateRDPExtension("RDPExtension") }
                    };

                    cloudService.Properties.ExtensionProfile = extensionProfile;

                    UpdateCloudService(rgName, csName, cloudService);

                    var getUpdatedResponse = m_CrpClient.CloudServices.Get(rgName, csName);
                    ValidateCloudService(cloudService, getUpdatedResponse, rgName, csName);

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

        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Network Resources
        /// Create CloudService
        /// ScaleOut CloudService
        /// ScaleIn CloudService
        /// Delete CloudService
        /// Delete RG
        /// </summary>
        [Fact]
        public void TestCloudServiceOperations_ScaleIn_ScaleOut()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                // Create resource group
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var csName = TestUtilities.GenerateName("cs");
                string cloudServiceName = "HelloWorldTest_WorkerRoleWithEndpoint";
                string publicIPAddressName = TestUtilities.GenerateName("cspip");
                string vnetName = TestUtilities.GenerateName("csvnet");
                string subnetName = TestUtilities.GenerateName("subnet");
                string dnsName = TestUtilities.GenerateName("dns");
                string lbName = TestUtilities.GenerateName("lb");
                string lbfeName = TestUtilities.GenerateName("lbfe");
                const string welcomeMessage = "Hello world from PaaS CloudService!";


                try
                {
                    CreateVirtualNetwork(rgName, vnetName, subnetName);
                    PublicIPAddress publicIPAddress = CreatePublicIP(publicIPAddressName, rgName, dnsName);
                    #region Create new PaaS CloudService
                    Dictionary<string, string> roleSettings = new Dictionary<string, string>
                {
                    { "Application.WelcomeString", welcomeMessage }
                };

                    List<string> supportedRoleInstanceSizes = GetSupportedRoleInstanceSizes();
                    Dictionary<string, RoleConfiguration> roleNameToPropertiesMapping = new Dictionary<string, RoleConfiguration>
                {
                    { "WorkerRole1", new RoleConfiguration { InstanceCount = 1, RoleInstanceSize = supportedRoleInstanceSizes[0], Settings = roleSettings } }
                };
                    string cspkgSasUri = CreateCspkgSasUrl(rgName, WorkerRoleWithInputEndpointSasUri);
                    CloudService cloudService = GenerateCloudServiceWithNetworkProfile(
                        serviceName: cloudServiceName,
                        cspkgSasUri: cspkgSasUri,
                        resourceGroupName: rgName,
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

                    #endregion

                    #region Update existing PaaS CloudService with new value for role setting
                    const string updatedWelcomeMessage = "Hello world from updated PaaS CloudService!";
                    Dictionary<string, string> updatedRoleSettings = new Dictionary<string, string>
                {
                    { "Application.WelcomeString", updatedWelcomeMessage }
                };

                    roleNameToPropertiesMapping = new Dictionary<string, RoleConfiguration>
                {
                    { "WorkerRole1", new RoleConfiguration { InstanceCount = 1, RoleInstanceSize = supportedRoleInstanceSizes[0], Settings = updatedRoleSettings } }
                };

                    cloudService = GenerateCloudServiceWithNetworkProfile(serviceName: cloudServiceName,
                        cspkgSasUri: cspkgSasUri,
                        resourceGroupName: rgName,
                        roleNameToPropertiesMapping: roleNameToPropertiesMapping,
                        publicIPAddressName: publicIPAddressName,
                        vnetName: vnetName,
                        subnetName: subnetName,
                        lbName: lbName,
                        lbFrontendName: lbfeName);

                    getResponse = CreateCloudService_NoAsyncTracking(
                    rgName,
                    csName,
                    cloudService);
                    #endregion

                    #region Scale-out existing PaaS CloudService

                    roleNameToPropertiesMapping = new Dictionary<string, RoleConfiguration>
                {
                    { "WorkerRole1", new RoleConfiguration { InstanceCount = 2, RoleInstanceSize = supportedRoleInstanceSizes[0], Settings = roleSettings } }
                };

                    cloudService = GenerateCloudServiceWithNetworkProfile(serviceName: cloudServiceName,
                        cspkgSasUri: cspkgSasUri,
                        resourceGroupName: rgName,
                        roleNameToPropertiesMapping: roleNameToPropertiesMapping,
                        publicIPAddressName: publicIPAddressName,
                        vnetName: vnetName,
                        subnetName: subnetName,
                        lbName: lbName,
                        lbFrontendName: lbfeName);

                    getResponse = CreateCloudService_NoAsyncTracking(
                    rgName,
                    csName,
                    cloudService);

                    // Now verify by calling instances API to assert we have two instances
                    IPage<RoleInstance> roleInstanceList = m_CrpClient.CloudServiceRoleInstances.List(rgName, csName);
                    Assert.True(roleInstanceList.Count() == 2, "Returned CloudService does not have two RoleInstance. Postcondition failed.");
                    #endregion

                    #region Scale-in existing PaaS CloudService
                    roleNameToPropertiesMapping = new Dictionary<string, RoleConfiguration>
                {
                    { "WorkerRole1", new RoleConfiguration { InstanceCount = 1, RoleInstanceSize = supportedRoleInstanceSizes[0], Settings = roleSettings } }
                };

                    cloudService = GenerateCloudServiceWithNetworkProfile(serviceName: cloudServiceName,
                        cspkgSasUri: cspkgSasUri,
                        resourceGroupName: rgName,
                        roleNameToPropertiesMapping: roleNameToPropertiesMapping,
                        publicIPAddressName: publicIPAddressName,
                        vnetName: vnetName,
                        subnetName: subnetName,
                        lbName: lbName,
                        lbFrontendName: lbfeName);
                    getResponse = CreateCloudService_NoAsyncTracking(
                    rgName,
                    csName,
                    cloudService);

                    // Now verify by calling instances API to assert we have one instance
                    roleInstanceList = m_CrpClient.CloudServiceRoleInstances.List(rgName, csName);
                    Assert.True(roleInstanceList.Count() == 1, "Returned CloudService does not have 1 RoleInstance. Postcondition failed.");
                    #endregion

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
