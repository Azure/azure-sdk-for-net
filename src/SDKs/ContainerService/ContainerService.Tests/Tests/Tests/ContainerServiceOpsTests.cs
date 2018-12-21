// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using ContainerService.Tests;
using Microsoft.Azure.Management.ContainerService;
using Microsoft.Azure.Management.ContainerService.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.ContainerService.Tests
{
    public partial class ContainerServiceTests : TestBase
    {
        /// <summary>
        /// Test the listing of container orchestrators.
        /// </summary>
        [Fact]
        public async Task ContainerServiceListOrchestratorsTest()
        {
            using (MockContext context = MockContext.Start(GetType().FullName))
            {
                InitializeClients(context);

                var location = ContainerServiceTestUtilities.GetLocationFromProvider(ResourceManagementClient);

                var resourceGroup = ResourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(ContainerServiceTestUtilities.ResourceGroupPrefix);
                    ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                var orchestratorsListResult = await ContainerServiceClient.ContainerServices.ListOrchestratorsAsync(location);
                
                Assert.NotNull(orchestratorsListResult);
                Assert.True(orchestratorsListResult.Orchestrators.Count > 0);
            }
        }

        /// <summary>
        /// Test the creation of a managed cluster.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ContainerServiceCreateManagedServiceTest()
        {
            using (MockContext context = MockContext.Start(GetType().FullName))
            {
                InitializeClients(context);

                string location = ContainerServiceTestUtilities.GetLocationFromProvider(resourceManagementClient);

                var resourceGroup = resourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(ContainerServiceTestUtilities.ResourceGroupPrefix);
                    resourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                string clusterName = TestUtilities.GenerateName();

                // Create a managed AKS cluster
                ManagedCluster managedClusterResult = await CreateManagedCluster(
                    ResourceManagementClient, 
                    ContainerServiceClient,
                    location,
                    clusterName,
                    resourceGroup);

                try
                {
                    Assert.NotNull(managedClusterResult);
                    Assert.Equal(clusterName, managedClusterResult.Name);
                    Assert.Equal(ContainerServiceTestUtilities.DnsPrefix, managedClusterResult.DnsPrefix);
                }
                catch (Exception) { throw; }
                finally
                {
                    // Block to clean up our test resources via ResourceGroup deletion
                    ResourceManagementClient.ResourceGroups.Delete(resourceGroup);
                }
            }
        }

        /// <summary>
        /// CreateManagedCluster creates an AKS managed cluster
        /// </summary>
        /// <param name="resourceManagementClient"></param>
        /// <param name="containerServiceClient"></param>
        /// <param name="location"></param>
        /// <param name="clusterName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns></returns>
        internal async static Task<ManagedCluster> CreateManagedCluster(
            ResourceManagementClient resourceManagementClient,
            ContainerServiceClient containerServiceClient,
            string location,
            string clusterName,
            string resourceGroupName)
        {

            var servicePrincipalProfile = new ManagedClusterServicePrincipalProfile
            {
                ClientId = Environment.GetEnvironmentVariable("AKS_DEV_SPID"),
                Secret = Environment.GetEnvironmentVariable("AKS_DEV_SP_SECRET")
            };

            var agentPoolProfiles = new List<ManagedClusterAgentPoolProfile>
                {
                    new ManagedClusterAgentPoolProfile
                    {
                        Name = ContainerServiceTestUtilities.AgentPoolProfileName,
                        VmSize = ContainerServiceTestUtilities.VMSize,
                        Count = 1
                    }
                };

            ManagedCluster desiredManagedCluster = new ManagedCluster
            {
                DnsPrefix = ContainerServiceTestUtilities.DnsPrefix,
                Location = location,
                AgentPoolProfiles = agentPoolProfiles,
                ServicePrincipalProfile = servicePrincipalProfile
            };
            
            return await containerServiceClient.ManagedClusters.CreateOrUpdateAsync(resourceGroupName, clusterName, desiredManagedCluster);
        }
    }
}
