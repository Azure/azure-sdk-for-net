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
using SkuTier = Azure.ResourceManager.EventHubs.Models.SkuTier;

namespace Azure.ResourceManager.EventHubs.Tests.Helpers
{
    [ClientTestFixture]
    public class EventHubTestBase:ManagementRecordedTestBase<EventHubsManagementTestEnvironment>
    {
        public static Location DefaultLocation => Location.EastUS2;
        internal const string DefaultNamespaceAuthorizationRule = "RootManageSharedAccessKey";
        protected Subscription DefaultSubscription;
        protected ArmClient Client { get; private set; }
        protected EventHubTestBase(bool isAsync) : base(isAsync, useLegacyTransport: true)
        {
            Sanitizer = new EventHubRecordedTestSanitizer();
        }

        public EventHubTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode, useLegacyTransport: true)
        {
            Sanitizer = new EventHubRecordedTestSanitizer();
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync();
        }
        public async Task<ResourceGroup> CreateResourceGroupAsync()
        {
            string resourceGroupName = Recording.GenerateAssetName("testeventhubRG-");
            ResourceGroupCreateOrUpdateOperation operation = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(
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
                CheckNameAvailabilityResult res = await DefaultSubscription.CheckNameAvailabilityNamespaceAsync(new CheckNameAvailabilityOptions(namespaceName));
                if (res.NameAvailable==true)
                {
                    return namespaceName;
                }
            }
            return namespaceName;
        }

        public static void VerifyNamespaceProperties(EventHubNamespace eventHubNamespace, bool useDefaults)
        {
            Assert.NotNull(eventHubNamespace);
            Assert.NotNull(eventHubNamespace.Id);
            Assert.NotNull(eventHubNamespace.Id.Name);
            Assert.NotNull(eventHubNamespace.Data);
            Assert.NotNull(eventHubNamespace.Data.Location);
            Assert.NotNull(eventHubNamespace.Data.CreatedAt);
            Assert.NotNull(eventHubNamespace.Data.Sku);
            if (useDefaults)
            {
                Assert.AreEqual(DefaultLocation, eventHubNamespace.Data.Location);
                Assert.AreEqual(SkuTier.Standard, eventHubNamespace.Data.Sku.Tier);
            }
        }
    }
}
