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
        /// Test create container instance with regular priority.
        /// </summary>
        [Fact]
        public void ContainerInstanceCreateTest_RegularPriority()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourceClient = ContainerInstanceTestUtilities.GetResourceManagementClient(context, handler);
                var containerInstanceClient = ContainerInstanceTestUtilities.GetContainerInstanceManagementClient(context, handler);

                var resourceGroup = ContainerInstanceTestUtilities.CreateResourceGroup(resourceClient);

                // Create container group.
                var containerGroupName = TestUtilities.GenerateName("acinetsdk-regular");
                var containerGroup = ContainerInstanceTestUtilities.CreateTestContainerGroup(containerGroupName, containerGroupPriority: "Regular");

                // Verify created container group.
                var createdContainerGroup = containerInstanceClient.ContainerGroups.CreateOrUpdate(resourceGroup.Name, containerGroupName, containerGroup);
                ContainerInstanceTestUtilities.VerifyContainerGroupProperties(containerGroup, createdContainerGroup);
            }
        }

        /// <summary>
        /// Test create container instance with spot priority.
        /// </summary>
        [Fact]
        public void ContainerInstanceCreateTest_SpotPriority()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourceClient = ContainerInstanceTestUtilities.GetResourceManagementClient(context, handler);
                var containerInstanceClient = ContainerInstanceTestUtilities.GetContainerInstanceManagementClient(context, handler);

                var resourceGroup = ContainerInstanceTestUtilities.CreateResourceGroup(resourceClient);

                // Create container group.
                var containerGroupName = TestUtilities.GenerateName("acinetsdk-spot");
                var containerGroup = ContainerInstanceTestUtilities.CreateTestContainerGroup(containerGroupName, containerGroupPriority: "Spot");

                // Verify created container group.
                var createdContainerGroup = containerInstanceClient.ContainerGroups.CreateOrUpdate(resourceGroup.Name, containerGroupName, containerGroup);
                ContainerInstanceTestUtilities.VerifyContainerGroupProperties(containerGroup, createdContainerGroup);
            }
        }

        /// <summary>
        /// Test create container instance with confidential compute properties.
        /// </summary>
        [Fact]
        public void ContainerInstanceCreateTest_ConfidentialComputeProperties()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
	    string defaultCcePolicyString = "cGFja2FnZSBwb2xpY3kKCmFwaV9zdm4gOj0gIjAuOS4wIgoKaW1wb3J0IGZ1dHVyZS5rZXl3b3Jkcy5ldmVyeQppbXBvcnQgZnV0dXJlLmtleXdvcmRzLmluCgpmcmFnbWVudHMgOj0gWwpdCgpjb250YWluZXJzIDo9IFsKICAgIHsKICAgICAgICAiY29tbWFuZCI6IFsiL3BhdXNlIl0sCiAgICAgICAgImVudl9ydWxlcyI6IFt7InBhdHRlcm4iOiAiUEFUSD0vdXNyL2xvY2FsL3NiaW46L3Vzci9sb2NhbC9iaW46L3Vzci9zYmluOi91c3IvYmluOi9zYmluOi9iaW4iLCAic3RyYXRlZ3kiOiAic3RyaW5nIiwgInJlcXVpcmVkIjogdHJ1ZX0seyJwYXR0ZXJuIjogIlRFUk09eHRlcm0iLCAic3RyYXRlZ3kiOiAic3RyaW5nIiwgInJlcXVpcmVkIjogZmFsc2V9XSwKICAgICAgICAibGF5ZXJzIjogWyIxNmI1MTQwNTdhMDZhZDY2NWY5MmMwMjg2M2FjYTA3NGZkNTk3NmM3NTVkMjZiZmYxNjM2NTI5OTE2OWU4NDE1Il0sCiAgICAgICAgIm1vdW50cyI6IFtdLAogICAgICAgICJleGVjX3Byb2Nlc3NlcyI6IFtdLAogICAgICAgICJzaWduYWxzIjogW10sCiAgICAgICAgImFsbG93X2VsZXZhdGVkIjogZmFsc2UsCiAgICAgICAgIndvcmtpbmdfZGlyIjogIi8iCiAgICB9LApdCmFsbG93X3Byb3BlcnRpZXNfYWNjZXNzIDo9IHRydWUKYWxsb3dfZHVtcF9zdGFja3MgOj0gdHJ1ZQphbGxvd19ydW50aW1lX2xvZ2dpbmcgOj0gdHJ1ZQphbGxvd19lbnZpcm9ubWVudF92YXJpYWJsZV9kcm9wcGluZyA6PSB0cnVlCmFsbG93X3VuZW5jcnlwdGVkX3NjcmF0Y2ggOj0gdHJ1ZQoKCm1vdW50X2RldmljZSA6PSB7ICJhbGxvd2VkIiA6IHRydWUgfQp1bm1vdW50X2RldmljZSA6PSB7ICJhbGxvd2VkIiA6IHRydWUgfQptb3VudF9vdmVybGF5IDo9IHsgImFsbG93ZWQiIDogdHJ1ZSB9CnVubW91bnRfb3ZlcmxheSA6PSB7ICJhbGxvd2VkIiA6IHRydWUgfQpjcmVhdGVfY29udGFpbmVyIDo9IHsgImFsbG93ZWQiIDogdHJ1ZSB9CmV4ZWNfaW5fY29udGFpbmVyIDo9IHsgImFsbG93ZWQiIDogdHJ1ZSB9CmV4ZWNfZXh0ZXJuYWwgOj0geyAiYWxsb3dlZCIgOiB0cnVlIH0Kc2h1dGRvd25fY29udGFpbmVyIDo9IHsgImFsbG93ZWQiIDogdHJ1ZSB9CnNpZ25hbF9jb250YWluZXJfcHJvY2VzcyA6PSB7ICJhbGxvd2VkIiA6IHRydWUgfQpwbGFuOV9tb3VudCA6PSB7ICJhbGxvd2VkIiA6IHRydWUgfQpwbGFuOV91bm1vdW50IDo9IHsgImFsbG93ZWQiIDogdHJ1ZSB9CmdldF9wcm9wZXJ0aWVzIDo9IHsgImFsbG93ZWQiIDogdHJ1ZSB9CmR1bXBfc3RhY2tzIDo9IHsgImFsbG93ZWQiIDogdHJ1ZSB9CnJ1bnRpbWVfbG9nZ2luZyA6PSB7ICJhbGxvd2VkIiA6IHRydWUgfQpsb2FkX2ZyYWdtZW50IDo9IHsgImFsbG93ZWQiIDogdHJ1ZSB9CnNjcmF0Y2hfbW91bnQgOj0geyAiYWxsb3dlZCIgOiB0cnVlIH0Kc2NyYXRjaF91bm1vdW50IDo9IHsgImFsbG93ZWQiIDogdHJ1ZSB9CnJlYXNvbiA6PSB7ImVycm9ycyI6IGRhdGEuZnJhbWV3b3JrLmVycm9yc30K";

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourceClient = ContainerInstanceTestUtilities.GetResourceManagementClient(context, handler);
                var containerInstanceClient = ContainerInstanceTestUtilities.GetContainerInstanceManagementClient(context, handler);

                var resourceGroup = ContainerInstanceTestUtilities.CreateResourceGroup(resourceClient);

                // Create container group.
                var containerGroupName1 = TestUtilities.GenerateName("acinetsdk-confidential");
                var containerGroup1 = ContainerInstanceTestUtilities.CreateTestContainerGroup(containerGroupName1, isConfidentialSku: true);

                var containerGroupName2 = TestUtilities.GenerateName("acinetsdk-confidential-ccepolicy");
                var containerGroup2 = ContainerInstanceTestUtilities.CreateTestContainerGroup(containerGroupName2, isConfidentialSku: true, ccepolicy: defaultCcePolicyString);

                // Verify created container group.
                var createdContainerGroup1 = containerInstanceClient.ContainerGroups.CreateOrUpdate(resourceGroup.Name, containerGroupName1, containerGroup1);
                ContainerInstanceTestUtilities.VerifyContainerGroupProperties(containerGroup1, createdContainerGroup1);
                var createdContainerGroup2 = containerInstanceClient.ContainerGroups.CreateOrUpdate(resourceGroup.Name, containerGroupName2, containerGroup2);
                ContainerInstanceTestUtilities.VerifyContainerGroupProperties(containerGroup2, createdContainerGroup2);
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
