// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using System.Net;
using Microsoft.Azure.Management.ContainerInstance;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ContainerInstance.Tests
{
    /// <summary>
    /// Tests for container instance SDK.
    /// </summary>
    public class ContainerInstanceTests : TestBase
    {
        /// <summary>
        /// Test create container instance.
        /// </summary>
        [Fact]
        public void ContainerInstanceCreateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourceClient = ContainerInstanceTestUtilities.GetResourceManagementClient(context, handler);
                var containerInstanceClient = ContainerInstanceTestUtilities.GetContainerInstanceManagementClient(context, handler);

                var resourceGroup = ContainerInstanceTestUtilities.CreateResourceGroup(resourceClient);

                // Create container group.
                var containerGroupName = TestUtilities.GenerateName("acinetsdk");
                var containerGroup = ContainerInstanceTestUtilities.CreateTestContainerGroup(containerGroupName);

                // Verify created container group.
                var createdContainerGroup = containerInstanceClient.ContainerGroups.CreateOrUpdate(resourceGroup.Name, containerGroupName, containerGroup);
                ContainerInstanceTestUtilities.VerifyContainerGroupProperties(containerGroup, createdContainerGroup);
            }
        }

        /// <summary>
        /// Test get container instance.
        /// </summary>
        [Fact]
        public void ContainerInstanceGetTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourceClient = ContainerInstanceTestUtilities.GetResourceManagementClient(context, handler);
                var containerInstanceClient = ContainerInstanceTestUtilities.GetContainerInstanceManagementClient(context, handler);

                var resourceGroup = ContainerInstanceTestUtilities.CreateResourceGroup(resourceClient);

                // Create container group.
                var containerGroupName = TestUtilities.GenerateName("acinetsdk");
                var containerGroup = ContainerInstanceTestUtilities.CreateTestContainerGroup(containerGroupName);

                // Verify created container group.
                var createdContainerGroup = containerInstanceClient.ContainerGroups.CreateOrUpdate(resourceGroup.Name, containerGroupName, containerGroup);
                ContainerInstanceTestUtilities.VerifyContainerGroupProperties(containerGroup, createdContainerGroup);

                // Verifiy retrieved container group.
                var retrievedContainerGroup = containerInstanceClient.ContainerGroups.Get(resourceGroup.Name, containerGroupName);
                ContainerInstanceTestUtilities.VerifyContainerGroupProperties(containerGroup, retrievedContainerGroup);
            }
        }

        /// <summary>
        /// Test get container instance.
        /// </summary>
        [Fact]
        public void ContainerInstanceDeleteTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourceClient = ContainerInstanceTestUtilities.GetResourceManagementClient(context, handler);
                var containerInstanceClient = ContainerInstanceTestUtilities.GetContainerInstanceManagementClient(context, handler);

                var resourceGroup = ContainerInstanceTestUtilities.CreateResourceGroup(resourceClient);

                // Create container group.
                var containerGroupName = TestUtilities.GenerateName("acinetsdk");
                var containerGroup = ContainerInstanceTestUtilities.CreateTestContainerGroup(containerGroupName);

                // Verify created container group.
                var createdContainerGroup = containerInstanceClient.ContainerGroups.CreateOrUpdate(resourceGroup.Name, containerGroupName, containerGroup);
                ContainerInstanceTestUtilities.VerifyContainerGroupProperties(containerGroup, createdContainerGroup);

                // Verifiy delete container group.
                var deletedContainerGroup = containerInstanceClient.ContainerGroups.Delete(resourceGroup.Name, containerGroupName);
            }
        }

        /// <summary>
        /// Test list container instances.
        /// </summary>
        [Fact]
        public void ContainerInstanceListTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourceClient = ContainerInstanceTestUtilities.GetResourceManagementClient(context, handler);
                var containerInstanceClient = ContainerInstanceTestUtilities.GetContainerInstanceManagementClient(context, handler);

                // Create 2 container groups.
                var resourceGroup1 = ContainerInstanceTestUtilities.CreateResourceGroup(resourceClient);
                var containerGroupName1 = TestUtilities.GenerateName("acinetsdk");
                var containerGroup1 = ContainerInstanceTestUtilities.CreateTestContainerGroup(containerGroupName1, doNotEncrypt: true);
                containerInstanceClient.ContainerGroups.CreateOrUpdate(resourceGroup1.Name, containerGroupName1, containerGroup1);

                var resourceGroup2 = ContainerInstanceTestUtilities.CreateResourceGroup(resourceClient);
                var containerGroupName2 = TestUtilities.GenerateName("acinetsdk");
                var containerGroup2 = ContainerInstanceTestUtilities.CreateTestContainerGroup(containerGroupName2, doNotEncrypt: true);
                containerInstanceClient.ContainerGroups.CreateOrUpdate(resourceGroup2.Name, containerGroupName2, containerGroup2);

                // Verify both container group exist when listing.
                var retrievedContainerGroups = containerInstanceClient.ContainerGroups.List();
                Assert.True(retrievedContainerGroups.Count() >= 2);
                var retrievedContainerGroup1 = retrievedContainerGroups.Where(cg => cg.Name == containerGroupName1).FirstOrDefault();
                ContainerInstanceTestUtilities.VerifyContainerGroupProperties(containerGroup1, retrievedContainerGroup1);
                var retrievedContainerGroup2 = retrievedContainerGroups.Where(cg => cg.Name == containerGroupName2).FirstOrDefault();
                ContainerInstanceTestUtilities.VerifyContainerGroupProperties(containerGroup2, retrievedContainerGroup2);
            }
        }

        /// <summary>
        /// Test list container instances by resource group.
        /// </summary>
        [Fact]
        public void ContainerInstanceListByResourceGroupTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourceClient = ContainerInstanceTestUtilities.GetResourceManagementClient(context, handler);
                var containerInstanceClient = ContainerInstanceTestUtilities.GetContainerInstanceManagementClient(context, handler);

                // Create 2 container groups.
                var resourceGroup1 = ContainerInstanceTestUtilities.CreateResourceGroup(resourceClient);
                var containerGroupName1 = TestUtilities.GenerateName("acinetsdk");
                var containerGroup1 = ContainerInstanceTestUtilities.CreateTestContainerGroup(containerGroupName1, doNotEncrypt: true);
                containerInstanceClient.ContainerGroups.CreateOrUpdate(resourceGroup1.Name, containerGroupName1, containerGroup1);

                var resourceGroup2 = ContainerInstanceTestUtilities.CreateResourceGroup(resourceClient);
                var containerGroupName2 = TestUtilities.GenerateName("acinetsdk");
                var containerGroup2 = ContainerInstanceTestUtilities.CreateTestContainerGroup(containerGroupName2, doNotEncrypt: true);
                containerInstanceClient.ContainerGroups.CreateOrUpdate(resourceGroup2.Name, containerGroupName2, containerGroup2);

                // Verify only one exists when listing by resource group.
                var retrievedContainerGroups = containerInstanceClient.ContainerGroups.ListByResourceGroup(resourceGroup1.Name);
                Assert.True(retrievedContainerGroups.Count() >= 1);
                var retrievedContainerGroup1 = retrievedContainerGroups.Where(cg => cg.Name == containerGroupName1).FirstOrDefault();
                ContainerInstanceTestUtilities.VerifyContainerGroupProperties(containerGroup1, retrievedContainerGroup1);
                var retrievedContainerGroup2 = retrievedContainerGroups.Where(cg => cg.Name == containerGroupName2).FirstOrDefault();
                Assert.Null(retrievedContainerGroup2);
            }
        }
    }
}
