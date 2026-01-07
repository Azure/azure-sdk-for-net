// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.ResourceConnector.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ResourceConnector.Tests
{
    public class ApplianceOperationTests : ResourceConnectorManagementTestBase
    {
        public ApplianceOperationTests(bool isAsync)
                    : base(isAsync, RecordedTestMode.Record)
        {
        }

        private ResourceGroupResource ResourceGroup { get; set; }

        private ResourceConnectorApplianceCollection LocationCollection { get; set; }

        private async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync();
            LocationCollection = ResourceGroup.GetResourceConnectorAppliances();
        }

        [RecordedTest]
        [Ignore("Service not ready.")]
        public async Task TestOperationsAppliances()
        {
            await SetCollectionsAsync();

            // CREATE APPLIANCE RESOURCE
            var resourceName = Recording.GenerateAssetName("appliancetest-");
            var parameters = new ResourceConnectorApplianceData(DefaultLocation)
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
                Distro = ResourceConnectorDistro.AksEdge,
                InfrastructureConfig = new AppliancePropertiesInfrastructureConfig("VMWare", null)
            };
            var appliance = (await LocationCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, parameters)).Value;

            Assert.That(resourceName, Is.EqualTo(appliance.Data.Name));
            Assert.That(appliance.Data.ProvisioningState, Is.EqualTo("Succeeded"));
            Assert.That(String.IsNullOrEmpty(appliance.Data.Identity.PrincipalId.ToString()), Is.False);
            Assert.That(ManagedServiceIdentityType.SystemAssigned, Is.EqualTo(appliance.Data.Identity.ManagedServiceIdentityType));

            // GET ON CREATED APPLIANCE
            appliance = await LocationCollection.GetAsync(resourceName);

            // PATCH APPLIANCE
            var patchData = new ResourceConnectorAppliancePatch()
            {
                Tags = { { "newkey", "newvalue" } }
            };
            appliance = await appliance.UpdateAsync(patchData);
            appliance = await appliance.GetAsync();
            Assert.That(patchData.Tags, Is.EqualTo(appliance.Data.Tags));

            // // LIST BY RESOURCE GROUP
            var listResult = await LocationCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(listResult.Count, Is.EqualTo(1));
            foreach (ResourceConnectorApplianceResource item in listResult)
            {
                Assert.That(resourceName, Is.EqualTo(item.Data.Name));
            }

            // DELETE CREATED APPLIANCE
            await appliance.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await LocationCollection.ExistsAsync(resourceName)).Value;
            Assert.That(falseResult, Is.False);
        }
    }
}
