// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.TestFramework;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;
using Sku = Azure.ResourceManager.EventHubs.Models.Sku;
using SkuTier = Azure.ResourceManager.EventHubs.Models.SkuTier;

namespace Azure.ResourceManager.EventHubs.Tests.Helpers
{
    [ClientTestFixture]
    public class EventHubTestBase:ManagementRecordedTestBase<EventHubsManagementTestEnvironment>
    {
        public static Location DefaultLocation => Location.EastUS2;
        internal const string DefaultNamespaceAuthorizationRule = "RootManageSharedAccessKey";
        protected Subscription DefaultSubscription => Client.DefaultSubscription;
        protected ArmClient Client { get; private set; }
        protected EventHubTestBase(bool isAsync) : base(isAsync)
        {
        }
        public EventHubTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, RecordedTestMode.Record)
        {
        }
        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }
        public async Task<ResourceGroup> CreateResourceGroupAsync()
        {
            string resourceGroupName = Recording.GenerateAssetName("teststorageRG-");
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
        public static void VerifyNamespaceProperties(EHNamespace eHNamespace, bool useDefaults)
        {
            Assert.NotNull(eHNamespace);
            Assert.NotNull(eHNamespace.Id);
            Assert.NotNull(eHNamespace.Id.Name);
            Assert.NotNull(eHNamespace.Data);
            Assert.NotNull(eHNamespace.Data.Location);
            Assert.NotNull(eHNamespace.Data.CreatedAt);
            Assert.NotNull(eHNamespace.Data.Sku);
            if (useDefaults)
            {
                Assert.AreEqual(DefaultLocation, eHNamespace.Data.Location);
                Assert.AreEqual(SkuTier.Standard, eHNamespace.Data.Sku.Tier);
            }
        }
    }
}
