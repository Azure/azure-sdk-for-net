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

namespace Azure.ResourceManager.ServiceBus.Tests.Helpers
{
    public class ServiceBusTestBase: ManagementRecordedTestBase<ServiceBusManagementTestEnvironment>
    {
        public static Location DefaultLocation => Location.EastUS2;
        internal const string DefaultNamespaceAuthorizationRule = "RootManageSharedAccessKey";
        protected Subscription DefaultSubscription => Client.DefaultSubscription;
        protected ArmClient Client { get; private set; }
        protected ServiceBusTestBase(bool isAsync) : base(isAsync)
        {
            Sanitizer = new ServiceBusRecordedTestSanitizer();
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }
        public async Task<ResourceGroup> CreateResourceGroupAsync()
        {
            string resourceGroupName = Recording.GenerateAssetName("testservicebusRG-");
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
                CheckNameAvailabilityResult res = await DefaultSubscription.CheckNamespaceNameAvailabilityAsync(new CheckNameAvailability(namespaceName));
                if (res.NameAvailable == true)
                {
                    return namespaceName;
                }
            }
            return namespaceName;
        }

        public static void VerifyNamespaceProperties(SBNamespace sBNamespace, bool useDefaults)
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
    }
}
