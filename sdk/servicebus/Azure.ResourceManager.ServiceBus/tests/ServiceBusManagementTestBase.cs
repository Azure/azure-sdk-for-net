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
using System.Security.Cryptography;

namespace Azure.ResourceManager.ServiceBus.Tests
{
    public class ServiceBusManagementTestBase : ManagementRecordedTestBase<ServiceBusManagementTestEnvironment>
    {
        public static AzureLocation DefaultLocation => AzureLocation.EastUS2;
        internal const string DefaultNamespaceAuthorizationRule = "RootManageSharedAccessKey";
        protected SubscriptionResource DefaultSubscription;
        protected ArmClient Client { get; private set; }

        protected const string VaultName = "KeyVault-rg01";
        protected const string Key1 = "key4";
        protected const string Key2 = "key5";
        protected const string Key3 = "key6";

        protected ServiceBusManagementTestBase(bool isAsync, RecordedTestMode? mode = default) : base(isAsync, mode)
        {
            IgnoreNetworkDependencyVersions();
            IgnoreKeyVaultDependencyVersions();
            IgnoreManagedIdentityDependencyVersions();
            // Lazy sanitize fields in the request and response bodies
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
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync();
        }
        public async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            string resourceGroupName = Recording.GenerateAssetName("testservicebusRG-");
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
                ServiceBusNameAvailabilityResult res = await DefaultSubscription.CheckServiceBusNamespaceNameAvailabilityAsync(new ServiceBusNameAvailabilityContent(namespaceName));
                if (res.IsNameAvailable == true)
                {
                    return namespaceName;
                }
            }
            return namespaceName;
        }

        public static void VerifyNamespaceProperties(ServiceBusNamespaceResource sBNamespace, bool useDefaults)
        {
            Assert.NotNull(sBNamespace);
            Assert.NotNull(sBNamespace.Id);
            Assert.NotNull(sBNamespace.Id.Name);
            Assert.NotNull(sBNamespace.Data);
            Assert.NotNull(sBNamespace.Data.Location);
            Assert.NotNull(sBNamespace.Data.CreatedOn);
            Assert.NotNull(sBNamespace.Data.Sku);
            if (useDefaults)
            {
                Assert.AreEqual(DefaultLocation, sBNamespace.Data.Location);
                Assert.AreEqual(ServiceBusSkuTier.Standard, sBNamespace.Data.Sku.Tier);
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
