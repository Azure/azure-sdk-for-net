// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AgriculturePlatform.Models;
using Azure.ResourceManager.Resources;
using Newtonsoft.Json.Linq;
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
            var createResourceOperation = await rg.GetAgriServiceResources().CreateOrUpdateAsync(WaitUntil.Completed, resourceName, GetAgriServiceResourceData());
            Assert.IsTrue(createResourceOperation.HasCompleted);
            Assert.IsTrue(createResourceOperation.HasValue);
        }

        [TestCase]
        public async Task Get()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            var rg = await GetResourceGroup(subscription, resourceGroup);
            var agMoboResource = await rg.GetAgriServiceResources().GetAsync(resourceName);
            Assert.IsTrue(agMoboResource.HasValue);
            Assert.IsTrue(agMoboResource.Value.Data.Name == resourceName);
        }

        private AgriServiceResourceData GetAgriServiceResourceData()
        {
            var data = new AgriServiceResourceData("centraluseuap");
            data.Properties = GetAgriServiceResourceProperties();
            return data;
        }

        private AgriServiceResourceProperties GetAgriServiceResourceProperties()
        {
            return new Models.AgriServiceResourceProperties(null, null, null, GetDataConnectorCredentials(), [], null);
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
