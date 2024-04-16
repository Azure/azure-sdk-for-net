// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core;
using NUnit.Framework;
using Azure.ResourceManager.AppContainers.Models;

namespace Azure.ResourceManager.AppContainers.Tests
{
    public class ManagedEnvironmentOperationTests : AppContainersManagementTestBase
    {
        public ManagedEnvironmentOperationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task GetContainerAppManagedEnvironmentResource()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var containerAppManagedEnvironmentCollection = resourceGroup.GetContainerAppManagedEnvironments();
            var managedEnvironmentName = Recording.GenerateAssetName("ManagedEnvironment");
            var data = new ContainerAppManagedEnvironmentData(AzureLocation.EastUS)
            {
                VnetConfiguration = new ContainerAppVnetConfiguration()
                {
                    DockerBridgeCidr = "172.17.0.1/16"
                },
            };
            var containerAppManagedEnvironment = (await containerAppManagedEnvironmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, managedEnvironmentName, data)).Value;
            var managedEnvironment = Client.GetContainerAppManagedEnvironmentResource(containerAppManagedEnvironment.Id);
            Assert.IsNotNull(managedEnvironment);
        }
    }
}
