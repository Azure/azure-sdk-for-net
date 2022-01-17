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
using Azure.ResourceManager.ServiceBus.Models;
using Azure.Core;

namespace Azure.ResourceManager.ServiceBus.Tests.Helpers
{
    public class ServiceBusTestBase: ManagementRecordedTestBase<ServiceBusManagementTestEnvironment>
    {
        public static AzureLocation DefaultLocation => AzureLocation.EastUS2;
        internal const string DefaultNamespaceAuthorizationRule = "RootManageSharedAccessKey";
        protected Subscription DefaultSubscription;
        protected ArmClient Client { get; private set; }
        protected ServiceBusTestBase(bool isAsync) : base(isAsync)
        {
            Sanitizer = new ServiceBusRecordedTestSanitizer();
        }
        protected ServiceBusTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
            Sanitizer = new ServiceBusRecordedTestSanitizer();
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync();
        }
        public async Task<ResourceGroup> CreateResourceGroupAsync()
        {
            string resourceGroupName = Recording.GenerateAssetName("testservicebusRG-");
            ResourceGroupCreateOrUpdateOperation operation = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(
                true,
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
                CheckNameAvailabilityResult res = await DefaultSubscription.CheckServiceBusNameAvailabilityAsync(new CheckNameAvailability(namespaceName));
                if (res.NameAvailable == true)
                {
                    return namespaceName;
                }
            }
            return namespaceName;
        }

        public static void VerifyNamespaceProperties(ServiceBusNamespace sBNamespace, bool useDefaults)
        {
            Assert.NotNull(sBNamespace);
            Assert.NotNull(sBNamespace.Id);
            Assert.NotNull(sBNamespace.Id.Name);
            Assert.NotNull(sBNamespace.Data);
            Assert.NotNull(sBNamespace.Data.Location);
            Assert.NotNull(sBNamespace.Data.CreatedAt);
            Assert.NotNull(sBNamespace.Data.Sku);
            if (useDefaults)
            {
                Assert.AreEqual(DefaultLocation, sBNamespace.Data.Location);
                Assert.AreEqual(SkuTier.Standard, sBNamespace.Data.Sku.Tier);
            }
        }

        public void IgnoreTestInLiveMode()
        {
            if (Mode == RecordedTestMode.Live)
            {
                Assert.Ignore();
            }
        }
    }
}
