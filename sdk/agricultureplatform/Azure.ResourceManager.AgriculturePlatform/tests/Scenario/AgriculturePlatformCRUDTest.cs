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
using NUnit.Framework;

namespace Azure.ResourceManager.AgriculturePlatform.Tests.Scenario
{
    [TestFixture]
    public class AgriculturePlatformCRUDTest : AgriculturePlatformManagementTestBase
    {
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
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "SidduSDKTestRg", AzureLocation.EastUS);
            string resourceName = Recording.GenerateAssetName("resource");
            var createResourceOperation = await rg.GetAgriServiceResources().CreateOrUpdateAsync(WaitUntil.Completed, resourceName, GetAgriServiceResourceData());
            Assert.IsTrue(createResourceOperation.HasCompleted);
            Assert.IsTrue(createResourceOperation.HasValue);
        }

        private AgriServiceResourceData GetAgriServiceResourceData()
        {
            return new AgriServiceResourceData()
            {
                Properties = GetAgriServiceResourceProperties(),
            };
        }

        private AgriServiceResourceProperties GetAgriServiceResourceProperties()
        {
            return new Models.AgriServiceResourceProperties()
            {
                DataConnectorCredentials = GetDataConnectorCredentials(),
                InstalledSolutions = GetInstalledSolutions(),
            };
        }

        private List<DataConnectorCredentialMap> GetDataConnectorCredentials()
        {
            return new List<DataConnectorCredentialMap>()
            {
                new DataConnectorCredentialMap()
                {
                    Key = "CredentialKey",
                    Value = new DataConnectorCredentials()
                    {
                        ClientId = "ClientId",
                        KeyName = "KeyName",
                        Kind = AuthCredentialsKind.OAuthClientCredentials,
                        KeyVaultUri = "KeyVaultUri",
                        KeyVersion = "KeyVersion",
                    }
                }
            };
        }

        private List<InstalledSolutionMap> GetInstalledSolutions()
        {
            return new List<InstalledSolutionMap>()
            {
                new InstalledSolutionMap()
                {
                    Key = "SolutionKey",
                    Value = new Solution()
                    {
                        ApplicationName = "ApplicationName",
                        PartnerId = "PartnerId",
                        MarketPlacePublisherId = "MarketPlacePublisherId",
                        SaasSubscriptionId = "SaasSubscriptionId",
                        SaasSubscriptionName = "SaasSubscriptionName",
                        PlanId = "PlanId",
                    }
                }
            };
        }
    }
}
