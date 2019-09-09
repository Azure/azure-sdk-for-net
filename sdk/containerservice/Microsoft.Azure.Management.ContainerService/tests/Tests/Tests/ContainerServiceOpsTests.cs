// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using Microsoft.Azure.Management.ContainerService;
using Microsoft.Azure.Management.ContainerService.Models;
using Microsoft.Azure.Management.Resources;
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
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                InitializeClients(context);

                var location = ContainerServiceTestUtilities.GetLocationFromProvider(ResourceManagementClient);

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
            using (MockContext context = MockContext.Start(this.GetType()))
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
                ManagedCluster managedClusterResult = await ContainerServiceTestUtilities.CreateManagedCluster(
                    context,
                    ResourceManagementClient,
                    ContainerServiceClient,
                    location,
                    clusterName,
                    resourceGroup);

                Assert.NotNull(managedClusterResult);
                Assert.Equal(clusterName, managedClusterResult.Name);
                Assert.Equal(ContainerServiceTestUtilities.DnsPrefix, managedClusterResult.DnsPrefix);

                // Clean up our Azure resources
                ResourceManagementClient.ResourceGroups.DeleteAsync(resourceGroup).Wait();
            }
        }

        /// <summary>
        /// Test an update to an AKS cluster
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ContainerServiceUpdateServiceTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
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
                ManagedCluster managedClusterResult = await ContainerServiceTestUtilities.CreateManagedCluster(
                    context,
                    ResourceManagementClient,
                    ContainerServiceClient,
                    location,
                    clusterName,
                    resourceGroup);

                // Alter the number of agents and invoke update
                managedClusterResult.AgentPoolProfiles[0].Count = 2;

                var updatedCluster = await ContainerServiceClient.ManagedClusters.CreateOrUpdateAsync(resourceGroup, clusterName, managedClusterResult);

                Assert.Equal(2, updatedCluster.AgentPoolProfiles[0].Count);
                Assert.Equal(clusterName, managedClusterResult.Name);

                // Clean up our Azure resources
                ResourceManagementClient.ResourceGroups.DeleteAsync(resourceGroup).Wait();
            }
        }

        /// <summary>
        /// Test the deletion of an AKS cluster
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ContainerServiceDeleteServiceTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
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
                ManagedCluster managedClusterResult = await ContainerServiceTestUtilities.CreateManagedCluster(
                    context,
                    ResourceManagementClient,
                    ContainerServiceClient,
                    location,
                    clusterName,
                    resourceGroup);

                // Wait for 10 seconds a sanity check
                TestUtilities.Wait(10000);

                // Delete the cluster
                containerServiceClient.ManagedClusters.DeleteAsync(resourceGroup, clusterName).Wait();

                // List clusters by resource group
                var managedService = await containerServiceClient.ManagedClusters.ListByResourceGroupAsync(resourceGroup);

                Assert.True(!managedService.IsAny());

                // Clean up our Azure resources
                ResourceManagementClient.ResourceGroups.DeleteAsync(resourceGroup).Wait();
            }
        }

        /// <summary>
        /// Test the fetching of cluster admin credentials
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ContainerListClusterAdminCredentialsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
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
                ManagedCluster managedClusterResult = ContainerServiceTestUtilities.CreateManagedCluster(
                    context,
                    ResourceManagementClient,
                    ContainerServiceClient,
                    location,
                    clusterName,
                    resourceGroup).Result;

                // Wait for 10 seconds a sanity check
                TestUtilities.Wait(10000);

                CredentialResults adminCredentials = await containerServiceClient.ManagedClusters.ListClusterAdminCredentialsAsync(resourceGroup, clusterName);

                Assert.True(adminCredentials.Kubeconfigs.Count > 0);
                Assert.True(!string.IsNullOrWhiteSpace(adminCredentials.Kubeconfigs[0].Name));

                // Clean up our Azure resources
                ResourceManagementClient.ResourceGroups.DeleteAsync(resourceGroup).Wait();
            }
        }

        /// <summary>
        /// Test the fetching of AKS cluster credentials
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ContainerServiceGetCredentialsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
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
                ManagedCluster managedClusterResult = await ContainerServiceTestUtilities.CreateManagedCluster(
                    context,
                    ResourceManagementClient,
                    ContainerServiceClient,
                    location,
                    clusterName,
                    resourceGroup);

                // Fetch admin credentials
                var adminCredentials = await containerServiceClient.ManagedClusters.ListClusterAdminCredentialsAsync(resourceGroup, clusterName);

                Assert.True(adminCredentials.Kubeconfigs.Count > 0);

                // Fetch user credentials
                var userCredentials = await containerServiceClient.ManagedClusters.ListClusterUserCredentialsAsync(resourceGroup, clusterName);

                Assert.True(userCredentials.Kubeconfigs.Count > 0);

                // Clean up our Azure resources
                ResourceManagementClient.ResourceGroups.DeleteAsync(resourceGroup).Wait();
            }
        }
    }
}
