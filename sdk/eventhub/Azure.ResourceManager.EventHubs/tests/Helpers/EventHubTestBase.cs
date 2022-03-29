// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.TestFramework;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.EventHubs.Models;
using Azure.Core;

namespace Azure.ResourceManager.EventHubs.Tests.Helpers
{
    [ClientTestFixture]
    public class EventHubTestBase:ManagementRecordedTestBase<EventHubsManagementTestEnvironment>
    {
        public static AzureLocation DefaultLocation => AzureLocation.EastUS2;
        internal const string DefaultNamespaceAuthorizationRule = "RootManageSharedAccessKey";
        protected SubscriptionResource DefaultSubscription;
        protected ArmClient Client { get; private set; }

        public EventHubTestBase(bool isAsync, RecordedTestMode? mode = default) : base(isAsync, mode)
        {
            JsonPathSanitizers.Add("$..aliasPrimaryConnectionString");
            JsonPathSanitizers.Add("$..aliasSecondaryConnectionString");
            JsonPathSanitizers.Add("$..keyName");
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync();
        }
        public async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            string resourceGroupName = Recording.GenerateAssetName("testeventhubRG-");
            ArmOperation<ResourceGroupResource> operation = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceGroupName,
                new ResourceGroupData(DefaultLocation)
                {
                    Tags =
                    {
                        { "test", "env" }
                    }
                });
            return operation.Value;
        }

        public async Task<string> CreateValidNamespaceName(string prefix)
        {
            string namespaceName = "";
            for (int i = 0; i < 10; i++)
            {
                namespaceName = Recording.GenerateAssetName(prefix);
                CheckNameAvailabilityResult res = await DefaultSubscription.CheckEventHubNameAvailabilityAsync(new CheckNameAvailabilityOptions(namespaceName));
                if (res.NameAvailable==true)
                {
                    return namespaceName;
                }
            }
            return namespaceName;
        }

        public static void VerifyNamespaceProperties(EventHubNamespaceResource eventHubNamespace, bool useDefaults)
        {
            Assert.NotNull(eventHubNamespace);
            Assert.NotNull(eventHubNamespace.Id);
            Assert.NotNull(eventHubNamespace.Id.Name);
            Assert.NotNull(eventHubNamespace.Data);
            Assert.NotNull(eventHubNamespace.Data.Location);
            Assert.NotNull(eventHubNamespace.Data.CreatedOn);
            Assert.NotNull(eventHubNamespace.Data.Sku);
            if (useDefaults)
            {
                Assert.AreEqual(DefaultLocation, eventHubNamespace.Data.Location);
                Assert.AreEqual(EventHubsSkuTier.Standard, eventHubNamespace.Data.Sku.Tier);
            }
        }
    }
}
