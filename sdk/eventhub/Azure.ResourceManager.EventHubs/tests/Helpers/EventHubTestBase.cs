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
using System.Security.Cryptography;
using Azure.ResourceManager.ManagedServiceIdentities;

namespace Azure.ResourceManager.EventHubs.Tests.Helpers
{
    [ClientTestFixture]
    public class EventHubTestBase:ManagementRecordedTestBase<EventHubsManagementTestEnvironment>
    {
        public static AzureLocation DefaultLocation => AzureLocation.EastUS2;
        internal const string DefaultNamespaceAuthorizationRule = "RootManageSharedAccessKey";
        protected SubscriptionResource DefaultSubscription;
        protected ArmClient Client { get; private set; }

        protected const string VaultName = "PS-Test-kv1";
        protected const string Key1 = "key1";
        protected const string Key2 = "key2";

        public EventHubTestBase(bool isAsync, RecordedTestMode? mode = default) : base(isAsync, mode)
        {
            JsonPathSanitizers.Add("$..aliasPrimaryConnectionString");
            JsonPathSanitizers.Add("$..aliasSecondaryConnectionString");
            JsonPathSanitizers.Add("$..keyName");
            JsonPathSanitizers.Add("$..primaryKey");
            JsonPathSanitizers.Add("$..secondaryKey");
            JsonPathSanitizers.Add("$..primaryConnectionString");
            JsonPathSanitizers.Add("$..secondaryConnectionString");
            JsonPathSanitizers.Add("$..key");
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            // Currently our pipeline will run this test project with project reference
            // And we jsut upgraded the version of ManagedServiceIdentities, therefore the related tests will fail
            // Use the version override as a work around because we lack the test resource now.
            ArmClientOptions options = new ArmClientOptions();
            options.SetApiVersion(UserAssignedIdentityResource.ResourceType, "2018-11-30");

            Client = GetArmClient(options);
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

        public static string GenerateRandomKey()
        {
            byte[] key256 = new byte[32];
            using (var rngCryptoServiceProvider = RandomNumberGenerator.Create())
            {
                rngCryptoServiceProvider.GetBytes(key256);
            }

            return Convert.ToBase64String(key256);
        }

        public async Task<ResourceGroupResource> GetResourceGroupAsync(string resourceGroupName)
        {
            Response<ResourceGroupResource> operation = await DefaultSubscription.GetResourceGroups().GetAsync(resourceGroupName);
            return operation.Value;
        }

        public async Task<string> CreateValidNamespaceName(string prefix)
        {
            string namespaceName = "";
            for (int i = 0; i < 10; i++)
            {
                namespaceName = Recording.GenerateAssetName(prefix);
                EventHubsNameAvailabilityResult res = await DefaultSubscription.CheckEventHubsNamespaceNameAvailabilityAsync(new EventHubsNameAvailabilityContent(namespaceName));
                if (res.NameAvailable==true)
                {
                    return namespaceName;
                }
            }
            return namespaceName;
        }

        public static void VerifyNamespaceProperties(EventHubsNamespaceResource eventHubNamespace, bool useDefaults)
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
