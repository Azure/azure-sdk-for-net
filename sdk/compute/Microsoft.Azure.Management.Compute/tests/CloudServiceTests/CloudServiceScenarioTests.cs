// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Compute.Tests
{
    public class CloudServiceScenarioTests : CloudServiceTestsBase
    {
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Virtual Network
        /// Create Network Resources
        /// Create CloudService
        /// Get CloudService
        /// Get CloudService Instance View
        /// List CloudService in a RG
        /// Delete CloudService
        /// Delete RG
        /// </summary>
        [Fact]
        [Trait("Name", "TestCloudServiceScenarioOperations")]
        public void TestCloudServiceScenarioOperations()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                TestCloudServiceOperationsInternal(context);
            }

        }

        [Fact]
        [Trait("Name", "TestCloudServiceScenarioOperations_DeleteCloudService")]
        public void TestCloudServiceScenarioOperations_DeleteCloudService()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                TestCloudServiceOperationsInternal(context, deleteAsPartOfTest: true);
            }
        }

        [Fact]
        [Trait("Name", "TestCloudServiceScenarioOperations_ExtensionProfile")]
        public void TestCloudServiceScenarioOperations_ExtensionProfile()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                TestCloudServiceOperationsInternal(context, extensionProfile: new CloudServiceExtensionProfile()
                {
                    Extensions = new List<Extension>() { CreateRDPExtension("RDPExtension") }
                });
            }
        }

        [Fact]
        [Trait("Name", "TestCloudServiceScenarioOperations_AvailabilityZones")]
        public void TestCloudServiceScenarioOperations_AvailabilityZones()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                TestCloudServiceOperationsInternal(context, zones: new List<string>() { "1" });
            }
        }

        [Fact]
        [Trait("Name", "TestCloudServiceScenarioOperations_InstanceView")]
        public void TestCloudServiceScenarioOperations_InstanceView()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                TestCloudServiceOperationsInternal(context, validateInstanceView: true);
            }
        }

        private void TestCloudServiceOperationsInternal(MockContext context, CloudServiceExtensionProfile extensionProfile = null, bool validateInstanceView = false, bool deleteAsPartOfTest = false, List<string> zones = null)
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
                if (extensionProfile != null)
                {
                    cloudService.Properties.ExtensionProfile = extensionProfile;
                }
                cloudService.Zones = zones;

                CloudService getResponse = CreateCloudService_NoAsyncTracking(
                    rgName,
                    csName,
                    cloudService);

                if (validateInstanceView)
                {
                    var getInstanceViewResponse = m_CrpClient.CloudServices.GetInstanceView(rgName, csName);
                    Assert.NotNull(getInstanceViewResponse);
                    ValidateCloudServiceInstanceView(cloudService, getInstanceViewResponse);
                }

                ///
                /// Delete the CloudService
                ///
                if (deleteAsPartOfTest)
                {
                    m_CrpClient.CloudServices.Delete(rgName, csName);
                }
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
