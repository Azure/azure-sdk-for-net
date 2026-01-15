// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AgriculturePlatform.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.AgriculturePlatform.Tests.Scenario
{
    [TestFixture]
    public class AgriculturePlatformCRUDTest : AgriculturePlatformManagementTestBase
    {
        private string resourceGroup;
        private string resourceName;

        public AgriculturePlatformCRUDTest() : base(true)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await CreateCommonClient();
            }
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        [TestCase]
        public async Task CreateOrUpdate()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            var rg = await CreateResourceGroup(subscription, "rg", AzureLocation.EastUS2);
            resourceGroup = rg.Data.Name.ToString();
            resourceName = Recording.GenerateAssetName("agmobo");
            var createResourceOperation = await rg.GetAgricultureServices().CreateOrUpdateAsync(WaitUntil.Completed, resourceName, GetAgriServiceResourceData());
            Assert.That(createResourceOperation.HasCompleted, Is.True);
            Assert.That(createResourceOperation.HasValue, Is.True);
        }

        [TestCase]
        public async Task Get()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            var rg = await GetResourceGroup(subscription, resourceGroup);
            var agMoboResource = await rg.GetAgricultureServices().GetAsync(resourceName);
            Assert.That(agMoboResource.HasValue, Is.True);
            Assert.That(agMoboResource.Value.Data.Name == resourceName, Is.True);
        }

        private AgricultureServiceData GetAgriServiceResourceData()
        {
            var data = new AgricultureServiceData("centraluseuap");
            data.Properties = GetAgriServiceResourceProperties();
            return data;
        }

        private AgricultureServiceProperties GetAgriServiceResourceProperties()
        {
            return new Models.AgricultureServiceProperties(null, null, null, GetDataConnectorCredentials(), [], null);
        }

        private List<DataConnectorCredentialMap> GetDataConnectorCredentials()
        {
            var value = new DataConnectorCredentials()
            {
                ClientId = "e1917a7e-114b-45f7-a8d0-badbdaa990cb",
            };
            return new List<DataConnectorCredentialMap>()
            {
                new DataConnectorCredentialMap("BackendAADApplicationCredentials", value)
            };
        }
    }
}
