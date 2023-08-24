// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ResourceConnector.Models;
using Azure.ResourceManager.Models;
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

        private ApplianceCollection LocationCollection { get; set; }

        private async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync();
            LocationCollection = ResourceGroup.GetAppliances();
        }

        [Test]
        public async Task TestOperationsAppliances()
        {
            await SetCollectionsAsync();

            // CREATE APPLIANCE RESOURCE
            var resourceName = Recording.GenerateAssetName("appliancetest-");
            var parameters = new ApplianceData(DefaultLocation)
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
                Distro = Distro.AKSEdge,
                InfrastructureConfig = new AppliancePropertiesInfrastructureConfig("VMWare"),
                PublicKey = ""
            };
            var appliance = (await LocationCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, parameters)).Value;

            Assert.AreEqual(appliance.Data.Name, resourceName);
            Assert.AreEqual(appliance.Data.ProvisioningState, "Succeeded");
            // Assert.IsFalse(String.IsNullOrEmpty(appliance.Data.Identity.PrincipalId.ToString()));
            // Assert.AreEqual(appliance.Data.Identity.ManagedServiceIdentityType, ManagedServiceIdentityType.SystemAssigned);

            // GET ON CREATED APPLIANCE
            appliance = await LocationCollection.GetAsync(resourceName);

            // PATCH APPLIANCE
            var patchData = new AppliancePatch()
            {
                Tags = { { "newkey", "newvalue"} }
            };
            appliance = await appliance.UpdateAsync(patchData);
            appliance = await appliance.GetAsync();

            // // LIST BY SUBSCRIPTION
            // var listResult = await DefaultSubscription.GetAppliancesAsync().ToEnumerableAsync();
            // Assert.GreaterOrEqual(listResult.Count, 1);

            // // LIST BY RESOURCE GROUP
            // listResult = await LocationCollection.GetAppliances().ToEnumerableAsync();
            // Assert.GreaterOrEqual(listResult.Count, 1);

            // DELETE CREATED CL
            await appliance.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await LocationCollection.ExistsAsync(resourceName)).Value;
            Assert.IsFalse(falseResult);
        }
    }
}
