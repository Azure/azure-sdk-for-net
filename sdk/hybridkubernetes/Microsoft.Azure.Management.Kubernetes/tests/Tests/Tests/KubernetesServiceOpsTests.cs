// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using Microsoft.Kubernetes;
using Microsoft.Kubernetes.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace KubernetesService.Tests
{
    public partial class KubernetesServiceTests : TestBase
    {
        /// <summary>
        /// Test the creation of a connected cluster.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateConnectedClusterTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                InitializeClients(context);

                string location = KubernetesServiceTestUtilities.GetLocationFromProvider(resourceManagementClient);

                var resourceGroup = resourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(KubernetesServiceTestUtilities.ResourceGroupPrefix);
                    resourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                string clusterName = TestUtilities.GenerateName();

                // Create a connected cluster
                ConnectedCluster connectedClusterResult = await KubernetesServiceTestUtilities.CreateConnectedCluster(
                    context,
                    ResourceManagementClient,
                    ConnectedKubernetesClient,
                    location,
                    clusterName,
                    resourceGroup);

                Assert.NotNull(connectedClusterResult);
                Assert.Equal(clusterName, connectedClusterResult.Name);
                Assert.Equal(connectedClusterResult.ProvisioningState, ProvisioningState.Succeeded);

                // Clean up our Azure resources
                ResourceManagementClient.ResourceGroups.DeleteAsync(resourceGroup).Wait();
            }
        }

        /// <summary>
        /// Test the listClusterUserCredential API of connected cluster with CSP = true & auth method = AAD.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ListClusterUserCredentialCSPAADTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                InitializeClients(context);

                string location = KubernetesServiceTestUtilities.GetLocationFromProvider(resourceManagementClient);
                ListClusterUserCredentialProperties listClusterUserCredentialProperties = new ListClusterUserCredentialProperties("AAD", true);
                var resourceGroup = resourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(KubernetesServiceTestUtilities.ResourceGroupPrefix);
                    resourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                string clusterName = TestUtilities.GenerateName();

                // Create a connected cluster
                ConnectedCluster connectedClusterResult = await KubernetesServiceTestUtilities.CreateConnectedCluster(
                    context,
                    ResourceManagementClient,
                    ConnectedKubernetesClient,
                    location,
                    clusterName,
                    resourceGroup);

                Assert.NotNull(connectedClusterResult);
                Assert.Equal(clusterName, connectedClusterResult.Name);
                Assert.Equal(connectedClusterResult.ProvisioningState, ProvisioningState.Succeeded);

                CredentialResults credentialResults = await kubernetesServiceClient.ConnectedCluster.ListClusterUserCredentialAsync(resourceGroup, clusterName, listClusterUserCredentialProperties);

                Assert.NotNull(credentialResults);
                Assert.NotNull(credentialResults.HybridConnectionConfig);
                Assert.NotNull(credentialResults.Kubeconfigs);

                // Clean up our Azure resources
                ResourceManagementClient.ResourceGroups.DeleteAsync(resourceGroup).Wait();
            }
        }

        /// <summary>
        /// Test the listClusterUserCredential API of connected cluster with CSP = true & auth method = Token
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ListClusterUserCredentialCSPTokenTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                InitializeClients(context);

                string location = KubernetesServiceTestUtilities.GetLocationFromProvider(resourceManagementClient);
                ListClusterUserCredentialProperties listClusterUserCredentialProperties = new ListClusterUserCredentialProperties("Token", true);
                var resourceGroup = resourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(KubernetesServiceTestUtilities.ResourceGroupPrefix);
                    resourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                string clusterName = TestUtilities.GenerateName();

                // Create a connected cluster
                ConnectedCluster connectedClusterResult = await KubernetesServiceTestUtilities.CreateConnectedCluster(
                    context,
                    ResourceManagementClient,
                    ConnectedKubernetesClient,
                    location,
                    clusterName,
                    resourceGroup);

                Assert.NotNull(connectedClusterResult);
                Assert.Equal(clusterName, connectedClusterResult.Name);
                Assert.Equal(connectedClusterResult.ProvisioningState, ProvisioningState.Succeeded);

                CredentialResults credentialResults = await kubernetesServiceClient.ConnectedCluster.ListClusterUserCredentialAsync(resourceGroup, clusterName, listClusterUserCredentialProperties);

                Assert.NotNull(credentialResults);
                Assert.NotNull(credentialResults.HybridConnectionConfig);
                Assert.NotNull(credentialResults.Kubeconfigs);

                // Clean up our Azure resources
                ResourceManagementClient.ResourceGroups.DeleteAsync(resourceGroup).Wait();
            }
        }

        /// <summary>
        /// Test the listClusterUserCredential API of connected cluster with CSP = false & auth method = Token
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ListClusterUserCredentialHPTokenTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                InitializeClients(context);

                string location = KubernetesServiceTestUtilities.GetLocationFromProvider(resourceManagementClient);
                ListClusterUserCredentialProperties listClusterUserCredentialProperties = new ListClusterUserCredentialProperties("Token", false);
                var resourceGroup = resourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(KubernetesServiceTestUtilities.ResourceGroupPrefix);
                    resourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                string clusterName = TestUtilities.GenerateName();

                // Create a connected cluster
                ConnectedCluster connectedClusterResult = await KubernetesServiceTestUtilities.CreateConnectedCluster(
                    context,
                    ResourceManagementClient,
                    ConnectedKubernetesClient,
                    location,
                    clusterName,
                    resourceGroup);

                Assert.NotNull(connectedClusterResult);
                Assert.Equal(clusterName, connectedClusterResult.Name);
                Assert.Equal(connectedClusterResult.ProvisioningState, ProvisioningState.Succeeded);

                CredentialResults credentialResults = await kubernetesServiceClient.ConnectedCluster.ListClusterUserCredentialAsync(resourceGroup, clusterName, listClusterUserCredentialProperties);

                Assert.NotNull(credentialResults);
                Assert.NotNull(credentialResults.Kubeconfigs);

                // Clean up our Azure resources
                ResourceManagementClient.ResourceGroups.DeleteAsync(resourceGroup).Wait();
            }
        }

        /// <summary>
        /// Test the listClusterUserCredential API of connected cluster with CSP = false & auth method = AAD
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ListClusterUserCredentialHPAADTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                InitializeClients(context);

                string location = KubernetesServiceTestUtilities.GetLocationFromProvider(resourceManagementClient);
                ListClusterUserCredentialProperties listClusterUserCredentialProperties = new ListClusterUserCredentialProperties("AAD", false);
                var resourceGroup = resourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(KubernetesServiceTestUtilities.ResourceGroupPrefix);
                    resourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                string clusterName = TestUtilities.GenerateName();

                // Create a connected cluster
                ConnectedCluster connectedClusterResult = await KubernetesServiceTestUtilities.CreateConnectedCluster(
                    context,
                    ResourceManagementClient,
                    ConnectedKubernetesClient,
                    location,
                    clusterName,
                    resourceGroup);

                Assert.NotNull(connectedClusterResult);
                Assert.Equal(clusterName, connectedClusterResult.Name);
                Assert.Equal(connectedClusterResult.ProvisioningState, ProvisioningState.Succeeded);

                CredentialResults credentialResults = await kubernetesServiceClient.ConnectedCluster.ListClusterUserCredentialAsync(resourceGroup, clusterName, listClusterUserCredentialProperties);

                Assert.NotNull(credentialResults);
                Assert.NotNull(credentialResults.Kubeconfigs);

                // Clean up our Azure resources
                ResourceManagementClient.ResourceGroups.DeleteAsync(resourceGroup).Wait();
            }
        }

        /// <summary>
        /// Test the deletion of an connected cluster
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task DeleteConnectedClusterTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                InitializeClients(context);

                string location = KubernetesServiceTestUtilities.GetLocationFromProvider(resourceManagementClient);

                var resourceGroup = resourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(KubernetesServiceTestUtilities.ResourceGroupPrefix);
                    resourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                string clusterName = TestUtilities.GenerateName();

                // Create a connected cluster
                ConnectedCluster managedClusterResult = await KubernetesServiceTestUtilities.CreateConnectedCluster(
                    context,
                    ResourceManagementClient,
                    ConnectedKubernetesClient,
                    location,
                    clusterName,
                    resourceGroup);

                // Wait for 10 seconds a sanity check
                TestUtilities.Wait(10000);

                // Delete the cluster
                kubernetesServiceClient.ConnectedCluster.DeleteAsync(resourceGroup, clusterName).Wait();

                // List clusters by resource group
                var listConnectedCluster = await kubernetesServiceClient.ConnectedCluster.ListByResourceGroupAsync(resourceGroup);

                Assert.True(!listConnectedCluster.IsAny());

                // Clean up our Azure resources
                ResourceManagementClient.ResourceGroups.DeleteAsync(resourceGroup).Wait();
            }
        }
    }
}
