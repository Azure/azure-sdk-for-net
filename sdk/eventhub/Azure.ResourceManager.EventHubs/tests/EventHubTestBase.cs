// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventHubs.Models;
using Azure.ResourceManager.ManagedServiceIdentities;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.EventHubs.Tests
{
    [ClientTestFixture]
    public class EventHubTestBase : ManagementRecordedTestBase<EventHubsManagementTestEnvironment>
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
            IgnoreKeyVaultDependencyVersions();
            IgnoreNetworkDependencyVersions();
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
            if (TestContext.CurrentContext.Test.Properties["Category"].Contains("Unit"))
            {
                return;
            }
            // Currently our pipeline will run this test project with project reference
            // And we jsut upgraded the version of ManagedServiceIdentities, therefore the related tests will fail
            // Use the version override as a work around because we lack the test resource now.
            ArmClientOptions options = new ArmClientOptions();
            options.SetApiVersion(UserAssignedIdentityResource.ResourceType, "2018-11-30");
            options.AddPolicy(new ResponseStatusPolicy(), HttpPipelinePosition.PerCall);

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
                        { "test", "env" },
                        { "azsdk-test-class", GetType().Name }
                    }
                });
            return operation.Value;
        }

        protected static void AssertStatus(Response response, params int[] expected)
        {
            TestContext.WriteLine($"HTTP {response.Status}");
            Assert.That(expected, Does.Contain(response.Status));
        }

        protected static async Task<T> CompleteAsync<T>(ArmOperation<T> operation)
        {
            AssertStatus(operation.GetRawResponse(), 200, 201, 202);
            await operation.WaitForCompletionResponseAsync();
            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            AssertStatus(operation.GetRawResponse(), 200, 201);
            return operation.Value;
        }

        protected static async Task CompleteAsync(ArmOperation operation)
        {
            AssertStatus(operation.GetRawResponse(), 200, 202, 204);
            await operation.WaitForCompletionResponseAsync();
            Assert.IsTrue(operation.HasCompleted);
            AssertStatus(operation.GetRawResponse(), 200, 204);
        }

        protected async Task<EventHubsNamespaceResource> CreateNamespaceAsync(ResourceGroupResource group, string name, EventHubsSkuName? sku = null, AzureLocation? location = null)
        {
            var data = new EventHubsNamespaceData(location ?? DefaultLocation)
            {
                DisableLocalAuth = true,
                Sku = new EventHubsSku(sku ?? EventHubsSkuName.Standard) { Capacity = 1 }
            };
            if (sku == EventHubsSkuName.Premium)
            {
                data.Sku.Tier = EventHubsSkuTier.Premium;
            }
            EventHubsNamespaceResource resource = await CompleteAsync(
                await group.GetEventHubsNamespaces().CreateOrUpdateAsync(WaitUntil.Started, name, data));
            Assert.AreEqual("Succeeded", resource.Data.ProvisioningState);
            Assert.IsTrue(resource.Data.DisableLocalAuth);
            return resource;
        }

        protected static async Task<List<T>> ReadAllAsync<T>(AsyncPageable<T> values)
        {
            var result = new List<T>();
            await foreach (Page<T> page in values.AsPages())
            {
                AssertStatus(page.GetRawResponse(), 200);
                result.AddRange(page.Values);
            }
            return result;
        }

        private sealed class ResponseStatusPolicy : HttpPipelineSynchronousPolicy
        {
            public override void OnReceivedResponse(HttpMessage message)
            {
                TestContext.WriteLine($"{message.Request.Method} {message.Request.Uri.Path} -> HTTP {message.Response.Status}");
                if (message.Response.Status < 400)
                {
                    AssertStatus(message.Response, 200, 201, 202, 204);
                }
            }
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
                if (res.NameAvailable == true)
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
