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

            Assert.AreEqual(appliance.Data.Name, resourceName);
            Assert.AreEqual(appliance.Data.ProvisioningState, "Succeeded");
            Assert.IsFalse(String.IsNullOrEmpty(appliance.Data.Identity.PrincipalId.ToString()));
            Assert.AreEqual(appliance.Data.Identity.ManagedServiceIdentityType, ManagedServiceIdentityType.SystemAssigned);

            // GET ON CREATED APPLIANCE
            appliance = await LocationCollection.GetAsync(resourceName);

            // PATCH APPLIANCE
            var patchData = new ResourceConnectorAppliancePatch()
            {
                Tags = { { "newkey", "newvalue" } }
            };
            appliance = await appliance.UpdateAsync(patchData);
            appliance = await appliance.GetAsync();
            Assert.AreEqual(appliance.Data.Tags, patchData.Tags);

            // // LIST BY RESOURCE GROUP
            var listResult = await LocationCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(listResult.Count, 1);
            foreach (ResourceConnectorApplianceResource item in listResult)
            {
                Assert.AreEqual(item.Data.Name, resourceName);
            }

            // DELETE CREATED APPLIANCE
            await appliance.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await LocationCollection.ExistsAsync(resourceName)).Value;
            Assert.IsFalse(falseResult);
        }
    }
}
